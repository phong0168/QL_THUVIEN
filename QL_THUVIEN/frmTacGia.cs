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
    public partial class frmTacGia : Form
    {
        KetNoiSql dt = new KetNoiSql();
        public frmTacGia()
        {
            InitializeComponent();
            loadDuLieuTacGia();
        }
        void loadDuLieuTacGia()
        {
            string cauLenh = "select * from tacgia";
            dt.loadDuLieu(cauLenh, dataGridView1);
        }
        void clear()
        {
            textBox1.ResetText();
            textBox2.ResetText();
            textBox3.ResetText();
        }
        bool themTacGia()
        {
            string cauLenh = "insert into TACGIA values('" + textBox1.Text + "', N'" + textBox2.Text + "', N'" + textBox3.Text + "')";
            if (dt.getQuery(cauLenh))
                return true;
            else
                return false;
        }
        bool xoaTacGia()
        {
            string cauLenh = "delete tacgia where matg = '" + textBox1.Text + "'";
            if (dt.getQuery(cauLenh))
                return true;
            else
                return false;
        }
        bool suaTacGia()
        {
            string cauLenh = "update tacgia set tentg = N'" + textBox2.Text + "', diachi = N'" + textBox3.Text + "' where MATG = '" + textBox1.Text + "'";
            if (dt.getQuery(cauLenh))
                return true;
            else
                return false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
            }
            else
            {

                string cauLenh = "select count(*) from tacgia where matg = '" + textBox1.Text + "'";
                if (dt.KTKC(cauLenh))
                {
                    if (themTacGia())
                        MessageBox.Show("Thêm thành công!");
                    else MessageBox.Show("Thêm thất bại!");
                }
                else
                    MessageBox.Show("Trùng khóa chính!");
                loadDuLieuTacGia();
                clear();
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Mã tác giả chưa được nhập!");
            }
            else
            {
                string cauLenh = "select count(*) from tacgia where MATG = '" + textBox1.Text + "'";
                if (dt.KTTT(cauLenh))
                {
                    if (xoaTacGia())
                        MessageBox.Show("Xóa thành công!");
                    else MessageBox.Show("Xóa thất bại, dữ liệu đang được sử dụng!");
                }
                else MessageBox.Show("Không có mã tác giả này!");
                loadDuLieuTacGia();
                clear();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
            }
            else
            {
                string cauLenh = "select count(*) from tacgia where MATG = '" + textBox1.Text + "'";
                if (dt.KTTT(cauLenh))
                {
                    if (suaTacGia())
                        MessageBox.Show("Sửa thành công!");
                    else MessageBox.Show("Sửa thất bại!");
                }
                else MessageBox.Show("Không có mã tác giả này!");
                loadDuLieuTacGia();
                clear();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadDuLieuTacGia();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query;
            string text = txtSearch.Text;
            if (cbBoLoc.SelectedIndex == 0)
            {
                query = "select * from tacgia where tentg like '%" + text + "%'";
                dt.loadDuLieu(query, dataGridView1);

            }
            else if (cbBoLoc.SelectedIndex == 1)
            {
                query = "select * from tacgia where matg like '%" + text + "%'";
                dt.loadDuLieu(query, dataGridView1);


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
