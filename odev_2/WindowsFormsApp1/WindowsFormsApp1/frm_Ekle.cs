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
    public partial class frm_Ekle : Form
    {
        public frm_Ekle()
        {
            InitializeComponent();
        }
        string gorev;
        string detay;
        string date;
        string time;
        Random r = new Random();
  
        public int NewelemanSayısı;
        private  void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox2.Text != null)
            {
                gorev = textBox1.Text;
                detay = textBox2.Text;
                date = maskedTextBox1.Text;
                time = maskedTextBox2.Text;
                Sabitler.ekleGorev(gorev, detay, date, time, (r.Next(200)+2)+ gorev);
                frm_yapilacaklar frm = new frm_yapilacaklar();
                frm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Boş görev eklenmez", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void frm_Ekle_Load(object sender, EventArgs e)
        {
            if (Sabitler.modeIsDark)
            {
                this.BackColor = Color.Black;
                panel1.BackColor = Color.SlateGray;
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                label4.ForeColor = Color.White;
                label5.ForeColor = Color.White;
                ///BackColor 
                label2.BackColor = Color.Black;
                label3.BackColor = Color.Black;
                label4.BackColor = Color.Black;
                label5.BackColor = Color.Black;

            }
            else
            {
                this.BackColor = Color.WhiteSmoke;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                label5.ForeColor = Color.Black;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_yapilacaklar frm = new frm_yapilacaklar();
            frm.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
