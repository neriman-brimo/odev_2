using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class frm_ayarlar : Form
    {
        public frm_ayarlar()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == false) 
            { Sabitler.modeIsDark = false; } 
            else { Sabitler.modeIsDark = true; }

            if (Sabitler.modeIsDark)
            {
                this.BackColor = Color.Black;
                label2.ForeColor = Color.White;
                label1.ForeColor = Color.White;

            }
            else
            {
                this.BackColor = Color.WhiteSmoke;
                label2.ForeColor = Color.Black;
                label1.ForeColor = Color.Black;

            }
        }

        private void frm_ayarlar_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = Sabitler.modeIsDark;
        }
    }
}
