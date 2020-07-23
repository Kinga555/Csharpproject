using System;

namespace kalkulator_statystyczny
{
    class Program
    {
        static void Main(string[] args)
        {
            double b;
            bool c;

            Console.WriteLine("Czy dane podane są w szeregu rozdzielczym? (T)");
            string kindData = Console.ReadLine();
            Console.WriteLine("Podaj ilośc obserwacji");
            int length = int.Parse(Console.ReadLine());

            Console.WriteLine("Wprowadź szereg liczebności odzielając dane spacją");

            string[] x = Console.ReadLine().Split(' ');

            double[] num = new double[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                c = double.TryParse(x[i], out b);
                if (c)
                {
                    num[i] = b;
                }
                else
                {
                    do
                    {

                        Console.WriteLine($"Dana na pozycji {i} niezgodna z formatem\n" +
                            $"Ponownie wczytaj daną");
                        c = double.TryParse(Console.ReadLine(), out b);
                    } while (c != true);
                }
                num[i] = b;
            }

            Console.WriteLine("Wprowadź szereg  danej x");
            string[] y = Console.ReadLine().Split(' ');

            double[] dsx = new double[y.Length];

            for (int i = 0; i < x.Length; i++)
            {
                c = double.TryParse(x[i], out b);
                if (c != true)
                {

                    do
                    {

                        Console.WriteLine($"Dana na pozycji {i} niezgodna z formatem\n" +
                            $"Ponownie wczytaj daną");
                        c = double.TryParse(Console.ReadLine(), out b);
                    } while (c != true);
                    num[i] = b;
                }
            }




        }
    }
}
