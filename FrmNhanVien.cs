using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using EDCZONE.Class;

namespace EDCZONE
{
    public partial class FrmNhanVien : Form
    {
        DataTable tblnhanvien;
        public FrmNhanVien()
        {
            InitializeComponent();
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM tblnhanhvien";
            tblnhanvien = Functions.GetDataToTable(sql);  ; //Đọc dữ liệu từ bảng
            dgvNhanVien.DataSource = tblnhanvien; //Nguồn dữ liệu            
            


            dgvNhanVien.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgvNhanVien.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = dgvNhanVien.CurrentRow.Cells["MaNV"].Value.ToString();
            txtTenNV.Text = dgvNhanVien.CurrentRow.Cells["HoTen"].Value.ToString();
            txtNamSinh.Text = dgvNhanVien.CurrentRow.Cells["NamSinh"].Value.ToString();
            txtQueQuan.Text = dgvNhanVien.CurrentRow.Cells["QueQuan"].Value.ToString();
            txtGioiTinh.Text = dgvNhanVien.CurrentRow.Cells["GioiTinh"].Value.ToString();
            txtEmail.Text = dgvNhanVien.CurrentRow.Cells["Email"].Value.ToString();
            txtSdt.Text = dgvNhanVien.CurrentRow.Cells["SDT"].Value.ToString();
            txtMaCV.Text = dgvNhanVien.CurrentRow.Cells["MaCV"].Value.ToString();
        }
    }
}
