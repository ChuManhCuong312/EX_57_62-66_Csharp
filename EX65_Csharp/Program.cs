using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Globalization;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // Đặt văn hóa hiện tại của luồng chính thành "en-US"
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

        // Thiết lập encoding cho đầu vào và đầu ra
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        // Tạo Dictionary với khóa là string và giá trị là double
        Dictionary<string, double> dict = new Dictionary<string, double>
        {
            { "Item1", 1.23 },
            { "Item2", 4.56 },
            { "Item3", 7.89 },
            { "Item4", 0.12 }
        };

        // Gọi hàm để ghi Dictionary ra file CSV
        WriteDictionaryToCsv("output.csv", dict);

        Console.WriteLine("Đã ghi Dictionary ra file CSV.");
    }

    // Hàm ghi Dictionary ra file CSV
    public static void WriteDictionaryToCsv(string fileName, Dictionary<string, double> dict)
    {
        using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
        {
            // Ghi header
            writer.WriteLine("Key,Value");

            // Ghi từng cặp khóa-giá trị ra file CSV
            foreach (var kvp in dict)
            {
                writer.WriteLine($"{kvp.Key},{kvp.Value.ToString(CultureInfo.InvariantCulture)}");
            }
        }
    }
}
