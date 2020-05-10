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
    public partial class Ana : Form
    {
        public Ana()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Yönetici admin = new Yönetici();
            admin.Show();
            this.Hide();
        }

        private void Ana_Load(object sender, EventArgs e)
        {
             button1.Hide();
            label2.Text = Giris.ad;
            label2.Text = Admin.ad_admin;
            SqlConnection bagla = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
            System.Windows.Forms.Application.StartupPath + "\\veri.mdf;Integrated Security=True;Connect Timeout=30");
            bagla.Open();
            string sorgu = "select count(*) from Cbu_Admin where Cbu_Nick=@a";
            SqlCommand esle = new SqlCommand(sorgu, bagla);
            esle.Parameters.AddWithValue("@a", label2.Text);
            Int32 count = (Int32)esle.ExecuteScalar();
            if (count > 0)
            {
                button1.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sEkleCikar gec1 = new sEkleCikar();
            gec1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sSorgulama gec2 = new sSorgulama();
            gec2.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cGelen gec3 = new cGelen();
            gec3.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cGiden gec4 = new cGiden();
            gec4.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ArizaGecmisSorgulama gec5 = new ArizaGecmisSorgulama();
            gec5.Show();
            this.Hide();
        }

        private void Button1_MouseHover(object sender, EventArgs e)
        {
            button1.Size = new System.Drawing.Size(510, 73);
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Size = new System.Drawing.Size(354, 73);
        }

        private void Button5_MouseHover(object sender, EventArgs e)
        {
            button5.Size = new System.Drawing.Size(510, 73);
        }

        private void Button5_MouseLeave(object sender, EventArgs e)
        {
            button5.Size = new System.Drawing.Size(354, 73);
        }

        private void Button4_MouseHover(object sender, EventArgs e)
        {
            button4.Size = new System.Drawing.Size(510, 73);
        }

        private void Button4_MouseLeave(object sender, EventArgs e)
        {
            button4.Size = new System.Drawing.Size(354, 73);
        }

        private void Button3_MouseHover(object sender, EventArgs e)
        {
            button3.Size = new System.Drawing.Size(510, 73);
        }

        private void Button3_MouseLeave(object sender, EventArgs e)
        {
            button3.Size = new System.Drawing.Size(354, 73);
        }

        private void Button2_MouseHover(object sender, EventArgs e)
        {
        
        }

        private void Button6_MouseHover(object sender, EventArgs e)
        {
            button6.Size = new System.Drawing.Size(510, 73);
        }

        private void Button6_MouseLeave(object sender, EventArgs e)
        {
            button6.Size = new System.Drawing.Size(354, 73);
        }

       
    }
}
