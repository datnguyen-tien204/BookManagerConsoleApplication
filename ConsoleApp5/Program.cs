using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Data;

class Sach
{
    public string Masach { get; set; }
    public string TenSach { get; set; }
    public int SoLuong { get; set; }
    public string TacGia { get; set; }
    public string NhaXuatBan { get; set; }
    public string chungloai { get; set; }
    public float GiaBan { get; set; }
}
class QuanLySach
{
    private List<Sach> danhSachSach = new List<Sach>();

    public void ThemSach()
    {
        Console.WriteLine("Nhap thong tin sach moi");

        Sach sach = new Sach();

        Console.Write(">>>Hay nhap so cuon sach can them: ");
        int a=int.Parse(Console.ReadLine());
        for (int i = 0; i < a; i++)
        {
            Console.WriteLine(">>>Hay nhap thong tin cho cuon sach thu {0}",i+1);

            Console.Write(">>>Ma sach: ");
            string maSach = Console.ReadLine();

            // Kiem tra xem ma sach da ton tai hay chua
            while (danhSachSach.Any(sach => sach.Masach == maSach))
            {
                Console.WriteLine($"Ma sach {maSach} da ton tai. Vui long nhap lai.");
                Console.Write("Ma sach: ");
                maSach = Console.ReadLine();
            }

            Console.Write(">>>Ten sach : ");
            sach.TenSach = Console.ReadLine();

            Console.Write(">>>So luong: ");
            sach.SoLuong = int.Parse(Console.ReadLine());

            Console.Write(">>>Tac gia : ");
            sach.TacGia = Console.ReadLine();

            Console.Write(">>>Chung loai: ");
            sach.chungloai = Console.ReadLine();
            

            Console.Write(">>>Nha xuat ban: ");
            sach.NhaXuatBan = Console.ReadLine();

            Console.Write(">>>Gia ban: ");
            sach.GiaBan = float.Parse(Console.ReadLine());

            danhSachSach.Add(sach);

            Console.WriteLine("Sach moi thu {0} da duoc them vao danh sach.",i+1);
        }
    }

    public void SuaSach()
    {
        Console.Write("Nhap ten sach can sua: ");
        string tenSach = Console.ReadLine();

        Sach sach = danhSachSach.Find(s => s.TenSach.Equals(tenSach, StringComparison.OrdinalIgnoreCase));

        if (sach != null)
        {
            Console.WriteLine("Thong tin sach can sua:");
            Console.WriteLine($"Ma sach: {sach.Masach}");
            Console.WriteLine($"Ten sach: {sach.TenSach}");
            Console.WriteLine($"So luong sach: {sach.SoLuong}");
            Console.WriteLine($"Tac gia: {sach.TacGia}");
            Console.WriteLine($"Nha xuat ban: {sach.NhaXuatBan}");
            Console.WriteLine($"Gia ban: {sach.GiaBan}");
            Console.WriteLine($"Chung loai: {sach.chungloai}");

            Console.WriteLine("Nhap thong tin sach moi:");

            Console.Write("Ma sach: ");
            sach.Masach = Console.ReadLine();

            Console.Write("Ten sach: ");
            sach.TenSach = Console.ReadLine();

            Console.Write("So luong: ");
            sach.SoLuong= int.Parse(Console.ReadLine());

            Console.Write("Tac gia: ");
            sach.TacGia = Console.ReadLine();

            Console.Write("Nha xuat ban: ");
            sach.NhaXuatBan = Console.ReadLine();

            Console.Write("Gia ban: ");
            sach.GiaBan = float.Parse(Console.ReadLine());

            Console.Write("Chung loai: ");
            sach.chungloai = Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Khong tim thay sach can sua.");
        }
    }
    public void XoaSach()
    {
        Console.Write("Nhap ten sach can xoa: ");
        string tenSach = Console.ReadLine();

        Sach sach = danhSachSach.Find(s => s.TenSach.Equals(tenSach, StringComparison.OrdinalIgnoreCase));

        if (sach != null)
        {
            danhSachSach.Remove(sach);

            Console.WriteLine($"Sach {tenSach} da bi xoa khoi danh sach.");
        }
        else
        {
            Console.WriteLine($"Khong tim thay sach {tenSach} trong danh sach.");
        }
    }

