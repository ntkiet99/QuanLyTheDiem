using System;

namespace QuanLyTheDiemKH.Models
{
    public class KhachHang
    {
        public int Id { get; set; }
        public string HoLot { get; set; }
        public string Ten { get; set; }
        public string TaiKhoan { get; set; }
        public DateTime NgaySinh { get; set; } = DateTime.Now;
        public string DiaChi { get; set; }
        public DateTime NgayThamGia { get; set; } = DateTime.Now;
        public int DiemSo { get; set; } = 0;
    }
}