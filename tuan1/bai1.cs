// bài 1
using System;
using System.Collections.Generic;

// Lớp PhanSo để biểu diễn phân số
class PhanSo
{
    public int TuSo { get; set; }  // Thuộc tính tử số
    public int MauSo { get; set; } // Thuộc tính mẫu số

    // Constructor mặc định
    public PhanSo()
    {
        TuSo = 0;
        MauSo = 1;
    }

    // Constructor có tham số
    public PhanSo(int tuSo, int mauSo)
    {
        TuSo = tuSo;
        MauSo = mauSo != 0 ? mauSo : 1; // Nếu mẫu bằng 0 thì gán mẫu = 1
    }

    // Phương thức nhập phân số từ bàn phím
    public void Nhap()
    {
        Console.Write("Nhap tu so: ");
        TuSo = int.Parse(Console.ReadLine());
        Console.Write("Nhap mau so (khac 0): ");
        MauSo = int.Parse(Console.ReadLine());
        if (MauSo == 0)
        {
            Console.WriteLine("Mau so phai khac 0. Đat mau so = 1.");
            MauSo = 1;
        }
    }

    // Phương thức cộng hai phân số
    public static PhanSo Cong(PhanSo a, PhanSo b)
    {
        int tu = a.TuSo * b.MauSo + b.TuSo * a.MauSo; // Quy đồng mẫu rồi cộng tử
        int mau = a.MauSo * b.MauSo; // Mẫu chung
        return RutGon(new PhanSo(tu, mau)); // Trả về kết quả sau khi rút gọn
    }

    // Phương thức rút gọn phân số
    public static PhanSo RutGon(PhanSo ps)
    {
        int ucln = UCLN(Math.Abs(ps.TuSo), Math.Abs(ps.MauSo)); // Tìm ước chung lớn nhất
        ps.TuSo /= ucln;
        ps.MauSo /= ucln;

        // Nếu mẫu âm thì đổi dấu cả tử và mẫu
        if (ps.MauSo < 0)
        {
            ps.TuSo = -ps.TuSo;
            ps.MauSo = -ps.MauSo;
        }

        return ps;
    }

    // Phương thức tìm ước chung lớn nhất (dùng thuật toán Euclid)
    private static int UCLN(int a, int b)
    {
        while (b != 0)
        {
            int temp = a % b;
            a = b;
            b = temp;
        }
        return a;
    }

    // Ghi đè phương thức ToString() để in phân số dưới dạng "tử/mẫu"
    public override string ToString()
    {
        return $"{TuSo}/{MauSo}";
    }
}

class Program
{
    static void Main()
    {
        // Tạo danh sách chứa các phân số
        List<PhanSo> danhSachPhanSo = new List<PhanSo>();

        Console.Write("Nhap so luong phan so: ");
        int n = int.Parse(Console.ReadLine()); // Nhập số lượng phân số

        // Vòng lặp nhập từng phân số
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Nhap phan so thu: {i + 1}:");
            PhanSo ps = new PhanSo();
            ps.Nhap(); // Gọi hàm nhập
            danhSachPhanSo.Add(ps); // Thêm phân số vào danh sách
        }

        // Khởi tạo tổng ban đầu bằng 0/1
        PhanSo tong = new PhanSo(0, 1);

        // Duyệt danh sách và cộng dồn các phân số
        foreach (PhanSo ps in danhSachPhanSo)
        {
            tong = PhanSo.Cong(tong, ps);
        }

        // In tổng các phân số ra màn hình
        Console.WriteLine($"Tong cac phan so la: {tong}");
    }
}