    public void HienThiDanhSachSach()
    {
        Console.WriteLine("Danh sach cac sach:");

        foreach (Sach sach in danhSachSach)
        {
            Console.WriteLine($"Ma sach: {sach.Masach}");
            Console.WriteLine($"Ten sach: {sach.TenSach}");
            Console.WriteLine($"So luong sach: {sach.SoLuong}");
            Console.WriteLine($"Tac gia: {sach.TacGia}");
            Console.WriteLine($"Nha xuat ban: {sach.NhaXuatBan}");
            Console.WriteLine($"Gia ban: {sach.GiaBan}");
            Console.WriteLine();
        }
    }
    public void TimSachTheoTen()
    {
        Console.Write("Nhap ten sach can tim: ");
        string tenSach = Console.ReadLine();

        List<Sach> ketQuaTimKiem = danhSachSach.FindAll(s => s.TenSach.Equals(tenSach, StringComparison.OrdinalIgnoreCase));

        if (ketQuaTimKiem.Count > 0)
        {
            Console.WriteLine("Ket qua tim kiem:");
            foreach (Sach sach in ketQuaTimKiem)
            {
                Console.WriteLine($"-Ten sach: {sach.TenSach},Ma sach: {sach.Masach},So luong: {sach.SoLuong},Tac gia: ({sach.TacGia}), gia: {sach.GiaBan} dong");
            }
        }
        else
        {
            Console.WriteLine($"Khong tim thay sach co ten {tenSach} trong danh sach.");
        }
    }
    public void TimSachTheoChungLoai()
    {
        Console.Write("Nhap chung loai sach can tim: ");
        string chungLoai = Console.ReadLine();

        List<Sach> ketQuaTimKiem = danhSachSach.FindAll(s => s.chungloai.Equals(chungLoai, StringComparison.OrdinalIgnoreCase));

        if (ketQuaTimKiem.Count > 0)
        {
            Console.WriteLine("Ket qua tim kiem:");
            foreach (Sach sach in ketQuaTimKiem)
            {
                Console.WriteLine($"-Ten sach: {sach.TenSach},Ma sach: {sach.Masach},So luong: {sach.SoLuong},Tac gia: ({sach.TacGia}), gia: {sach.GiaBan} dong");
            }
        }
        else
        {
            Console.WriteLine($"Khong tim thay sach co chung loai {chungLoai} trong danh sach.");
        }
    }
    public void GhiDanhSachSachVaoTep()
    {
        Console.Write("Nhap ten tap tin de ghi danh sach sach: ");
        string tenTep1 = Console.ReadLine();
        string tenTep2 = tenTep1+".txt";

        try
        {
            using (StreamWriter writer = new StreamWriter(tenTep2))
            {
                foreach (Sach sach in danhSachSach)
                {
                    writer.WriteLine($"-Ten sach: {sach.TenSach},\tMa sach: {sach.Masach},\tSo luong: {sach.SoLuong},\tTac gia: {sach.TacGia}, \tgia: {sach.GiaBan} dong");
                }
            }

            Console.WriteLine($"Da ghi danh sach sach vao tep {tenTep2} thanh cong.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Loi khi ghi danh sach sach vao tep: {ex.Message}");
        }
    }
    public void TimSachTheoMa()
    {
        Console.Write("Nhap ma sach can tim: ");
        string MaSach = Console.ReadLine();

        Sach sachTimThay = danhSachSach.Find(sach => sach.Masach == MaSach);

        if (sachTimThay == null)
        {
            Console.WriteLine($"Khong tim thay sach voi ma {MaSach}.");
        }
        else
        {
            Console.WriteLine("Thong tin sach tim thay:");
            Console.WriteLine(sachTimThay);
        }
    }
    public void DongBoDuLieu()
    {
        string strCon = @"Data Source=NGUYENTIENDAT\MSSQLSERVER01;Initial Catalog=QLSach;Integrated Security=True";

        using (SqlConnection connection = new SqlConnection(strCon))
        {
            try
            {
                //Mở kết nối thành công
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open(); //Đóng thì mở
                    Console.WriteLine("Mo ket noi den SQL Server thanh cong");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //connection.Open();

            SqlCommand command = new SqlCommand("TRUNCATE TABLE Sach", connection);
            command.ExecuteNonQuery();
            //SqlCommand command = new SqlCommand();
            //Thiết lập các thuộc tính cho đối tượng Command
            //command.Connection = connection;
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "QLSach";
            foreach (Sach sach in danhSachSach)
            {
                command = new SqlCommand("INSERT INTO Sach VALUES (@MaSach, @TenSach,@Soluong, @TacGia, @Nhaxuatban, @ChungLoai, @GiaBan)", connection);
                command.Parameters.AddWithValue("@MaSach", sach.Masach);
                command.Parameters.AddWithValue("@TenSach", sach.TenSach);
                command.Parameters.AddWithValue("@Soluong", sach.SoLuong);
                command.Parameters.AddWithValue("@TacGia", sach.TacGia);
                command.Parameters.AddWithValue("@Nhaxuatban", sach.NhaXuatBan);
                command.Parameters.AddWithValue("@ChungLoai", sach.TenSach);
                command.Parameters.AddWithValue("@GiaBan", sach.GiaBan);
                command.ExecuteNonQuery();
            }

            Console.WriteLine($"Dong bo {danhSachSach.Count} sach thanh cong.");
        }
    }
    public int TinhTongSoLuongSach()
    {
        int tongSoLuong = 0;
        foreach (Sach sach in danhSachSach)
        {
            tongSoLuong += sach.SoLuong;
        }
        return tongSoLuong;
    }

    public double TinhTongGiaTriSach()
    {
        double tongGiaTri = 0;
        foreach (Sach sach in danhSachSach)
        {
            tongGiaTri +=(double)(sach.SoLuong * sach.GiaBan);
        }
        return tongGiaTri;
    }

}
class Program
{
    static QuanLySach quanLySach = new QuanLySach();

