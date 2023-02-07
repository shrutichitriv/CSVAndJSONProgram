using AddressbookCSVAndJSON;

namespace AddressbookCsvAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Addressbook CSV And Json");

            ReadWriteOperationForCsvFile csvOperation = new ReadWriteOperationForCsvFile();
            csvOperation.ReadWriteOperation();

        }
    }
}

