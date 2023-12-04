using System;
using System.Collections.Generic;
using System.Linq;


namespace wolfproblem
{
    class MainClass
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Gözlem Boyutu Girin: ");
            int arrayLenght = int.Parse(Console.ReadLine());

            if (arrayLenght < 5 || arrayLenght > 200000 )
            {
                Console.WriteLine("Gözlem Boyutu 5-200.000 aralığında olmalıdır");
            }

            //Console.WriteLine("Gözlemlenen Kurtların ID'lerini Giriniz: ");
            string[] wolfIdStrArray = Console.ReadLine().Split(' ');

            int[] wolfKindIdArray = new int[arrayLenght];

            if (wolfIdStrArray.Length != arrayLenght)
            {
                Console.WriteLine("hatalı işlem");
                return;
            }

            for (int i = 0; i < arrayLenght; i++)
            {
                if (!int.TryParse(wolfIdStrArray[i], out wolfKindIdArray[i]))
                {
                    Console.WriteLine("Yalnızca Rakam Girişi Yapılmalıdır!!!");
                    return;
                }
            }


            if (wolfKindIdArray.Any(id => id < 1 || id > 5))
            {
                Console.WriteLine("Kurt Türleri Id'leri 1-5 Aralığında Olmalıdır.");
                return;
            }

            Dictionary<int, int> wolfKindCounter = new Dictionary<int, int>();

            foreach (int wolfKindId in wolfKindIdArray)
            {
                if (wolfKindCounter.ContainsKey(wolfKindId))
                    wolfKindCounter[wolfKindId]++;
                else
                    wolfKindCounter[wolfKindId] = 1;
            }

            int mostPopularWolfKind = wolfKindCounter
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .First().Key;

            Console.WriteLine(mostPopularWolfKind);
        }
    }
}
