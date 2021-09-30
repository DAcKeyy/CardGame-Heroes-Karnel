using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CardGame_Heroes.Kernel.Terminal
{
    public static class ConsoleExtention
    {

        /// <summary>
        /// Расширение консоли для раскрашиваня выходного текста.
        /// 
        /// Пример: "Это мой ♥текст♥ где алтькод это то ♥что нужно раскасить♥"  
        /// где ♥ - цвет color1 (alt + numpad [4])
        /// </summary>
        /// <param name="message">Тест сообщения (не забываем расставить ♥ (alt + numpad [3]))</param>
        /// <param name="color">Текст цвета заключённый в ♥__♥</param>
        public static void WriteColor(string message, ConsoleColor color)
        {
            var pieces = Regex.Split(message, @"(\♥[^\♥]*\♥)");

            for (int i = 0; i < pieces.Length; i++)
            {
                string piece = pieces[i];

                if (piece.StartsWith("♥") && piece.EndsWith("♥"))
                {
                    Console.ForegroundColor = color;
                    piece = piece.Substring(1, piece.Length - 2);
                }

                Console.Write(piece);
                Console.ResetColor();
            }

            //Console.WriteLine();
        }

        /// <summary>
        /// Расширение консоли для раскрашиваня выходного текста.
        ///  
        /// Пример: 
        /// "Это мой ♦текст♦ где алтькод это то ♠что нужно раскасить♠"  
        /// 
        /// где ♦ - цвет color1 (alt + numpad [4])
        /// где ♠ - цвет color2 (alt + numpad [6])
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        /// <param name="color1">Раскрашивает всё, что заключено между ♦, в этот цвет</param>
        /// <param name="color2">Раскрашивает всё, что заключено между ♠, в этот цвет</param>
        public static void WriteColor(string message, ConsoleColor color1, ConsoleColor color2)
        {
            var pieces = Regex.Split(message, @"(\♦[^\♦]*\♦)|(\♠[^\♠]*\♠)");


            for (int i = 0; i < pieces.Length; i++)
            {
                string piece = pieces[i];

                if (piece.StartsWith("♦") && piece.EndsWith("♦"))
                {
                    Console.ForegroundColor = color1;
                    piece = piece.Substring(1, piece.Length - 2);
                }

                if (piece.StartsWith("♠") && piece.EndsWith("♠"))
                {
                    Console.ForegroundColor = color2;
                    piece = piece.Substring(1, piece.Length - 2);
                }

                Console.Write(piece);
                Console.ResetColor();
            }

            //Console.WriteLine();
        }
    }
}