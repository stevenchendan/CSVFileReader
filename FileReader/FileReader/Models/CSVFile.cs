using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileReader.Models
{
    public class CSVFile
    {
        public string FileName { get; set; }
        public string DateTime { get; set; }
        public float Value { get; set; }
        public float MedianValue { get; set; }


        public double CalculateMedian(List<double> valueList)
        {
            double result = 0;
            if (valueList != null && !valueList.Any())
            {
                return result;
            }

            valueList.Sort();

            int size = valueList.Count;
            int mid = size / 2;
            if (size % 2 != 0)
            {
                return valueList[mid];
            }
            result = (valueList[mid] + valueList[mid - 1]) * 0.5;
            return result;
        }
    }
}
