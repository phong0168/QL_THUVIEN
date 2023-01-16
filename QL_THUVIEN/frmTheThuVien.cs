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
    public partial class frmTheThuVien : Form
    {
        KetNoiSql dt = new KetNoiSql();

        public frmTheThuVien()
        {
            InitializeComponent();
            loadCBDG();
            loadDuLieuThe();
            databindings();
        }
        void loadDuLieuThe()
        {
            string cauLenh = "select mathe, tendg, ngaybd, ngaykt, ghichu from THETHUVIEN, DOCGIA where THETHUVIEN.MADG = DOCGIA.MADG";
            dt.loadDuLieu(cauLenh, dataGridView1);
        }

        void databindings()
        {
            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            comboBox1.DataBindings.Clear();
            dateTimePicker1.DataBindings.Clear();
            dateTimePicker2.DataBindings.Clear();
            textBox1.DataBindings.Add("Text", dataGridView1.DataSource, "mathe");
            textBox2.DataBindings.Add("Text", dataGridView1.DataSource, "ghichu");
            comboBox1.DataBindings.Add("Text", dataGridView1.DataSource, "tendg");
            dateTimePicker1.DataBindings.Add("Text", dataGridView1.DataSource, "ngaybd");
            dateTimePicker2.DataBindings.Add("Text", dataGridView1.DataSource, "ngaykt");




        }
        void loadCBDG()
        {
            dt.Conn.Open();
            DataTable data = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from docgia", dt.Conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(data);
            dt.Conn.Close();
            comboBox1.DataSource = data;
            comboBox1.DisplayMember = "tendg";
            comboBox1.ValueMember = "madg";
        }
        bool themThe()
        {
            string cauLenh = "insert into thethuvien values('" + textBox1.Text + "', '" + comboBox1.SelectedValue.ToString() + "', '" + dateTimePicker1.Value.ToString("yyyyMMdd") + "', '"+ dateTimePicker2.Value.ToString("yyyyMMdd") + "', N'"+textBox2.Text+"')";
            if (dt.getQuery(cauLenh))
                return true;
            else
                return false;
        }
        bool xoaThe()
        {
            string cauLenh = "delete thethuvien where mathe = '" + textBox1.Text + "'";
            if (dt.getQuery(cauLenh))
                return true;
            else
                return false;
        }
        bool suaThe()
        {
            string cauLenh = "update thethuvien set madg = '" + comboBox1.SelectedValue.ToString() + "', ngaybd = '" + dateTimePicker1.Value.ToString("yyyyMMdd") + "', ngaykt = '" + dateTimePicker2.Value.ToString("yyyyMMdd") + "', ghichu = N'"+textBox2.Text+"' where mathe = '" + textBox1.Text + "'";
            if (dt.getQuery(cauLenh))
                return true;
            else
                return false;
        }
        void clear()
        {
            textBox1.ResetText();
            textBox2.ResetText();
            comboBox1.ResetText();
            dateTimePicker1.ResetText();
            dateTimePicker2.ResetText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadDuLieuThe();
            databindings();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(dateTimePicker1.Text) || string.IsNullOrEmpty(dateTimePicker2.Text))
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
            }
            else
            {

                string cauLenh = "select count(*) from thethuvien where mathe = '" + textBox1.Text + "'";
                if (dt.KTKC(cauLenh))
                {
                    if (themThe())
                        MessageBox.Show("Thêm thành công!");
                    else MessageBox.Show("Thêm thất bại!");
                }
                else
                    MessageBox.Show("Trùng mã thẻ!");
                loadDuLieuThe();
                clear();

            }
            databindings();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(dateTimePicker1.Text) || string.IsNullOrEmpty(dateTimePicker2.Text))
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!");
            }
            else
            {
                string cauLenh = "select count(*) from thethuvien where mathe = '" + textBox1.Text + "'";
                if (dt.KTTT(cauLenh))
                {
                    if (suaThe())
                        MessageBox.Show("Sửa thành công!");
                    else MessageBox.Show("Sửa thất bại!");
                }
                else MessageBox.Show("Không có mã thẻ này!");
                loadDuLieuThe();
                clear();
                databindings();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query;
            string text = txtSearch.Text;
            if (cbBoLoc.SelectedIndex == 0)
            {
                query = "select mathe, tendg, ngaybd, ngaykt, ghichu from THETHUVIEN, DOCGIA where THETHUVIEN.MADG = DOCGIA.MADG and TENDG like N'%" + text + "%'";
                dt.loadDuLieu(query, dataGridView1);

            }
            else if (cbBoLoc.SelectedIndex == 1)
            {
                query = "select mathe, tendg, ngaybd, ngaykt, ghichu from THETHUVIEN, DOCGIA where THETHUVIEN.MADG = DOCGIA.MADG and mathe like '%" + text + "%'";

                dt.loadDuLieu(query, dataGridView1);

            }
            databindings();

        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Mã thẻ chưa được nhập!");
            }
            else
            {
                string cauLenh = "select count(*) from thethuvien where mathe = '" + textBox1.Text + "'";
                if (dt.KTTT(cauLenh))
                {
                    if (xoaThe())
                        MessageBox.Show("Xóa thành công!");
                    else MessageBox.Show("Xóa thất bại, dữ liệu đang được sử dụng!");
                }
                else MessageBox.Show("Không có mã thẻ này!");
                loadDuLieuThe();
                clear();
            }
            databindings();

        }

       
    }
}
