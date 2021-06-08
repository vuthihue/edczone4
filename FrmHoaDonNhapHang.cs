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
using COMExcel = Microsoft.Office.Interop.Excel;

namespace EDCZONE
{
    public partial class FrmHoaDonNhapHang : Form
    {
        DataTable tblCTHDN;
        public FrmHoaDonNhapHang()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmHoaDonNhapHang_Load(object sender, EventArgs e)
        {
            btnThemHĐ.Enabled = true;
            btnLuuHD.Enabled = false;
            btnXoaHĐ.Enabled = false;
            
           txtSoHDN.ReadOnly = true;
          txtTenNV.ReadOnly = true;
            txtTenNCC.ReadOnly = true;
            txtThanhTien.Enabled = true;
            txtTongTien.ReadOnly = true;
            txTenSP.ReadOnly = true;
            txtSDT.ReadOnly = true;
            txtDiaChi.ReadOnly = true;
            txtGiamGia.Text = "0";
            txtTongTien.Text = "0";
            txtThanhTien.Text = "";

            Functions.FillCombo1("select MaNV from tblnhanhvien", cboMaNV, "MaNV");
            cboMaNV.SelectedIndex = -1;
            Functions.FillCombo1("select MaNCC from tblncc", cboMaNCC, "MaNCC");
            cboMaNCC.SelectedIndex = -1;
            Functions.FillCombo1("select MaSP from tblsanpham", cboMaSP, "MaSP");
            cboMaSP.SelectedIndex = -1;
            
            if (txtSoHDN.Text != "")
            {
                LoadInfoHoaDon();
                btnXoaHĐ.Enabled = true;
                
            }
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "Select * from tblchitietphieunhaphang";
            tblCTHDN = Functions.GetDataToTable(sql);
            dataGridView_HDN.DataSource = tblCTHDN;
            dataGridView_HDN.AllowUserToAddRows = false;
            dataGridView_HDN.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void LoadInfoHoaDon()
        {
            string str;
            str = "Select NgayLapPNK from tblphieunhaphang where MaPNH = N'" + txtSoHDN.Text + "'";
            dtpNgayBan.Value = DateTime.Parse(Functions.GetFieldValues(str));
            str = "Select MaNV from tblphieunhaphang where SoHDN = N'" + txtSoHDN.Text + "'";
            cboMaNV.Text = Functions.GetFieldValues(str);
            str = "Select MaNCC from tblphieunhaphang where SoHDN = N'" + txtSoHDN.Text + "'";
            cboMaNCC.Text = Functions.GetFieldValues(str);
            str = "Select TongTien from tblphieunhaphang where SoHDN = N'" + txtSoHDN.Text + "'";
            textTongTien.Text = Functions.GetFieldValues(str);
            lblBangChu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(Double.Parse(textTongTien.Text));
        }

        private void btnThemHĐ_Click(object sender, EventArgs e)
        {
            btnXoaHĐ.Enabled = false;
            btnLuuHD.Enabled = true;
            
            btnThemHĐ.Enabled = false;
            ResetValues();
            txtSoHDN.Text = Functions.CreateKey("HDN");
            LoadDataGridView();
        }
        private void ResetValues()
        {
            txtSoHDN.Text = "";
            dtpNgayBan.Value = DateTime.Now;
            cboMaNV.Text = "";
            cboMaNCC.Text = "";
            txtTongTien.Text = "";
            lblBangChu.Text = "Bằng chữ: ";
            cboMaSP.Text = "";
            txtSoLuong.Text = "";
            txtGiamGia.Text = "";
            txtDonGia.Text = "";
            txtThanhTien.Text = "";
        }

        private void btnLuuHD_Click(object sender, EventArgs e)
        {
           
            

        }

       
    }
}
