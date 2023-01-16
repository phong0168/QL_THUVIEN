using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace QL_THUVIEN
{
    public class KetNoiSql
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-DA7RA70\\PHONG;Initial Catalog=ql_thuvien;Integrated Security=True");

        public SqlConnection Conn { get => conn; set => conn = value; }

        public KetNoiSql()
        {

        }
        public void loadDuLieu(string cauLenh, DataGridView dataGridView)
        {

            if (Conn.State == ConnectionState.Closed)
            {
                Conn.Open();
            }
           
            SqlCommand sqlCommand = new SqlCommand(cauLenh, Conn);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            adapter.Fill(data);
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
            dataGridView.DataSource = data;
        }
        

        //Hàm kiểm tra khóa chính
        public bool KTKC(string cauLenh)
        {
            try
            {
                if (Conn.State == System.Data.ConnectionState.Closed)
                {
                    Conn.Open();
                }
                SqlCommand cmd = new SqlCommand(cauLenh, Conn);
                int ketQua = (int)cmd.ExecuteScalar();
                if (Conn.State == System.Data.ConnectionState.Open)
                {
                    Conn.Close();
                }
                if (ketQua > 0)
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }

        }
        public bool getQuery(string cauLenh)
        {
            try
            {
                if (Conn.State == System.Data.ConnectionState.Closed)
                {
                    Conn.Open();
                }
                SqlCommand cmd = new SqlCommand(cauLenh, Conn);
                cmd.ExecuteNonQuery();
                if (Conn.State == System.Data.ConnectionState.Open)
                {
                    Conn.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool KTTT(string cauLenh)
        {
            try
            {
                if (Conn.State == System.Data.ConnectionState.Closed)
                {
                    Conn.Open();
                }
                SqlCommand cmd = new SqlCommand(cauLenh, Conn);
                int ketQua = (int)cmd.ExecuteScalar();
                if (Conn.State == System.Data.ConnectionState.Open)
                {
                    Conn.Close();
                }
                if (ketQua > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }

        }


    }
}
