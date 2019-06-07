using System;
using System.Drawing;

namespace Epam.Exercises.CleanCode.AdvancedAscii.ConsoleApp
{
    internal class Program
    {
        private static ExtendedImage image;
        private static int stepY;
        private static int stepX;
        private static char[] charsByDarkness = { '#', '@', 'X', 'L', 'I', ':', '.', ' ' };

        private static void Main()
        {
            int min = 0;
            int max = 255 * 3;
            Initialize();

            for (int y = 0; y < image.GetHeight() - stepY; y += stepY)
            {
                for (int x = 0; x < image.GetWidth() - stepX; x += stepX)
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
            image = new ExtendedImage("pair_hiking.png");
            stepY = image.GetHeight() / 45;
            stepX = image.GetWidth() / 150;
        }
    }
}
