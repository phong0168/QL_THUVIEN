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
    public partial class frmDocGia : Form
    {
        KetNoiSql dt = new KetNoiSql();

        public frmDocGia()
        {
            InitializeComponent();
            loadDuLieuDocGia();
            databindings();
          
        }
        void loadDuLieuDocGia()
        {
            string cauLenh = "select * from DOCGIA";
            dt.loadDuLieu(cauLenh, dataGridView1);
        }

        

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(comboBox1.SelectedItem.ToString()) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(dateTimePicker1.Value.ToString("yyyyMMdd")))
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
            }
            else
            {

                string cauLenh = "select count(*) from DOCGIA where MADG = '" + textBox1.Text + "'";
                if (dt.KTKC(cauLenh))
                {
                    if (themDocGia())
                        MessageBox.Show("Thêm thành công!");
                    else MessageBox.Show("Thêm thất bại!");
                }
                else
                    MessageBox.Show("Trùng mã độc giả!");
                loadDuLieuDocGia();
                clear();
            }
            databindings();
        }
        bool themDocGia()
        {
            string cauLenh = "insert into DOCGIA values('" + textBox1.Text + "', N'" + textBox2.Text + "', '" + dateTimePicker1.Value.ToString("yyyyMMdd") + "', N'" + comboBox1.SelectedItem.ToString() + "', '" + textBox4.Text + "')";
            if (dt.getQuery(cauLenh))
                return true;
            else
                return false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Mã độc giả chưa được nhập!");
            }
            else
            {
                string cauLenh = "select count(*) from DOCGIA where MADG = '" + textBox1.Text + "'";
                if (dt.KTTT(cauLenh))
                {
                    if (xoaDocGia())
                        MessageBox.Show("Xóa thành công!");
                    else MessageBox.Show("Xóa thất bại, dữ liệu đang được sử dụng!");
                }
                else MessageBox.Show("Không có mã độc giả này!");
                loadDuLieuDocGia();
                clear();
            }
            databindings();

        }
        bool xoaDocGia()
        {
            string cauLenh = "delete DOCGIA where MADG = '" + textBox1.Text + "'";
            if (dt.getQuery(cauLenh))
                return true;
            else
                return false;
        }

        bool suaDocGia()
        {
            string cauLenh = "update DOCGIA set TENDG = N'" + textBox2.Text + "', NGAYSINH = '" + dateTimePicker1.Value.ToString("yyyyMMdd") + "', GIOITINH = N'" + comboBox1.SelectedItem.ToString() + "', LIENHE = '" + textBox4.Text + "' where MADG = '" + textBox1.Text + "'";
            if (dt.getQuery(cauLenh))
                return true;
            else
                return false;
        }

        void clear()
        {
            textBox1.ResetText();
            textBox2.ResetText();
            textBox4.ResetText();
            comboBox1.ResetText();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(comboBox1.SelectedItem.ToString()) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(dateTimePicker1.Value.ToString("yyyyMMdd")))
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
            }
            else
            {
                string cauLenh = "select count(*) from DOCGIA where MADG = '" + textBox1.Text + "'";
                if (dt.KTTT(cauLenh))
                {
                    if (suaDocGia())
                        MessageBox.Show("Sửa thành công!");
                    else MessageBox.Show("Sửa thất bại!");
                }
                else MessageBox.Show("Không có mã độc giả này!");
                loadDuLieuDocGia();
                clear();
            }
            databindings();


        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadDuLieuDocGia();
            databindings();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string query;
            string text = txtSearch.Text;
            if (cbBoLoc.SelectedIndex == 0)
            {
                query = "select * from DOCGIA where TENDG like N'%" + text + "%'";
                dt.loadDuLieu(query, dataGridView1);

            }
            else if (cbBoLoc.SelectedIndex == 1)
            {
                query = "select * from DOCGIA where MADG like '%" + text + "%'";
                dt.loadDuLieu(query, dataGridView1);
                

            }
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
            textBox4.DataBindings.Clear();
            dateTimePicker1.DataBindings.Clear();
            comboBox1.DataBindings.Clear();

            textBox1.DataBindings.Add("Text", dataGridView1.DataSource, "madg");
            textBox2.DataBindings.Add("Text", dataGridView1.DataSource, "tendg");
            textBox4.DataBindings.Add("Text", dataGridView1.DataSource, "lienhe");
            dateTimePicker1.DataBindings.Add("Text", dataGridView1.DataSource, "ngaysinh");
            comboBox1.DataBindings.Add("Text", dataGridView1.DataSource, "gioitinh");


        }
    }
}
