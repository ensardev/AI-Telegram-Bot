namespace JikanTelegramBot.Models;

public class AppSettings
{
    public DeepseekSettings Deepseek { get; set; } = new();
    public TelegramSettings Telegram { get; set; } = new();
    public JikanSettings Jikan { get; set; } = new();
}

public class DeepseekSettings
{
    public string ApiKey { get; set; } = string.Empty;
    public string ApiUrl { get; set; } = string.Empty;
}

public class TelegramSettings
{
    public string BotToken { get; set; } = string.Empty;
    public string BotHostUrl { get; set; } = string.Empty;
}

public class JikanSettings
{
    public string BaseUrl { get; set; } = string.Empty;
}