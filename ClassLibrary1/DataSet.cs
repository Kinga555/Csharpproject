using System.Collections.Generic;
using System.Data;

namespace ClassLibrary1
{
    public class DataSet
    {
        protected List<Data> datas;
        public List<Data> GetDataList => datas;
        private double[] tabNumer { get; set; }
        private double[] tabStartRange { get; set; }
        private double[] tabEndOfRange { get; set; }

        public DataSet(double[] num, double[] start)
        {
            datas = new List<Data>();
            tabNumer = num;
            tabStartRange = start;
            SetUpSimpleDataList();
        }
        public DataSet(double[] num, double[] start, double[] end)
        {
            datas = new List<Data>();
            tabNumer = num;
            tabStartRange = start;
            tabEndOfRange = end;
            SetUpRangeDataList();
        }

        public void SetUpSimpleDataList()
        {
            for (int i = 0; i < tabNumer.Length; i++)
            {
                Data data = new Data(tabNumer[i], tabStartRange[i]);
                datas.Add(data);
            }

        }
        public void SetUpRangeDataList()
        {
            for (int i = 0; i < tabNumer.Length; i++)
            {
                Data data = new Data(tabNumer[i], (tabStartRange[i] - tabEndOfRange[i]) / 2);
                datas.Add(data);
            }
        }


    }
}