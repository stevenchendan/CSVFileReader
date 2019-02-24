using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileReader.Models
{
    class LPFile : CSVFile, IFileOperation
    {
        public List<string> MeterPointCodeList { get; set; }
        public List<string> SerialNumberList { get; set; }
        public List<string> PlantCodeList { get; set; }
        public List<string> DateTimeList { get; set; }
        public List<string> DataTypeList { get; set; }
        public List<string> DataValueList { get; set; }
        public List<string> UnitsList { get; set; }
        public List<string> StatusList { get; set; }


        public bool ReadDataFromCsvFile(string filePath)
        {
            var meterPointCode = new List<string>();
            var serialNumber = new List<string>();
            var plantCode = new List<string>();
            var dateTime = new List<string>();
            var dataType = new List<string>();
            var dataValue = new List<string>();
            var units = new List<string>();
            var status = new List<string>();

            if (String.IsNullOrEmpty(filePath))
            {
                return false;
            }
            using (var reader = new StreamReader($@"{filePath}"))
            {
                while (!reader.EndOfStream)
                {
                    var splits = reader.ReadLine().Split(',');

                    meterPointCode.Add(splits[0]);
                    serialNumber.Add(splits[1]);
                    plantCode.Add(splits[2]);
                    dateTime.Add(splits[3]);
                    dataType.Add(splits[4]);
                    dataValue.Add(splits[5]);
                    units.Add(splits[6]);
                    status.Add(splits[7]);
                }

                MeterPointCodeList = meterPointCode;
                SerialNumberList = serialNumber;
                PlantCodeList = plantCode;
                DateTimeList = dateTime;
                DataTypeList = dataType;
                DataValueList = dataValue;
                UnitsList = units;
                StatusList = status;
            }
            return true;
        }
    }
}
