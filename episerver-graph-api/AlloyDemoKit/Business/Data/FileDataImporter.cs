﻿using System.IO;

namespace EpiServer.AlloyDemo.GraphAPI.Business.Data
{
    public class FileDataImporter : IFileDataImporter
    {
        public string[] RetrieveAllData(string fullFileName)
        {
            return File.ReadAllLines(fullFileName, System.Text.Encoding.Default);
        }


        public bool ImportFileExists(string fullFileName)
        {
            return File.Exists(fullFileName);
        }


        public string[] SplitByDelimiter(string row, char[] delimiter)
        {
            return row.Split(delimiter);
        }
    }
}