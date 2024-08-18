using Microsoft.Extensions.Configuration;
using DatingTelegramBot;

class Program
{
    static async Task Main(string[] args)
    {
        var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
        var botToken = config["TelegramBotToken"];
        var url = System.Configuration.ConfigurationManager.AppSettings["Url"];
        switch (args.Length)
        {
            case 1:
                {
                    url = args[0];
                    break;
                }

            case 2:
                {
                    url = args[0];
                    botToken = args[1];
                    break;
                }
        }

        DatingBot datingBot = new DatingBot(botToken, url, i => Console.WriteLine(i));

        using var cts = new CancellationTokenSource();

        await datingBot.Run(cts.Token);

        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine();

        cts.Cancel();
    }
}