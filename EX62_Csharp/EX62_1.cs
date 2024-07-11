using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

//Cách 1: Sử dụng File.ReadAllText
class EX62_1
{
    public static Dictionary<string, object> ReadJsonFileToDictionary(string fileName)
    {
        try
        {
            // Đọc toàn bộ nội dung của tệp JSON vào một chuỗi
            string jsonString = File.ReadAllText(fileName);

            // Phân tích chuỗi JSON thành đối tượng Dictionary
            Dictionary<string, object> dictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonString);
            return dictionary;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading JSON file: " + ex.Message);
            return null;
        }
    }

    static void Main(string[] args)
    {
        string fileName = "data.json"; // Thay thế bằng tên tệp JSON mới
        Dictionary<string, object> result = ReadJsonFileToDictionary(fileName);
        
        if (result != null)
        {
            foreach (var item in result)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }
        }
    }
}
