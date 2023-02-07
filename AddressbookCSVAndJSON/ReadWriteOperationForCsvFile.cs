using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressbookCSVAndJSON
{
    public class ReadWriteOperationForCsvFile
    {
        public void ReadWriteOperation()
        {
            string csvFilepath = @"C:\Users\HP\source\RFP_244\CSVAndJSONProgram\AddressbookCSVAndJSON\Addresses.csv";
            string writerCsvFilePath = @"C:\Users\HP\source\RFP_244\CSVAndJSONProgram\AddressbookCSVAndJSON\writeData.csv";
            string writerJsonFilePath = @"C:\Users\HP\source\RFP_244\CSVAndJSONProgram\AddressbookCSVAndJSON\addressData.json";

            //read operation
            using (var reader = new StreamReader(csvFilepath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Addresses>().ToList();

                foreach (var data in records)
                {
                    Console.Write(data.firstName);
                    Console.Write("," + data.lastName);
                    Console.Write("," + data.City);
                    Console.Write("," + data.State);
                    Console.Write("," + data.email);
                    Console.Write("," + data.phoneNo);
                    Console.Write("," + data.Address);
                    Console.WriteLine();
                }

                Console.WriteLine("Write records to Csv file");

                //write operation
                using (var writer = new StreamWriter(writerCsvFilePath))
                using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecords(records);
                }


                JsonSerializer serializer = new JsonSerializer();
                using (var writer = new StreamWriter(writerJsonFilePath))
                using (var jsonWriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(jsonWriter, records);
                }

                Console.ReadKey();

            }
        
        }
    }
}
