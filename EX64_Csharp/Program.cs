using System;
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

        // Tạo mảng 2 chiều các số thực 4 byte
        float[,] array2D = {
            { 1.1f, 2.2f, 3.3f },
            { 4.4f, 5.5f, 6.6f },
            { 7.7f, 8.8f, 9.9f }
        };

        // Gọi hàm để ghi mảng ra file CSV
        WriteArrayToCsv("output.csv", array2D);

        Console.WriteLine("Đã ghi mảng 2 chiều ra file CSV.");
    }

    // Hàm ghi mảng 2 chiều ra file CSV
    public static void WriteArrayToCsv(string fileName, float[,] array)
    {
        using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                string[] row = new string[cols];
                for (int j = 0; j < cols; j++)
                {
                    row[j] = array[i, j].ToString(CultureInfo.InvariantCulture);
                }
                writer.WriteLine(string.Join(",", row));
            }
        }
    }
}
