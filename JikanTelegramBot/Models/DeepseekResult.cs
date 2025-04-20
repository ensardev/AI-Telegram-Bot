using System.Text.Json.Serialization;

namespace JikanTelegramBot.Models;

public class DeepseekResult
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = "none";

    [JsonPropertyName("query")]
    public string Query { get; set; } = "";
}