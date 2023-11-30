using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text;
using Telegram.Bot;
using UtilityBot.Controllers;
using UtilityBot.Services;

namespace UtilityBot
{
    class Program
    {
        public static async Task Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            var host = new HostBuilder()
                .ConfigureServices((hostContext, services) => ConfigureServices(services))
                .UseConsoleLifetime()
                .Build();

            Console.WriteLine("Launch");

            await host.RunAsync();
            Console.WriteLine("Stop");
        }

        static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient("Bot Token"));
            services.AddHostedService<Bot>();
            services.AddSingleton<IStorage, MemoryStorage>();
            services.AddTransient<TextMessageController>();
            services.AddTransient<InLineKeyboardController>();
            services.AddTransient<Addition>();
            services.AddTransient<Quantity>();
        }
    }
}