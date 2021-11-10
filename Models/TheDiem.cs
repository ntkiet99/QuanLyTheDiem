namespace QuanLyTheDiemKH.Models
{
    public class TheDiem
    {
        public TheDiem() { }
        public TheDiem(int id, string tenThe, string loaiThe, int canDuoi = 0, int canTren = 0)
        {
            this.Id = id;
            this.TenThe = tenThe;
            this.LoaiThe = loaiThe;
            this.CanTren = canTren;
            this.CanDuoi = canDuoi;
        }
        public int Id { get; set; }
        public string TenThe { get; set; }
        public string LoaiThe { get; set; }
        public int CanDuoi { get; set; } = 0;
        public int CanTren { get; set; } = 0;
    }
}