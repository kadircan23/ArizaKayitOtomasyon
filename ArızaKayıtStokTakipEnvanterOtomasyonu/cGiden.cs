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
    public partial class cGiden : Form
    {
        public cGiden()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
            System.Windows.Forms.Application.StartupPath + "\\veri.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
            string bul2 = "Select * From GelenCihaz WHere IstemNo=@bul";
            con.Open();
            SqlCommand al = new SqlCommand(bul2, con);
            al.Parameters.AddWithValue("@bul", textBox1.Text);
            SqlDataReader oku2;
            oku2 = al.ExecuteReader();
            if (oku2.Read() == true)
            {
                textBox5.Text = oku2["Bolum"].ToString();
                textBox6.Text = oku2["AltBirim"].ToString();
                textBox7.Text = oku2["cBilgi"].ToString();
                textBox8.Text = oku2["cSorun"].ToString();
                MessageBox.Show("Bulundu !");
                button2.Enabled = true;
            }
            else
            {
                MessageBox.Show("Bulunamadi!");
                button2.Enabled = false;
            }
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                groupBox1.Text = "Ram";
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                groupBox1.Text = "Hdd";
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                groupBox1.Text = "İşlemci";
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
            }
            if (comboBox1.SelectedIndex == 3)
            {
                groupBox1.Text = "Ana Kart";
                textBox2.Enabled = true;
                textBox3.Enabled = false;
                textBox4.Enabled = true;
            }
            if (comboBox1.SelectedIndex == 4)
            {
                groupBox1.Text = "Ekran Kartı";
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
            }
            if (comboBox1.SelectedIndex == 5)
            {
                groupBox1.Text = "Power";
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = false;
            }
            if (comboBox1.SelectedIndex == 6)
            {
                groupBox1.Text = "Bios Pili";
                textBox2.Enabled = true;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
            }
            if (comboBox1.SelectedIndex == 7)
            {
                groupBox1.Text = "Toner";
                textBox2.Enabled = true;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("Boş Satır");
                }
                else
                {
                    string varsa = "select count(RamSayisi) From StokSorgu";
                    string varmi = "select count(*) from Ram Where Marka=@mrk AND Bellek=@bllk AND Ozellik=@Ozllk";
                    string sil = "delete from Ram where Id=(select min(Id) From Ram Where Marka='" + textBox2.Text + "' AND Bellek='" + textBox3.Text + "' AND Ozellik='" + textBox4.Text + "')";
                    string cikar = "update StokSorgu set RamSayisi=RamSayisi-1";
                    string ekle = "insert into GidenCihaz(IstemNo,Degisen,Aciklama)values(@a,@b,@c)";
                    con.Open();
                    SqlCommand varmii = new SqlCommand(varmi, con);
                    SqlCommand varsas = new SqlCommand(varsa, con);
                    varmii.Parameters.AddWithValue("@mrk", textBox2.Text);
                    varmii.Parameters.AddWithValue("@bllk", textBox3.Text);
                    varmii.Parameters.AddWithValue("@ozllk", textBox4.Text);
                    Int32 saydir = (Int32)varsas.ExecuteScalar();
                    Int32 say = (Int32)varmii.ExecuteScalar();
                    con.Close();
                    if (say > 0 && saydir > 0)
                    {
                        con.Open();
                        SqlCommand silt = new SqlCommand(sil, con);
                        SqlCommand cikars = new SqlCommand(cikar, con);
                        SqlCommand yekle = new SqlCommand(ekle, con);
                        yekle.Parameters.AddWithValue("@a", textBox1.Text);
                        yekle.Parameters.AddWithValue("@b", comboBox1.Text);
                        yekle.Parameters.AddWithValue("@c", textBox9.Text);
                        yekle.ExecuteNonQuery();
                        silt.ExecuteNonQuery();
                        cikars.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Başarılı");
                    }
                    else
                        MessageBox.Show("Seçtiğiniz Ürün Stoklarımızda Bulunmamaktadır\n İşlem Başarısız");
                }
            }
            if (comboBox1.SelectedIndex == 1)
            {
                if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("Boş Satır");
                }
                else
                {
                    string varsa = "select count(HddSayisi) From StokSorgu";
                    string varmi = "select count(*) from Hdd Where Marka=@mrk AND Bellek=@bllk AND Ozellik=@Ozllk";
                    string sil = "delete from Hdd where Id=(select min(Id) From Hdd Where Marka='" + textBox2.Text + "' AND Bellek='" + textBox3.Text + "' AND Ozellik='" + textBox4.Text + "')";
                    string cikar = "update StokSorgu set HddSayisi=HddSayisi-1";
                    string ekle = "insert into GidenCihaz(IstemNo,Degisen,Aciklama)values(@a,@b,@c)";
                    con.Open();
                    SqlCommand varmii = new SqlCommand(varmi, con);
                    SqlCommand varsas = new SqlCommand(varsa, con);
                    varmii.Parameters.AddWithValue("@mrk", textBox2.Text);
                    varmii.Parameters.AddWithValue("@bllk", textBox3.Text);
                    varmii.Parameters.AddWithValue("@ozllk", textBox4.Text);
                    Int32 saydir = (Int32)varsas.ExecuteScalar();
                    Int32 say = (Int32)varmii.ExecuteScalar();
                    con.Close();
                    if (say > 0 && saydir > 0)
                    {
                        con.Open();
                        SqlCommand silt = new SqlCommand(sil, con);
                        SqlCommand cikars = new SqlCommand(cikar, con);
                        SqlCommand yekle = new SqlCommand(ekle, con);
                        yekle.Parameters.AddWithValue("@a", textBox1.Text);
                        yekle.Parameters.AddWithValue("@b", comboBox1.Text);
                        yekle.Parameters.AddWithValue("@c", textBox9.Text);
                        yekle.ExecuteNonQuery();
                        silt.ExecuteNonQuery();
                        cikars.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Başarılı");
                    }
                    else
                        MessageBox.Show("Seçtiğiniz Ürün Stoklarımızda Bulunmamaktadır\n İşlem Başarısız");
                }
            }
            if (comboBox1.SelectedIndex == 2)
            {
                if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("Boş Satır");
                }
                else
                {
                    string varsa = "select count(IslemciSayisi) From StokSorgu";
                    string varmi = "select count(*) from Islemci Where Marka=@mrk AND Bellek=@bllk AND Ozellik=@Ozllk";
                    string sil = "delete from Islemci where Id=(select min(Id) From Islemci Where Marka='" + textBox2.Text + "' AND Bellek='" + textBox3.Text + "' AND Ozellik='" + textBox4.Text + "')";
                    string cikar = "update StokSorgu set IslemciSayisi=IslemciSayisi-1";
                    string ekle = "insert into GidenCihaz(IstemNo,Degisen,Aciklama)values(@a,@b,@c)";
                    con.Open();
                    SqlCommand varmii = new SqlCommand(varmi, con);
                    SqlCommand varsas = new SqlCommand(varsa, con);
                    varmii.Parameters.AddWithValue("@mrk", textBox2.Text);
                    varmii.Parameters.AddWithValue("@bllk", textBox3.Text);
                    varmii.Parameters.AddWithValue("@ozllk", textBox4.Text);
                    Int32 saydir = (Int32)varsas.ExecuteScalar();
                    Int32 say = (Int32)varmii.ExecuteScalar();
                    con.Close();
                    if (say > 0 && saydir > 0)
                    {
                        con.Open();
                        SqlCommand silt = new SqlCommand(sil, con);
                        SqlCommand cikars = new SqlCommand(cikar, con);
                        SqlCommand yekle = new SqlCommand(ekle, con);
                        yekle.Parameters.AddWithValue("@a", textBox1.Text);
                        yekle.Parameters.AddWithValue("@b", comboBox1.Text);
                        yekle.Parameters.AddWithValue("@c", textBox9.Text);
                        yekle.ExecuteNonQuery();
                        silt.ExecuteNonQuery();
                        cikars.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Başarılı");
                    }
                    else
                        MessageBox.Show("Seçtiğiniz Ürün Stoklarımızda Bulunmamaktadır\n İşlem Başarısız");
                }
            }
            if (comboBox1.SelectedIndex == 3)
            {
                if (textBox2.Text == "" || textBox4.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("Boş Satır");
                }
                else
                {
                    string varsa = "select count(AnaKartSayisi) From StokSorgu";
                    string varmi = "select count(*) from AnaKart Where Marka=@mrk AND Ozellik=@Ozllk";
                    string sil = "delete from AnaKart where Id=(select min(Id) From AnaKart Where Marka='" + textBox2.Text + "' AND Ozellik='" + textBox4.Text + "')";
                    string cikar = "update StokSorgu set AnaKartSayisi=AnaKartSayisi-1";
                    string ekle = "insert into GidenCihaz(IstemNo,Degisen,Aciklama)values(@a,@b,@c)";
                    con.Open();
                    SqlCommand varmii = new SqlCommand(varmi, con);
                    SqlCommand varsas = new SqlCommand(varsa, con);
                    varmii.Parameters.AddWithValue("@mrk", textBox2.Text);
                    varmii.Parameters.AddWithValue("@ozllk", textBox4.Text);
                    Int32 saydir = (Int32)varsas.ExecuteScalar();
                    Int32 say = (Int32)varmii.ExecuteScalar();
                    con.Close();
                    if (say > 0 && saydir > 0)
                    {
                        con.Open();
                        SqlCommand silt = new SqlCommand(sil, con);
                        SqlCommand cikars = new SqlCommand(cikar, con);
                        SqlCommand yekle = new SqlCommand(ekle, con);
                        yekle.Parameters.AddWithValue("@a", textBox1.Text);
                        yekle.Parameters.AddWithValue("@b", comboBox1.Text);
                        yekle.Parameters.AddWithValue("@c", textBox9.Text);
                        yekle.ExecuteNonQuery();
                        silt.ExecuteNonQuery();
                        cikars.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Başarılı");
                    }
                    else
                        MessageBox.Show("Seçtiğiniz Ürün Stoklarımızda Bulunmamaktadır\n İşlem Başarısız");
                }
            }
            if (comboBox1.SelectedIndex == 4)
            {
                if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("Boş Satır");
                }
                else
                {
                    string varsa = "select count(EkranKarti) From StokSorgu";
                    string varmi = "select count(*) from EkranKarti Where Marka=@mrk AND Bellek=@bllk AND Ozellik=@Ozllk";
                    string sil = "delete from EkranKarti where Id=(select min(Id) From EkranKarti Where Marka='" + textBox2.Text + "' AND Bellek='" + textBox3.Text + "' AND Ozellik='" + textBox4.Text + "')";
                    string cikar = "update StokSorgu set EkranKarti=EkranKarti-1";
                    string ekle = "insert into GidenCihaz(IstemNo,Degisen,Aciklama)values(@a,@b,@c)";
                    con.Open();
                    SqlCommand varmii = new SqlCommand(varmi, con);
                    SqlCommand varsas = new SqlCommand(varsa, con);
                    varmii.Parameters.AddWithValue("@mrk", textBox2.Text);
                    varmii.Parameters.AddWithValue("@bllk", textBox3.Text);
                    varmii.Parameters.AddWithValue("@ozllk", textBox4.Text);
                    Int32 saydir = (Int32)varsas.ExecuteScalar();
                    Int32 say = (Int32)varmii.ExecuteScalar();
                    con.Close();
                    if (say > 0 && saydir > 0)
                    {
                        con.Open();
                        SqlCommand silt = new SqlCommand(sil, con);
                        SqlCommand cikars = new SqlCommand(cikar, con);
                        SqlCommand yekle = new SqlCommand(ekle, con);
                        yekle.Parameters.AddWithValue("@a", textBox1.Text);
                        yekle.Parameters.AddWithValue("@b", comboBox1.Text);
                        yekle.Parameters.AddWithValue("@c", textBox9.Text);
                        yekle.ExecuteNonQuery();
                        silt.ExecuteNonQuery();
                        cikars.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Başarılı");
                    }
                    else
                        MessageBox.Show("Seçtiğiniz Ürün Stoklarımızda Bulunmamaktadır\n İşlem Başarısız");
                }
            }
            if (comboBox1.SelectedIndex == 5)
            {
                if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("Boş Satır");
                }
                else
                {
                    string varsa = "select count(PowerSayisi) From StokSorgu";
                    string varmi = "select count(*) from Power Where Marka=@mrk AND Ozellik=@Ozllk";
                    string sil = "delete from Power where Id=(select min(Id) From Power Where Marka='" + textBox2.Text + "' AND Ozellik='" + textBox4.Text + "')";
                    string cikar = "update StokSorgu set PowerSayisi=PowerSayisi-1";
                    string ekle = "insert into GidenCihaz(IstemNo,Degisen,Aciklama)values(@a,@b,@c)";
                    con.Open();
                    SqlCommand varmii = new SqlCommand(varmi, con);
                    SqlCommand varsas = new SqlCommand(varsa, con);
                    varmii.Parameters.AddWithValue("@mrk", textBox2.Text);
                    varmii.Parameters.AddWithValue("@ozllk", textBox4.Text);
                    Int32 saydir = (Int32)varsas.ExecuteScalar();
                    Int32 say = (Int32)varmii.ExecuteScalar();
                    con.Close();
                    if (say > 0 && saydir > 0)
                    {
                        con.Open();
                        SqlCommand silt = new SqlCommand(sil, con);
                        SqlCommand cikars = new SqlCommand(cikar, con);
                        SqlCommand yekle = new SqlCommand(ekle, con);
                        yekle.Parameters.AddWithValue("@a", textBox1.Text);
                        yekle.Parameters.AddWithValue("@b", comboBox1.Text);
                        yekle.Parameters.AddWithValue("@c", textBox9.Text);
                        yekle.ExecuteNonQuery();
                        silt.ExecuteNonQuery();
                        cikars.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Başarılı");
                    }
                    else
                        MessageBox.Show("Seçtiğiniz Ürün Stoklarımızda Bulunmamaktadır\n İşlem Başarısız");
                }
            }
            if (comboBox1.SelectedIndex == 6)
            {
                if (textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("Boş Satır");
                }
                else
                {
                    string varsa = "select count(BiosPilSayisi) From StokSorgu";
                    string varmi = "select count(*) from BiosPil Where Marka=@mrk";
                    string sil = "delete from Bios where Id=(select min(Id) From Bios Where Marka='" + textBox2.Text + "')";
                    string cikar = "update StokSorgu set BiosPİlSayisi=BiosPilSayisi-1";
                    string ekle = "insert into GidenCihaz(IstemNo,Degisen,Aciklama)values(@a,@b,@c)";
                    con.Open();
                    SqlCommand varmii = new SqlCommand(varmi, con);
                    SqlCommand varsas = new SqlCommand(varsa, con);
                    varmii.Parameters.AddWithValue("@mrk", textBox2.Text);
                    Int32 saydir = (Int32)varsas.ExecuteScalar();
                    Int32 say = (Int32)varmii.ExecuteScalar();
                    con.Close();
                    if (say > 0 && saydir > 0)
                    {
                        con.Open();
                        SqlCommand silt = new SqlCommand(sil, con);
                        SqlCommand cikars = new SqlCommand(cikar, con);
                        SqlCommand yekle = new SqlCommand(ekle, con);
                        yekle.Parameters.AddWithValue("@a", textBox1.Text);
                        yekle.Parameters.AddWithValue("@b", comboBox1.Text);
                        yekle.Parameters.AddWithValue("@c", textBox9.Text);
                        yekle.ExecuteNonQuery();
                        silt.ExecuteNonQuery();
                        cikars.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Başarılı");
                    }
                    else
                        MessageBox.Show("Seçtiğiniz Ürün Stoklarımızda Bulunmamaktadır\n İşlem Başarısız");
                }
            }
            if (comboBox1.SelectedIndex == 7)
            {
                if (textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("Boş Satır");
                }
                else
                {
                    string varsa = "select count(Tonersayisi) From StokSorgu";
                    string varmi = "select count(*) from Toner Where Marka=@mrk";
                    string sil = "delete from Toner where Id=(select min(Id) From Toner Where Marka='" + textBox2.Text + "')";
                    string cikar = "update StokSorgu set TonerSayisi=TonerSayisi-1";
                    string ekle = "insert into GidenCihaz(IstemNo,Degisen,Aciklama)values(@a,@b,@c)";
                    con.Open();
                    SqlCommand varmii = new SqlCommand(varmi, con);
                    SqlCommand varsas = new SqlCommand(varsa, con);
                    varmii.Parameters.AddWithValue("@mrk", textBox2.Text);
                    Int32 saydir = (Int32)varsas.ExecuteScalar();
                    Int32 say = (Int32)varmii.ExecuteScalar();
                    con.Close();
                    if (say > 0 && saydir > 0)
                    {
                        con.Open();
                        SqlCommand silt = new SqlCommand(sil, con);
                        SqlCommand cikars = new SqlCommand(cikar, con);
                        SqlCommand yekle = new SqlCommand(ekle, con);
                        yekle.Parameters.AddWithValue("@a", textBox1.Text);
                        yekle.Parameters.AddWithValue("@b", comboBox1.Text);
                        yekle.Parameters.AddWithValue("@c", textBox9.Text);
                        yekle.ExecuteNonQuery();
                        silt.ExecuteNonQuery();
                        cikars.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Başarılı");
                    }
                    else
                        MessageBox.Show("Seçtiğiniz Ürün Stoklarımızda Bulunmamaktadır\n İşlem Başarısız");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ana gec = new Ana();
            gec.Show();
            this.Close();
        }

        private void CGiden_Load(object sender, EventArgs e)
        {

        }
    }
}
