using ClassLibrary1;
using System;

namespace kalkulator_statystyczny
{
    class Program
    {
        static void Main(string[] args)
        {
            double b;
            bool c;
            Console.WriteLine("Podaj ilośc obserwacji");
            int length = int.Parse(Console.ReadLine());
            double[] num = new double[length];
            double[] dsx = new double[length];
            double[] dex = new double[length];
            Console.WriteLine("Czy dane podane są w szeregu rozdzielczym? (t/n)");
            string kindData = Console.ReadLine();

            Console.WriteLine("czy twoje dane zawierają szereg liczebności? (t/n)");
            string ifNumer = Console.ReadLine();
            if (ifNumer == "t")
            {
                Console.WriteLine("Wprowadź szereg liczebności ");

                for (int i = 0; i < length; i++)
                {
                    c = double.TryParse(Console.ReadLine(), out b);
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
            }

            Console.WriteLine("Wprowadź szereg  danej x ( lub początek przedziału  x)");

            for (int i = 0; i < length; i++)
            {
                c = double.TryParse(Console.ReadLine(), out b);
                if (c)
                {

                    dsx[i] = b;
                }
                else
                {

                    do
                    {
                        Console.WriteLine($"Dana na pozycji {i} niezgodna z formatem\n" +
                            $"Ponownie wczytaj daną");
                        c = double.TryParse(Console.ReadLine(), out b);
                    } while (c != true);
                    dsx[i] = b;
                }

            }
            if (kindData == "t")
            {
                Console.WriteLine("Wprowadź szereg końca przedziału danej x");

                for (int i = 0; i < length; i++)
                {
                    c = double.TryParse(Console.ReadLine(), out b);
                    if (c)
                    {

                        dex[i] = b;
                    }
                    else
                    {
                        do
                        {
                            Console.WriteLine($"Dana na pozycji {i + 1} niezgodna z formatem\n" +
                                $"Ponownie wczytaj daną");
                            c = double.TryParse(Console.ReadLine(), out b);
                        } while (c != true);
                        dex[i] = b;
                    }
                }
            }


            if (ifNumer == "t" && kindData != "t")
            {
                DataSet ds = new DataSet(num, dsx);

                Console.WriteLine($"Sredna arytmetyczna x: {ds.Averange(ds.GetDataList)}");
                Console.WriteLine($" Srednia ważona: {ds.AverangeW(ds.GetDataList)}");

            }
            else if (ifNumer != "t" && kindData != "t")
            {
                DataSet ds = new DataSet(dsx);

                Console.WriteLine($"Sredna arytmetyczna { ds.Averange(ds.GetDataList)}");
            }
            else if (ifNumer == "t" && kindData == "t")
            {
                DataSet ds = new DataSet(num, dsx, dex);
                Console.WriteLine($"Sredna arytmetyczna x ( wg środka przedziału): {ds.Averange(ds.GetDataList)}");
                Console.WriteLine($"Srednia ważona: {ds.AverangeW(ds.GetDataList)}");
            }
            else
            {
                DataSet ds = new DataSet(num, dsx, dex);
                Console.WriteLine($"Sredna arytmetyczna { ds.Averange(ds.GetDataList)}");
            }



        }
    }
}