    static void Main(string[] args)
    {
        while (true)
        {
            Menu();

            Console.Write("Nhap vao lua chon cua ban: ");
            string luaChon = Console.ReadLine();

            Console.WriteLine();

            switch (luaChon)
            {
                case "1":
                    quanLySach.ThemSach();
                    break;

                case "2":
                    quanLySach.SuaSach();
                    break;

                case "3":
                    quanLySach.XoaSach();
                    break;

                case "4":
                    quanLySach.HienThiDanhSachSach();
                    break;

                case "5":
                    quanLySach.TimSachTheoTen();
                    break;
                case "6":
                    quanLySach.TimSachTheoChungLoai();
                    break;
                case "7":
                    quanLySach.GhiDanhSachSachVaoTep();
                    break;
                case "8":
                    quanLySach.TimSachTheoMa();
                    break;
                case "9":
                    quanLySach.DongBoDuLieu();
                    break;
                case "10":
                    {
                        Console.WriteLine("Tong so luong sach: "+quanLySach.TinhTongSoLuongSach());
                        Console.WriteLine("Tong gia tri sach: "+quanLySach.TinhTongGiaTriSach());
                    }
                    break;
                case "11":
                    Console.WriteLine("Cam on ban da su dung chuong trinh!");
                    return;

                default:
                    Console.WriteLine("Lua chon khong hop le. Vui long thu lai!");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void Menu()
    {
        Console.WriteLine("*\t\t\t===== MENU =====\t\t\t*");
        Console.WriteLine("*\t\t\t\t\t\t\t\t*");
        Console.WriteLine("*\t\t1. Them sach moi\t\t\t\t*");
        Console.WriteLine("*\t\t2. Sua thong tin sach\t\t\t\t*");
        Console.WriteLine("*\t\t3. Xoa sach\t\t\t\t\t*");
        Console.WriteLine("*\t\t4. Hien thi danh sach sach\t\t\t*");
        Console.WriteLine("*\t\t5. Tim sach theo ten\t\t\t\t*");
        Console.WriteLine("*\t\t6. Tim sach theo chung loai\t\t\t*");
        Console.WriteLine("*\t\t7. Ghi toan bo thong tin sach vao tep\t\t*");
        Console.WriteLine("*\t\t8. Tim sach theo ma sach\t\t\t*");
        Console.WriteLine("*\t\t9. Dong bo thong tin sach len SQL Server\t*");
        Console.WriteLine("*\t\t10. Hien thi tong so luong va tong gia tri sach\t*");
        Console.WriteLine("*\t\t11. Thoat chuong trinh\t\t\t\t*");
        Console.WriteLine("*\t\t\t\t\t\t\t\t*");
        Console.WriteLine("*****************************************************************");
    }
}