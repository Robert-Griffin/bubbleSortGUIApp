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
    public class CSVReaderModel
    {
        public List<List<string>> ReadCSV(string path)
        {
            Tuple<StreamReader, CsvReader> readers = BuildCsvReader(path);
            var streamReader = readers.Item1;
            var csvReader = readers.Item2;

            List<List<string>> csv = new List<List<string>>();

            while (csvReader.Read())
            {
                List<string> row = new List<string>();
                string value;
                for (int i = 0; csvReader.TryGetField<string>(i, out value); i++)
                {
                    row.Add(value);
                }
                csv.Add(row);

            }
            csvReader.Dispose();
            streamReader.Close();
            return csv;


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
    }
}
