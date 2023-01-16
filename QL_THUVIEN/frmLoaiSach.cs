using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace QL_THUVIEN
{
    public partial class frmLoaiSach : Form
    {
        KetNoiSql dt = new KetNoiSql();
        public frmLoaiSach()
        {
            InitializeComponent();
            loadDuLieuLoaiSach();
        }
        void loadDuLieuLoaiSach()
        {
            string cauLenh = "select * from loaisach";
            dt.loadDuLieu(cauLenh, dataGridView1);
            databindings();
        }
        bool themLoaiSach()
        {
            string cauLenh = "insert into loaisach values('" + textBox1.Text + "', N'" + textBox2.Text + "')";
            if (dt.getQuery(cauLenh))
                return true;
            else
                return false;
        }
        bool xoaLoaiSach()
        {
            string cauLenh = "delete loaisach where maloai = '" + textBox1.Text + "'";
            if (dt.getQuery(cauLenh))
                return true;
            else
                return false;
        }
        bool suaLoaiSach()
        {
            string cauLenh = "update loaisach set tenloai = '" + textBox2.Text + "' where maloai = '" + textBox1.Text + "'";
            if (dt.getQuery(cauLenh))
                return true;
            else
                return false;
        }
        void clear()
        {
            textBox1.ResetText();
            textBox2.ResetText();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
            }
            else
            {

                string cauLenh = "select count(*) from loaisach where maloai = '" + textBox1.Text + "'";
                if (dt.KTKC(cauLenh))
                {
                    if (themLoaiSach())
                        MessageBox.Show("Thêm thành công!");
                    else MessageBox.Show("Thêm thất bại!");
                }
                else
                    MessageBox.Show("Trùng mã loại sách!");
                loadDuLieuLoaiSach();
                clear();
            }
            databindings();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Mã kệ chưa được nhập!");
            }
            else
            {
                string cauLenh = "select count(*) from loaisach where maloai = '" + textBox1.Text + "'";
                if (dt.KTTT(cauLenh))
                {
                    if (xoaLoaiSach())
                        MessageBox.Show("Xóa thành công!");
                    else MessageBox.Show("Xóa thất bại, dữ liệu đang được sử dụng!");
                }
                else MessageBox.Show("Không có mã loại sách này!");
                loadDuLieuLoaiSach();
                clear();
            }
            databindings();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
            }
            else
            {
                string cauLenh = "select count(*) from loaisach where maloai  = '" + textBox1.Text + "'";
                if (dt.KTTT(cauLenh))
                {
                    if (suaLoaiSach())
                        MessageBox.Show("Sửa thành công!");
                    else MessageBox.Show("Sửa thất bại!");
                }
                else MessageBox.Show("Không có mã loại sách này!");
                loadDuLieuLoaiSach();
                clear();
            }
            databindings();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadDuLieuLoaiSach();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }
        void databindings()
        {
            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            textBox1.DataBindings.Add("Text", dataGridView1.DataSource, "maloai");
            textBox2.DataBindings.Add("Text", dataGridView1.DataSource, "tenloai");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query;
            string text = txtSearch.Text;
            if (cbBoLoc.SelectedIndex == 0)
            {
                query = "select * from loaisach where tenloai like '%" + text + "%'";
                dt.loadDuLieu(query, dataGridView1);

            }
            else if (cbBoLoc.SelectedIndex == 1)
            {
                query = "select * from loaisach where maloai like '%" + text + "%'";
                dt.loadDuLieu(query, dataGridView1);


            }
            databindings();
        }
    }
}
