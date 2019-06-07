using System;
using System.Drawing;

namespace Epam.Exercises.CleanCode.AdvancedAscii.ConsoleApp
{
    internal class Program
    {
        private static ImageHelper image;
        private static int stepY;
        private static int stepX;
        private static char[] charsByDarkness = { '#', '@', 'X', 'L', 'I', ':', '.', ' ' };

        private static void Main()
        {
            int min = 0;
            int max = 255 * 3;
            Initialize();

            var maxStepY = image.GetHeight() - stepY;
            var maxStepX = image.GetWidth() - stepX;

            for (int y = 0; y < maxStepY; y += stepY)
            {
                for (int x = 0; x < maxStepX; x += stepX)
                {
                    var point = new Point(x, y);
                    int sum = image.GetRGB(point);

                    Console.Write(charsByDarkness[(sum - min) * charsByDarkness.Length / (max - min + 1)]);
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }

        private static void Initialize()
        {
            image = new ImageHelper("pair_hiking.png");
            stepY = image.GetHeight() / 45;
            stepX = image.GetWidth() / 150;
        }
    }
}
