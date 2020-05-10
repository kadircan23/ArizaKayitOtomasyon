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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        public static string ad_admin;
        SqlConnection bagla = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
            System.Windows.Forms.Application.StartupPath + "\\veri.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
            Ana gec = new Ana();
            bagla.Open();
            SqlCommand loginName = new SqlCommand("select count(*) from Cbu_Admin where Cbu_Nick=@kulAdi and Cbu_Pass=@parola", bagla);
            loginName.Parameters.AddWithValue("@kulAdi", textBox1.Text);
            loginName.Parameters.AddWithValue("@parola", textBox2.Text);
            Int32 count = (Int32)loginName.ExecuteScalar();
            bagla.Close();
            if (count > 0)
            {
                ad_admin = textBox1.Text;
                this.Hide();
                gec.Show();
            }
            else
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Giris uye = new Giris();
            uye.Show();
            this.Hide();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }
    }
}
