using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using UtilityBot.Services;

namespace UtilityBot.Controllers
{
    public class TextMessageController
    {
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly Addition _addition;
        private readonly IStorage _memoryStorage;
        private readonly Quantity _quantity;

        public TextMessageController(ITelegramBotClient telegramBotClient, Addition addition, IStorage memoryStorage, Quantity quantity)
        {
            _telegramBotClient = telegramBotClient;
            _addition = addition;
            _memoryStorage = memoryStorage;
            _quantity = quantity;
        }

        public async Task Handle(Message message, CancellationToken ct)
        {
            if (message.Text == "/start")
            {
                var buttons = new List<InlineKeyboardButton[]>();
                buttons.Add(new[]
                {
                        InlineKeyboardButton.WithCallbackData($"Сумма чисел", "+"),
                        InlineKeyboardButton.WithCallbackData($"Число символов в строке", "=")
                    });

                await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, $"<b> Наш бот считает сумму чисел или считает символы в тексте.</b>{Environment.NewLine}"
                   + $"{Environment.NewLine}", cancellationToken: ct, parseMode: ParseMode.Html, replyMarkup: new InlineKeyboardMarkup(buttons));
            }

            else
            {
                var Code = _memoryStorage.GetSession(message.Chat.Id).Code;
                var fileId = message.Chat?.Id;
                string result = "";
                if (fileId == null)
                    return;

                if (Code == "+")
                {
                    result = _addition.Process(message.Text);
                }
                else
                {
                    result = _quantity.Process(message.Text);
                }
                await _telegramBotClient.SendTextMessageAsync(message.Chat.Id, result, cancellationToken: ct);
            }
        }
    }
}
