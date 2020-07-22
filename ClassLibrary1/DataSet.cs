using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class DataSet
    {
        public List<Data> DataSetList { get; private set; }
        private double[] tabNumer { get; set; }
        private double[] tabStartRange { get; set; }
        private double[] tabEndOfRange { get; set; }

        public DataSet()
        {
            DataSetList = new List<Data>();
            SetUpSimpleDataList();
        }
        public void SetUpSimpleDataList()
        {
            for (int i = 0; i < tabNumer.Length; i++)
            {
                Data data = new Data(tabNumer[i], tabStartRange[i]);
                DataSetList.Add(data);
            }

        }
        public void SetUpRangeDataList()
        {
            for (int i = 0; i < tabNumer.Length; i++)
            {
                Data data = new Data(tabNumer[i], tabStartRange[i] - tabEndOfRange[i]);
            }
        }

    }
}
