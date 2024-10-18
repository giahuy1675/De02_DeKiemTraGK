using System;
using System.Collections.Generic;
using System.Linq;
using DAL;

namespace BLL
{
    public class SanphamBLL
    {
        private Model1 db = new Model1(); // Kết nối đến cơ sở dữ liệu

        // Lấy danh sách tất cả các sản phẩm
        public List<Sanpham> GetAllSanpham()
        {
            try
            {
                return db.Sanpham.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách sản phẩm: " + ex.Message);
                return new List<Sanpham>(); // Trả về danh sách rỗng nếu có lỗi
            }
        }

        public List<Sanpham> GetSanphamByTen(string tenSP)
        {
            try
            {
                return db.Sanpham.Where(s => s.TenSP.Contains(tenSP)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tìm sản phẩm theo tên: " + ex.Message);
                return new List<Sanpham>(); // Trả về danh sách rỗng nếu có lỗi
            }
        }
        public Sanpham GetSanphamById(string maSP)
        {
            try
            {
                return db.Sanpham.FirstOrDefault(sp => sp.MaSP == maSP);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy sản phẩm theo mã: " + ex.Message);
                return null;
            }
        }



        // Thêm một sản phẩm mới
        public bool AddSanpham(Sanpham sp)
        {
            try
            {
                db.Sanpham.Add(sp);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm sản phẩm: " + ex.Message);
                return false;
            }
        }

        // Sửa thông tin sản phẩm
        public bool UpdateSanpham(Sanpham sp)
        {
            try
            {
                var existingSP = db.Sanpham.FirstOrDefault(s => s.MaSP == sp.MaSP);
                if (existingSP != null)
                {
                    existingSP.TenSP = sp.TenSP;
                    existingSP.NgayNhap = sp.NgayNhap;
                    existingSP.MaLoai = sp.MaLoai;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi sửa sản phẩm: " + ex.Message);
                return false;
            }
        }

        // Xóa một sản phẩm
        public bool DeleteSanpham(string maSP)
        {
            try
            {
                var sp = db.Sanpham.FirstOrDefault(s => s.MaSP == maSP);
                if (sp != null)
                {
                    db.Sanpham.Remove(sp);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa sản phẩm: " + ex.Message);
                return false;
            }
        }
    }
}
