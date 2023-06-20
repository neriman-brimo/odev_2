using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using System.Net.Http;
using Newtonsoft.Json;


namespace WindowsFormsApp1
{
    public partial class frm_kurlar : Form
    {
        public frm_kurlar()
        {
            InitializeComponent();
        }
       // string json = "{\"USD\":{\"satis\":\"23.6190\",\"alis\":\"23.6140\",\"degisim\":\"0.00\",\"d_oran\":\"0.0000\",\"d_yon\":\"minus\"},\"EUR\":{\"satis\":\"25.9690\",\"alis\":\"25.7130\",\"degisim\":\"0.00\",\"d_oran\":\"0.0000\",\"d_yon\":\"minus\"},\"GBP\":{\"satis\":\"30.3339\",\"alis\":\"30.1826\",\"degisim\":\"0.00\",\"d_oran\":\"0.0000\",\"d_yon\":\"minus\"},\"GA\":{\"satis\":\"1486.4221\",\"alis\":\"1486.0821\",\"degisim\":\"0.00\",\"d_oran\":\"0.0000\",\"d_yon\":\"minus\"},\"C\":{\"satis\":\"2445.5072\",\"alis\":\"2407.2230\",\"degisim\":\"0.00\",\"d_oran\":\"0.0000\",\"d_yon\":\"minus\"},\"GAG\":{\"satis\":\"18.3821\",\"alis\":\"18.3621\",\"degisim\":\"0.00\",\"d_oran\":\"0.0000\",\"d_yon\":\"minus\"},\"BTC\":{\"satis\":\"26341.3623\",\"alis\":\"26341.3623\",\"degisim\":\"-0.23\",\"d_oran\":\"-60.5851\",\"d_yon\":\"caret-down\"},\"ETH\":{\"satis\":\"1717.6061\",\"alis\":\"1717.6061\",\"degisim\":\"-0.48\",\"d_oran\":\"-8.2445\",\"d_yon\":\"caret-down\"},\"XU100\":{\"satis\":\"5475.48\",\"alis\":\"5475.48\",\"degisim\":\"0.00\"}}";

        private void frm_kurlar_Load(object sender, EventArgs e)
        {
            if (Sabitler.modeIsDark)
            {
                this.BackColor = Color.Black;
                label1.ForeColor = Color.White;
                listView1.BackColor = Color.Black;
                listView1.ForeColor = Color.White;

            }
            else
            {
                this.BackColor = Color.White;
                label1.ForeColor = Color.Black;
                listView1.BackColor = Color.White;
                listView1.ForeColor = Color.Black;
            }
            getKurlar();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            getKurlar();
        }
       void getKurlar()
        {
            listView1.Columns[0].Width = 101;
            listView1.Columns[1].Width = 80;
            listView1.Columns[2].Width = 101;
            listView1.Columns[3].Width = 101;
            listView1.Columns[4].Width = 80;
            listView1.Items.Clear();
            JObject jsonObj = KurlarGuncelle();
            ImageList imageList = new ImageList();
            imageList.Images.Add(Properties.Resources.caret);
            imageList.Images.Add(Properties.Resources.minus);
            listView1.SmallImageList = imageList;
            var x = listView1.SmallImageList;
            foreach (var item in jsonObj)
            {
                string paraBirimi = item.Key;
                string alis = item.Value["alis"].ToString();
                string satis = item.Value["satis"].ToString();
                string degisim = item.Value["degisim"].ToString();
                string yon = item.Value["d_yon"]?.ToString() ?? string.Empty;
                string yonText = "";
                switch (yon)
                {
                    case "minus":
                        yonText = "   Artış";
                        break;
                    case "caret-down":
                        yonText = "   Düşüş";
                        break;
                    default:
                        yonText = "      -";
                        break;
                }
                ListViewItem listViewItem = new ListViewItem(new string[] { yonText, paraBirimi, alis, satis, degisim });
                listViewItem.ImageIndex = (yon == "minus") ? 0 : (yon == "caret-down") ? 1 : -1;
                listView1.Items.Add(listViewItem);


            }
        }
        JObject KurlarGuncelle()
        {
            string apiUrl = "https://api.genelpara.com/embed/altin.json";
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
                return data;               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata oluştu: {ex.Message}");
                return null;
            }
            finally
            {
                // HttpClient nesnesini temizleyin
                httpClient.Dispose();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
