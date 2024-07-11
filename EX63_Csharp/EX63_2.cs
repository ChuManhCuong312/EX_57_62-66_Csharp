using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

//Cách 2: Sử dụng StreamWriter
class EX63_2
{
    // Hàm static ghi Dictionary ra tệp JSON
    public static bool WriteDictionaryToJsonFileAlternative(string fileName, Dictionary<string, object> dictionary)
    {
        try
        {
            // Chuyển đổi Dictionary thành chuỗi JSON
            string jsonString = JsonSerializer.Serialize(dictionary);

            // Sử dụng StreamWriter để ghi chuỗi JSON vào tệp
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.Write(jsonString);
            }

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
            { "Name", "Jane" },
            { "Age", 25 },
            { "Country", "UK" }
        };

        string fileName = "output2.json";
        bool result = WriteDictionaryToJsonFileAlternative(fileName, myDictionary);

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
