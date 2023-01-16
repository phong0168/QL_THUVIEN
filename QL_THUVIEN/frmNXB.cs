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
    public partial class frmNXB : Form
    {
        KetNoiSql dt = new KetNoiSql();
        public frmNXB()
        {
            InitializeComponent();
            loadDuLieuNXB();
        }
        void loadDuLieuNXB()
        {
            string cauLenh = "select * from nhaxuatban";
            dt.loadDuLieu(cauLenh, dataGridView1);
            databindings();
        }
        bool themNXB()
        {
            string cauLenh = "insert into nhaxuatban values('" + textBox1.Text + "', N'" + textBox2.Text + "', N'" + textBox3.Text + "', '" + Convert.ToInt32(textBox4.Text) + "')";
            if (dt.getQuery(cauLenh))
                return true;
            else
                return false;
        }
        bool xoaNXB()
        {
            string cauLenh = "delete nhaxuatban where manxb = '" + textBox1.Text + "'";
            if (dt.getQuery(cauLenh))
                return true;
            else
                return false;
        }
        bool suaNXB()
        {
            string cauLenh = "update nhaxuatban set tennxb = N'" + textBox2.Text + "', dcnxb = N'" + textBox3.Text + "', sdtnxb = '" + textBox4.Text + "'  where manxb = '" + textBox1.Text + "'";
            if (dt.getQuery(cauLenh))
                return true;
            else
                return false;
        }
        void databindings()
        {
            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            textBox3.DataBindings.Clear();
            textBox4.DataBindings.Clear();
            textBox1.DataBindings.Add("Text", dataGridView1.DataSource, "manxb");
            textBox2.DataBindings.Add("Text", dataGridView1.DataSource, "tennxb");
            textBox3.DataBindings.Add("Text", dataGridView1.DataSource, "dcnxb");
            textBox4.DataBindings.Add("Text", dataGridView1.DataSource, "sdtnxb");

        }

        void clear()
        {
            textBox1.ResetText();
            textBox2.ResetText();
            textBox3.ResetText();
            textBox4.ResetText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadDuLieuNXB();
            databindings();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
            }
            else
            {

                string cauLenh = "select count(*) from nhaxuatban where manxb = '" + textBox1.Text + "'";
                if (dt.KTKC(cauLenh))
                {
                    if (themNXB())
                        MessageBox.Show("Thêm thành công!");
                    else MessageBox.Show("Thêm thất bại!");
                }
                else
                    MessageBox.Show("Trùng mã nhà xuất bản!");
                loadDuLieuNXB();
                clear();
            }
            databindings();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Mã nhà xuất bản chưa được nhập!");
            }
            else
            {
                string cauLenh = "select count(*) from nhaxuatban where manxb = '" + textBox1.Text + "'";
                if (dt.KTTT(cauLenh))
                {
                    if (xoaNXB())
                        MessageBox.Show("Xóa thành công!");
                    else MessageBox.Show("Xóa thất bại, dữ liệu đang được sử dụng!");
                }
                else MessageBox.Show("Không có mã nhà xuất bản này!");
                loadDuLieuNXB();
                clear();
            }
            databindings();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
            }
            else
            {
                string cauLenh = "select count(*) from nhaxuatban where manxb = '" + textBox1.Text + "'";
                if (dt.KTTT(cauLenh))
                {
                    if (suaNXB())
                        MessageBox.Show("Sửa thành công!");
                    else MessageBox.Show("Sửa thất bại!");
                }
                else MessageBox.Show("Không có mã nhà xuất bản này!");
                loadDuLieuNXB();
                clear();
            }
            databindings();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query;
            string text = txtSearch.Text;
            if (cbBoLoc.SelectedIndex == 1)
            {
                query = "select * from nhaxuatban where tennxb like N'%" + text + "%'";
                dt.loadDuLieu(query, dataGridView1);
            }
            else if (cbBoLoc.SelectedIndex == 0)
            {
                query = "select * from nhaxuatban where manxb like '%" + text + "%'";
                dt.loadDuLieu(query, dataGridView1);
            }
            databindings();
        }

        private void frmNXB_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
