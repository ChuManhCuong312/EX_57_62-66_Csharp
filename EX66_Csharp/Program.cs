using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        // Đọc file CSV và lưu vào mảng 2 chiều
        float[,] resultArray = ReadCsvTo2DArray("input.csv");

        // In kết quả
        Print2DArray(resultArray);
    }

    public static float[,] ReadCsvTo2DArray(string fileName)
    {
        List<List<float>> rows = new List<List<float>>();

        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            bool isFirstLine = true;

            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] values = line.Split(',');

                // Kiểm tra header
                if (isFirstLine)
                {
                    isFirstLine = false;
                    if (IsNumeric(values[0])) // Nếu dòng đầu tiên có thể chuyển đổi sang số thực, có thể là dòng dữ liệu
                    {
                        rows.Add(ParseRow(values));
                    }
                    continue;
                }

                rows.Add(ParseRow(values));
            }
        }

        // Chuyển danh sách List<List<float>> thành mảng 2 chiều float[,]
        int rowCount = rows.Count;
        int colCount = rows[0].Count;
        float[,] resultArray = new float[rowCount, colCount];

        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < colCount; j++)
            {
                resultArray[i, j] = rows[i][j];
            }
        }

        return resultArray;
    }

    // Hàm phân tích một dòng dữ liệu từ file CSV thành danh sách các số thực
    private static List<float> ParseRow(string[] values)
    {
        List<float> row = new List<float>();
        foreach (var value in values)
        {
            if (float.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out float result))
            {
                row.Add(result);
            }
        }
        return row;
    }

    // Hàm kiểm tra xem chuỗi có phải là số không
    private static bool IsNumeric(string value)
    {
        return float.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out float result);
    }

    // Hàm in mảng 2 chiều
    private static void Print2DArray(float[,] array)
    {
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);

        Console.WriteLine("Mảng 2 chiều đọc từ file CSV:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
