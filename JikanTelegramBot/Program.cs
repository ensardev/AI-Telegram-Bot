using JikanTelegramBot.Models;
using JikanTelegramBot.Services;
using Microsoft.SemanticKernel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.Configure<AppSettings>(builder.Configuration);
var config = builder.Configuration.Get<AppSettings>();

builder.Services.AddHttpClient("Jikan", client =>
{
    client.BaseAddress = new Uri(config.Jikan.BaseUrl);
});

builder.Services.AddSingleton(sp =>
{
    var httpClient = new HttpClient();
    httpClient.BaseAddress = new Uri(config.Deepseek.ApiUrl);
    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {config.Deepseek.ApiKey}");

    var builder = Kernel.CreateBuilder();

    builder.AddOpenAIChatCompletion(
    modelId: "deepseek-chat",
    apiKey: config.Deepseek.ApiKey,
    httpClient: httpClient
    );

    return builder.Build();
});

builder.Services.AddSingleton<TelegramService>();
builder.Services.AddSingleton<DeepseekService>();
builder.Services.AddSingleton<JikanService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


using var scope = app.Services.CreateScope();
var botService = scope.ServiceProvider.GetRequiredService<TelegramService>();
botService.Initialize().GetAwaiter().GetResult();

app.Run();
