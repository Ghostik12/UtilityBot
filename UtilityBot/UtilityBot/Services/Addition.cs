using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            //string s = message;
            //int result = 0;
            //for (int i = 0; i < s.Length; i++)
            //{
            //    if (char.IsNumber(s[i]))
            //    {
            //        result += Convert.ToInt32(s[i].ToString());
            //    }
            //}
            //var total = Convert.ToString(result);
            //return total;
            var sum = message.Split(' ').Select(int.Parse).Sum();
            return sum.ToString();
        }
    }
}
