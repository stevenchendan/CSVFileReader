using System;
using System.Collections.Generic;
using System.Text;

namespace FileReader.Models
{
    interface IFileOperation
    {
        bool ReadDataFromCsvFile(string filePath);
    }
}
