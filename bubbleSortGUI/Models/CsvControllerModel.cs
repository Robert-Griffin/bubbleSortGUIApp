using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace bubbleSortGUI.Models
{
    public class CsvControllerModel
    {
        public List<string> ReadCSV(string path)
        {
            Tuple<StreamReader, CsvReader> readers = BuildCsvReader(path);
            var streamReader = readers.Item1;
            var csvReader = readers.Item2;
            List<string> csv = new List<string>();

            while (csvReader.Read())
            {
                string value;
                for (int i = 0; csvReader.TryGetField<string>(i, out value); i++)
                {
                    csv.Add(value);
                }
            }

            csvReader.Dispose();
            streamReader.Close();
            return csv;
        }

        public void WriteCsv(List<string> items, string path)
        {
            Tuple<StreamWriter, CsvWriter> writers = BuildCsvWriter(path);
            using (var streamWriter = writers.Item1)
            {
                using (var csvWriter = writers.Item2)
                {
                    foreach (string item in items)
                    {
                        csvWriter.WriteField(item);
                    }
                }
            }
        }

        private Tuple <StreamReader, CsvReader> BuildCsvReader(string path)
        {
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = false,
                Comment = '#',
                AllowComments = true,
                Delimiter = ",",
            };

            var streamReader = File.OpenText(path);
            var csvReader = new CsvReader(streamReader, csvConfig);

            return Tuple.Create(streamReader, csvReader);
        }

        private Tuple<StreamWriter, CsvWriter> BuildCsvWriter(string path)
        {
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = false,
                Comment = '#',
                AllowComments = true,
                Delimiter = ",",
            };

            var streamWriter = File.CreateText(path);
            var csvWriter = new CsvWriter(streamWriter, csvConfig);

            return Tuple.Create(streamWriter, csvWriter);
        }s
    }
}
