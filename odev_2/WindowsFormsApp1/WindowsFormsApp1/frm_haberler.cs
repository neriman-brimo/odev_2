using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class frm_haberler : Form
    {
        public frm_haberler()
        {
            InitializeComponent();
        }
        string hTur;
         int myItemCount=0;
        List<string> img = new List<string>();
        List<string> basilk = new List<string>();
        List<string> tarih = new List<string>();
        List<string> yazar = new List<string>();
        List<string> links = new List<string>();


        private void frm_haberler_Load(object sender, EventArgs e)
        {
            if (Sabitler.modeIsDark)
            {
                this.BackColor = Color.Black;
                panel3.BackColor = Color.Black;
                label1.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = Color.White;
                panel3.BackColor = Color.White;
                label1.ForeColor = Color.Black;
            }

            hTur = "manset";
            btnM.BackColor = Color.DeepSkyBlue;
            getHaaberler();
            for (int i = 0; i < myItemCount; i++)
            {
                createMyİtems( img[i], basilk[i], tarih[i], yazar[i], links[i]);
                n += 260;
            }
            
        }
       void getHaaberler()
        {
            // API endpoint URL'sini belirtin
            string apiUrl = "https://api.rss2json.com/v1/api.json?rss_url=https%3A%2F%2Fwww.trthaber.com%2F"+ hTur + "_articles.rss";

            // HttpClient oluşturun
            HttpClient httpClient = new HttpClient();
            try
            {
                // API'den veriyi alın
                HttpResponseMessage response = httpClient.GetAsync(apiUrl).Result;
                response.EnsureSuccessStatusCode(); // İsteğin başarılı olup olmadığını kontrol edin

                // Yanıtı okuyun
                string responseBody = response.Content.ReadAsStringAsync().Result;

                // JSON'den veri okuyun
                dynamic data = JsonConvert.DeserializeObject(responseBody);
                myItemCount = data["items"].Count;
                foreach (var item in data["items"])
                {
                    string foto = item["enclosure"]["link"];
                    string t = item["title"];
                    string y = item["author"];
                    string b = item["pubDate"];
                    string l = item["link"];

                    img.Add(foto);
                    tarih.Add(t);
                    yazar.Add(y);
                    basilk.Add(b);
                    links.Add(l);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata oluştu: {ex.Message}");
            }
            finally
            {
                // HttpClient nesnesini temizleyin
                httpClient.Dispose();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }
        void updateMyPanle()
        {
            myItemCount = 0;
            img.Clear();
            basilk.Clear();
            tarih.Clear();
            yazar.Clear();
            panel3.Controls.Clear();
            n = 5;
            getHaaberler();

            for (int i = 0; i < myItemCount; i++)
            {
                createMyİtems(img[i], basilk[i], tarih[i], yazar[i],links[i]);
                n += 260;
            }
        }
        private void btnM_Click(object sender, EventArgs e)
        {
            hTur = "manset";
            updateMyPanle();
            btnM.BackColor = Color.DeepSkyBlue;
            btnE.BackColor = Color.White;
            btnG.BackColor = Color.White;
            btnS.BackColor = Color.White;
            btnT.BackColor = Color.White;
        }

        private void btnS_Click(object sender, EventArgs e)
        { 

            hTur = "sondakika";
            updateMyPanle();
            btnM.BackColor = Color.White;
            btnE.BackColor = Color.White;
            btnG.BackColor = Color.White;
            btnS.BackColor = Color.DeepSkyBlue;
            btnT.BackColor = Color.White;
        }

        private void btnG_Click(object sender, EventArgs e)
        {
            hTur = "gundem";
            updateMyPanle();
            btnM.BackColor = Color.White;
            btnE.BackColor = Color.White;
            btnG.BackColor = Color.DeepSkyBlue;
            btnS.BackColor = Color.White;
            btnT.BackColor = Color.White;
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            hTur = "ekonomi";
            updateMyPanle();
            
            btnM.BackColor = Color.White;
            btnE.BackColor = Color.DeepSkyBlue;
            btnG.BackColor = Color.White;
            btnS.BackColor = Color.White;
            btnT.BackColor = Color.White;
        }

        private void btnT_Click(object sender, EventArgs e)
        {
            hTur = "bilim_teknoloji";
            updateMyPanle();
           
            btnM.BackColor = Color.White;
            btnE.BackColor = Color.White;
            btnG.BackColor = Color.White;
            btnS.BackColor = Color.White;
            btnT.BackColor = Color.DeepSkyBlue;
        }
        int n = 5;
        //int ilk = 0;
        Sabitler s1 = new Sabitler();
        void createMyİtems( string link, string t, string b,string y, string hL)
        {
            // Yeni bir Panel oluşturun
            Panel newPanel = new Panel();
            newPanel.Location = new Point(20, n); // Yeni panelin konumunu ayarlayın
            newPanel.Size = new Size(410, 250); // Yeni panelin boyutunu ayarlayın
            newPanel.BackColor = Color.White;

            // Yeni bir Label 1 oluşturun
            Label newLabel = new Label();
            newLabel.Text = y;
            newLabel.Font = new Font(newLabel.Font.FontFamily, 10);
            newLabel.Location = new Point(100, 230); // Yeni label'in konumunu ayarlayın
            newLabel.AutoSize = true; // Yeni label'in boyutunu otomatik olarak ayarlayın

            // Yeni bir Label 2 oluşturun
            Label newLabe2 = new Label();
            newLabe2.Text = "|     "+t ;
            newLabe2.Font = new Font(newLabe2.Font.FontFamily, 10);
            newLabe2.Location = new Point(150,230); // Yeni label'in konumunu ayarlayın
            newLabe2.AutoSize = true; // Yeni label'in boyutunu otomatik olarak ayarlayın

            // Yeni bir Label 3 oluşturun
            Label newLabe3 = new Label();
            newLabe3.Text = b;
            newLabe3.Font = new Font(newLabe3.Font.FontFamily, 10);
            newLabe3.Location = new Point(40, 210); // Yeni label'in konumunu ayarlayın
            newLabe3.AutoSize = false; // Yeni label'in boyutunu otomatik olarak ayarlayın
            newLabe3.TextAlign = ContentAlignment.TopLeft;
            newLabe3.Width = 420; // Label'in genişliğini ayarlayın
            newLabe3.Height = 20;
           
            // yeni pictureBox1
            PictureBox newPictureBox = new PictureBox();
            newPictureBox.Size = new Size(300, 200);
            newPictureBox.Location = new Point(60, 5);
           // newPictureBox.Image = Properties.Resources.wrong;
            newPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            // URI'den resmi yükleme
            string uriString = link;
            Uri uri = new Uri(uriString);
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                using (System.IO.Stream stream = client.OpenRead(uri))
                {
                    newPictureBox.Image = Image.FromStream(stream);
                }
            }
            newPictureBox.Click += new EventHandler(newPictureBox_Click);
            void newPictureBox_Click(object sender, EventArgs e)
            {
                //frm_HaberDetay frm = new frm_HaberDetay();
                //frm.kaynak = hL;
                //frm.Show();
               

                Process.Start(hL);
               // this.Hide(); 
            }
           
            //  newPanel.Controls.Add(newWebBrowser);
            newPanel.Controls.Add(newPictureBox);
            // Yeni Label1   Panel'e ekleyin
            newPanel.Controls.Add(newLabel);
            // Yeni Label 2 ve Panel'e ekleyin
            newPanel.Controls.Add(newLabe2);
            // Yeni Label 3 ve Panel'e ekleyin
            newPanel.Controls.Add(newLabe3);
            // Yeni Panel'i ana Panel'e ekleyin
            panel3.Controls.Add(newPanel);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            updateMyPanle();
        }
    }
}
