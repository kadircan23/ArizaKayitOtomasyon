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
    public partial class sSorgulama : Form
    {
        public sSorgulama()
        {
            InitializeComponent();
        }

        private void sSorgulama_Load(object sender, EventArgs e)
        {
            string tab = "select * from StokSorgu";
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
            this.Close(); ;
            gec.Show();
        }

        private void StokSorguBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
