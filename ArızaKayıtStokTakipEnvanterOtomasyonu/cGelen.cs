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
    public partial class cGelen : Form
    {
        public cGelen()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
            System.Windows.Forms.Application.StartupPath + "\\veri.mdf;Integrated Security=True;Connect Timeout=30");
        private void cGelen_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            con.Open();
            string sorgu = "select * from Bolum";
            SqlCommand komut = new SqlCommand(sorgu, con);
            SqlDataReader oku;
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["BolumAd"]);
            }
            con.Close();
            //con.Open();
            //string istemnoarttir = "Update GidenCihaz Set IstemNo=IstemNo+1";
            //SqlCommand arttir = new SqlCommand(istemnoarttir,con);
            //arttir.ExecuteNonQuery();
            //con.Close();
            con.Open();
            string istemnocek = "Select max(IstemNo) From GelenCihaz";
            string a;
            SqlCommand al = new SqlCommand(istemnocek, con);
            SqlDataReader cek;
            cek = al.ExecuteReader();
            if (cek.Read())
            {
                a = cek[0].ToString();
                textBox1.Text = Convert.ToString(Convert.ToInt32(a) + 1);
            }
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            con.Open();
            string sorgu = "Select * From AltBirim Where BolumId=(Select BolumId From Bolum Where BolumAd=@a) ";
            SqlCommand komut = new SqlCommand(sorgu, con);
            komut.Parameters.AddWithValue("@a", comboBox1.Text);
            SqlDataReader oku;
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox2.Items.Add(oku["AltBirimAdi"]);
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string sorgu = "Select Count(*) From GelenCihaz Where IstemNo=@a ";
                SqlCommand gelencihaz = new SqlCommand(sorgu, con);
                gelencihaz.Parameters.AddWithValue("@a", textBox1.Text);

                Int32 count = (Int32)gelencihaz.ExecuteScalar();
                con.Close();

                if (count > 0)
                {
                    con.Open();
                    MessageBox.Show("Kayıt Zaten Var");
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox1.Text = "";
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    con.Close();
                }
                else
                {
                    con.Open();
                    string ekle = "insert into GelenCihaz(IstemNo,Bolum,AltBirim,cBilgi,cSorun)values(@a,@b,@c,@d,@e)";
                    SqlCommand kayit = new SqlCommand(ekle, con);
                    kayit.Parameters.AddWithValue("@a", textBox1.Text);
                    kayit.Parameters.AddWithValue("@b", comboBox1.Text);
                    kayit.Parameters.AddWithValue("@c", comboBox2.Text);
                    kayit.Parameters.AddWithValue("@d", textBox2.Text);
                    kayit.Parameters.AddWithValue("@e", textBox3.Text);
                    kayit.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Başarılı!");
                }
            }
            catch (Exception hata)
            {

                MessageBox.Show("hata" + hata);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(textBox2.Text == "" & textBox3.Text == "" & textBox1.Text == "" & comboBox1.Text == "" & comboBox2.Text == "")
            {
                button1.Enabled = false;
            }
            else
                button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ana gec = new Ana();
            gec.Show();
            this.Close();
        }
    }
}
