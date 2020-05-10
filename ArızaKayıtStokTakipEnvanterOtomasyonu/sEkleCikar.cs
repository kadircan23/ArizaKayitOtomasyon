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
    public partial class sEkleCikar : Form
    {
        public sEkleCikar()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
            System.Windows.Forms.Application.StartupPath + "\\veri.mdf;Integrated Security=True;Connect Timeout=30");
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
            }
            if (listBox1.SelectedIndex == 1)
            {
                textBox3.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
            }
            if (listBox1.SelectedIndex == 2)
            {
                textBox2.Enabled = true; textBox1.Enabled = true;
                textBox3.Enabled = false;
            }
            if (listBox1.SelectedIndex == 3)
            {
                textBox3.Enabled = false; textBox1.Enabled = true; textBox2.Enabled = true;
            }
            if (listBox1.SelectedIndex == 4)
            {
                textBox1.Enabled = true; textBox2.Enabled = true; textBox3.Enabled = true;
            }
            if (listBox1.SelectedIndex == 5)
            {
                textBox2.Enabled = true; textBox1.Enabled = true;
                textBox3.Enabled = true;
            }
            if (listBox1.SelectedIndex == 6)
            {
                textBox2.Enabled = false; textBox1.Enabled = true;
                textBox3.Enabled = false;
            }
            if (listBox1.SelectedIndex == 7)
            {
                textBox2.Enabled = false; textBox1.Enabled = true;
                textBox3.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || listBox1.Text == "") { MessageBox.Show("Boş Satır"); }
                else
                {
                    con.Open();
                    string ram = "insert into Ram(Ozellik,Marka,Bellek)values(@a,@b,@c)";
                    SqlCommand ramekle = new SqlCommand(ram, con);
                    ramekle.Parameters.AddWithValue("@a", textBox2.Text);
                    ramekle.Parameters.AddWithValue("@b", textBox1.Text);
                    ramekle.Parameters.AddWithValue("@c", textBox3.Text);
                    ramekle.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Başarılı");
                    con.Open();
                    string s1 = "Update StokSorgu Set RamSayisi=Ramsayisi+1";
                    SqlCommand s1e = new SqlCommand(s1, con);
                    s1e.ExecuteNonQuery();
                    con.Close();
                }
            }
            if (listBox1.SelectedIndex == 1)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || listBox1.Text == "") { MessageBox.Show("Boş Satır"); }
                else
                {
                    con.Open();
                    string hdd = "insert into Hdd(Ozellik,Marka,Bellek)values(@a,@b,@c)";
                    SqlCommand hddekle = new SqlCommand(hdd, con);
                    hddekle.Parameters.AddWithValue("@a", textBox2.Text);
                    hddekle.Parameters.AddWithValue("@c", textBox1.Text);
                    hddekle.Parameters.AddWithValue("@b", textBox3.Text);
                    hddekle.ExecuteNonQuery(); con.Close();
                    MessageBox.Show("Başarılı");
                    con.Open();
                    string s1 = "Update StokSorgu Set HddSayisi=HddSayisi+1";
                    SqlCommand s1e = new SqlCommand(s1, con);
                    s1e.ExecuteNonQuery(); con.Close();
                }
            }
            if (listBox1.SelectedIndex == 2)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || listBox1.Text == "") { MessageBox.Show("Boş Satır"); }
                else
                {
                    con.Open();
                    string power = "insert into Power(Ozellik,Marka)values(@a,@b)";
                    SqlCommand Poweekle = new SqlCommand(power, con);
                    Poweekle.Parameters.AddWithValue("@a", textBox2.Text);
                    Poweekle.Parameters.AddWithValue("@b", textBox1.Text);
                    Poweekle.ExecuteNonQuery(); con.Close();
                    MessageBox.Show("Başarılı");
                    con.Open();
                    string s1 = "Update StokSorgu Set PowerSayisi=PowerSayisi+1";
                    SqlCommand s1e = new SqlCommand(s1, con);
                    s1e.ExecuteNonQuery(); con.Close();
                }
            }
            if (listBox1.SelectedIndex == 3)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || listBox1.Text == "") { MessageBox.Show("Boş Satır"); }
                else
                {
                    con.Open();
                    string anakart = "insert into AnaKart(Ozellik,Marka)values(@a,@b)";
                    SqlCommand anakartekle = new SqlCommand(anakart, con);
                    anakartekle.Parameters.AddWithValue("@a", textBox2.Text);
                    anakartekle.Parameters.AddWithValue("@b", textBox1.Text);
                    anakartekle.ExecuteNonQuery(); con.Close();
                    MessageBox.Show("Başarılı");
                    con.Open();
                    string s1 = "Update StokSorgu Set AnaKartSayisi=AnaKartSayisi+1";
                    SqlCommand s1e = new SqlCommand(s1, con);
                    s1e.ExecuteNonQuery(); con.Close();
                }
            }
            if (listBox1.SelectedIndex == 4)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || listBox1.Text == "") { MessageBox.Show("Boş Satır"); }
                else
                {
                    con.Open();
                    string ekran = "insert into EkranKarti(Ozellik,Marka,Bellek)values(@a,@b,@c)";
                    SqlCommand ekranekle = new SqlCommand(ekran, con);
                    ekranekle.Parameters.AddWithValue("@a", textBox2.Text);
                    ekranekle.Parameters.AddWithValue("@b", textBox1.Text);
                    ekranekle.Parameters.AddWithValue("@c", textBox3.Text);
                    ekranekle.ExecuteNonQuery(); con.Close();
                    MessageBox.Show("Başarılı"); con.Open();
                    string s1 = "Update StokSorgu Set EkranKarti=EkranKarti+1";
                    SqlCommand s1e = new SqlCommand(s1, con);
                    s1e.ExecuteNonQuery(); con.Close();
                }
            }
            if (listBox1.SelectedIndex == 5)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || listBox1.Text == "") { MessageBox.Show("Boş Satır"); }
                else
                {
                    con.Open();
                    string islem = "insert into Islemci(Ozellik,Marka,Bellek)values(@a,@b,@c)";
                    SqlCommand islemci = new SqlCommand(islem, con);
                    islemci.Parameters.AddWithValue("@a", textBox2.Text);
                    islemci.Parameters.AddWithValue("@b", textBox1.Text);
                    islemci.Parameters.AddWithValue("@c", textBox3.Text);
                    islemci.ExecuteNonQuery(); con.Close();
                    MessageBox.Show("Başarılı");
                    con.Open();
                    string s1 = "Update StokSorgu Set IslemciSayisi=IslemciSayisi+1";
                    SqlCommand s1e = new SqlCommand(s1, con);
                    s1e.ExecuteNonQuery(); con.Close();
                }
            }

            if (listBox1.SelectedIndex == 6)
            {
                if (textBox1.Text == "" || listBox1.Text == "") { MessageBox.Show("Boş Satır"); }
                else
                {
                    con.Open();
                    string bios = "insert into BiosPil(Marka)values(@b)";
                    SqlCommand biosp = new SqlCommand(bios, con);
                    biosp.Parameters.AddWithValue("@b", textBox1.Text);
                    biosp.ExecuteNonQuery(); con.Close();
                    MessageBox.Show("Başarılı");
                    con.Open();
                    string s1 = "Update StokSorgu Set BiosPilSayisi=BiosPilSayisi+1";
                    SqlCommand s1e = new SqlCommand(s1, con);
                    s1e.ExecuteNonQuery(); con.Close();
                }
            }
            if (listBox1.SelectedIndex == 7)
            {
                if (textBox1.Text == "" || listBox1.Text == "") { MessageBox.Show("Boş Satır"); }
                else
                {
                    con.Open();
                    string toner = "insert into Toner(Marka)values(@b)";
                    SqlCommand tonerekle = new SqlCommand(toner, con);
                    tonerekle.Parameters.AddWithValue("@b", textBox1.Text);
                    tonerekle.ExecuteNonQuery(); con.Close();
                    MessageBox.Show("Başarılı");
                    con.Open();
                    string s1 = "Update StokSorgu Set TonerSayisi=TonerSayisi+1";
                    SqlCommand s1e = new SqlCommand(s1, con);
                    s1e.ExecuteNonQuery(); con.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndex == 0)
                {
                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                    {
                        MessageBox.Show("Boş Satır");
                    }
                    else
                    {
                        string varsa = "select count(*) from Ram Where Marka=@mrk AND Ozellik=@ozllk AND Bellek=@bllk";
                        string yoksa = "Delete From Ram Where Id=(Select min(Id) From Ram Where Marka='" + textBox1.Text + "' AND (Ozellik='" + textBox2.Text + "' AND Bellek='" + textBox3.Text + "'))";
                        string varsas = "Select count(RamSayisi) from StokSorgu ";
                        string yoksasdus = "Update StokSorgu Set RamSayisi=RamSayisi-1";
                        con.Open();
                        SqlCommand bak = new SqlCommand(varsa, con);
                        bak.Parameters.AddWithValue("@mrk", textBox1.Text);
                        bak.Parameters.AddWithValue("@ozllk", textBox2.Text);
                        bak.Parameters.AddWithValue("@bllk", textBox3.Text);
                        Int32 say = (Int32)bak.ExecuteScalar();//marka bellek ve özelliklere sahip olan ram saydırma
                        SqlCommand bakbi = new SqlCommand(varsas, con);//stok sorgu tablosunda değer 0 dan büyük ise 
                        Int32 saydir = (Int32)bakbi.ExecuteScalar();// ss değer saydırma
                        con.Close();
                        if (0<say&&0<saydir)// kosullar
                        {
                            con.Open();
                            SqlCommand cikar = new SqlCommand(yoksa, con);
                            SqlCommand dus = new SqlCommand(yoksasdus, con);
                            dus.ExecuteNonQuery();
                            cikar.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Başarılı");
                        }
                        else
                            MessageBox.Show("Seçtiğiniz Ürün Stoklarımızda Bulunmamaktadır.\n İşlem Başarısız");
                    }
                }
                if (listBox1.SelectedIndex == 1)
                {
                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                    {
                        MessageBox.Show("Boş Satır");
                    }
                    else
                    {
                        string varsa = "select count(*) from Hdd Where Marka=@mrk AND Ozellik=@ozllk AND Bellek=@bllk";
                        string yoksa = "Delete From Hdd Where Id=(Select min(Id) From Hdd Where Marka='" + textBox1.Text + "' AND (Ozellik='" + textBox2.Text + "' AND Bellek='" + textBox3.Text + "'))";
                        string varsas = "Select count(HddSayisi) from StokSorgu ";
                        string yoksasdus = "Update StokSorgu Set HddSayisi=HddSayisi-1";
                        con.Open();
                        SqlCommand bak = new SqlCommand(varsa, con);
                        bak.Parameters.AddWithValue("@mrk", textBox1.Text);
                        bak.Parameters.AddWithValue("@ozllk", textBox2.Text);
                        bak.Parameters.AddWithValue("@bllk", textBox3.Text);
                        Int32 say = (Int32)bak.ExecuteScalar();//marka bellek ve özelliklere sahip olan HDD saydırma
                        SqlCommand bakbi = new SqlCommand(varsas, con);//stok sorgu tablosunda değer 0 dan büyük ise 
                        Int32 saydir = (Int32)bakbi.ExecuteScalar();// ss değer saydırma
                        con.Close();
                        if (say > 0 && saydir > 0)// kosullar
                        {
                            con.Open();
                            SqlCommand cikar = new SqlCommand(yoksa, con);
                            SqlCommand dus = new SqlCommand(yoksasdus, con);
                            dus.ExecuteNonQuery();
                            cikar.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Başarılı");
                        }
                        else
                            MessageBox.Show("Seçtiğiniz Ürün Stoklarımızda Bulunmamaktadır.\n İşlem Başarısız");
                    }
                }
                if (listBox1.SelectedIndex == 2)
                {
                    if (textBox1.Text == "" || textBox2.Text == "")
                    {
                        MessageBox.Show("Boş Satır");
                    }
                    else
                    {
                        string varsa = "select count(*) from Power Where Marka=@mrk AND Ozellik=@ozllk";
                        string yoksa = "Delete From Ram Where Id=(Select min(Id) From Power Where Marka='" + textBox1.Text + "' AND Ozellik='" + textBox2.Text + "') ";
                        string varsas = "Select count(PowerSayisi) from StokSorgu ";
                        string yoksasdus = "Update StokSorgu Set PowerSayisi=PowerSayisi-1";
                        con.Open();
                        SqlCommand bak = new SqlCommand(varsa, con);
                        bak.Parameters.AddWithValue("@mrk", textBox1.Text);
                        bak.Parameters.AddWithValue("@ozllk", textBox2.Text);
                        Int32 say = (Int32)bak.ExecuteScalar();//marka  ve özelliklere sahip olan power saydırma
                        SqlCommand bakbi = new SqlCommand(varsas, con);//stok sorgu tablosunda değer 0 dan büyük ise 
                        Int32 saydir = (Int32)bakbi.ExecuteScalar();// ss değer saydırma
                        con.Close();
                        if (say > 0 && saydir > 0)// kosullar
                        {
                            con.Open();
                            SqlCommand cikar = new SqlCommand(yoksa, con);
                            SqlCommand dus = new SqlCommand(yoksasdus, con);
                            dus.ExecuteNonQuery();
                            cikar.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Başarılı");
                        }
                        else
                            MessageBox.Show("Seçtiğiniz Ürün Stoklarımızda Bulunmamaktadır.\n İşlem Başarısız");
                    }
                }
                if (listBox1.SelectedIndex == 3)
                {
                    if (textBox1.Text == "" || textBox2.Text == "")
                    {
                        MessageBox.Show("Boş Satır");
                    }
                    else
                    {
                        string varsa = "select count(*) from AnaKart Where Marka=@mrk AND Ozellik=@ozllk";
                        string yoksa = "Delete From AnaKart Where Id=(Select min(Id) From AnaKart Where Marka='" + textBox1.Text + "' AND Ozellik='" + textBox2.Text + "')";
                        string varsas = "Select count(AnaKartSayisi) from StokSorgu ";
                        string yoksasdus = "Update StokSorgu Set AnaKartSayisi=AnaKartSayisi-1";
                        con.Open();
                        SqlCommand bak = new SqlCommand(varsa, con);
                        bak.Parameters.AddWithValue("@mrk", textBox1.Text);
                        bak.Parameters.AddWithValue("@ozllk", textBox2.Text);
                        Int32 say = (Int32)bak.ExecuteScalar();//marka  ve özelliklere sahip olan Anakart saydırma
                        SqlCommand bakbi = new SqlCommand(varsas, con);//stok sorgu tablosunda değer 0 dan büyük ise 
                        Int32 saydir = (Int32)bakbi.ExecuteScalar();// ss değer saydırma
                        con.Close();
                        if (say > 0 && saydir > 0)// kosullar
                        {
                            con.Open();
                            SqlCommand cikar = new SqlCommand(yoksa, con);
                            SqlCommand dus = new SqlCommand(yoksasdus, con);
                            dus.ExecuteNonQuery();
                            cikar.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Başarılı");
                        }
                        else
                            MessageBox.Show("Seçtiğiniz Ürün Stoklarımızda Bulunmamaktadır.\n İşlem Başarısız");
                    }
                }
                if (listBox1.SelectedIndex == 4)
                {
                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                    {
                        MessageBox.Show("Boş Satır");
                    }
                    else
                    {
                        string varsa = "select count(*) from EkranKarti Where Marka=@mrk AND Ozellik=@ozllk AND Bellek=@bllk";
                        string yoksa = "Delete From EkranKarti Where Id=(Select min(Id) From EkranKarti Where Marka='" + textBox1.Text + "' AND (Ozellik='" + textBox2.Text + "' AND Bellek='" + textBox3.Text + "'))";
                        string varsas = "Select count(EkranKarti) from StokSorgu ";
                        string yoksasdus = "Update StokSorgu Set EkranKarti=EkranKarti-1";
                        con.Open();
                        SqlCommand bak = new SqlCommand(varsa, con);
                        bak.Parameters.AddWithValue("@mrk", textBox1.Text);
                        bak.Parameters.AddWithValue("@ozllk", textBox2.Text);
                        bak.Parameters.AddWithValue("@bllk", textBox3.Text);
                        Int32 say = (Int32)bak.ExecuteScalar();//marka bellek ve özelliklere sahip olan ekrankarti saydırma
                        SqlCommand bakbi = new SqlCommand(varsas, con);//stok sorgu tablosunda değer 0 dan büyük ise 
                        Int32 saydir = (Int32)bakbi.ExecuteScalar();// ss değer saydırma
                        con.Close();
                        if (say > 0 && saydir > 0)// kosullar
                        {
                            con.Open();
                            SqlCommand cikar = new SqlCommand(yoksa, con);
                            SqlCommand dus = new SqlCommand(yoksasdus, con);
                            dus.ExecuteNonQuery();
                            cikar.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Başarılı");
                        }
                        else
                            MessageBox.Show("Seçtiğiniz Ürün Stoklarımızda Bulunmamaktadır.\n İşlem Başarısız");
                    }
                }
                if (listBox1.SelectedIndex == 5)
                {
                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                    {
                        MessageBox.Show("Boş Satır");
                    }
                    else
                    {
                        string varsa = "select count(*) from Islemci Where Marka=@mrk AND Ozellik=@ozllk AND Bellek=@bllk";
                        string yoksa = "Delete From Islemci Where Id=(Select min(Id) From Islemci Where Marka='" + textBox1.Text + "' AND (Ozellik='" + textBox2.Text + "' AND Bellek='" + textBox3.Text + "'))";
                        string varsas = "Select count(IslemciSayisi) from StokSorgu ";
                        string yoksasdus = "Update StokSorgu Set IslemciSayisi=IslemciSayisi-1";
                        con.Open();
                        SqlCommand bak = new SqlCommand(varsa, con);
                        bak.Parameters.AddWithValue("@mrk", textBox1.Text);
                        bak.Parameters.AddWithValue("@ozllk", textBox2.Text);
                        bak.Parameters.AddWithValue("@bllk", textBox3.Text);
                        Int32 say = (Int32)bak.ExecuteScalar();//marka bellek ve özelliklere sahip olan işlemci saydırma
                        SqlCommand bakbi = new SqlCommand(varsas, con);//stok sorgu tablosunda değer 0 dan büyük ise 
                        Int32 saydir = (Int32)bakbi.ExecuteScalar();// ss değer saydırma
                        con.Close();
                        if (say > 0 && saydir > 0)// kosullar
                        {
                            con.Open();
                            SqlCommand cikar = new SqlCommand(yoksa, con);
                            SqlCommand dus = new SqlCommand(yoksasdus, con);
                            dus.ExecuteNonQuery();
                            cikar.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Başarılı");
                        }
                        else
                            MessageBox.Show("Seçtiğiniz Ürün Stoklarımızda Bulunmamaktadır.\n İşlem Başarısız");
                    }
                }
                if (listBox1.SelectedIndex == 6)
                {
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Boş Satır");
                    }
                    else
                    {
                        string varsa = "select count(*) from BiosPil Where Marka=@mrk";
                        string yoksa = "Delete From BiosPil Where Id=(Select min(Id) From BiosPil Where Marka='" + textBox1.Text + "')";
                        string varsas = "Select count(BiosPilSayisi) from StokSorgu ";
                        string yoksasdus = "Update StokSorgu Set BiosPilSayisi=BiosPilSayisi-1";
                        con.Open();
                        SqlCommand bak = new SqlCommand(varsa, con);
                        bak.Parameters.AddWithValue("@mrk", textBox1.Text);
                        Int32 say = (Int32)bak.ExecuteScalar();//marka sahip olan biospili saydırma
                        SqlCommand bakbi = new SqlCommand(varsas, con);//stok sorgu tablosunda değer 0 dan büyük ise 
                        Int32 saydir = (Int32)bakbi.ExecuteScalar();// ss değer saydırma
                        con.Close();
                        if (say > 0 && saydir > 0)// kosullar
                        {
                            con.Open();
                            SqlCommand cikar = new SqlCommand(yoksa, con);
                            SqlCommand dus = new SqlCommand(yoksasdus, con);
                            dus.ExecuteNonQuery();
                            cikar.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Başarılı");
                        }
                        else
                            MessageBox.Show("Seçtiğiniz Ürün Stoklarımızda Bulunmamaktadır.\n İşlem Başarısız");
                    }
                }
                if (listBox1.SelectedIndex == 7)
                {
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Boş Satır");
                    }
                    else
                    {
                        string varsa = "select count(*) from Toner Where Marka=@mrk";
                        string yoksa = "Delete From Toner Where Id=(Select min(Id) From Toner Where Marka='" + textBox1.Text + "')";
                        string varsas = "Select count(TonerSayisi) from StokSorgu ";
                        string yoksasdus = "Update StokSorgu Set TonerSayisi=TonerSayisi-1";
                        con.Open();
                        SqlCommand bak = new SqlCommand(varsa, con);
                        bak.Parameters.AddWithValue("@mrk", textBox1.Text);
                        Int32 say = (Int32)bak.ExecuteScalar();//marka sahip olan toner saydırma
                        SqlCommand bakbi = new SqlCommand(varsas, con);//stok sorgu tablosunda değer 0 dan büyük ise 
                        Int32 saydir = (Int32)bakbi.ExecuteScalar();// ss değer saydırma
                        con.Close();
                        if (say > 0 && saydir > 0)// kosullar
                        {
                            con.Open();
                            SqlCommand cikar = new SqlCommand(yoksa, con);
                            SqlCommand dus = new SqlCommand(yoksasdus, con);
                            dus.ExecuteNonQuery();
                            cikar.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Başarılı");
                        }
                        else
                            MessageBox.Show("Seçtiğiniz Ürün Stoklarımızda Bulunmamaktadır.\n İşlem Başarısız");
                    }
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show("Hata" + hata);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ana gec = new Ana();
            gec.Show();
            this.Close();
        }

        private void SEkleCikar_Load(object sender, EventArgs e)
        {

        }
    }
}
