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
    public partial class ÜyelikBilgileriniGüncelle : Form
    {
        public ÜyelikBilgileriniGüncelle()
        {
            InitializeComponent();
        }
        SqlConnection bagla = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
            System.Windows.Forms.Application.StartupPath + "\\veri.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
            string bul = "Select * From Kullanici WHere kadi=@bul";
            bagla.Open();
            SqlCommand al = new SqlCommand(bul, bagla);
            al.Parameters.AddWithValue("@bul", textBox3.Text);
            SqlDataReader oku;
            oku = al.ExecuteReader();
            if (oku.Read() == true)
            {
                textBox1.Text = oku["ad"].ToString();
                textBox2.Text = oku["soyad"].ToString();
                textBox3.Text = oku["kadi"].ToString();
                textBox4.Text = oku["email"].ToString();
                textBox5.Text = oku["sifre"].ToString();
                button2.Visible = true;
                button3.Visible = true;
                MessageBox.Show("Bulundu !");
            }
            else
            {
                MessageBox.Show("Bulunamadi!");
                textBox3.Text = "";
            }
            bagla.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bagla.Open();
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "") { MessageBox.Show("Bos Alan Bırakma"); }
            else
            {
                string güncelle = "Update Kullanici Set ad=@a,soyad=@b,kadi=@c,email=@d,sifre=@e";
                SqlCommand Update = new SqlCommand(güncelle, bagla);
                Update.Parameters.AddWithValue("@a", textBox1.Text);
                Update.Parameters.AddWithValue("@b", textBox2.Text);
                Update.Parameters.AddWithValue("@c", textBox3.Text);
                Update.Parameters.AddWithValue("@d", textBox4.Text);
                Update.Parameters.AddWithValue("@e", textBox5.Text);
                Update.ExecuteNonQuery();
                MessageBox.Show(";)");
            }
            bagla.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bagla.Open();

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "") { MessageBox.Show("Bos Alan Bırakma"); }
            else
            {
                DialogResult yesno = new DialogResult();
                yesno = MessageBox.Show("Emin Misiniz ?", "Uyarı!!!", MessageBoxButtons.YesNo);
                if (yesno == DialogResult.Yes)
                {
                    string sil = "Delete  From Kullanici Where ad=@a AND (soyad=@b AND (kadi=@c AND (email=@d AND sifre=@e)))";
                    SqlCommand silme = new SqlCommand(sil, bagla);
                    silme.Parameters.AddWithValue("@a", textBox1.Text);
                    silme.Parameters.AddWithValue("@b", textBox2.Text);
                    silme.Parameters.AddWithValue("@c", textBox3.Text);
                    silme.Parameters.AddWithValue("@d", textBox4.Text);
                    silme.Parameters.AddWithValue("@e", textBox5.Text);
                    silme.ExecuteNonQuery();
                    MessageBox.Show("Silme Başarılı");
                }
            }
            bagla.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Yönetici g = new Yönetici();
            g.Show();
            this.Hide();

        }

        private void ÜyelikBilgileriniGüncelle_Load(object sender, EventArgs e)
        {

        }
    }
}
