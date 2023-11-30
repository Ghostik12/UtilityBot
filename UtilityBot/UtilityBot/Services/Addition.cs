using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Telegram.Bot;
using UtilityBot.Controllers;

namespace UtilityBot.Services
{
    public class Addition
    {
        private readonly ITelegramBotClient _telegramBotClient;

        public Addition(ITelegramBotClient telegramBotClient)
        {
            _telegramBotClient = telegramBotClient;
        }

        public string Process(string message)
        {
            if (!Regex.IsMatch(message, @"[^\d\s]")) 
            {
                var sum = message.Split(' ').Select(int.Parse).Sum();
                return sum.ToString();
            }
            else 
            {
                return "Неккоректно введены числа, попробуйте еще раз";
            }
        }
    }
}
