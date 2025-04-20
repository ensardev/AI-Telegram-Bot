using System.Text.Json;

namespace JikanTelegramBot.Services;

public class JikanService
{
    private readonly HttpClient _httpClient;

    public JikanService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("Jikan");
    }

    public async Task<object?> SearchAsync(string query, string type)
    {
        var endpoint = type == "anime"
            ? $"anime?q={query}"
            : $"characters?q={query}";

        var response = await _httpClient.GetAsync(endpoint);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Jikan API call failed: {response.StatusCode}");
        }

        var content = await response.Content.ReadAsStringAsync();

        using var jsonDoc = JsonDocument.Parse(content);
        var root = jsonDoc.RootElement;

        if (!root.TryGetProperty("data", out var data) || data.GetArrayLength() == 0)
            return null;

        var mostFavorite = data.EnumerateArray()
            .OrderByDescending(item =>
                item.TryGetProperty("favorites", out var fav) ? fav.GetInt32() : 0)
            .FirstOrDefault();

        var safeJson = mostFavorite.GetRawText();
        return JsonSerializer.Deserialize<object>(safeJson);
    }
}