using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using ConsoleTables;
using FileReader.Models;

namespace FileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = ConfigurationManager.AppSettings["Path"];
            var fileName = Path.GetFileName(filePath);
            Console.WriteLine("CSV File Reader");
            Console.WriteLine("The value below are either 80% lower than median value or 120% larger than median value.");
            var table = new ConsoleTable("File Name", "Datetime", "Value", "Median Value");
            if (fileName.ToLower().StartsWith("lp"))
            {
                var lpFile = new LPFile();
                lpFile.ReadDataFromCsvFile(filePath);
                lpFile.DataValueList.RemoveAt(0);
                lpFile.DateTimeList.RemoveAt(0);
                List<double> result = lpFile.DataValueList.Select(x => double.Parse(x)).ToList();
                var median = lpFile.CalculateMedian(result);

                for (int i = 0; i < result.Count(); i++)
                {
                    if (result[i] < median * 0.8 || result[i] > median * 1.2)
                    {
                        table.AddRow(fileName, lpFile.DateTimeList[i], result[i], median);
                    }
                }
            }
            else if (fileName.ToLower().StartsWith("tou"))
            {
                var touFile = new TOUFile();
                touFile.ReadDataFromCsvFile(filePath);
                touFile.EnergyList.RemoveAt(0);
                touFile.DateTimeList.RemoveAt(0);
                List<double> result = touFile.EnergyList.Select(x => double.Parse(x)).ToList();
                var median = touFile.CalculateMedian(result);
                for (int i = 0; i < result.Count(); i++)
                {
                    if (result[i] < median * 0.8 || result[i] > median * 1.2)
                    {
                        table.AddRow(fileName, touFile.DateTimeList[i], result[i], median);
                    }
                }
            }
            table.Write();
            Console.WriteLine("Finish the program by pressing Enter Key");
            Console.ReadLine();
        }
    }
}
