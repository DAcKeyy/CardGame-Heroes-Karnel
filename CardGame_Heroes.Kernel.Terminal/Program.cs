using Leopotam.Ecs;
using CardGame_Heroes.Kernel.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CardGame_Heroes.Kernel.Terminal
{
    static class Program
    {
        static Game game;
        static List<PlayerComponent> playerComponents = new List<PlayerComponent>(); 

        static void Main(string[] args)
        {
            ConsoleExtention.WriteColor($"♥Card Game Server Console Application♥\n", ConsoleColor.DarkGreen);
            ConsoleExtention.WriteColor($"Version ♥{Assembly.GetExecutingAssembly().GetName().Version}♥\n\n", ConsoleColor.DarkGreen);
            game = new Game();
            ReadCommandLine();
        }

        private static void ReadCommandLine()
        {
            ConsoleExtention.WriteColor("Write  ♥/help♥  or  ♥/h♥  to show server commands\n\n", ConsoleColor.Yellow);

            string command;
            bool stop = false;

            while (!stop)
            {
                command = Console.ReadLine();
                string[] args = command.Split(' ');
                switch (args[0])
                {
                    case "/s":
                    case "/start":
                        if(playerComponents == null || playerComponents.Count < 2)
                        {
                            ConsoleExtention.WriteColor($"♥Вы забыли добавить информацию о игроках!♥\n", ConsoleColor.Red);
                            ConsoleExtention.WriteColor($"Для добавления игроков введите команду ♥/addnp♥ или ♥/addNewPlayer♥\n", ConsoleColor.Yellow);
                        }
                        game.Start(playerComponents.ToArray());
                        break;
                    case "/addnp":
                    case "/addNewPlayer":
                        ConsoleExtention.WriteColor($"Введите ♥никнейм♥: ", ConsoleColor.Blue);
                        var nickname = Console.ReadLine();
                        ConsoleExtention.WriteColor($"Введите путь до файла массива карт ♥(C:\\...\\[deckname].json)♥: ", ConsoleColor.Blue);
                        FileInfo fi = new FileInfo(Console.ReadLine());
                        if(fi.Exists == false) ConsoleExtention.WriteColor($"♥Такого пути не существует♥!\n", ConsoleColor.Red);
                        if(fi.Extension != ".json") ConsoleExtention.WriteColor($"♥Коненчый файл пути НЕ .json♥!\n", ConsoleColor.Red);
                        //TODO: addNewPlayer deck.json to cardArray
                        ConsoleExtention.WriteColor($"♥Feature not implemented!♥\n", ConsoleColor.Red);
                        ConsoleExtention.WriteColor($"♦You can contact the creator by email:♦ ♠alexanderdovmantov@gmail.com♠\n", ConsoleColor.Yellow, ConsoleColor.Blue);
                        break;
                    case "/dwlddeck":
                    case "/downloadDeck":
                        //TODO: download Deck.json from server
                        ConsoleExtention.WriteColor($"♥Feature not implemented!♥\n", ConsoleColor.Red);
                        ConsoleExtention.WriteColor($"♦You can contact the creator by email:♦ ♠alexanderdovmantov@gmail.com♠\n", ConsoleColor.Yellow, ConsoleColor.Blue);
                        break;
                    case "/pinf":
                    case "/playerInfo":
                        if (game.ECSystem.Players == null || game.ECSystem.Players.Length == 0)
                        {
                            ConsoleExtention.WriteColor($"♥Нету зарегистрированных в игре игроков!♥\n", ConsoleColor.Red);
                            break;
                        }
                        ConsoleExtention.WriteColor($"♥Информация о игроках:♥\n", ConsoleColor.Yellow);
                        foreach (var player in game.ECSystem.Players)
                        {
                            ConsoleExtention.WriteColor($"Никнейм игрока- ♥{player.Get<PlayerComponent>().Cards}♥\n", ConsoleColor.Yellow);
                            ConsoleExtention.WriteColor($"Карт в колоде ♥{player.Get<PlayerComponent>().Cards.Length}♥:\n", ConsoleColor.Yellow);
                            foreach (var card in player.Get<PlayerComponent>().Cards)
                            {
                                if (string.IsNullOrEmpty(card.Name) != true) ConsoleExtention.WriteColor($"Название карты: ♥{card.Name}♥\n", ConsoleColor.Green);
                                if (card.Type != null) ConsoleExtention.WriteColor($"Тип : ♥{card.Type}♥\n", ConsoleColor.Yellow);
                                if (card.Class != null) ConsoleExtention.WriteColor($"Класс : ♥{card.Class}♥\n", ConsoleColor.Yellow);
                                if (card.Elements != null) ConsoleExtention.WriteColor($"Стихия : ♥{card.Elements}♥\n", ConsoleColor.Yellow);
                                if (card.Cost != null) ConsoleExtention.WriteColor($"Стоимсоть : ♥{card.Cost}♥\n", ConsoleColor.Yellow);
                                if (card.Health != null) ConsoleExtention.WriteColor($"Здоровье : ♥{card.Health}♥\n", ConsoleColor.Yellow);
                                if (card.Attack != null) ConsoleExtention.WriteColor($"Атака : ♥{card.Attack}♥\n", ConsoleColor.Yellow);
                                if (string.IsNullOrEmpty(card.Text) != true) ConsoleExtention.WriteColor($"Описание : ♥{card.Text}♥\n", ConsoleColor.Yellow);
                            }
                            Console.WriteLine();
                        }
                        break;
                    case "/help":
                    case "/h":
                        ConsoleExtention.WriteColor($"♥List of commands: ♥\n\n", ConsoleColor.Blue);
                        ConsoleExtention.WriteColor($"♦/s♦ or ♦/start♦  -  ♠Starts game core♠\n", ConsoleColor.Yellow, ConsoleColor.Green);
                        ConsoleExtention.WriteColor($"♦/addnp♦ or ♦/addNewPlayer♦  -  ♠Добовляет нового игрока к системе♠\n", ConsoleColor.Yellow, ConsoleColor.Green);
                        ConsoleExtention.WriteColor($"♦/dwlddeck♦ or ♦/downloadDeck♦  -  ♠Скачивает выбранную далее колоду (deckname.json) с сервера игры♠\n", ConsoleColor.Yellow, ConsoleColor.Green);
                        ConsoleExtention.WriteColor($"♦/pinf♦ or ♦/playerInfo♦  -  ♠Показывает данные о игроках в запущеной игре♠\n", ConsoleColor.Yellow, ConsoleColor.Green);
                        break;
                    default:
                        ConsoleExtention.WriteColor($"Unknown Command ♥{command}♥\n", ConsoleColor.Red);
                        break;
                }
            }
        }
    }
}
