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
    public partial class hOlustur : Form
    {
        public hOlustur()
        {
            InitializeComponent();
        }
        SqlConnection bagla = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
            System.Windows.Forms.Application.StartupPath + "\\veri.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
            bagla.Open();
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                {
                    MessageBox.Show("Lütfen Bilgilerinizi Eksiksiz Giriniz..!"); textBox1.Text = ""; textBox2.Text = ""; textBox3.Text = "";
                    textBox4.Text = ""; textBox5.Text = ""; textBox6.Text = "";
                }
                else
                {
                    string sorgu1 = "select count(*) from Kullanici where kadi=@kadi or email=@mail";
                    SqlCommand esas1 = new SqlCommand(sorgu1, bagla);
                    esas1.Parameters.AddWithValue("@kadi", textBox3.Text);
                    esas1.Parameters.AddWithValue("@mail", textBox5.Text);
                    Int32 count = (Int32)esas1.ExecuteScalar();
                    if (count > 0)
                    {

                        MessageBox.Show("Belirtilen Kullanıcı Adı veya E-mail Daha Öncede Kullanılmış..!");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                    }
                    else
                    {
                        string s, st;
                        s = textBox5.Text;
                        st = textBox6.Text;
                        if (s == st)
                        {
                            string kayit = "insert into Kullanici(ad,soyad,kadi,sifre,email) values (@ad,@soyad,@kadi,@sifre,@mail)";

                            SqlCommand komut = new SqlCommand(kayit, bagla);
                            komut.Parameters.AddWithValue("@ad", textBox1.Text);
                            komut.Parameters.AddWithValue("@soyad", textBox2.Text);
                            komut.Parameters.AddWithValue("@kadi", textBox3.Text);
                            komut.Parameters.AddWithValue("@mail", textBox4.Text);
                            komut.Parameters.AddWithValue("@sifre", textBox5.Text);
                            komut.ExecuteNonQuery();
                            MessageBox.Show("Kayıt Başarıyla Gerçekleştirildi..!");
                            Giris gec = new Giris();
                            gec.Show();
                            this.Close();
                        }
                    }
                }
            }

            catch (Exception hata)
            {
                MessageBox.Show("HATA" + hata);
            }
            bagla.Close();
        }

        private void HOlustur_Load(object sender, EventArgs e)
        {

        }
    }
}
