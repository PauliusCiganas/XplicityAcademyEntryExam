using System;
using System.Collections;
using System.Collections.Generic;

namespace Xplicity.Academy.EntranceExam.Tasks
{
    //Task #1 (Points: 25)
    //Apparently, mages use money: Galleon, Sickle and Knut.
    //They are gold, silver, and bronze, respectively.
    //There are 17 Sickles in a Galleon, and 29 Knuts in a Sickle.
    //All the money data (prices, amount of cash etc.) is to be written in Galleons, Sickles and Knuts; the number of Sickles cannot be bigger than 16 and the number of Knuts cannot be bigger than 28.
    //Harry Potter needs to buy some magic stuff before coming to his school of wizardry.
    //Initially, he took some amount of cash from his bank account and then he went shopping.
    //How much money he will have after all his purchases?
    //The input data are the initial cash value and the list of prices.
    //Each string has a fixed format of three integer numbers – count of Galleons, Sickles and Knuts separated by spaces, for example: "5 16 10", "3 9 21", "0 4 0".
    //The count of purchases is 0 <= N <= 100000.
    //The number of Galleons for each string is less or equal to 100000 as well.
    //The output data is a string of the same format.
    //If the total sum of all the purchases exceeds the initial cash value, return "-1".
    public class Task1
    {
        public static string CashFromBank()
        {
            string initialCash = MoneyMethod();
            Console.WriteLine(initialCash);
            return initialCash;
        }

        public static List<string> PriceList()
        {
            List<string> prices = new List<string>();

            Console.Clear();
            Console.WriteLine("select the Wand price : ");
            string wandPrice = MoneyMethod();
            prices.Add(wandPrice);

            Console.Clear();
            Console.WriteLine("select the Broom price : ");
            string broomPrice = MoneyMethod();
            prices.Add(broomPrice);

            Console.Clear();
            Console.WriteLine("select the Parchment price : ");
            string parchmentPrice = MoneyMethod();
            prices.Add(parchmentPrice);

            return prices;
        }

        public static string Purchase(string initialCash, IEnumerable<string> prices)
        {
            var priceList = new List<string>();
            foreach (var item in prices)
            {
                priceList.Add(item);
            }

            var wand = StringToInt(priceList[0]);
            var broom = StringToInt(priceList[1]);
            var parchment = StringToInt(priceList[2]); ;

            List<int> cash = StringToInt(initialCash);
            int cashGalleon = cash[0] - wand[0] - broom[0] - parchment[0];
            int cashSickle = cash[1] - wand[1] - broom[1] - parchment[1];
            int cashKnut = cash[2] - wand[2] - broom[2] - parchment[2];


            while (cashKnut < 0)
            {
                cashSickle--;
                cashKnut += 29;
            }
            while (cashSickle < 0)
            {
                cashGalleon--;
                cashSickle += 17;
            }

            string CashLeft = cashGalleon.ToString() + " " + cashSickle.ToString() + " " + cashKnut.ToString();
            if (cashGalleon < 0)
            {
                Console.WriteLine("You dont have enough money!!!");
                CashLeft = "-1";
            }
            Console.Clear();
            Console.WriteLine($"Cash left after diagon alley : " + CashLeft);

            return CashLeft;
        }

        public static string MoneyMethod()
        {
            int galleon;
            int sickle;
            int knut;

            Console.WriteLine("Galleon : ");
            while (!int.TryParse(Console.ReadLine(), out galleon) || galleon < 0 || galleon > 100000)
            {
                Console.WriteLine("please chose another Galleon amount");
                continue;
            }

            Console.WriteLine("Sickle, no more than 15! : ");
            while (!int.TryParse(Console.ReadLine(), out sickle) || sickle < 0 || sickle > 16)
            {
                Console.WriteLine("please chose another Sickle amount");
                continue;
            }

            Console.WriteLine("Knut, no more than 27! : ");
            while (!int.TryParse(Console.ReadLine(), out knut) || knut < 0 || knut > 28)
            {
                Console.WriteLine("please chose another Knut amount");
                continue;
            }

            string initialValue = (galleon.ToString() + " " + sickle.ToString() + " " + knut.ToString());
            return initialValue;
        }

        public static List<int> StringToInt(string data)
        {
            List<int> newData = data.Split(' ').Select(int.Parse).ToList();
            return newData;
        }
    }
}