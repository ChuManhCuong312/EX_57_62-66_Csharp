using System;
using System.Globalization;

class Program
{
    // Hàm tính diện tích hình tròn
    public static double TinhDienTich(double r)
    {
        return Math.PI * r * r;
    }

    // Hàm tính chu vi hình tròn
    public static double TinhChuVi(double r)
    {
        return 2 * Math.PI * r;
    }

    // Hàm tính đường kính hình tròn
    public static double TinhDuongKinh(double r)
    {
        return 2 * r;
    }

    // Hàm trả về chuỗi JSON chứa diện tích, chu vi và đường kính của hình tròn
    public static string GetCircleInfo(double r)
    {
        double dienTich = TinhDienTich(r);
        double chuVi = TinhChuVi(r);
        double duongKinh = TinhDuongKinh(r);

        string json = $"{{ \"Diện tích\": {dienTich}, \"Chu vi\": {chuVi}, \"Đường kính\": {duongKinh} }}";
        return json;
    }

    static void Main(string[] args)
    {
        // Đặt văn hóa hiện tại của luồng chính thành "en-US"
        CultureInfo.CurrentCulture = new CultureInfo("en-US");

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        double r;
        while (true)
        {
            Console.Write("Nhập bán kính của hình tròn: ");
            if (double.TryParse(Console.ReadLine(), out r) && r > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Bán kính không hợp lệ. Vui lòng nhập lại.");
            }
        }

        // Gọi hàm để lấy thông tin về hình tròn
        string circleInfoJson = GetCircleInfo(r);
        Console.WriteLine("Thông tin về hình tròn:");
        Console.WriteLine(circleInfoJson);
    }
}
