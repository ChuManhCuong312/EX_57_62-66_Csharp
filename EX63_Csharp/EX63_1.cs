using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

//Cách 1: Sử dụng File.WriteAllText
class Program
{
    // Hàm static ghi Dictionary ra tệp JSON
    public static bool WriteDictionaryToJsonFile(string fileName, Dictionary<string, object> dictionary)
    {
        try
        {
            // Chuyển đổi Dictionary thành chuỗi JSON
            string jsonString = JsonSerializer.Serialize(dictionary);

            // Ghi chuỗi JSON vào tệp
            File.WriteAllText(fileName, jsonString);

            return true; // Ghi thành công
        }
        catch (Exception ex)
        {
            Console.WriteLine("Lỗi khi ghi tệp JSON: " + ex.Message);
            return false; // Ghi thất bại
        }
    }

    static void Main(string[] args)
    {
        Dictionary<string, object> myDictionary = new Dictionary<string, object>
        {
            { "Name", "John" },
            { "Age", 30 },
            { "Country", "USA" }
        };

        string fileName = "output1.json";
        bool result = WriteDictionaryToJsonFile(fileName, myDictionary);

        if (result)
        {
            Console.WriteLine("Ghi tệp JSON thành công.");
        }
        else
        {
            Console.WriteLine("Ghi tệp JSON thất bại.");
        }
    }
}
