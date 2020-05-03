using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace WpfApp1.View.FileExtension
{
    public static class FileExtensions
    {
        public static List<Employee> GetFromFile(string path)
        {
            try
            {
                using var reader = new StreamReader(path);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                csv.Configuration.Delimiter = ";";
                csv.Configuration.RegisterClassMap<CollectionMap>();
                return csv.GetRecords<Employee>().ToList();
            }
            catch (FileNotFoundException massage)
            {
                Console.WriteLine(massage.Message);
                return null;
            }
        }

        public static void SaveToFile(string path, ObservableCollection<Employee> employee)
        {
            using StreamWriter streamReader = new StreamWriter(path);
            using CsvWriter csvReader = new CsvWriter(streamReader, CultureInfo.InvariantCulture);
            csvReader.Configuration.Delimiter = ";";
            csvReader.Configuration.RegisterClassMap<CollectionMap>();
            csvReader.WriteRecords(employee);
        }
    }
}
