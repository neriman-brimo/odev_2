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
    public partial class frm_yapilacaklar : Form
    {
        public frm_yapilacaklar()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }
        int elemansayısı;
        List<string> ids;
        private async void frm_yapilacaklar_Load(object sender, EventArgs e)
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
                anaPanel.BackColor = Color.WhiteSmoke;

            }
            ids = await Sabitler.getIds();
            elemansayısı = ids.Count;
            guncelle();
            //Console.WriteLine("girdikkkkkkkkkkkkkkkkkkkkk" + elemansayısı);

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_Ekle frm = new frm_Ekle();
            frm.NewelemanSayısı = elemansayısı;
            frm.Show();
            this.Close();
           // MessageBox.Show("Silmeyi onayla", "Görev Ekle", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }
        int n = 5;
        void addNewPanel(string g , string d, string t, string s,string id,bool check)
        {
            // Yeni bir Panel oluşturun
            Panel newPanel = new Panel();
            newPanel.Location = new Point(10, n); // Yeni panelin konumunu ayarlayın
            newPanel.Size = new Size(430, 100); // Yeni panelin boyutunu ayarlayın
            newPanel.BackColor = Color.MintCream;
            newPanel.BorderStyle = BorderStyle.FixedSingle;
            // Yeni bir Label oluşturun gorev
            Label newLabel = new Label();
            newLabel.Text = g;
            newLabel.Font = new Font(newLabel.Font.FontFamily, 12, FontStyle.Bold);
            newLabel.Location = new Point(40, 10); // Yeni label'in konumunu ayarlayın
            newLabel.AutoSize = true; // Yeni label'in boyutunu otomatik olarak ayarlayın
            // Yeni bir checkBox oluşturun 
            CheckBox checkBox = new CheckBox();
            checkBox.Checked = check;
            checkBox.Location = new Point(10, 10); // CheckBox'in konumunu ayarlayın
            checkBox.CheckedChanged += new EventHandler(checkBox_Click);
            void checkBox_Click(object sender, EventArgs e)
            {
                if (checkBox.Checked == true)
                {
             
                    Sabitler.guncelleGorev(id, g, d, t, s,true);
                }
                else
                {
                    Sabitler.guncelleGorev(id, g, d, t, s,false);
                }
            }
            //  Label 2 oluşturun   detay                             
            Label Label2 = new Label();
            Label2.Text = d;
            Label2.Font = new Font(Label2.Font.FontFamily, 12);
            Label2.Location = new Point(10, 40); // Yeni label'in konumunu ayarlayın
            Label2.AutoSize = true; // Yeni label'in boyutunu otomatik olarak ayarlayın

            //  Label 3 oluşturun  tarih                                
            Label Label3 = new Label();
            Label3.Text = t;
            Label3.Font = new Font(Label3.Font.FontFamily, 12);
            Label3.Location = new Point(10, 70); // Yeni label'in konumunu ayarlayın
            Label3.AutoSize = true; // Yeni label'in boyutunu otomatik olarak ayarlayın

            //  Label 3 oluşturun  saat                                
            Label Label4 = new Label();
            Label4.Text = s;
            Label4.Font = new Font(Label4.Font.FontFamily, 12);
            Label4.Location = new Point(100, 70); // Yeni label'in konumunu ayarlayın
            Label4.AutoSize = true; // Yeni label'in boyutunu otomatik olarak ayarlayın

            // yeni pictureBox1
            PictureBox deletePictureBox = new PictureBox();
            deletePictureBox.Size = new Size(30, 30);
            deletePictureBox.Location = new Point(380, 10);
            deletePictureBox.Image = Properties.Resources.wrong;
            deletePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            deletePictureBox.Click += new EventHandler(deletePictureBox_Click);
            void deletePictureBox_Click(object sender, EventArgs e)
            {
                //  mySehirler.Remove(id);
                //Console.WriteLine("222222222222222222222222222222222222"+ id);
                // Sabitler.silGorev(id.ToString());
                Sabitler.silGorev(id);

             guncelle();
            }

            // yeni pictureBox1
            PictureBox editPictureBox = new PictureBox();
            editPictureBox.Size = new Size(30, 30);
            editPictureBox.Location = new Point(380,50);
            editPictureBox.Image = Properties.Resources.edit;
            editPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            editPictureBox.Click += new EventHandler(editPictureBox_Click);
            void editPictureBox_Click(object sender, EventArgs e)
            {
                frm_gorevGuncelle frm = new frm_gorevGuncelle();
                frm.gorev = g;
                frm.detay = d;
                frm.date = t;
                frm.time = s;
                frm.id = id;
                frm.ch = checkBox.Checked;
                frm.Show();
                this.Close();
                //Sabitler.guncelleGorev(elemansayısı.ToString());
                //guncelle();
            }

            //// newPanel
            newPanel.Controls.Add(newLabel);
            newPanel.Controls.Add(checkBox);
            newPanel.Controls.Add(Label2);
            newPanel.Controls.Add(Label3);
            newPanel.Controls.Add(Label4);
            newPanel.Controls.Add(deletePictureBox);
            newPanel.Controls.Add(editPictureBox);


            ///   anaPanel
            anaPanel.Controls.Add(newPanel);
        }
        async Task guncelle ()
        {
            ids = await Sabitler.getIds();
            elemansayısı = ids.Count;
            n = 0;
            anaPanel.Controls.Clear();
            elemansayısı = (ids.Count);
            

            for (int i = 0; i < elemansayısı; i++)
            {
                var sonuc = await Sabitler.okuGorev(ids[i]);
                addNewPanel(sonuc.Item1, sonuc.Item2, sonuc.Item3, sonuc.Item4, ids[i], sonuc.Item5);
                n += 110;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // var r = GetUserIDsAndCount();
          //  Console.WriteLine("wwwwwwwwwwwwwwwwwwwww" + r);
            guncelle();
        }

        private void anaPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
