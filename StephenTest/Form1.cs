using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Orb;
using Orb.Core.Computer;
using Orb.Core.Media;
using Orb.Core.Session;
using Orb.Core.Stream;


namespace StephenTest
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            
        }

        public string SessionID;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var oAuth = new Session(txtAppKey.Text);
            if (oAuth.sessionlogin(txtUser.Text, txtpassword.Text))
            {
                SessionID = StaticSessionSettings.sessionID;
                label1.Text = SessionID;
            }

        }

        public void streamMofo()
        {
            var oStreaming = new Stream();

            var result = oStreaming.GetStreamingUri(Stream.FORMAT_ASX, txtMediumId.Text);

            var strUrl = result;

            axWindowsMediaPlayer1.URL = strUrl;
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtUser.Text = "drpcni";
            txtpassword.Text = "downfall";
            txtAppKey.Text = "2rbl7rlmt009u";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            var result = Media.mediasearch(textBox1.Text);

            dataGridView1.DataSource = "";
            dataGridView1.Refresh();
            
            dataGridView1.DataSource = result;
            dataGridView1.Refresh();
        }

        private void btnPlayVideo_Click(object sender, EventArgs e)
        {
            streamMofo();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var restart = new Computer();
            restart.restartOrb();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var keepAlive = new Session();
            keepAlive.sessionkeepAlive();
        }

        

      
    }
}
