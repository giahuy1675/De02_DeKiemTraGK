using System;
using System.Collections.Generic;
using System.Linq;
using DAL;

namespace BLL
{
    public class LoaiSPBLL
    {
        private Model1 db = new Model1(); // Kết nối đến cơ sở dữ liệu

        // Lấy danh sách tất cả các loại sản phẩm
        public List<LoaiSP> GetAllLoaiSP()
        {
            try
            {
                return db.LoaiSP.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách loại sản phẩm: " + ex.Message);
                return new List<LoaiSP>(); // Trả về danh sách rỗng nếu có lỗi
            }
        }
        public LoaiSP GetLoaiSPByName(string tenLoai)
        {
            try
            {
                return db.LoaiSP.FirstOrDefault(l => l.TenLoai == tenLoai);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy loại sản phẩm theo tên: " + ex.Message);
                return null;
            }
        }

        public LoaiSP GetLoaiSPById(string maLoai)
        {
            try
            {
                return db.LoaiSP.FirstOrDefault(l => l.MaLoai == maLoai);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy loại sản phẩm: " + ex.Message);
                return null; // Trả về null nếu có lỗi
            }
        }

        // Thêm một loại sản phẩm mới
        public bool AddLoaiSP(LoaiSP loaiSP)
        {
            try
            {
                db.LoaiSP.Add(loaiSP);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm loại sản phẩm: " + ex.Message);
                return false;
            }
        }

        // Sửa thông tin loại sản phẩm
        public bool UpdateLoaiSP(LoaiSP loaiSP)
        {
            try
            {
                var existingLoaiSP = db.LoaiSP.FirstOrDefault(l => l.MaLoai == loaiSP.MaLoai);
                if (existingLoaiSP != null)
                {
                    existingLoaiSP.TenLoai = loaiSP.TenLoai;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi sửa loại sản phẩm: " + ex.Message);
                return false;
            }
        }

        // Xóa một loại sản phẩm
        public bool DeleteLoaiSP(string maLoai)
        {
            try
            {
                var loaiSP = db.LoaiSP.FirstOrDefault(l => l.MaLoai == maLoai);
                if (loaiSP != null)
                {
                    db.LoaiSP.Remove(loaiSP);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa loại sản phẩm: " + ex.Message);
                return false;
            }
        }
    }
}
