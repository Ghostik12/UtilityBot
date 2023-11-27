using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text;
using Telegram.Bot;

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
            services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient("6511541259:AAFl-SdhJFFLxDs2m9nBEbmuu0oHcPUyFUs"));

            services.AddHostedService<Bot>();
        }
    }
}