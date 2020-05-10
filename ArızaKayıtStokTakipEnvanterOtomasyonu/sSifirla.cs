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
    public partial class sSifirla : Form
    {
        public sSifirla()
        {
            InitializeComponent();
        }
        SqlConnection bagla = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
            System.Windows.Forms.Application.StartupPath + "\\veri.mdf;Integrated Security=True;Connect Timeout=30");
        private void sSifirla_Load(object sender, EventArgs e)
        {
            Random rastgele = new Random();
            int sayi = rastgele.Next(1000, 9999);
            label4.Text = Convert.ToString(sayi);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Lütfen Bilgilerinizi Eksiksiz Giriniz..!");
                    textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = "";
                }
                else
                {
                    if (textBox4.Text == label4.Text)
                    {
                        bagla.Open();
                        SqlCommand loginName = new SqlCommand("SELECT count(*) FROM Kullanici WHERE kadi=@kadi AND email=@mail", bagla);
                        loginName.Parameters.AddWithValue("@kadi", textBox1.Text);
                        loginName.Parameters.AddWithValue("@mail", textBox2.Text);
                        Int32 count = (Int32)loginName.ExecuteScalar();
                        bagla.Close();
                        if (count > 0)
                        {
                            bagla.Open();
                            string guncelle = "Update Kullanici Set sifre=@newpass Where kadi=@kadi And email=@mail";
                            SqlCommand update = new SqlCommand(guncelle, bagla);
                            update.Parameters.AddWithValue("@kadi", textBox1.Text);
                            update.Parameters.AddWithValue("@mail", textBox2.Text);
                            update.Parameters.AddWithValue("@newpass", textBox3.Text);
                            update.ExecuteNonQuery();
                            bagla.Close();
                            MessageBox.Show("Şifreniz Başarıyla Değiştirildi");
                            this.Close();
                            Giris gec = new Giris();
                            gec.Show();
                        }
                        else
                            MessageBox.Show("Lütfen Bilgilerinizi Doğru Girdiğinizden Emin Olun..!");
                    }
                    else
                        MessageBox.Show("Lütfen Doğrulama Kodunu Doğru Girdiğinizden Emin Olun");
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show("Başarısız" + hata);
            }
        }
    }
}
