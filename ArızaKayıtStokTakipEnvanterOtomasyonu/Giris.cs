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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        public static string ad;
        SqlConnection bagla = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
            System.Windows.Forms.Application.StartupPath + "\\veri.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
            Ana gec = new Ana();
            bagla.Open();
            SqlCommand loginName = new SqlCommand("select count(*) from Kullanici where kadi=@kulAdi and sifre=@parola", bagla);
            loginName.Parameters.AddWithValue("@kulAdi", textBox1.Text);
            loginName.Parameters.AddWithValue("@parola", textBox2.Text);
            Int32 count = (Int32)loginName.ExecuteScalar();
            bagla.Close();
            if (count > 0)
            {
                ad = textBox1.Text;
                this.Hide();
                gec.Show();
            }
            else
                MessageBox.Show("hatalı giriş");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sSifirla gecis1 = new sSifirla();
            gecis1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hOlustur gecis2 = new hOlustur();
            gecis2.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            this.Hide();
        }

        private void Giris_Load(object sender, EventArgs e)
        {

        }
    }
}
