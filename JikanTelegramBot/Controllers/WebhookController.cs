using JikanTelegramBot.Services;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;

namespace JikanTelegramBot.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WebhookController : ControllerBase
{
    private readonly TelegramService _telegramService;

    public WebhookController(TelegramService telegramService)
    {
        _telegramService = telegramService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Update update)
    {
        await _telegramService.HandleUpdateAsync(update);
        return Ok();
    }
}