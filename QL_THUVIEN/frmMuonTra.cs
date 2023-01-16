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
    public partial class frmMuonTra : Form
    {
        KetNoiSql dt = new KetNoiSql();
        string today = DateTime.Today.ToString("dd/MM/yyyy");
        public frmMuonTra()
        {
            InitializeComponent();
            loadDuLieu();
            loadCBDG();
            loadCBNV();
            loadCBSach();
            loadCbMaMuonTra();
            
            //databindings();

        }
        void loadDuLieu()
        {
            string cauLenh = "select phieumuontra.MAMUONTRA, tennv, tendg, tensh, ngaymuon, ngaytra, datra, ct_muontra.ghichu from NHANVIEN, DOCGIA, SACH, PHIEUMUONTRA, THETHUVIEN, CT_MUONTRA where NHANVIEN.MANV = PHIEUMUONTRA.MANV and DOCGIA.MADG = THETHUVIEN.MADG and PHIEUMUONTRA.MATHE = THETHUVIEN.MATHE and PHIEUMUONTRA.MAMUONTRA = CT_MUONTRA.MAMUONTRA and CT_MUONTRA.MASH = SACH.MASH";
            dt.loadDuLieu(cauLenh, dataGridView1);
        }
        void loadCBDG()
        {
            dt.Conn.Open();
            DataTable data = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from DOCGIA, THETHUVIEN where DOCGIA.MADG = THETHUVIEN.MADG", dt.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(data);
            dt.Conn.Close();
            comboBox2.DataSource = data;
            comboBox2.DisplayMember = "tendg";
            comboBox2.ValueMember = "mathe";
        }
        void loadCBSach()
        {
            dt.Conn.Open();
            DataTable data = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from sach", dt.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(data);
            dt.Conn.Close();
            comboBox3.DataSource = data;
            comboBox3.DisplayMember = "tensh";
            comboBox3.ValueMember = "mash";
        }
        void loadCBNV()
        {
            dt.Conn.Open();
            DataTable data = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from nhanvien", dt.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(data);
            dt.Conn.Close();
            comboBox1.DataSource = data;
            comboBox1.DisplayMember = "tennv";
            comboBox1.ValueMember = "manv";
        }
        bool themMuonTra()
        {
            string cauLenh = "insert into phieumuontra values('" + textBox1.Text + "', '" + comboBox1.SelectedValue.ToString() + "', '" + comboBox2.SelectedValue.ToString() + "', '" + dateTimePicker1.Value.ToString("yyyyMMdd") + "')";
            //string cauLenh2 = "insert into CT_MUONTRA(mash,mamuontra,ngaytra,datra,ghichu) values('" + comboBox3.SelectedValue.ToString() + "', '" + textBox1.Text + "', '" + dateTimePicker2.Value.ToString("yyyyMMdd") + "', '" + textBox3.Text + "', '" + textBox4.Text + "')";
            if (dt.getQuery(cauLenh)/* && dt.getQuery(cauLenh2)*/)
                return true;
            else
                return false;
        }
        bool themCTMuonTra()
        {
            string cauLenh2 = "insert into CT_MUONTRA(mash,mamuontra,ngaytra,ghichu) values('" + comboBox3.SelectedValue.ToString() + "', '" + comboBox4.SelectedValue.ToString() + "', '" + dateTimePicker2.Value.ToString("yyyyMMdd") + "', N'" + textBox4.Text + "')";
            if (dt.getQuery(cauLenh2))
                return true;
            else
                return false;
        }

        
        //bool suaMuonTra()
        //{
        //    string cauLenh = "update phieumuontra set manv = '"+comboBox1.SelectedValue.ToString()+"', mathe = '"+comboBox2.SelectedValue.ToString()+"', ngaymuon = '"+ dateTimePicker1.Value.ToString("yyyyMMdd") + "' where mamuontra = '"+ textBox1.Text+"'";
        //    string cauLenh2 = "update ct_muontra set ghichu = N'" + textBox4.Text + "', datra = '" + textBox3.Text + "', ngaytra = '" + dateTimePicker2.Value.ToString("yyyyMMdd") + "' where mamuontra = '" + textBox1.Text + "' and mash = '" + comboBox3.SelectedValue.ToString() + "'";
        //    if (dt.getQuery(cauLenh) && dt.getQuery(cauLenh2))
        //        return true;
        //    else
        //        return false;
        //}

        void clear()
        {
            textBox1.ResetText();
            textBox4.ResetText();
            comboBox1.ResetText();
            comboBox2.ResetText();
            comboBox3.ResetText();
            comboBox4.ResetText();

        }

        //private void btnSua_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox2.Text))
        //    {
        //        MessageBox.Show("Bạn chưa nhập đủ thông tin!");
        //    }
        //    else
        //    {

        //        string cauLenh = "select count(*) from phieumuontra where mamuontra = '" + textBox1.Text + "'";
        //        if (dt.KTTT(cauLenh))
        //        {
        //            if (suaMuonTra())
        //                MessageBox.Show("Sửa thành công!");
        //            else MessageBox.Show("Sửa thất bại!");
        //        }
        //        else
        //            MessageBox.Show("Không có mã mượn trả này!");
        //        loadDuLieu();
        //        clear();

        //    }
            //databindings();

        //}

        private void button1_Click(object sender, EventArgs e)
        {
            loadDuLieu();
            //databindings();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query;
            string text = txtSearch.Text;
            if (cbBoLoc.SelectedIndex == 0)
            {
                query = "select phieumuontra.MAMUONTRA, tennv, tendg, tensh,  ngaymuon, ngaytra, datra, ct_muontra.ghichu from NHANVIEN, DOCGIA, SACH, PHIEUMUONTRA, THETHUVIEN, CT_MUONTRA where NHANVIEN.MANV = PHIEUMUONTRA.MANV and DOCGIA.MADG = THETHUVIEN.MADG and PHIEUMUONTRA.MATHE = THETHUVIEN.MATHE and PHIEUMUONTRA.MAMUONTRA = CT_MUONTRA.MAMUONTRA and CT_MUONTRA.MASH = SACH.MASH and PHIEUMUONTRA.MAMUONTRA like '%" + text + "%'";
                dt.loadDuLieu(query, dataGridView1);

            }
            else if (cbBoLoc.SelectedIndex == 1)
            {
                query = "select phieumuontra.MAMUONTRA, tennv, tendg, tensh,  ngaymuon, ngaytra, datra, ct_muontra.ghichu from NHANVIEN, DOCGIA, SACH, PHIEUMUONTRA, THETHUVIEN, CT_MUONTRA where NHANVIEN.MANV = PHIEUMUONTRA.MANV and DOCGIA.MADG = THETHUVIEN.MADG and PHIEUMUONTRA.MATHE = THETHUVIEN.MATHE and PHIEUMUONTRA.MAMUONTRA = CT_MUONTRA.MAMUONTRA and CT_MUONTRA.MASH = SACH.MASH and tendg like N'%" + text + "%'";

                dt.loadDuLieu(query, dataGridView1);

            }
            //databindings();

        }

        private void btnThemCT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox4.Text) || string.IsNullOrEmpty(comboBox3.Text))
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
            }
            else
            {
                string cauLenh = "select count(*) from phieumuontra where mamuontra = '" + comboBox4.SelectedValue.ToString() + "'";
                if (dt.KTTT(cauLenh))
                {
                    if (themCTMuonTra())
                    {
                        MessageBox.Show("Thêm thành công!");
                        clear();
                        
                    }
                    else MessageBox.Show("Hết sách!");
                }
                else
                    MessageBox.Show("Không có mã mượn trả này!");
                loadDuLieu();


            }

            //databindings();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox3.ResetText();
            textBox4.ResetText();
            comboBox4.ResetText();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "False")
            {
                btnTraSach.Enabled = true;
            }
            else
                btnTraSach.Enabled = false;


        }

        bool traSach()
        {
            string cauLenh = "update ct_muontra set datra = 'True', ghichu = N'Đã trả "+today+ "' where mamuontra = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() +  "'";
            if (dt.getQuery(cauLenh))
                return true;
            else
                return false;
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            if (traSach())
                MessageBox.Show("Trả sách thành công!");
            else
                MessageBox.Show("Trả sách thất bại!");
            loadDuLieu();
            //databindings();

        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "False")
            {
                MessageBox.Show("Sách đang mượn không được xóa");
            }
            else
            {
                if (xoaCTMuonTra())
                {
                    MessageBox.Show("Xóa thành công");
                    loadDuLieu();
                }
                else
                    MessageBox.Show("Xóa thất bại");
                
            }

            
            //databindings();
        }
        bool xoaCTMuonTra()
        {
           
            string cauLenh = "delete CT_MUONTRA where mamuontra = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
            if (dt.getQuery(cauLenh))
                return true;
            else
                return false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.ResetText();
            comboBox1.ResetText();
            comboBox2.ResetText();
        }

      

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox2.Text) || string.IsNullOrEmpty(dateTimePicker1.Text))
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
            else
            {
                string cauLenh = "select count(*) from phieumuontra where mamuontra = '" + textBox1.Text + "'";
                if (dt.KTKC(cauLenh))
                {
                    if (themMuonTra())
                    {
                        MessageBox.Show("Tạo thành công!");
                        clear();
                        loadCbMaMuonTra();
                        comboBox4.Focus();
                    }
                    else MessageBox.Show("Tạo thất bại!");
                }
                else
                    MessageBox.Show("Trùng mã mượn trả!");
                loadDuLieu();
               
     

            }    


        }
        void loadCbMaMuonTra()
        {
            dt.Conn.Open();
            DataTable data = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from phieumuontra", dt.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(data);
            dt.Conn.Close();
            comboBox4.DataSource = data;
            comboBox4.DisplayMember = "mamuontra";
            comboBox4.ValueMember = "mamuontra";
        }

        private void frmMuonTra_Load(object sender, EventArgs e)
        {
            comboBox1.ResetText();
            comboBox2.ResetText();
            comboBox3.ResetText();
            comboBox4.ResetText();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }
    }
}
