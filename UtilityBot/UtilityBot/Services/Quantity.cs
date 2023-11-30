using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace UtilityBot.Services
{
    public class Quantity
    {
        private readonly ITelegramBotClient _telegramBotClient;

        public Quantity(ITelegramBotClient telegramBotClient)
        {
            _telegramBotClient = telegramBotClient;
        }

        public string Process(string message)
        {
            var s = message.Length;
            string result = s.ToString();
            return result;
        }
    }
}
