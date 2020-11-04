using System;
using System.IO;

namespace Task_5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Путь к файлу
            string path_x = @"C:\Users\user\source\repos\ConsoleApp2\ConsoleApp2\x.txt";
            string path_y = @"C:\Users\user\source\repos\ConsoleApp2\ConsoleApp2\y.txt";

            // Создание пустых массивов
            double[] x = FilesToGetArrays(path_x);
            double[] y = FilesToGetArrays(path_y);

            Console.WriteLine($"Array X: {string.Join(' ', x)}");
            Console.WriteLine($"Array Y: {string.Join(' ', y)}");

            New_x(ref x);
            Console.WriteLine($"Changed X: {string.Join(' ', x)}");

            double[] z = new double[x.Length];

            New_z(x, y, ref z);
            Console.WriteLine($"Array Z: {string.Join(' ', z)}");
        }
        public static double[] FilesToGetArrays(string path_x)
        {
            string[] file = File.ReadAllText(path_x).Split(", ");
            double[] newArr = new double[file.Length];
            for (int i = 0; i < file.Length; i++)
            {
                try
                {
                    newArr[i] = Convert.ToDouble(file[i]);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Некоректні дані у файлі");
                    Environment.Exit(0);
                }
            }
            return newArr;
        }
        public static void New_x(ref double[] x)
        {
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] % 7 == 0 && x[i] != 0)
                {
                    x[i] = x[i] + 8;
                }
            }
        }
        public static void New_z(double[] x, double[] y, ref double[] z)
        {
            for (int i = 0; i < x.Length; i++)
            {
                z[i] = (x[i] * x[i] - y[i] * y[i]) / 2;
            }

        }
    }
}
