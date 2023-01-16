using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_THUVIEN
{
    public partial class frmDN : Form
    {
        public frmDN()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDN_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Thoát chương trình?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "1" && textBox2.Text == "1")
            {
                mainForm f = new mainForm();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else if(string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Chưa nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Sai tài khoản/ mật khẩu đăng nhập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
    }
}
