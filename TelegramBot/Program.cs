using System;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    public class Program
    {
        static ITelegramBotClient bot = new TelegramBotClient("6907469280:AAG9ZrX8-vrUXy1uzNM7Zk6Nqaq-S84QdIQ"); // Вставь свой токен

        public static IServiceProvider Services;

        static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            using (var scope = Services.CreateScope())
            {
                if (update.Type == UpdateType.Message)
                {
                    var message = update.Message;
                    if (message.Text == "/start")
                    {
                        await botClient.SendTextMessageAsync(
                            message.Chat.Id,
                            "Добро пожаловать! Открыть мини-приложение:",
                            replyMarkup: new InlineKeyboardMarkup(InlineKeyboardButton.WithWebApp(
                                "Открыть",
                                new WebAppInfo { Url = "https://127.0.0.1:7058/Auth/Login", }   //https://wax-wing.ru

                            ))
                        );
                    }
                }
            }
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Ошибка бота: {exception.Message}");
        }


        public static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            var receiverOptions = new ReceiverOptions { AllowedUpdates = { } };
            bot.StartReceiving(HandleUpdateAsync, HandleErrorAsync, receiverOptions, cts.Token);

            var builder = WebApplication.CreateBuilder(args);

            builder.WebHost.UseUrls("http://localhost:3000"); // Добавьте эту строку

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            var app = builder.Build();
            Services = app.Services;

            app.UseCors("AllowAll");

            app.Use(async (context, next) =>
            {
                Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
                await next.Invoke();
                Console.WriteLine($"Response: {context.Response.StatusCode}");
            });
            app.MapGet("/", () => "Сервер работает!");

            app.Run();
        }
    }

}



//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddRazorPages();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();

//app.UseRouting();

//app.UseAuthorization();

//app.MapStaticAssets();
//app.MapRazorPages()
//   .WithStaticAssets();

//app.Run();
