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
    public partial class frmKe : Form
    {
        KetNoiSql dt = new KetNoiSql();
        public frmKe()
        {
            InitializeComponent();
            loadDuLieuKe();
            databindings();
        }
        void loadDuLieuKe()
        {
            string cauLenh = "select * from Ke";
            dt.loadDuLieu(cauLenh, dataGridView1);
        }
        bool themKe()
        {
            string cauLenh = "insert into Ke values('" + textBox1.Text + "', '" + textBox2.Text + "')";
            if (dt.getQuery(cauLenh))
                return true;
            else
                return false;
        }
        bool xoaKe()
        {
            string cauLenh = "delete ke where MAKE = '" + textBox1.Text + "'";
            if (dt.getQuery(cauLenh))
                return true;
            else
                return false;
        }
        bool suaKe()
        {
            string cauLenh = "update KE set VITRI = '" + textBox2.Text + "' where MAKE = '" + textBox1.Text + "'";
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

                string cauLenh = "select count(*) from KE where MAKE = '" + textBox1.Text + "'";
                if (dt.KTKC(cauLenh))
                {
                    if (themKe())
                        MessageBox.Show("Thêm thành công!");
                    else MessageBox.Show("Thêm thất bại!");
                }
                else
                    MessageBox.Show("Trùng mã kệ!");
                loadDuLieuKe();
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
                string cauLenh = "select count(*) from ke where MAKE = '" + textBox1.Text + "'";
                if (dt.KTTT(cauLenh))
                {
                    if (xoaKe())
                        MessageBox.Show("Xóa thành công!");
                    else MessageBox.Show("Xóa thất bại, dữ liệu đang được sử dụng!");
                }
                else MessageBox.Show("Không có mã kệ này!");
                loadDuLieuKe();
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
                string cauLenh = "select count(*) from KE where MAKE = '" + textBox1.Text + "'";
                if (dt.KTTT(cauLenh))
                {
                    if (suaKe())
                        MessageBox.Show("Sửa thành công!");
                    else MessageBox.Show("Sửa thất bại!");
                }
                else MessageBox.Show("Không có mã kệ này!");
                loadDuLieuKe();
                clear();
            }
            databindings();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query;
            string text = txtSearch.Text;
            if (cbBoLoc.SelectedIndex == 0)
            {
                query = "select * from ke where make like '%" + text + "%'";
                dt.loadDuLieu(query, dataGridView1);

            }
            else if (cbBoLoc.SelectedIndex == 1)
            {
                query = "select * from ke where vitri like '%" + text + "%'";
                dt.loadDuLieu(query, dataGridView1);


            }
            databindings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadDuLieuKe();
            databindings();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }
        void databindings()
        {
            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            textBox1.DataBindings.Add("Text", dataGridView1.DataSource, "make");
            textBox2.DataBindings.Add("Text", dataGridView1.DataSource, "vitri");

        }
    }
}
