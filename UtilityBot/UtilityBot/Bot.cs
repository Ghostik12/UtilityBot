using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Exceptions;

namespace UtilityBot
{
    internal class Bot : BackgroundService
    {
        private ITelegramBotClient _telegramBotClient;

        public Bot(ITelegramBotClient telegramBotClient)
        {
            _telegramBotClient = telegramBotClient;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _telegramBotClient.StartReceiving(HandleUpdateAsync, HandleErrorAsync, new ReceiverOptions() { AllowedUpdates = { } }, cancellationToken: stoppingToken);
            Console.WriteLine("Bot Launch");
            return;
        }

        async Task HandleUpdateAsync (ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == UpdateType.Message)
                switch (update.Message!.Type) 
                {
                    case MessageType.Text :
                        Console.WriteLine($"{update.Message.Text}");
                        string str = update.Message.Text;
                        await _telegramBotClient.SendTextMessageAsync(update.Message.Chat.Id, $"Длина сообщения: {str.Length} знаков", cancellationToken: cancellationToken);
                        return;
                    default:
                        await _telegramBotClient.SendTextMessageAsync(update.Message.Chat.Id, $"Не верный формат сообщения, отправте сообщение", cancellationToken: cancellationToken);
                        return;
                }

            if (update.Type == UpdateType.CallbackQuery)
                await _telegramBotClient.SendTextMessageAsync(update.CallbackQuery.From.Id, "Не верный формат сообщения, отправте сообщение", cancellationToken : cancellationToken);
            return;
        }

        Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var errorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(errorMessage);

            Console.WriteLine("Ожидаем 10 секунд перед повторным подключением.");
            Thread.Sleep(10000);

            return Task.CompletedTask;
        }
    }
}
