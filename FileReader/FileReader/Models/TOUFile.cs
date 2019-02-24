using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileReader.Models
{
    class TOUFile : File
    {
        public List<string> MeterPointCodeList { get; set; }
        public List<string> SerialNumberList { get; set; }
        public List<string> PlantCodeList { get; set; }
        public List<string> DateTimeList { get; set; }
        public List<string> DataTypeList { get; set; }
        public List<string> EnergyList { get; set; }
        public List<string> MaximumDemandList { get; set; }
        public List<string> TimeofMaxDemandList { get; set; }
        public List<string> UnitsList { get; set; }
        public List<string> StatusList { get; set; }
        public List<string> PeriodList { get; set; }
        public List<string> DlsActiveList { get; set; }
        public List<string> BillingResetCountList { get; set; }
        public List<string> BillingResetDateTimeList { get; set; }
        public List<string> RateList { get; set; }

        public bool ReadDataFromCsvFile(string filePath)
        {
            var meterPointCode = new List<string>();
            var serialNumber = new List<string>();
            var plantCode = new List<string>();
            var dateTime = new List<string>();
            var dataType = new List<string>();
            var energy = new List<string>();
            var maximumDemand = new List<string>();
            var timeofMaxDemand = new List<string>();
            var units = new List<string>();
            var status = new List<string>();
            var period = new List<string>();
            var dlsActive = new List<string>();
            var billingResetCount = new List<string>();
            var billingResetDateTime = new List<string>();
            var rate = new List<string>();

            if (String.IsNullOrEmpty(filePath))
            {
                return false;
            }
            using (var reader = new StreamReader($@"{filePath}"))
            {
                while (!reader.EndOfStream)
                {
                    var splits = reader.ReadLine()?.Split(',');
                    if (splits != null && splits.Length != 0)
                    {
                        meterPointCode.Add(splits[0]);
                        serialNumber.Add(splits[1]);
                        plantCode.Add(splits[2]);
                        dateTime.Add(splits[3]);
                        dataType.Add(splits[4]);
                        energy.Add(splits[5]);
                        maximumDemand.Add(splits[6]);
                        timeofMaxDemand.Add(splits[7]);
                        units.Add(splits[8]);
                        status.Add(splits[9]);
                        period.Add(splits[10]);
                        dlsActive.Add(splits[11]);
                        billingResetCount.Add(splits[12]);
                        billingResetDateTime.Add(splits[13]);
                        rate.Add(splits[14]);
                    }
                }
                MeterPointCodeList = meterPointCode;
                SerialNumberList = serialNumber;
                PlantCodeList = plantCode;
                DateTimeList = dateTime;
                DataTypeList = dataType;
                EnergyList = energy;
                MaximumDemandList = maximumDemand;
                TimeofMaxDemandList = timeofMaxDemand;
                UnitsList = units;
                StatusList = status;
                PeriodList = period;
                DlsActiveList = dlsActive;
                BillingResetCountList = billingResetCount;
                BillingResetDateTimeList = billingResetDateTime;
                RateList = rate;
            }
            return true;
        }
    }
}
