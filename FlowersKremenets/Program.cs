using System;

using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using System.Data.OleDb;

namespace FlowersKremenets_Bot
{
    class Program
    {

        static TelegramBotClient Bot;
        static void Main(string[] args)
        {
            Bot = new TelegramBotClient("608153277:AAF9CcDg5zAQHsXi7tAwyVeP2kVKDW5DbYc");

            Bot.OnMessage += Bot_OnMessage;

            var me = Bot.GetMeAsync().Result;

            Console.WriteLine(me.FirstName);

            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();
        }

        private static OleDbConnection connection = new OleDbConnection();

        private static async void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\User\Desktop\Курсова\FlowersKremenets\Database1.mdb;
            Persist Security Info=False;";

            var message = e.Message;

            if (message == null || message.Type == MessageType.MessagePinned)
                return;
            string name = $"{message.From.FirstName} {message.From.LastName}";

            Console.WriteLine($"{name} Надіслано повідомлення: '{message.Text}'");

            switch (message.Text)
            {
                case "/start":
                    string text =
@"Вітаємо у нашому магазині! :) 
Для початку роботи бота оберіть команду:
/menu - меню";
                    await Bot.SendTextMessageAsync(message.From.Id, text);
                    break;
                case "/menu":
                    var replyKeyboard = new ReplyKeyboardMarkup(new[]
                    {
                        new[]
                        {
                            new KeyboardButton("Каталог")
                        },
                        new[]
                        {
                            new KeyboardButton("Наші контакти"),
                            new KeyboardButton("Місцезнаходження")
                        }
                    });
                    await Bot.SendTextMessageAsync(message.Chat.Id, "Оберіть дію", replyMarkup: replyKeyboard);
                    break;
                case "Каталог":
                    var replyKeyboard1 = new ReplyKeyboardMarkup(new[]
                    {
                        new[]
                        {
                            new KeyboardButton("Роза"),
                            new KeyboardButton("Гвоздика"),
                            new KeyboardButton("Тюльпани")
                        },
                        new[]
                        {
                            new KeyboardButton("Лілія"),
                            new KeyboardButton("Ромашки"),
                            new KeyboardButton("Хризантема")
                        },
                        new[]
                        {
                            new KeyboardButton("Орхідея"),
                            new KeyboardButton("Вазони"),
                            new KeyboardButton("Дерев'яні вироби з іменами")
                        },
                        new[]
                        {
                            new KeyboardButton("Оформити букет")
                        },
                        new[]
                        {
                            new KeyboardButton("Повернутись")
                        }
                    });
                    await Bot.SendTextMessageAsync(message.Chat.Id, "Оберіть товар", replyMarkup: replyKeyboard1);
                    break;
                case "Наші контакти":
                    await Bot.SendTextMessageAsync(message.Chat.Id, @"
Час роботи магазину: Пн-Нд з 08:00 по 20:00.
Прийом дзвінків: цілодобово.
life: +380632085664.
kyivstar: +380672085674.
");
                    break;
                case "Місцезнаходження":
                    await Bot.SendLocationAsync(message.Chat.Id, 50.1163f, 25.7193f);
                    break;
                case "Роза":

                    if (message.Text == "Роза")
                    {
                        await Bot.SendPhotoAsync(message.Chat.Id, "AgADAgADZKkxG8NheUgKmZ9gsX3u1kv0mw4ABGT6lptLiTAGVQABBQABAg");

                        connection.Open();
                        OleDbCommand command = new OleDbCommand();
                        command.Connection = connection;
                        command.CommandText = "select Price from Flowers where Код = 1";
                        var rx = command.ExecuteScalar().ToString();
                        connection.Close();

                        await Bot.SendTextMessageAsync(message.Chat.Id, rx);
                    }
                    var replyKeyboard1_1 = new ReplyKeyboardMarkup(new[]
                   {
                        new[]
                        {
                            new KeyboardButton("Замовити")
                        },
                        new[]
                        {
                            new KeyboardButton("Повернутись до меню")
                        }
                    });
                    await Bot.SendTextMessageAsync(message.Chat.Id, "Оберіть дію:", replyMarkup: replyKeyboard1_1);
                    break;
                case "Гвоздика":

                    if (message.Text == "Гвоздика")
                    {
                        await Bot.SendPhotoAsync(message.Chat.Id, "AgADAgAD5agxG7VPeEhiJfE_Ed2g6exiqw4ABIUTyTZ8VMZeFxkCAAEC");

                        connection.Open();
                        OleDbCommand command1 = new OleDbCommand();
                        command1.Connection = connection;
                        command1.CommandText = "select Price from Flowers where Код = 2";
                        var rx1 = command1.ExecuteScalar().ToString();
                        connection.Close();

                        await Bot.SendTextMessageAsync(message.Chat.Id, rx1);
                    }
                    var replyKeyboard1_2 = new ReplyKeyboardMarkup(new[]
                  {
                        new[]
                        {
                            new KeyboardButton("Замовити")
                        },
                        new[]
                        {
                            new KeyboardButton("Повернутись до меню")
                        }
                    });
                    await Bot.SendTextMessageAsync(message.Chat.Id, "Оберіть дію:", replyMarkup: replyKeyboard1_2);

                    break;
                case "Тюльпани":

                    if (message.Text == "Тюльпани")
                    {
                        await Bot.SendPhotoAsync(message.Chat.Id, "AgADAgADaakxG8NheUhFiUtCSYPirqu4mg4ABAsOk3p43yrz8f8EAAEC");

                        connection.Open();
                        OleDbCommand command1 = new OleDbCommand();
                        command1.Connection = connection;
                        command1.CommandText = "select Price from Flowers where Код = 3";
                        var rx1 = command1.ExecuteScalar().ToString();
                        connection.Close();

                        await Bot.SendTextMessageAsync(message.Chat.Id, rx1);
                    }
                    var replyKeyboard1_3 = new ReplyKeyboardMarkup(new[]
                  {
                        new[]
                        {
                            new KeyboardButton("Замовити")
                        },
                        new[]
                        {
                            new KeyboardButton("Повернутись до меню")
                        }
                    });
                    await Bot.SendTextMessageAsync(message.Chat.Id, "Оберіть дію:", replyMarkup: replyKeyboard1_3);

                    break;
                case "Лілія":

                    if (message.Text == "Лілія")
                    {
                        await Bot.SendPhotoAsync(message.Chat.Id, "AgADAgADaqkxG8NheUg27Ja7MsHajVO4qw4ABHCom115Kj00yhoCAAEC");

                        connection.Open();
                        OleDbCommand command1 = new OleDbCommand();
                        command1.Connection = connection;
                        command1.CommandText = "select Price from Flowers where Код = 4";
                        var rx1 = command1.ExecuteScalar().ToString();
                        connection.Close();

                        await Bot.SendTextMessageAsync(message.Chat.Id, rx1);
                    }
                    var replyKeyboard1_4 = new ReplyKeyboardMarkup(new[]
                  {
                        new[]
                        {
                            new KeyboardButton("Замовити")
                        },
                        new[]
                        {
                            new KeyboardButton("Повернутись до меню")
                        }
                    });
                    await Bot.SendTextMessageAsync(message.Chat.Id, "Оберіть дію:", replyMarkup: replyKeyboard1_4);

                    break;
                case "Ромашки":

                    if (message.Text == "Ромашки")
                    {
                        await Bot.SendPhotoAsync(message.Chat.Id, "AgADAgADa6kxG8NheUgbdWUrNSD0RSSlmg4ABBL6X_ugH_3TDAgFAAEC");

                        connection.Open();
                        OleDbCommand command1 = new OleDbCommand();
                        command1.Connection = connection;
                        command1.CommandText = "select Price from Flowers where Код = 5";
                        var rx1 = command1.ExecuteScalar().ToString();
                        connection.Close();

                        await Bot.SendTextMessageAsync(message.Chat.Id, rx1);
                    }
                    var replyKeyboard1_5 = new ReplyKeyboardMarkup(new[]
                  {
                        new[]
                        {
                            new KeyboardButton("Замовити")
                        },
                        new[]
                        {
                            new KeyboardButton("Повернутись до меню")
                        }
                    });
                    await Bot.SendTextMessageAsync(message.Chat.Id, "Оберіть дію:", replyMarkup: replyKeyboard1_5);

                    break;
               case "Хризантема":

                    if (message.Text == "Хризантема")
                    {
                        await Bot.SendPhotoAsync(message.Chat.Id, "AgADAgADb6kxG8NheUgmyUgt9ZECBecXnA4ABEOJ3AfCqY1qkQcFAAEC");

                        connection.Open();
                        OleDbCommand command1 = new OleDbCommand();
                        command1.Connection = connection;
                        command1.CommandText = "select Price from Flowers where Код = 6";
                        var rx1 = command1.ExecuteScalar().ToString();
                        connection.Close();

                        await Bot.SendTextMessageAsync(message.Chat.Id, rx1);
                    }
                    var replyKeyboard1_6 = new ReplyKeyboardMarkup(new[]
                  {
                        new[]
                        {
                            new KeyboardButton("Замовити")
                        },
                        new[]
                        {
                            new KeyboardButton("Повернутись до меню")
                        }
                    });
                    await Bot.SendTextMessageAsync(message.Chat.Id, "Оберіть дію:", replyMarkup: replyKeyboard1_6);

                    break;
                case "Орхідея":

                    if (message.Text == "Орхідея")
                    {
                        await Bot.SendPhotoAsync(message.Chat.Id, "AgADAgAD-KgxG7VPeEjLp7xul3K9-aDzmw4ABMDp86-IMZCITwEFAAEC");

                        connection.Open();
                        OleDbCommand command1 = new OleDbCommand();
                        command1.Connection = connection;
                        command1.CommandText = "select Price from Flowers where Код = 7";
                        var rx1 = command1.ExecuteScalar().ToString();
                        connection.Close();

                        await Bot.SendTextMessageAsync(message.Chat.Id, rx1);
                    }
                    var replyKeyboard1_7 = new ReplyKeyboardMarkup(new[]
                  {
                        new[]
                        {
                            new KeyboardButton("Замовити")
                        },
                        new[]
                        {
                            new KeyboardButton("Повернутись до меню")
                        }
                    });
                    await Bot.SendTextMessageAsync(message.Chat.Id, "Оберіть дію:", replyMarkup: replyKeyboard1_7);

                    break;
                case "Вазони":

                    if (message.Text == "Вазони")
                    {
                        await Bot.SendPhotoAsync(message.Chat.Id, "AgADAgADcakxG8NheUhT8zFy4BlMbNQdrQ4ABHW9-_GX9LDCthoCAAEC");

                        connection.Open();
                        OleDbCommand command1 = new OleDbCommand();
                        command1.Connection = connection;
                        command1.CommandText = "select Price from Flowers where Код = 8";
                        var rx1 = command1.ExecuteScalar().ToString();
                        connection.Close();

                        await Bot.SendTextMessageAsync(message.Chat.Id, rx1);
                    }
                    var replyKeyboard1_8 = new ReplyKeyboardMarkup(new[]
                  {
                        new[]
                        {
                            new KeyboardButton("Замовити")
                        },
                        new[]
                        {
                            new KeyboardButton("Повернутись до меню")
                        }
                    });
                    await Bot.SendTextMessageAsync(message.Chat.Id, "Оберіть дію:", replyMarkup: replyKeyboard1_8);

                    break;
                case "Дерев'яні вироби з іменами":

                    if (message.Text == "Дерев'яні вироби з іменами")
                    {
                        await Bot.SendPhotoAsync(message.Chat.Id, "AgADAgAD-qgxG7VPeEiu7VbDwlXo9vFWqw4ABAMfCC4Ea9uSthwCAAEC");

                        connection.Open();
                        OleDbCommand command1 = new OleDbCommand();
                        command1.Connection = connection;
                        command1.CommandText = "select Price from Flowers where Код = 9";
                        var rx1 = command1.ExecuteScalar().ToString();
                        connection.Close();

                        await Bot.SendTextMessageAsync(message.Chat.Id, rx1);
                    }
                    var replyKeyboard1_9 = new ReplyKeyboardMarkup(new[]
                  {
                        new[]
                        {
                            new KeyboardButton("Замовити")
                        },
                        new[]
                        {
                            new KeyboardButton("Повернутись до меню")
                        }
                    });
                    await Bot.SendTextMessageAsync(message.Chat.Id, "Оберіть дію:", replyMarkup: replyKeyboard1_9);

                    break;
                case "Оформити букет":
                    await Bot.SendTextMessageAsync(message.Chat.Id, "Залиште, будь ласка, свій номер телефону для деталізації замовлення і ми з вами найближчим часом зв'яжемось");
                    goto case "/menu";
                case "Повернутись":
                    goto case "/menu";
                case "Замовити":
                    await Bot.SendTextMessageAsync(message.Chat.Id,
                        @"Залиште, будь ласка, свої дані: 
1. Кількість квітів.
2. Чи потрібне оформлення (Так або Ні).
3. Для доставки замовлення необхідно:
    Вулиця, номер будинку/квартири, номер телефону того, кому потрібно доставити замовлення.
3. Ваш номер телефону для підтвердження замовлення.

спасибі за замовлення, очікуйте ;)");
                    break;
               case "Повернутись до меню":
                    goto case "Каталог";
                default:
                    break;
            }
        }
    }
}
