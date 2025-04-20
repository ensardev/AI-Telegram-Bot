using JikanTelegramBot.Models;
using JikanTelegramBot.Prompts;
using Microsoft.SemanticKernel;
using System.Text.Json;

namespace JikanTelegramBot.Services;

public class DeepseekService
{
    private readonly Kernel _kernel;

    public DeepseekService(Kernel kernel)
    {
        _kernel = kernel;
    }

    public async Task<DeepseekResult> AnalyzeMessage(string input)
    {
        var prompt = PromptTemplates.IntentDetectionPrompt.Replace("{{input}}", input);
        var result = await _kernel.InvokePromptAsync(prompt);
        var json = result.GetValue<string>().Replace("```json", "").Replace("```", "").Trim();
        return JsonSerializer.Deserialize<DeepseekResult>(json);
    }

    public async Task<string> FormatResponse(object jsonObj)
    {
        var json = JsonSerializer.Serialize(jsonObj);
        var prompt = PromptTemplates.FormatResponsePrompt.Replace("{{json}}", json);
        var result = await _kernel.InvokePromptAsync(prompt);
        return result.GetValue<string>();
    }
}
