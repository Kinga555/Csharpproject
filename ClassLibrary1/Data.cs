using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Data
    {

        public double Numer { get; set; }
        public double DataX { get; set; }




        public Data(double numer, double dataX)
        {
            Numer = numer;
            DataX = dataX;

        }


        public override string ToString() => $"{Numer} {DataX}";

    }
}
