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



            Console.WriteLine("Czy dane podane są w szeregu rozdzielczym? (t/n)");
            string kindData = Console.ReadLine();
            Console.WriteLine("Podaj ilośc obserwacji");
            int length = int.Parse(Console.ReadLine());
            double[] num = new double[length];
            double[] dsx = new double[length];
            double[] dex = new double[length];
            Console.WriteLine("czy twoje dane zawierają szereg liczebności? (t/n)");
            string ifNumer = Console.ReadLine();
            if (ifNumer == "t")
            {
                Console.WriteLine("Wprowadź szereg liczebności odzielając dane spacją");

                string[] x = Console.ReadLine().Split(' ');


                for (int i = 0; i < length; i++)
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
            }

            Console.WriteLine("Wprowadź szereg  danej x");
            string[] y = Console.ReadLine().Split(' ');



            for (int i = 0; i < length; i++)
            {
                c = double.TryParse(y[i], out b);
                if (c != true)
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
                string[] z = Console.ReadLine().Split(' ');



                for (int i = 0; i < length; i++)
                {
                    c = double.TryParse(z[i], out b);
                    if (c != true)
                    {

                        do
                        {
                            Console.WriteLine($"Dana na pozycji {i} niezgodna z formatem\n" +
                                $"Ponownie wczytaj daną");
                            c = double.TryParse(Console.ReadLine(), out b);
                        } while (c != true);
                        dex[i] = b;
                    }
                }
            }

            if (ifNumer == "t" || kindData != "t")
            {
                DataSet ds = new DataSet(num, dsx);
                double sred = ds.Averange(ds.GetDataList);
                Console.WriteLine($"Sredna arytmetyczna{ sred}");
            }
            else if (ifNumer != "t" || kindData == "t")
            {
                DataSet ds = new DataSet(num, dsx);
                double sred = ds.AverangeW(ds.GetDataList);
                Console.WriteLine($"Sredna ważona { sred}");
            }
            else
            {
                DataSet ds = new DataSet(num, dsx, dex);
                double sred = ds.AverangeW(ds.GetDataList);
                Console.WriteLine($"Srednia ważona: {sred}");
            }



        }
    }
}
