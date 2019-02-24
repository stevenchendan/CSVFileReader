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
            DirectoryInfo di = new DirectoryInfo(ConfigurationManager.AppSettings["FolderPath"]);
            FileInfo[] files = di.GetFiles("*.csv");

            Console.WriteLine("CSV File Reader");
            Console.WriteLine("The value below are either 80% lower than median value or 120% larger than median value.");
            var table = new ConsoleTable("File Name", "Datetime", "Value", "Median Value");
            for (int i = 0; i < files.Length; i++)
            {
                var fileName = Path.GetFileName(files[i].FullName);
                if (fileName.ToLower().StartsWith("lp"))
                {
                    var lpFile = new LPFile();
                    lpFile.ReadDataFromCsvFile(files[i].FullName);
                    lpFile.DataValueList.RemoveAt(0);
                    lpFile.DateTimeList.RemoveAt(0);
                    List<double> result = lpFile.DataValueList.Select(x => double.Parse(x)).ToList();
                    var median = lpFile.CalculateMedian(result);

                    for (int j = 0; j < result.Count(); j++)
                    {
                        if (result[j] < median * 0.8 || result[j] > median * 1.2)
                        {
                            table.AddRow(fileName, lpFile.DateTimeList[j], result[j], median);
                        }
                    }
                }
                else if (fileName.ToLower().StartsWith("tou"))
                {
                    var touFile = new TOUFile();
                    touFile.ReadDataFromCsvFile(files[i].FullName);
                    touFile.EnergyList.RemoveAt(0);
                    touFile.DateTimeList.RemoveAt(0);
                    List<double> result = touFile.EnergyList.Select(x => double.Parse(x)).ToList();
                    var median = touFile.CalculateMedian(result);
                    for (int j = 0; j < result.Count(); j++)
                    {
                        if (result[j] < median * 0.8 || result[j] > median * 1.2)
                        {
                            table.AddRow(fileName, touFile.DateTimeList[j], result[j], median);
                        }
                    }
                }
            }
            table.Write();
            Console.WriteLine("Finish the program by pressing Enter Key");
            Console.ReadLine();
        }
    }
}
