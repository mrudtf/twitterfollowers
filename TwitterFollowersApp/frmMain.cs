using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TwitterFollowersApp {
    public partial class frmMain : Form {
        private Config c;
        public frmMain()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            try
            {
                this.c = new Config();
                this.txtConsumerKey.Text = c.conf.consumerKey;
                this.txtConsumerSecret.Text = c.conf.consumerSecret;
                this.lblLastCheck.Text = c.conf.lastCheck;
                this.lstCurrent.Items.Clear();
                this.lstUnfollows.Items.Clear();
                this.lstNew.Items.Clear();                
            }
            catch (FileNotFoundException exception)
            {
                MessageBox.Show("Failed to load the config file.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {            
           // save config...
           c.conf.consumerKey = txtConsumerKey.Text;
           c.conf.consumerSecret = txtConsumerSecret.Text;
           c.saveConfig();                         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.c.conf.lastCheck = DateTime.Now.ToString();
            this.c.saveConfig();
            this.Dispose();
        }
    }
}
