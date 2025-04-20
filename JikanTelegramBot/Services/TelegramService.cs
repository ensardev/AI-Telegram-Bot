using System.Text.RegularExpressions;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace JikanTelegramBot.Services;

public class TelegramService
{
    private readonly ITelegramBotClient _botClient;
    private readonly DeepseekService _deepseekService;
    private readonly JikanService _jikanService;
    private readonly IConfiguration _configuration;

    public TelegramService(DeepseekService deepseekService, JikanService jikanService, IConfiguration configuration)
    {
        _deepseekService = deepseekService;
        _jikanService = jikanService;
        _configuration = configuration;

        _botClient = new TelegramBotClient(_configuration["Telegram:BotToken"]);
    }

    public async Task Initialize()
    {
        var webhookAddress = $"{_configuration["Telegram:BotHostUrl"]}/api/webhook";
        await _botClient.SetWebhook(webhookAddress);
    }

    public async Task HandleUpdateAsync(Update update)
    {
        if (update.Message?.Text == null)
            return;

        var chatId = update.Message.Chat.Id;
        var messageText = update.Message.Text;

        await _botClient.SendChatAction(chatId, ChatAction.Typing);

        try
        {
            if (messageText.Equals("/start", StringComparison.OrdinalIgnoreCase))
            {
                var welcomeMessage = "👋 Merhaba! Anime ve karakter bilgisi sorgulayabileceğiniz Vi Anime Bot'a hoş geldiniz!\n\n" +
                                     "📌 Bir anime adı ya da karakter adı yazın, size detaylı bilgi vereyim.\n\n" +
                                     "Örneğin:\n" +
                                     "- *Attack on Titan hakkında bilgi ver*\n" +
                                     "- *Naruto karakteri kimdir?*";

                await _botClient.SendMessage(
                    chatId: chatId,
                    text: welcomeMessage,
                    parseMode: ParseMode.Markdown
                );

                return;
            }


            var intent = await _deepseekService.AnalyzeMessage(messageText);

            if (intent.Type == "none")
            {
                await _botClient.SendMessage(chatId, "Bu mesaj bir anime veya anime karakteriyle ilgili görünmüyor. Lütfen ilgili bir mesaj gönderin.");
            }
            else
            {
                var result = await _jikanService.SearchAsync(intent.Query, intent.Type);
                if (result == null)
                {
                    await _botClient.SendMessage(chatId, "Sorduğunun soruya dair sonuç bulunamadı.");
                }
                else
                {
                    var formattedResponse = await _deepseekService.FormatResponse(result);
                    await _botClient.SendMessage(chatId, formattedResponse, parseMode: ParseMode.Html);
                }
            }
        }
        catch (Exception ex)
        {
            await _botClient.SendMessage(
                chatId: chatId,
                text: "Üzgünüm, bir hata oluştu. Lütfen daha sonra tekrar deneyin.");
        }
    }
}