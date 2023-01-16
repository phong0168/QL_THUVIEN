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
    public partial class frmNhanVien : Form
    {
        KetNoiSql dt = new KetNoiSql();
        public frmNhanVien()
        {
            InitializeComponent();
            loadDuLieuNV();
            databindings();

        }
        void loadDuLieuNV()
        {
            string cauLenh = "select * from NHANVIEN";
            dt.loadDuLieu(cauLenh, dataGridView1);
        }
        bool themNhanVien()
        {
            string cauLenh = "insert into nhanvien values('" + textBox1.Text + "', N'" + textBox2.Text + "', N'" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "')";
            if (dt.getQuery(cauLenh))
                return true;
            else
                return false;
        }
        bool xoaNhanVien()
        {
            string cauLenh = "delete nhanvien where manv = '" + textBox1.Text + "'";
            if (dt.getQuery(cauLenh))
                return true;
            else
                return false;
        }
        bool suaNhanVien()
        {
            string cauLenh = "update nhanvien set tennv = '" + textBox2.Text + "', gioitinh = N'" + textBox3.Text + "', lienhe = '" + textBox4.Text + "', cccd = '" + textBox5.Text + "' where manv = '" + textBox1.Text + "'";
            if (dt.getQuery(cauLenh))
                return true;
            else
                return false;
        }
        void clear()
        {
            textBox1.ResetText();
            textBox2.ResetText();
            textBox3.ResetText();
            textBox4.ResetText();
            textBox5.ResetText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) ||  string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
            }
            else
            {

                string cauLenh = "select count(*) from nhanvien where manv = '" + textBox1.Text + "'";
                if (dt.KTKC(cauLenh))
                {
                    if (themNhanVien())
                        MessageBox.Show("Thêm thành công!");
                    else MessageBox.Show("Thêm thất bại!");
                }
                else
                    MessageBox.Show("Trùng mã nhân viên!");
                loadDuLieuNV();
                clear();
            }
            databindings();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Mã nhân viên chưa được nhập!");
            }
            else
            {
                string cauLenh = "select count(*) from nhanvien where manv = '" + textBox1.Text + "'";
                if (dt.KTTT(cauLenh))
                {
                    if (xoaNhanVien())
                        MessageBox.Show("Xóa thành công!");
                    else MessageBox.Show("Xóa thất bại, dữ liệu đang được sử dụng!");
                }
                else MessageBox.Show("Không có mã kệ này!");
                loadDuLieuNV();
                clear();
            }
            databindings();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
            }
            else
            {
                string cauLenh = "select count(*) from nhanvien where manv = '" + textBox1.Text + "'";
                if (dt.KTTT(cauLenh))
                {
                    if (suaNhanVien())
                        MessageBox.Show("Sửa thành công!");
                    else MessageBox.Show("Sửa thất bại!");
                }
                else MessageBox.Show("Không có mã nhân viên này!");
                loadDuLieuNV();
                clear();
            }
            databindings();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadDuLieuNV();
            databindings();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query;
            string text = txtSearch.Text;
            if (cbBoLoc.SelectedIndex == 0)
            {
                query = "select * from nhanvien where TENNV like N'%" + text + "%'";
                dt.loadDuLieu(query, dataGridView1);

            }
            else if (cbBoLoc.SelectedIndex == 1)
            {
                query = "select * from nhanvien where MANV like '%" + text + "%'";
                dt.loadDuLieu(query, dataGridView1);


            }
            databindings();
        }
        void databindings()
        {
            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            textBox3.DataBindings.Clear();
            textBox4.DataBindings.Clear();
            textBox5.DataBindings.Clear();

            textBox1.DataBindings.Add("Text", dataGridView1.DataSource, "manv");
            textBox2.DataBindings.Add("Text", dataGridView1.DataSource, "tennv");
            textBox3.DataBindings.Add("Text", dataGridView1.DataSource, "gioitinh");
            textBox4.DataBindings.Add("Text", dataGridView1.DataSource, "lienhe");
            textBox5.DataBindings.Add("Text", dataGridView1.DataSource, "cccd");


        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

       
    }
}
