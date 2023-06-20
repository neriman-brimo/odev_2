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
    public partial class frm_havaDurumu : Form
    {
        string sehir = "ANKARA";
        List<string> mySehirler = new List<string>();
        int n = 5;
        int ilk = 0;
        
        public frm_havaDurumu()
        {
            InitializeComponent();
        }

        private void frm_havaDurumu_Load(object sender, EventArgs e)
        {
            if (Sabitler.modeIsDark)
            {
                this.BackColor = Color.Black;
              
                label1.ForeColor = Color.White;
                anaPanel.BackColor = Color.Black;
            }
            else
            {
                this.BackColor = Color.WhiteSmoke;
                label1.ForeColor = Color.Black;
                anaPanel.BackColor = Color.White;
            }
            ///
            if (Sabitler.sehirler != null)
            {
 mySehirler = Sabitler.sehirler;
            Console.WriteLine(mySehirler.Count);
            }
           
            /// anaPanel
            anaPanel.Location = new Point(0, 90);
            anaPanel.Size = new Size(465, 390);
            anaPanel.AutoScroll = true;
            //anaPanel.BackColor = Color.Aqua;
            this.Controls.Add(anaPanel);
            if (mySehirler.Count != 0)
            {
                for (int i = 0; i < mySehirler.Count; i++)
                {
                    addNewPanel(mySehirler[i]);
                    ilk++;
                    n += 180;
                }
                
            }
           
        }
        Panel anaPanel = new Panel();
        
        private void button1_Click(object sender, EventArgs e)
        {
            //panel1.Visible = true;
           // sehirler.Add(sehir);
            sehir = textBox1.Text.ToUpper();
            //label1.Text= sehirler[0].ToUpper();
            sehir = sehir.Replace("Ö","O");
            sehir = sehir.Replace("İ", "I");
            sehir = sehir.Replace("Ğ", "G");
            sehir = sehir.Replace("Ç", "C");
            sehir = sehir.Replace("Ü", "U");
            sehir = sehir.Replace("Ş", "S");
            Sabitler.sehirler = mySehirler;
            mySehirler.Add(sehir);
         
            addNewPanel(mySehirler[ilk]);
            ilk++;
            n += 180;
           // Sabitler.sehirler = mySehirler;
            Sabitler.yazSehirler(mySehirler);

        }
       // Sabitler s1 = new Sabitler();
        void addNewPanel(string s)
        {
            // Yeni bir Panel oluşturun
            Panel newPanel = new Panel();
            newPanel.Location = new Point(30, n); // Yeni panelin konumunu ayarlayın
            newPanel.Size = new Size(410,170); // Yeni panelin boyutunu ayarlayın
            newPanel.BackColor = Color.White;

            // Yeni bir Label oluşturun
            Label newLabel = new Label();
            newLabel.Text = s;
            newLabel.Font = new Font(newLabel.Font.FontFamily, 12, FontStyle.Bold);
            newLabel.Location = new Point(185, 9); // Yeni label'in konumunu ayarlayın
            newLabel.AutoSize = true; // Yeni label'in boyutunu otomatik olarak ayarlayın

            // yeni pictureBox1
            PictureBox newPictureBox = new PictureBox();
            newPictureBox.Size= new Size(33, 33);
            newPictureBox.Location = new Point(380, 3);
            newPictureBox.Image = Properties.Resources.wrong;
            newPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            newPictureBox.Click += new EventHandler(newPictureBox_Click);
            void newPictureBox_Click(object sender, EventArgs e)
            {
                mySehirler.Remove(s);
                ilk = 0;
                n = 5;
                anaPanel.Controls.Clear();
                foreach (var item in mySehirler)
                {
                    addNewPanel(item);
                    ilk++;
                    n += 180;
                }
                Sabitler.sehirler = mySehirler;
                Sabitler.yazSehirler(mySehirler);
            }
            // Yeni bir WebBrowser oluşturun
            WebBrowser newWebBrowser = new WebBrowser();
            newWebBrowser.Location = new Point(0, 30); // Yeni WebBrowser'ın konumunu ayarlayın
            newWebBrowser.Size = new Size(551, 171); // Yeni WebBrowser'ın boyutunu ayarlayın
            newWebBrowser.ScrollBarsEnabled = false;
            newWebBrowser.Navigate("https://www.mgm.gov.tr/sunum/tahmin-show-2.aspx?m=" + s + "&basla=1&bitir=5&rC=111&rZ=fff");
            
            // Yeni Label ve WebBrowser'ı yeni Panel'e ekleyin
            newPanel.Controls.Add(newLabel);
            newPanel.Controls.Add(newWebBrowser);
            newPanel.Controls.Add(newPictureBox);

            // Yeni Panel'i ana Panel'e ekleyin
            anaPanel.Controls.Add(newPanel);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ilk = 0;
            n = 5;
            anaPanel.Controls.Clear();
            foreach (var item in mySehirler)
            {
                addNewPanel(item);
                ilk++;
                n += 180;
            }
        }
        

    }
    
}
