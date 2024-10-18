using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        private LoaiSPBLL loaiSPBLL = new LoaiSPBLL();
        private SanphamBLL sanphamBLL = new SanphamBLL();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadLoaiSanpham();
            LoadSanphamList();
            SetupListView();
        }

        private void LoadLoaiSanpham()
        {
            // Giả sử bạn có danh sách loại sản phẩm trong cơ sở dữ liệu
            var loaiSPs = loaiSPBLL.GetAllLoaiSP();
            cboLoaiSP.Items.Clear();
            foreach (var loaiSP in loaiSPs)
            {
                cboLoaiSP.Items.Add(loaiSP.TenLoai);
            }
        }
        private void LoadSanphamList()
        {
            lvSanpham.Items.Clear(); // Xóa dữ liệu cũ trong ListView
            var sanphams = sanphamBLL.GetAllSanpham();
            foreach (var sp in sanphams)
            {
                var loaiSP = loaiSPBLL.GetLoaiSPById(sp.MaLoai); // Lấy đối tượng LoaiSP

                var listItem = new ListViewItem(sp.MaSP); // Cột Mã SP
                listItem.SubItems.Add(sp.TenSP); // Cột Tên SP
                listItem.SubItems.Add(sp.NgayNhap.HasValue ? sp.NgayNhap.Value.ToString("dd/MM/yyyy") : ""); // Cột Ngày nhập
                listItem.SubItems.Add(loaiSP?.TenLoai ?? "Không xác định"); // Cột Loại SP (Tên loại sản phẩm)

                lvSanpham.Items.Add(listItem); // Thêm vào ListView
            }
        }



        private void SetupListView()
        {
            lvSanpham.View = View.Details; // Chế độ xem chi tiết
            lvSanpham.FullRowSelect = true; // Chọn toàn bộ hàng
            lvSanpham.GridLines = true; // Hiển thị đường kẻ bảng

            // Thêm các cột vào ListView
            lvSanpham.Columns.Add("Mã SP", 100);
            lvSanpham.Columns.Add("Tên SP", 200);
            lvSanpham.Columns.Add("Ngày nhập", 150);
            lvSanpham.Columns.Add("Loại SP", 150);
        }

        private void bt_Them_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboLoaiSP.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn loại sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy tên loại sản phẩm từ ComboBox
                string tenLoaiSP = cboLoaiSP.SelectedItem.ToString();

                // Kiểm tra mã sản phẩm có bị trùng không
                string maSP = txtMaSP.Text;
                var existingSP = sanphamBLL.GetSanphamById(maSP);
                if (existingSP != null)
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại! Vui lòng nhập mã khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng sản phẩm mới
                Sanpham sp = new Sanpham
                {
                    MaSP = maSP,
                    TenSP = txtTenSP.Text,
                    NgayNhap = dtNgaynhap.Value,
                    MaLoai = loaiSPBLL.GetLoaiSPByName(tenLoaiSP)?.MaLoai
                };

                // Thêm sản phẩm vào ListView (không lưu vào cơ sở dữ liệu)
                var listItem = new ListViewItem(sp.MaSP);
                listItem.SubItems.Add(sp.TenSP);
                listItem.SubItems.Add(sp.NgayNhap?.ToString("dd/MM/yyyy") ?? ""); // Cột Ngày nhập
                listItem.SubItems.Add(tenLoaiSP);

                lvSanpham.Items.Add(listItem);

                // Xóa dữ liệu trong TextBox sau khi thêm thành công
                txtMaSP.Clear();
                txtTenSP.Clear();
                dtNgaynhap.Value = DateTime.Now; // Đặt lại giá trị mặc định cho Ngày nhập
                cboLoaiSP.SelectedIndex = -1; // Hủy chọn trong ComboBox

                MessageBox.Show("Đã thêm sản phẩm (chưa lưu).");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvSanpham.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm để sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cboLoaiSP.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn loại sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy dòng được chọn trong ListView
                ListViewItem selectedItem = lvSanpham.SelectedItems[0];

                // Cập nhật thông tin trên ListView
                selectedItem.SubItems[0].Text = txtMaSP.Text;
                selectedItem.SubItems[1].Text = txtTenSP.Text;
                selectedItem.SubItems[2].Text = dtNgaynhap.Value.ToString("dd/MM/yyyy");
                selectedItem.SubItems[3].Text = cboLoaiSP.SelectedItem.ToString();

                MessageBox.Show("Đã cập nhật sản phẩm (chưa lưu).");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private List<string> danhSachMaSPDaXoa = new List<string>(); // Danh sách các mã sản phẩm đã xóa

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvSanpham.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hiển thị hộp thoại cảnh báo trước khi xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Lấy mã sản phẩm được chọn và thêm vào danh sách xóa
                    string maSP = lvSanpham.SelectedItems[0].SubItems[0].Text;
                    danhSachMaSPDaXoa.Add(maSP);

                    // Xóa dòng được chọn khỏi ListView
                    lvSanpham.SelectedItems[0].Remove();

                    // Xóa thông tin trong các TextBox
                    txtMaSP.Clear();
                    txtTenSP.Clear();
                    dtNgaynhap.Value = DateTime.Now;
                    cboLoaiSP.SelectedIndex = -1;

                    MessageBox.Show("Đã xóa sản phẩm (chưa lưu).");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Thoát chương trình
            }
        }
        private bool isSaved = true;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isSaved) // Kiểm tra nếu có thay đổi chưa được lưu
            {
                DialogResult result = MessageBox.Show("Bạn có thay đổi chưa được lưu. Bạn có muốn lưu trước khi thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    bt_Luu_Click(sender, e); // Gọi hàm lưu dữ liệu
                }
                else if (result == DialogResult.No)
                {
                    e.Cancel = false; // Tiếp tục thoát mà không lưu
                }
                else
                {
                    e.Cancel = true; // Hủy sự kiện đóng cửa sổ nếu người dùng chọn "Cancel"
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Hủy bỏ sự kiện đóng cửa sổ, không thoát
                }
            }
        }

        private void lvSanpham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSanpham.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvSanpham.SelectedItems[0];
                txtMaSP.Text = selectedItem.SubItems[0].Text;
                txtTenSP.Text = selectedItem.SubItems[1].Text;
                dtNgaynhap.Value = DateTime.Parse(selectedItem.SubItems[2].Text);
                string tenLoaiSP = selectedItem.SubItems[3].Text;
                cboLoaiSP.SelectedItem = tenLoaiSP;
                isSaved = false; // Đánh dấu là có thay đổi chưa lưu
            }
        }

        private void btTim_Click(object sender, EventArgs e)
        {
            try
            {
                string tenSP = txtTim.Text; // Lấy từ khóa tìm kiếm từ TextBox

                if (string.IsNullOrEmpty(tenSP))
                {
                    MessageBox.Show("Vui lòng nhập tên sản phẩm cần tìm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var sanphams = sanphamBLL.GetSanphamByTen(tenSP); // Tìm sản phẩm theo tên

                lvSanpham.Items.Clear(); // Xóa dữ liệu cũ trong ListView

                if (sanphams.Count > 0)
                {
                    foreach (var sp in sanphams)
                    {
                        var loaiSP = loaiSPBLL.GetLoaiSPById(sp.MaLoai); // Lấy đối tượng LoaiSP

                        var listItem = new ListViewItem(sp.MaSP); // Cột Mã SP
                        listItem.SubItems.Add(sp.TenSP); // Cột Tên SP
                        listItem.SubItems.Add(sp.NgayNhap.HasValue ? sp.NgayNhap.Value.ToString("dd/MM/yyyy") : ""); // Cột Ngày nhập
                        listItem.SubItems.Add(loaiSP?.TenLoai ?? "Không xác định"); // Cột Loại SP (Tên loại sản phẩm)

                        lvSanpham.Items.Add(listItem); // Thêm vào ListView
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void bt_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                // Xử lý các sản phẩm bị xóa
                foreach (string maSP in danhSachMaSPDaXoa)
                {
                    // Kiểm tra nếu sản phẩm tồn tại trong cơ sở dữ liệu, thì xóa
                    var existingSP = sanphamBLL.GetSanphamById(maSP);
                    if (existingSP != null)
                    {
                        sanphamBLL.DeleteSanpham(maSP);
                    }
                }

                // Sau khi lưu, làm trống danh sách các sản phẩm đã xóa
                danhSachMaSPDaXoa.Clear();

                // Lưu lại tất cả các sản phẩm hiện tại từ ListView vào cơ sở dữ liệu
                foreach (ListViewItem item in lvSanpham.Items)
                {
                    // Lấy thông tin từ ListView
                    string maSP = item.SubItems[0].Text;
                    string tenSP = item.SubItems[1].Text;
                    DateTime ngayNhap = DateTime.Parse(item.SubItems[2].Text);
                    string tenLoaiSP = item.SubItems[3].Text;

                    var loaiSP = loaiSPBLL.GetLoaiSPByName(tenLoaiSP);
                    if (loaiSP == null)
                    {
                        MessageBox.Show("Không tìm thấy loại sản phẩm: " + tenLoaiSP);
                        continue; // Bỏ qua sản phẩm nếu không tìm thấy loại sản phẩm
                    }

                    // Kiểm tra xem mã sản phẩm đã tồn tại trong cơ sở dữ liệu hay chưa
                    var existingSP = sanphamBLL.GetSanphamById(maSP);

                    if (existingSP == null)
                    {
                        // Thêm sản phẩm mới
                        Sanpham sp = new Sanpham
                        {
                            MaSP = maSP,
                            TenSP = tenSP,
                            NgayNhap = ngayNhap,
                            MaLoai = loaiSP.MaLoai
                        };
                        sanphamBLL.AddSanpham(sp);
                    }
                    else
                    {
                        // Cập nhật sản phẩm đã tồn tại
                        existingSP.TenSP = tenSP;
                        existingSP.NgayNhap = ngayNhap;
                        existingSP.MaLoai = loaiSP.MaLoai;
                        sanphamBLL.UpdateSanpham(existingSP);
                    }
                }

                // Đặt biến isSaved thành true để thông báo rằng đã lưu xong
                isSaved = true;

                MessageBox.Show("Đã lưu tất cả thay đổi vào cơ sở dữ liệu.");
                LoadSanphamList(); // Tải lại danh sách từ cơ sở dữ liệu
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void bt_KhongLuu_Click(object sender, EventArgs e)
        {
            // Xóa thông tin trên các TextBox và ComboBox
            txtMaSP.Clear();
            txtTenSP.Clear();
            dtNgaynhap.Value = DateTime.Now; // Đặt lại giá trị mặc định cho Ngày nhập
            cboLoaiSP.SelectedIndex = -1; // Hủy chọn trong ComboBox

            // Tải lại dữ liệu từ cơ sở dữ liệu, hủy bỏ mọi thay đổi chưa lưu
            LoadSanphamList();
            MessageBox.Show("Đã hủy bỏ thay đổi.");
        }

        private void bt_LoadLaiDuLieu_Click(object sender, EventArgs e)
        {
            try
            {
                // Tải lại dữ liệu sản phẩm
                LoadSanphamList();
                MessageBox.Show("Dữ liệu đã được tải lại!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
