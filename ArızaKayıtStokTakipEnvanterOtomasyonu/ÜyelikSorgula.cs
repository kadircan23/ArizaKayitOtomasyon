using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ArızaKayıtStokTakipEnvanterOtomasyonu
{
    public partial class ÜyelikSorgula : Form
    {
        public ÜyelikSorgula()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
            System.Windows.Forms.Application.StartupPath + "\\veri.mdf;Integrated Security=True;Connect Timeout=30");
        private void ÜyelikSorgula_Load(object sender, EventArgs e)
        {
            dataGridView2.Hide();
            string tab = "select * from Kullanici";
            con.Open();
            SqlCommand sorgu = new SqlCommand(tab, con);
            SqlDataAdapter rw = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            rw.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            dataGridView1.Hide();
            string tab2 = "select count(*) from Kullanici Where kadi='" + textBox1.Text + "'";
            SqlCommand sorgu2 = new SqlCommand(tab2, con);
            Int32 count = (Int32)sorgu2.ExecuteScalar();
            if (count > 0)
            {
                string tab3 = "select * from Kullanici Where kadi=@a";
                SqlCommand sorgu3 = new SqlCommand(tab3, con);
                sorgu3.Parameters.AddWithValue("@a", textBox1.Text);
                DataTable dt = new DataTable();
                SqlDataAdapter rw = new SqlDataAdapter(sorgu3);
                rw.Fill(dt);
                dataGridView2.DataSource = dt;
                dataGridView2.Show();
            }
            else
            {
                MessageBox.Show("Kayıt Bulunamadı?");
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Yönetici dön = new Yönetici();
            dön.Show();
            this.Close();
        }
    }
}
