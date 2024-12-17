using MediaPlayer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace MediaPlayer
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
        
        List<string> PlayList = new List<string>();
        List<string> PlayListUrl = new List<string>();
        List<Stream> pictures = new List<Stream>();
        int CurrentAudio, catPos = 1;
        bool autoplay = true, ltsgNtxt;

        public Form1()
        {
            InitializeComponent();
            button4.Visible = false;
            button3.Visible = false;
            button2.Visible = false;
            button1.Visible = false;
            textBox1.Visible = false;
            button5.Visible = false;
            progressBar1.Visible = false;
            pictureBox1.Visible = false;
            trackBar1.Visible = false;
            textBox2.Visible = false;
            listBox1.Visible = false;
            timer1.Stop();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1.Image = new Bitmap(global::MediaPlayer.Properties.Resources.cat1);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;


        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mathc = "*.mp3";
            string path = "";
            using (FolderBrowserDialog FolderDiaog = new FolderBrowserDialog())
            {
                if (FolderDiaog.ShowDialog() == DialogResult.OK)
                {
                    path = FolderDiaog.SelectedPath;
                }
            }
            var list = FindClass.Find1(path, mathc);
            System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
            int tlpRowCount = 1;
            foreach (var elm in list)
            {
                PlayList.Add(elm.Name.ToString());
                PlayListUrl.Add(elm.DirectoryName.ToString() + "\\" + elm.Name.ToString());



                Label label = new Label();
                label.Dock = DockStyle.Fill;
                label.Text = txt.Text = elm.Name.ToString();
                listBox1.Items.Add(label.Text);
                tlpRowCount++;
            }
            
            player.URL = PlayListUrl[0];
            player.controls.stop();
            player.controls.pause();
            CurrentAudio = 0;
            button3.Visible = true;
            button2.Visible = true;
            button1.Visible = true;
            textBox1.Visible = true;
            button5.Visible = true;
            progressBar1.Visible = true;
            pictureBox1.Visible = true;
            trackBar1.Maximum = 100;
            trackBar1.Value = 100;
            trackBar1.Visible = true;
            textBox2.Visible = true;
            listBox1.Visible = true;



           /* for (int i = 1; i <= 3; i++)
            {
                Assembly asm = Assembly.GetExecutingAssembly();
                string str = $"кот{i}.png";
                Stream stm = asm.GetManifestResourceStream($"MediaPlayer.Resourses.кот1.png");
                pictureBox1.Image = new Bitmap(stm);
                pictures.Add(asm.GetManifestResourceStream($"MediaPlayer.Resourses.кот1.png"));
            }*/



            textBox1.Text = PlayList[CurrentAudio];


        }

        //private void pictureBox1_Paint(object sender, PaintEventArgs e)
        //{
        //    var g = e.Graphics;
        //    g.DrawImage(pictures[0],0,0);
        //}


        private void button1_Click(object sender, EventArgs e)
        {
            player.controls.play();
            button1.Visible = false;
            button4.Visible = true;
            timer1.Start();
            timer2.Start();
            autoplay = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            player.controls.pause();
            button4.Visible = false;
            button1.Visible = true;
            timer1.Stop();
            timer2.Stop();
            autoplay = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int curr = PlayList.Count() - 1;
            if ((CurrentAudio + 1) <= curr)
            {
                CurrentAudio++;
                player.URL = PlayListUrl[CurrentAudio];
            }
            textBox1.Text = PlayList[CurrentAudio];
            progressBar1.Value = 0;
            button1.Visible = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((CurrentAudio - 1) >= 0)
            {
                CurrentAudio--;
                player.URL = PlayListUrl[CurrentAudio];
            }
            textBox1.Text = PlayList[CurrentAudio];
            progressBar1.Value = 0;
            button1.Visible = true;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Shuffle.Shuffle1(PlayListUrl);
            CurrentAudio = 0;
            player.URL = PlayListUrl[CurrentAudio];
            player.controls.stop();
            timer2.Stop();
            progressBar1.Value = 0;
            button1.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(autoplay && ltsgNtxt)
            {
                    ltsgNtxt = false;
                    int curr = PlayList.Count() - 1;
                    if ((CurrentAudio + 1) <= curr)
                    {
                        CurrentAudio++;
                        player.URL = PlayListUrl[CurrentAudio];
                        textBox1.Text = PlayList[CurrentAudio];
                        progressBar1.Value = 0;
                        player.controls.play();
                    }else
                {
                    timer1.Stop();
                    timer2.Stop();
                    CurrentAudio = 0;
                    player.URL = PlayListUrl[CurrentAudio];
                    textBox1.Text = PlayList[CurrentAudio];
                    autoplay = false;
                    player.controls.stop();

                }
                    
                
            }
            if ((int)player.currentMedia.duration > 0)
            { 
            int a = (int)player.currentMedia.duration;
            progressBar1.Maximum = a;
            progressBar1.Value = (int)player.controls.currentPosition;
                if((int)player.currentMedia.duration - 2 == (int)player.controls.currentPosition || (int)player.currentMedia.duration - 1 == (int)player.controls.currentPosition|| (int)player.currentMedia.duration == (int)player.controls.currentPosition)
                    ltsgNtxt = true;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            player.settings.volume = trackBar1.Value;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(catPos <=4)
            {
                switch (catPos)
                {
                    case 1:
                        pictureBox1.Image = new Bitmap(global::MediaPlayer.Properties.Resources.cat1);
                        catPos++;
                        break;
                    case 2:
                        pictureBox1.Image = new Bitmap(global::MediaPlayer.Properties.Resources.кот2);
                        catPos++;
                        break;
                    case 3:
                        pictureBox1.Image = new Bitmap(global::MediaPlayer.Properties.Resources.кот3);
                        catPos++;
                        break;
                    case 4:
                        pictureBox1.Image = new Bitmap(global::MediaPlayer.Properties.Resources.кот2);
                        catPos = 1;
                        break;
                }
            }
        }
    }
}
