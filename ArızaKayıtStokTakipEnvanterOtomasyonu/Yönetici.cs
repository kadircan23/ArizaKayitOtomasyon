using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArızaKayıtStokTakipEnvanterOtomasyonu
{
    public partial class Yönetici : Form
    {
        public Yönetici()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ÜyelikSorgula gec1 = new ÜyelikSorgula();
            gec1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ÜyelikBilgileriniGüncelle gec4 = new ÜyelikBilgileriniGüncelle();
            gec4.Show();
            this.Hide();
        }

        private void Yönetici_Load(object sender, EventArgs e)
        {

        }
    }
}
