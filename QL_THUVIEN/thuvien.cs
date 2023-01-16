using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace QL_THUVIEN
{
    public partial class frmThuVien : Form
    {
        KetNoiSql dt = new KetNoiSql();
        
        public frmThuVien()
        {
            InitializeComponent();
            loadDuLieuSach();
            loadCBTG();
            loadCBK();
            loadCBNXB();
            loadCBLS();
            loaCBLoc();
            databindings();

        }
       
        void loaCBLoc()
        {
            cbBoLoc.Items.Add("Tìm kiếm theo tên sách");
            cbBoLoc.Items.Add("Tìm kiếm theo mã sách");
        }
        void loadDuLieuSach()
        {
            string cauLenh = "select mash, tentg, tennxb, tenloai, ke.make, tensh, namxb, soluong from sach, tacgia, loaisach, ke, NHAXUATBAN where sach.MATG = TACGIA.MATG and sach.MALOAI = LOAISACH.MALOAI and sach.MAKE = KE.MAKE and SACH.MANXB = NHAXUATBAN.MANXB";
            dt.loadDuLieu(cauLenh, dataGridView1);
        }

        bool themSach()
        {
            string cauLenh = "insert into Sach values('" + textBox1.Text + "', '" + comboBox1.SelectedValue.ToString() + "', '" + comboBox2.SelectedValue.ToString() + "', N'" + comboBox4.SelectedValue.ToString() + "', N'" + comboBox3.SelectedValue.ToString() + "', N'" + textBox6.Text + "', '" + Convert.ToInt32(textBox7.Text) + "', '" + Convert.ToInt32(textBox8.Text) + "')";
            if (dt.getQuery(cauLenh))
                return true;
            else
                return false; 

        }

        bool xoaSach()
        {
            string cauLenh = "delete Sach where MASH = '" + textBox1.Text + "'";
            if (dt.getQuery(cauLenh))
                return true;
            else
                return false;
                     
        }

        bool suaSach()
        {
            string cauLenh = "update Sach set MATG = '" + comboBox1.SelectedValue.ToString() + "', MANXB = '" + comboBox2.SelectedValue.ToString() + "', MALOAI = '" + comboBox4.SelectedValue.ToString() + "', MAKE = '" + comboBox3.SelectedValue.ToString() + "', TENSH = N'" + textBox6.Text + "', NAMXB = '" + Convert.ToInt32(textBox7.Text) + "', SOLUONG = '" + Convert.ToInt32(textBox8.Text) + "' where MASH = '" + textBox1.Text + "'";
            if (dt.getQuery(cauLenh))
                return true;
            else
                return false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox2.Text) || string.IsNullOrEmpty(comboBox4.Text) || string.IsNullOrEmpty(comboBox3.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
            }
            else
            {

                string cauLenh = "select count(*) from Sach where MaSH = '" + textBox1.Text + "'";
                if (dt.KTKC(cauLenh))
                {
                    if (themSach())
                        MessageBox.Show("Thêm thành công!");
                    else MessageBox.Show("Thêm thất bại!");
                }
                else
                    MessageBox.Show("Trùng mã sách!");
                loadDuLieuSach();
                clear();
                
            }
            databindings();
   

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox2.Text) || string.IsNullOrEmpty(comboBox4.Text) || string.IsNullOrEmpty(comboBox3.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
            }
            else
            {
                string cauLenh = "select count(*) from SACH where MASH = '" + textBox1.Text + "'";
                if (dt.KTTT(cauLenh))
                {
                    if (suaSach())
                        MessageBox.Show("Sửa thành công!");
                    else MessageBox.Show("Sửa thất bại!");
                }
                else MessageBox.Show("Không có mã sách này!");
                loadDuLieuSach();
                clear();
                databindings();
            }

        }

        
        void loadCBTG()
        {
            DataSet ds = new DataSet();
            string cauLenh = "Select * from tacgia";
            SqlDataAdapter da = new SqlDataAdapter(cauLenh, dt.Conn);
            da.Fill(ds, "tacgia");
            comboBox1.DataSource = ds.Tables["tacgia"];
            comboBox1.DisplayMember = "tentg";
            comboBox1.ValueMember = "matg";
        }

        void loadCBNXB()
        {
            DataSet ds = new DataSet();
            string cauLenh = "Select * from nhaxuatban";
            SqlDataAdapter da = new SqlDataAdapter(cauLenh, dt.Conn);
            da.Fill(ds, "nhaxuatban");
            comboBox2.DataSource = ds.Tables["nhaxuatban"];
            comboBox2.DisplayMember = "tennxb";
            comboBox2.ValueMember = "manxb";
        }
        void loadCBK()
        {
            DataSet ds = new DataSet();
            string cauLenh = "Select * from ke";
            SqlDataAdapter da = new SqlDataAdapter(cauLenh, dt.Conn);
            da.Fill(ds, "ke");
            comboBox3.DataSource = ds.Tables["ke"];
            comboBox3.DisplayMember = "make";
            comboBox3.ValueMember = "make";
        }
        void loadCBLS()
        {
            DataSet ds = new DataSet();
            string cauLenh = "Select * from loaisach";
            SqlDataAdapter da = new SqlDataAdapter(cauLenh, dt.Conn);
            da.Fill(ds, "loaisach");
            comboBox4.DataSource = ds.Tables["loaisach"];
            comboBox4.DisplayMember = "tenloai";
            comboBox4.ValueMember = "maloai";
        }
        void clear()
        {
            textBox1.ResetText();
            comboBox4.ResetText();
            textBox6.ResetText();
            textBox7.ResetText();
            textBox8.ResetText();
            comboBox1.ResetText();
            comboBox2.ResetText();
            comboBox3.ResetText();

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query;
            string text = txtSearch.Text;
            if (cbBoLoc.SelectedIndex == 0)
            {
                query = "select mash, tentg, tennxb, tenloai, ke.make, tensh, namxb, soluong from sach, tacgia, loaisach, ke, NHAXUATBAN where sach.MATG = TACGIA.MATG and sach.MALOAI = LOAISACH.MALOAI and sach.MAKE = KE.MAKE and SACH.MANXB = NHAXUATBAN.MANXB and TENSH like N'%" + text + "%'";
                dt.loadDuLieu(query, dataGridView1);

            }
            else if (cbBoLoc.SelectedIndex == 1)
            {
                query = "select mash, tentg, tennxb, tenloai, ke.make, tensh, namxb, soluong from sach, tacgia, loaisach, ke, NHAXUATBAN where sach.MATG = TACGIA.MATG and sach.MALOAI = LOAISACH.MALOAI and sach.MAKE = KE.MAKE and SACH.MANXB = NHAXUATBAN.MANXB and mash like '%" + text + "%'";

                dt.loadDuLieu(query, dataGridView1);

            }
            databindings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadDuLieuSach();
            databindings();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
           
        }
        void databindings()
        {

            textBox1.DataBindings.Clear();
            textBox6.DataBindings.Clear();
            textBox7.DataBindings.Clear();
            textBox8.DataBindings.Clear();
            comboBox1.DataBindings.Clear();
            comboBox2.DataBindings.Clear();
            comboBox3.DataBindings.Clear();
            comboBox4.DataBindings.Clear();
            textBox1.DataBindings.Add("Text", dataGridView1.DataSource, "mash");
            textBox6.DataBindings.Add("Text", dataGridView1.DataSource, "tensh");
            textBox7.DataBindings.Add("Text", dataGridView1.DataSource, "namxb");
            textBox8.DataBindings.Add("Text", dataGridView1.DataSource, "soluong");
            comboBox1.DataBindings.Add("Text", dataGridView1.DataSource, "tentg");
            comboBox2.DataBindings.Add("Text", dataGridView1.DataSource, "tennxb");
            comboBox3.DataBindings.Add("Text", dataGridView1.DataSource, "make");
            comboBox4.DataBindings.Add("Text", dataGridView1.DataSource, "tenloai");

        }

        

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Mã sách chưa được nhập!");
            }
            else
            {
                string cauLenh = "select count(*) from SACH where MASH = '" + textBox1.Text + "'";
                if (dt.KTTT(cauLenh))
                {
                    if (xoaSach())
                        MessageBox.Show("Xóa thành công!");
                    else MessageBox.Show("Xóa thất bại, dữ liệu đang được sử dụng!");
                }
                else MessageBox.Show("Không có mã sách này!");
                loadDuLieuSach();
                clear();
            }
            databindings();

        }

      
    }

}
