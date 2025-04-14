// bài 2
using System;
using System.Collections.Generic;

// Lop co so Hinh (lop truu tuong)
abstract class Hinh
{
    // Phuong thuc ao tinh chu vi
    public abstract double TinhChuVi();

    // Phuong thuc ao tinh dien tich
    public abstract double TinhDienTich();
}

// Lop HinhTron ke thua tu Hinh
class HinhTron : Hinh
{
    public double BanKinh { get; set; }

    public HinhTron(double banKinh)
    {
        BanKinh = banKinh;
    }

    public override double TinhChuVi()
    {
        return 2 * Math.PI * BanKinh;
    }

    public override double TinhDienTich()
    {
        return Math.PI * BanKinh * BanKinh;
    }
}

// Lop HinhVuong ke thua tu Hinh
class HinhVuong : Hinh
{
    public double Canh { get; set; }

    public HinhVuong(double canh)
    {
        Canh = canh;
    }

    public override double TinhChuVi()
    {
        return 4 * Canh;
    }

    public override double TinhDienTich()
    {
        return Canh * Canh;
    }
}

// Lop HinhChuNhat ke thua tu Hinh
class HinhChuNhat : Hinh
{
    public double ChieuDai { get; set; }
    public double ChieuRong { get; set; }

    public HinhChuNhat(double chieuDai, double chieuRong)
    {
        ChieuDai = chieuDai;
        ChieuRong = chieuRong;
    }

    public override double TinhChuVi()
    {
        return 2 * (ChieuDai + ChieuRong);
    }

    public override double TinhDienTich()
    {
        return ChieuDai * ChieuRong;
    }
}

// Lop HinhTamGiac ke thua tu Hinh
class HinhTamGiac : Hinh
{
    public double CanhA { get; set; }
    public double CanhB { get; set; }
    public double CanhC { get; set; }

    public HinhTamGiac(double a, double b, double c)
    {
        CanhA = a;
        CanhB = b;
        CanhC = c;
    }

    public override double TinhChuVi()
    {
        return CanhA + CanhB + CanhC;
    }

    public override double TinhDienTich()
    {
        double p = TinhChuVi() / 2;
        return Math.Sqrt(p * (p - CanhA) * (p - CanhB) * (p - CanhC));
    }
}

class Program
{
    static void Main()
    {
        List<Hinh> danhSachHinh = new List<Hinh>();
        int luaChon;

        do
        {
            // Menu lua chon
            Console.WriteLine("----- MENU -----");
            Console.WriteLine("1. Them hinh tron");
            Console.WriteLine("2. Them hinh vuong");
            Console.WriteLine("3. Them hinh chu nhat");
            Console.WriteLine("4. Them hinh tam giac");
            Console.WriteLine("0. Ket thuc va tinh tong");
            Console.Write("Nhap lua chon cua ban: ");
            luaChon = int.Parse(Console.ReadLine());

            switch (luaChon)
            {
                case 1:
                    // Nhap hinh tron
                    Console.Write("Nhap ban kinh hinh tron: ");
                    double r = double.Parse(Console.ReadLine());
                    danhSachHinh.Add(new HinhTron(r));
                    break;

                case 2:
                    // Nhap hinh vuong
                    Console.Write("Nhap do dai canh hinh vuong: ");
                    double canh = double.Parse(Console.ReadLine());
                    danhSachHinh.Add(new HinhVuong(canh));
                    break;

                case 3:
                    // Nhap hinh chu nhat
                    Console.Write("Nhap chieu dai hinh chu nhat: ");
                    double dai = double.Parse(Console.ReadLine());
                    Console.Write("Nhap chieu rong hinh chu nhat: ");
                    double rong = double.Parse(Console.ReadLine());
                    danhSachHinh.Add(new HinhChuNhat(dai, rong));
                    break;

                case 4:
                    // Nhap hinh tam giac
                    Console.Write("Nhap canh A tam giac: ");
                    double a = double.Parse(Console.ReadLine());
                    Console.Write("Nhap canh B tam giac: ");
                    double b = double.Parse(Console.ReadLine());
                    Console.Write("Nhap canh C tam giac: ");
                    double c = double.Parse(Console.ReadLine());
                    // Kiem tra tam giac hop le
                    if (a + b > c && a + c > b && b + c > a)
                    {
                        danhSachHinh.Add(new HinhTamGiac(a, b, c));
                    }
                    else
                    {
                        Console.WriteLine("Ba canh khong tao thanh tam giac hop le!");
                    }
                    break;

                case 0:
                    // Thoat
                    Console.WriteLine("Dang tinh tong chu vi va tong dien tich...");
                    break;

                default:
                    Console.WriteLine("Lua chon khong hop le. Vui long nhap lai!");
                    break;
            }

            Console.WriteLine();

        } while (luaChon != 0);

        double tongChuVi = 0;
        double tongDienTich = 0;

        // Tinh tong chu vi va dien tich
        foreach (Hinh hinh in danhSachHinh)
        {
            tongChuVi += hinh.TinhChuVi();
            tongDienTich += hinh.TinhDienTich();
        }

        // In ket qua
        Console.WriteLine($"Tong chu vi cac hinh la: {tongChuVi:F2}");
        Console.WriteLine($"Tong dien tich cac hinh la: {tongDienTich:F2}");
    }
}
