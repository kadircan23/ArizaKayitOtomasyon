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
    public partial class ArizaGecmisSorgulama : Form
    {
        public ArizaGecmisSorgulama()
        {
            InitializeComponent();
        }
        private void ArizaGecmisSorgulama_Load(object sender, EventArgs e)
        {
            string tab = "select * from GidenCihaz";
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
            System.Windows.Forms.Application.StartupPath + "\\veri.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand sorgu = new SqlCommand(tab, con);
            SqlDataAdapter rw = new SqlDataAdapter(sorgu);
            DataTable dt = new DataTable();
            rw.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ana gec = new Ana();
            gec.Show();
            this.Hide();
        }
    }
}
