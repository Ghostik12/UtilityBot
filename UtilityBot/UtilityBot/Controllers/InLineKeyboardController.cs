using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using UtilityBot.Services;

namespace UtilityBot.Controllers
{
    public class InLineKeyboardController
    {
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly IStorage _memoryStorage;

        public InLineKeyboardController(ITelegramBotClient telegramBotClient, IStorage memoryStorage)
        {
            _telegramBotClient = telegramBotClient;
            _memoryStorage = memoryStorage;
        }
        
        public async Task Handle(CallbackQuery? callbackQuery, CancellationToken ct)
        {
            if (callbackQuery?.Data == null)
            {
                return;
            }
            else
            {
                _memoryStorage.GetSession(callbackQuery.From.Id).Code = callbackQuery.Data;
                await _telegramBotClient.SendTextMessageAsync(callbackQuery.From.Id, $"Напишите текст или два числа через пробел", cancellationToken: ct);
            }

            string Text = callbackQuery.Data switch
            {
                "+" => "Сумма",
                "=" => "Количество",
                _ => String.Empty
            };

            await _telegramBotClient.SendTextMessageAsync(callbackQuery.From.Id,
                $"<b>Выбрано дейсвтие - {Text}.{Environment.NewLine}</b>" + $"{Environment.NewLine}Можно поменять в главном меню.", cancellationToken: ct, parseMode: ParseMode.Html);
            Console.WriteLine($"Контроллер {GetType().Name} получил сообщение");
        }
    }
}
