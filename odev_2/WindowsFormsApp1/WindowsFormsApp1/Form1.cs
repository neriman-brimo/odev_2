using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
///////////////////////////////////
using FireSharp;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        
        
      //  IFirebaseClient client;
        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frm_havaDurumu frm = new frm_havaDurumu();
            frm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm_kurlar frm = new frm_kurlar();
            frm.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frm_ayarlar frm = new frm_ayarlar(); frm.Show();
            this.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            frm_yapilacaklar frm = new frm_yapilacaklar(); frm.Show();
            this.Hide();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_haberler frm = new frm_haberler();
            
            frm.Show(); this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Sabitler.veriYazmaAsync();
            //Sabitler.okuSehirler();
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

                /////BackColor 
                //label2.BackColor = Color.White;
                //label3.BackColor = Color.White;
                //label4.BackColor = Color.White;
                //label5.BackColor = Color.White;
            } 
        }

        private  void button3_Click(object sender, EventArgs e)
        {
            // Sabitler.veriOkumaAsync();
            // Sabitler.okuGorev();

        }
    }
}
