using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace DatingTelegramBot
{
    internal class DatingBot
    {
        private readonly string _url;
        private readonly TelegramBotClient _botClient;
        private readonly ReceiverOptions _receiverOptions;
        Action<string> _log;

        public DatingBot(string botToken, string url, Action<string> log)
        {
            _url = url;
            _botClient = new TelegramBotClient(botToken); // Присваиваем нашей переменной значение, в параметре передаем Token, полученный от BotFather
            _receiverOptions = new ReceiverOptions // Также присваем значение настройкам бота
            {
                AllowedUpdates = new[] // Тут указываем типы получаемых Update`ов, о них подробнее расказано тут https://core.telegram.org/bots/api#update
                {
                UpdateType.Message, // Сообщения (текст, фото/видео, голосовые/видео сообщения и т.д.)
            },
                // Параметр, отвечающий за обработку сообщений, пришедших за то время, когда ваш бот был оффлайн
                // True - не обрабатывать, False (стоит по умолчанию) - обрабаывать
                ThrowPendingUpdates = true,
            };
            _log = log;
        }

        public async Task Run(CancellationToken cts)
        {

            // UpdateHander - обработчик приходящих Update`ов
            // ErrorHandler - обработчик ошибок, связанных с Bot API
            _botClient.StartReceiving(UpdateHandler, ErrorHandler, _receiverOptions, cts); // Запускаем бота

            var me = await _botClient.GetMeAsync(); // Создаем переменную, в которую помещаем информацию о нашем боте.
            _log($"{me.FirstName} запущен!");
        }

        private async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Обязательно ставим блок try-catch, чтобы наш бот не "падал" в случае каких-либо ошибок
            try
            {
                // Сразу же ставим конструкцию switch, чтобы обрабатывать приходящие Update
                switch (update.Type)
                {
                    case UpdateType.Message:
                        {
                            // эта переменная будет содержать в себе все связанное с сообщениями
                            var message = update.Message;

                            // From - это от кого пришло сообщение (или любой другой Update)
                            var user = message.From;

                            // Chat - содержит всю информацию о чате
                            var chat = message.Chat;

                            // Выводим на экран то, что пишут нашему боту, а также небольшую информацию об отправителе
                            _log($"{user.FirstName} ({user.Id}) написал сообщение: {message.Text}");

                            WebAppInfo webAppInfo = new WebAppInfo() { Url = _url };

                            if (message.Text == "/start")
                            {
                                // Тут создаем нашу клавиатуру
                                var inlineKeyboard = new InlineKeyboardMarkup(
                                    new List<InlineKeyboardButton[]>() // здесь создаем лист (массив), который содрежит в себе массив из класса кнопок
                                    {
                                        // Каждый новый массив - это дополнительные строки,
                                        // а каждая дополнительная строка (кнопка) в массиве - это добавление ряда

                                        new InlineKeyboardButton[] // тут создаем массив кнопок
                                        {
                                            InlineKeyboardButton.WithWebApp("Это кнопка с сайтом", webAppInfo)
                                        },
                                    });

                                await botClient.SendTextMessageAsync(
                                    chat.Id,
                                    "Это inline клавиатура!",
                                    replyMarkup: inlineKeyboard); // Все клавиатуры передаются в параметр replyMarkup

                                return;
                            }

                            return;
                        }
                }
            }
            catch (Exception ex)
            {
                _log(ex.ToString());
            }
        }

        private Task ErrorHandler(ITelegramBotClient botClient, Exception error, CancellationToken cancellationToken)
        {
            // Тут создадим переменную, в которую поместим код ошибки и её сообщение 
            var ErrorMessage = error switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => error.ToString()
            };

            _log(ErrorMessage);
            return Task.CompletedTask;
        }
    }
}
