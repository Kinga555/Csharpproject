using System.Collections.Generic;
using System.Data;

namespace ClassLibrary1
{
    /// <summary>
    /// Klasa  implementująca dane wprowadzone w konsoli
    /// </summary>
    public class DataSet
    {
        protected List<Data> datas;
        /// <summary>
        /// zwraca dane jako listę w formacie (liczebność, dana x)
        /// </summary>
        public List<Data> GetDataList => datas;
        public double[] TabNumer { get; private set; }
        public double[] TabStartRange { get; private set; }
        public double[] TabEndOfRange { get; private set; }

        //konstruktor dla szeregu x bez szeregu liczebnosci
        public DataSet(double[] start)
        {
            datas = new List<Data>();

            TabStartRange = start;

            SetUpDataList();
        }
        //konstruktor dla danych z szeregiem liczebnosci i szeregiem szczegółowym danej x
        public DataSet(double[] num, double[] start)
        {
            datas = new List<Data>();
            TabNumer = num;
            TabStartRange = start;
            SetUpSimpleDataList();
        }
        //konstruktor dla danych z szeregiem liczebności i szeregiem rozdzielczym x
        public DataSet(double[] num, double[] start, double[] end)
        {
            datas = new List<Data>();
            TabNumer = num;
            TabStartRange = start;
            TabEndOfRange = end;
            SetUpRangeDataList();
        }

        private void SetUpDataList()
        {
            for (int i = 0; i < TabStartRange.Length; i++)
            {
                Data data = new Data(i + 1, TabStartRange[i]);
                datas.Add(data);
            }
        }

        private void SetUpSimpleDataList()
        {
            for (int i = 0; i < TabStartRange.Length; i++)
            {
                Data data = new Data(TabNumer[i], TabStartRange[i]);
                datas.Add(data);
            }

        }
        private void SetUpRangeDataList()
        {

            for (int i = 0; i < TabStartRange.Length; i++)
            {
                double v = ((TabEndOfRange[i] - TabStartRange[i]) / 2) + TabStartRange[i];
                Data data = new Data(TabNumer[i], dataX: v);
                datas.Add(data);
            }
        }
        /// <summary>
        /// metoda wylicza średnią arytmetyczną
        /// </summary>
        /// <param name="datas"></param>
        /// <returns> srednia arytmetyczna</returns>
        public double Averange(List<Data> datas)
        {

            double sum = 0;
            for (int i = 0; i < datas.Count; i++)
            {
                sum += datas[i].DataX;
            }
            return sum / datas.Count;
        }
        /// <summary>
        /// metoda wylicza średnią ważoną
        /// </summary>
        /// <param name="datas"></param>
        /// <returns>średnia ważona</returns>
        public double AverangeW(List<Data> datas)
        {
            double sum = 0;
            double f = 0;
            for (int i = 0; i < datas.Count; i++)
            {
                sum += datas[i].Numer * datas[i].DataX;
                f += datas[i].Numer;
            }
            return sum / f;
        }



    }
}
