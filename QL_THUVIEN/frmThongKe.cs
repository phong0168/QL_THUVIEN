using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace QL_THUVIEN
{
    public partial class frmThongKe : Form
    {
        KetNoiSql dt = new KetNoiSql();

        public frmThongKe()
        {
            InitializeComponent();
            loadDL();
            
        }
        public void loadDL()
        {
            dt.loadDuLieu("select * from View_1", dataGridView1);
            button2.Enabled = false;
         
        }
        DataTable loadDL1()
        {
            string cauLenh = "select tendg, phieumuontra.MAMUONTRA, tensh, ngaymuon, ngaytra from NHANVIEN, DOCGIA, SACH, PHIEUMUONTRA, THETHUVIEN, CT_MUONTRA where NHANVIEN.MANV = PHIEUMUONTRA.MANV and DOCGIA.MADG = THETHUVIEN.MADG and PHIEUMUONTRA.MATHE = THETHUVIEN.MATHE and PHIEUMUONTRA.MAMUONTRA = CT_MUONTRA.MAMUONTRA and CT_MUONTRA.MASH = SACH.MASH and datra = 0 and NGAYTRA < getdate()";
            SqlDataAdapter adapter = new SqlDataAdapter(cauLenh, dt.Conn);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;


        }

        DataTable loadDL2()
        {
            string cauLenh = "select tendg, phieumuontra.MAMUONTRA, tensh, ngaymuon, ngaytra from NHANVIEN, DOCGIA, SACH, PHIEUMUONTRA, THETHUVIEN, CT_MUONTRA where NHANVIEN.MANV = PHIEUMUONTRA.MANV and DOCGIA.MADG = THETHUVIEN.MADG and PHIEUMUONTRA.MATHE = THETHUVIEN.MATHE and PHIEUMUONTRA.MAMUONTRA = CT_MUONTRA.MAMUONTRA and CT_MUONTRA.MASH = SACH.MASH and datra = 0";
            SqlDataAdapter adapter = new SqlDataAdapter(cauLenh, dt.Conn);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;


        }

        private void cbBoLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoLoc.SelectedIndex == 0)
            {
                dt.loadDuLieu("select tendg, phieumuontra.MAMUONTRA, tensh, ngaymuon, ngaytra from NHANVIEN, DOCGIA, SACH, PHIEUMUONTRA, THETHUVIEN, CT_MUONTRA where NHANVIEN.MANV = PHIEUMUONTRA.MANV and DOCGIA.MADG = THETHUVIEN.MADG and PHIEUMUONTRA.MATHE = THETHUVIEN.MATHE and PHIEUMUONTRA.MAMUONTRA = CT_MUONTRA.MAMUONTRA and CT_MUONTRA.MASH = SACH.MASH and datra = 0 and NGAYTRA < getdate()", dataGridView1);

            }
            else
                dt.loadDuLieu("select tendg, phieumuontra.MAMUONTRA, tensh, ngaymuon, ngaytra from NHANVIEN, DOCGIA, SACH, PHIEUMUONTRA, THETHUVIEN, CT_MUONTRA where NHANVIEN.MANV = PHIEUMUONTRA.MANV and DOCGIA.MADG = THETHUVIEN.MADG and PHIEUMUONTRA.MATHE = THETHUVIEN.MATHE and PHIEUMUONTRA.MAMUONTRA = CT_MUONTRA.MAMUONTRA and CT_MUONTRA.MASH = SACH.MASH and datra = 0", dataGridView1);
            button2.Enabled = true;


        }



        private void button2_Click(object sender, EventArgs e)
        {
            frmBieuMau f = new frmBieuMau();
            if (cbBoLoc.SelectedIndex == 0)
            {
                DataTable data = loadDL1();
                CrystalReport1 c = new CrystalReport1();
                c.SetDataSource(data);
                f.crystalReportViewer1.ReportSource = c;
                f.ShowDialog();

            }
            else
            {
                DataTable data = loadDL2();
                CrystalReport1 c = new CrystalReport1();
                c.SetDataSource(data);
                f.crystalReportViewer1.ReportSource = c;
                f.ShowDialog();

            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadDL();
            button2.Enabled=false;
            cbBoLoc.ResetText();
        }
    }
}
