using CardGame_Heroes.Network;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CardGame_Heroes.Kernel.Random
{
    public class Randomizer
    {
        readonly RandomOrg randomOrg = new();

        public enum Coin {
            Obverse,
            Reverse
        }

        /// <summary>
        /// Метод перестановки элементов в заданном List
        /// </summary>
        /// <typeparam name="T">Шаблон любого объекта C#</typeparam>
        /// <param name="list">Цель перетосовки</param>
        /// <returns>Возвращает отсортированный List обезянним методом</returns>
        async public Task<List<T>> ShuffleList<T>(List<T> list)
        {
            List<T> shuffledList = new();

            if (randomOrg.isConnectingToGoogle == false)//Псведослучайное если нет соединения с рандом.орг
            {
                System.Random sharpRandom = new();
                List<int> tempRandomList = new(); //пустой лист для заполениня

                Task<List<int>> fillList_With_Rundom_int_Task = Task.Run(() => //асинхронная задача для абуза Random.Next 
                {
                    List<int> tempRandomList = new();
                    while (tempRandomList.Count != list.Count) //я ебал рот майкрософт
                    {
                        int randomSharpNumber = sharpRandom.Next(0, list.Count - 1);
                        if (!tempRandomList.Contains(randomSharpNumber)) tempRandomList.Add(randomSharpNumber);
                    }

                    return tempRandomList;
                });

                tempRandomList = await fillList_With_Rundom_int_Task; //ждём пока лист не запонлится без повторюшек

                for (int i = 0; i < list.Count; i++) //перетасовываем шаблонный список сгенериеными индакасми порядка
                    shuffledList.Add(list[tempRandomList[i]]);
            } 
            else
            {
                //берём данные с рандом орга чтобы пришёл список цифор от 0 до максДлинны листа без повторений индексов
                var response = await randomOrg.randomOrgClient.GenerateIntegersAsync(list.Count, 0, list.Count - 1, false);
                for(int i = 0; i < list.Count; i++)
                    shuffledList.Add(list[response.Random.Data[i]]);//перетасовываем шаблонный список случайными индакасми порядка
            }

            return shuffledList;
        }
        /// <summary>
        /// Метод получения случайного целочисленного числа
        /// </summary>
        /// <param name="min">Минимум в диапозоне генерации</param>
        /// <param name="max">Максимум в диапозоне генерации</param>
        /// <returns>Возвращает случайное число в заданом диапазоне</returns>
        async public Task<int> RandomInt(int min, int max)
        {
            if (randomOrg.isConnectingToGoogle == false) //если нет инета
            {
                System.Random sharpRandom = new();
                return sharpRandom.Next(min,max);
            }
            else
            {
                var response = await randomOrg.randomOrgClient.GenerateIntegersAsync(1, min, max, false);
                return response.Random.Data[0];
            }
        }

        /// <summary>
        /// Метод подброса монетки
        /// </summary>
        /// <returns>Возвращает монетку Coin - 0 или 1</returns>
        async public Task<Coin> CoinFlip()
        {
            if(randomOrg.isConnectingToGoogle == false) //если нет инета
            {
                System.Random sharpRandom = new();
                if (sharpRandom.Next(0, 1) is 0) return Coin.Obverse;
                else return Coin.Reverse;
            }
            else
            {
                var response = await randomOrg.randomOrgClient.GenerateIntegersAsync(1, 0, 1, false);
                if (response.Random.Data[0] is 0) return Coin.Obverse;
                else return Coin.Reverse;
            }
        }
    }
}
