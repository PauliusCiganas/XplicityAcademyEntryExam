using System;

namespace Xplicity.Academy.EntranceExam.Tasks
{
    //Task #2 (Points: 35)
    //Greta drinks only pure water, and water’s temperature must be x.
    //There is a water cooler in her school which serves exactly alpha milliliters of 100°C water by pressing the red button and beta milliliters of 0°C water by pressing the blue button.
    //Cooler has no thermometer, however Greta figured out if she mixes n milliliter of 100°C water and m milliliters of 0°C water,
    //then the temperature of resulted(n+m) milliliters of water is 100n / (n+m)
    //Greta is an eco-activist; therefore, she does not want to waste any single drop of water and she wants to use only her 1000 milliliters eco-bottle.
    //Which maximal amount of water(in milliliters) of temperature x she can pour using unlimited number of buttons presses?
    //The input data are integer values 1 <= alpha <= 1000, 1 <= beta <= 1000, 0 <= x <= 100.
    //The output data is an integer representing the amount of water in milliliters.
    public class Task2
    {
        public static int GretasWaterTemp()
        {
            int temp;
            Console.WriteLine("Please select Greta's wanted water temperature : ");
            while (!int.TryParse(Console.ReadLine(), out temp) || temp < 0 || temp > 100)
            {
                Console.Clear();
                Console.WriteLine("please select temperature between 0 to 100 degrees");
                continue;
            }
            Console.WriteLine($"selected temperature is " + temp + " degrees");
            return temp;  
        }

        public static int HotWater()
        {
            int ml;
            Console.WriteLine("how much hot water (100°C) is poured by pressing red button  ? ");
            while (!int.TryParse(Console.ReadLine(), out ml) || ml < 0 || ml > 1000)
            {
                Console.Clear();
                Console.WriteLine("please select between 0 to 1000 milliliters");
                continue;
            }
            return ml;
        }

        public static int ColdWater()
        {
            int ml;
            Console.WriteLine("how much cold water (0°C) is poured by pressing blue button ? ");
            while (!int.TryParse(Console.ReadLine(), out ml) || ml < 0 || ml > 1000)
            {
                Console.Clear();
                Console.WriteLine("please select between 1 to 1000 milliliters");
                continue;
            }
            return ml;
        }



        public static int MaxWaterAmount(int alpha, int beta, int x)
        {
            int maxWaterAmount = 0;
            int waterAmount = 0;

            var nRed = 0;
            var mBlue = 0;
            var timesRedPressed = 0;
            var timesBluePressed = 0;
            var nRedFinal = 0;
            var mBlueFinal = 0;
            var timesRedPressedFinal = 0;
            var timesBluePressedFinal = 0;

            while (waterAmount <= 1000)
            {
                nRed = alpha * timesRedPressed;
                timesBluePressed = (((nRed) * (100 - x)) / x) / beta;
                if (Convert.ToBoolean(timesBluePressed))
                {
                    mBlue = beta * timesBluePressed;
                    waterAmount = nRed + mBlue;
                      if (waterAmount <= 1000 && waterAmount > maxWaterAmount)
                      {
                        maxWaterAmount = waterAmount;
                        nRedFinal = nRed;
                        mBlueFinal = mBlue;
                        timesRedPressedFinal = timesRedPressed;
                        timesBluePressedFinal = timesBluePressed;
                      }
                }
                timesRedPressed++;
            }
            Console.WriteLine($"v:" + maxWaterAmount + ", n:" + nRedFinal + "=" + timesRedPressedFinal + " x " + alpha + ", m:" + mBlueFinal + "=" + timesBluePressedFinal + " x " + beta);

            return maxWaterAmount;
        }

    }
}
