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
            string wolfIdInput = Console.ReadLine();

            int[] validWolfKinds = { 1, 2, 3, 4, 5 };
            List<int> wolfKindIdList = new List<int>();

            foreach (char character in wolfIdInput)
            {
                if (char.IsDigit(character))
                {
                    int currentDigit = int.Parse(character.ToString());

                    if (validWolfKinds.Contains(currentDigit))
                    {
                        wolfKindIdList.Add(currentDigit);
                    }

                }

            }

            if (wolfKindIdList.Count != arrayLenght)
            {
                Console.WriteLine("Kurt id sayısı dizi boyutu kadar olmalıdır!");
                return;
            }


            Dictionary<int, int> wolfKindCounter = new Dictionary<int, int>();

            foreach (int wolfKindId in wolfKindIdList)
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
