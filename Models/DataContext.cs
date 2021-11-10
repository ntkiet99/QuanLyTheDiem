using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QuanLyTheDiemKH.Models
{
    public class DataContext : DbContext
    {
        public DataContext(): base("name=ConnectionString") { 
        }
        public DbSet<KhachHang> KhachHangs { get; set; }
    }
}