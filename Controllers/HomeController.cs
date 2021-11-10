using QuanLyTheDiemKH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyTheDiemKH.Controllers
{
    public class HomeController : Controller
    {
        public readonly DataContext _context;
        public HomeController()
        {
            _context = new DataContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoadTable()
        {
            var data = _context.KhachHangs.AsQueryable();

            return View(data.OrderBy(x => x.DiemSo).ToList());
        }
        [HttpGet]
        public ActionResult AddOrUpdate(int id = 0)
        {
            if (id == 0)
            {
                return View(new KhachHang());
            }
            else
            {
                var entity = _context.KhachHangs.Where(x => x.Id == id).FirstOrDefault();
                if (entity == default(KhachHang))
                    throw new Exception("Không tìm thấy dữ liệu");
                return View(entity);
            }
        }
        [HttpPost]
        public ActionResult AddOrUpdate(KhachHang model)
        {
            try
            {
                if (model.Id == 0)
                {
                    _context.KhachHangs.Add(model);
                    _context.SaveChanges();
                    return Json(new GenericMessageVM()
                    {
                        Status = true,
                        Message = $"Thêm thành công!",
                        MessageType = GenericMessage.success,
                        Data = model
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var entity = _context.KhachHangs.Where(x => x.Id == model.Id).FirstOrDefault();
                    if (entity == default(KhachHang))
                        throw new Exception("Không tìm thấy dữ liệu.");
                    entity.HoLot = model.HoLot;
                    entity.Ten = model.Ten;
                    entity.TaiKhoan = model.TaiKhoan;
                    entity.NgaySinh = model.NgaySinh;
                    entity.DiaChi = model.DiaChi;
                    entity.NgayThamGia = model.NgayThamGia;
                    entity.DiemSo = model.DiemSo;

                    _context.SaveChanges();
                    return Json(new GenericMessageVM()
                    {
                        Status = true,
                        Message = $"Cập nhật thành công!",
                        MessageType = GenericMessage.success,
                        Data = model
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new GenericMessageVM()
                {
                    Status = false,
                    Message = $"{ex.Message}",
                    MessageType = GenericMessage.error
                }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var data = _context.KhachHangs.Where(x => x.Id == id).FirstOrDefault();
                _context.KhachHangs.Remove(data);
                _context.SaveChanges();
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddDiem(int id)
        {
            var entity = _context.KhachHangs.Where(x => x.Id == id).FirstOrDefault();
            if (entity == default(KhachHang))
                throw new Exception("Không tìm thấy dữ liệu");
            var diem = new AddDiem();
            diem.Id = entity.Id;
            diem.Diem = entity.DiemSo;
            return View(diem);
        }

        [HttpPost]
        public ActionResult AddDiem(AddDiem model)
        {
            try
            {
                var entity = _context.KhachHangs.Where(x => x.Id == model.Id).FirstOrDefault();
                if (entity == default(KhachHang))
                    throw new Exception("Không tìm thấy dữ liệu");
                entity.DiemSo += model.TangDiem;

                _context.SaveChanges();
                return Json(new GenericMessageVM()
                {
                    Status = true,
                    Message = $"Tăng điểm thành công!",
                    MessageType = GenericMessage.success,
                    Data = model
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new GenericMessageVM()
                {
                    Status = false,
                    Message = $"{ex.Message}",
                    MessageType = GenericMessage.error
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}