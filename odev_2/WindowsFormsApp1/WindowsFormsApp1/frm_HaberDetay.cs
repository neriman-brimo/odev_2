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
    public partial class frm_HaberDetay : Form
    {
     public  string kaynak = "";
        public frm_HaberDetay()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_haberler frm = new frm_haberler();
            frm.Show();
            this.Close();
        }

        private void frm_HaberDetay_Load(object sender, EventArgs e)
        {
            
            //webBrowser1.ScriptErrorsSuppressed = true;
            //webBrowser1.Url = new Uri(kaynak);
        }
    }
}
