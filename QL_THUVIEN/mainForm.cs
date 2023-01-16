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
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThuVien f = new frmThuVien();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void độcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDocGia f = new frmDocGia();
            this.Hide();
            f.ShowDialog();
            this.Show();

        }

        private void thẻThưViệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTheThuVien f = new frmTheThuVien();
            this.Hide();
            f.ShowDialog();
            this.Show();

        }

        private void mượnTrảSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMuonTra f = new frmMuonTra();
            this.Hide();
            f.ShowDialog();
            this.Show();

        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanVien f = new frmNhanVien();
            this.Hide();
            f.ShowDialog();
            this.Show();

        }

        private void kệSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKe f = new frmKe();
            this.Hide();
            f.ShowDialog();
            this.Show();

        }

        private void loạiSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoaiSach f = new frmLoaiSach();
            this.Hide();
            f.ShowDialog();
            this.Show();

        }

        private void nhàXuấtBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNXB f = new frmNXB();
            this.Hide();
            f.ShowDialog();
            this.Show();


        }

        private void đGChưaTrảSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongKe f = new frmThongKe();
            this.Hide();
            f.ShowDialog();
            this.Show();

        }

     
    }
}
