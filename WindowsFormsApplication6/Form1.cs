using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;


namespace WindowsFormsApplication6
{





public partial class Form1 : Form

    {




        public class beslik
        {
            
            static int adet = 0;
            static int sayi;
            int nesneNo;
            static  Panel labelPaneli = new Panel();
            static Label[] toplam = new Label[14];
            Panel ust = new Panel();
            bool durum = false;
            SoundPlayer ses = new SoundPlayer(Application.StartupPath+"\\click.wav");
            
            public beslik(Form frm,int gelen)
            {
                if (adet == 0)
                {
                    labelPaneli.Size = new Size(780, 20);
                    labelPaneli.Location = new Point(0, 0);
                    labelPaneli.BackColor = Color.Black;
                    frm.Controls.Add(labelPaneli);

                    for (int i = 0; i < 14; i++)
                    {
                        toplam[i] = new Label();
                        toplam[i].Size = new Size(16, 16);
                        toplam[i].Location = new Point(58 + i * 50, 2);
                        toplam[i].BackColor = Color.Transparent;
                        toplam[i].ForeColor = Color.White;
                        toplam[i].Font = new Font("Microsoft Sans Serif", 9.5f, FontStyle.Bold);
                        toplam[i].BringToFront();

                        for (int j = 0; j < 14; j++)
                            toplam[i].Text = "0";

                    }

                    for (int i = 0; i < 14; i++)
                        labelPaneli.Controls.Add(toplam[i]);

                    

                }
                sayi = gelen;
                ust.Size = new Size(40, 20);
                ust.Location = new Point(45+adet*50, 20);
                ust.BackColor = Color.Red;
                ust.Click += new EventHandler(ust_Click);
                frm.Controls.Add(ust);
                ust.BringToFront();
                nesneNo = adet;
                adet++;
                
            }


            public static void toplamArttir(char artis,int hangiKolon)
            {
                if (artis == '1')
                    toplam[hangiKolon].Text = (Convert.ToInt32(toplam[hangiKolon].Text) + 1).ToString();
                if (artis == '5')
                    toplam[hangiKolon].Text = (Convert.ToInt32(toplam[hangiKolon].Text) + 5).ToString();

            }

            public static void toplamAzalt(char azalis, int hangiKolon)
            {
                if (azalis == '1')
                    toplam[hangiKolon].Text = (Convert.ToInt32(toplam[hangiKolon].Text) - 1).ToString();
                if (azalis == '5')
                    toplam[hangiKolon].Text = (Convert.ToInt32(toplam[hangiKolon].Text) - 5).ToString();

            }



            public void ust_Click(object sender,EventArgs e)
            {

                if (durum == false)
                {
                    ust.Top = ust.Top + 20;
                    ust.BackColor = Color.Yellow;
                    ses.Play();
                    toplamArttir('5', nesneNo);
                    durum = true;
                }
                else
                {
                    ust.Top = ust.Top - 20;
                    ust.BackColor = Color.Red;
                    ses.Play();
                    toplamAzalt('5', nesneNo);
                    durum = false;

                }

            }



        }

        public class birlik
        {
            static int[] dizi = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            static int sayi = 0;
            int nesneNo;
            int kolon;
            SoundPlayer ses = new SoundPlayer(Application.StartupPath+@"\\click.wav");
            Panel ust = new Panel();
            bool durum = false;
            

            public birlik(Form frm, int gelen)
            {
                
                kolon = gelen;
                ust.Size = new Size(40, 20);
                ust.Location = new Point(45+kolon*50,90+sayi*25);
                ust.BackColor = Color.Red;
                ust.Click += new EventHandler(ust_Click);

                frm.Controls.Add(ust);

                ust.BringToFront();
                nesneNo = sayi;
                sayi++;
                if (sayi % 4 == 0)
                    sayi = 0;
               

            }

            public void oynat()
            {

                //if (durum==false)
                //{
                //    ust.Top = ust.Top - 20;
                //    ust.BackColor = Color.Yellow;
                //    durum = true;
                //}
                //else
                //{
                //    ust.Top = ust.Top + 20;
                //    ust.BackColor = Color.Red;
                //    durum = false;

                //}
                

                switch (nesneNo)
                {
                    case 0:
                        if (durum == false)
                        {
                            ust.Top = ust.Top - 20;
                            ust.BackColor = Color.Yellow;
                            ses.Play();
                            beslik.toplamArttir('1', kolon);
                            dizi[nesneNo] = 1;
                            durum = true;
                        }
                        else if(durum==true && dizi[nesneNo+1]==0)
                        {
                            ust.Top = ust.Top + 20;
                            ust.BackColor = Color.Red;
                            ses.Play();
                            beslik.toplamAzalt('1', kolon);
                            dizi[nesneNo] = 0;
                            durum = false;

                        }
                        break;

                    case 1:
                        if (durum == false && dizi[nesneNo-1]==1)
                        {
                            ust.Top = ust.Top - 20;
                            ust.BackColor = Color.Yellow;
                            ses.Play();
                            beslik.toplamArttir('1', kolon);
                            dizi[nesneNo] = 1;
                            durum = true;
                        }
                        else if (durum == true && dizi[nesneNo+1] == 0)
                        {
                            ust.Top = ust.Top + 20;
                            ust.BackColor = Color.Red;
                            ses.Play();
                            beslik.toplamAzalt('1', kolon);
                            dizi[nesneNo] = 0;
                            durum = false;

                        }
                        break;

                    case 2:
                        if (durum == false && dizi[nesneNo-1] == 1)
                        {
                            ust.Top = ust.Top - 20;
                            ust.BackColor = Color.Yellow;
                            ses.Play();
                            beslik.toplamArttir('1', kolon);
                            dizi[nesneNo] = 1;
                            durum = true;
                        }
                        else if (durum == true && dizi[nesneNo + 1] == 0)
                        {
                            ust.Top = ust.Top + 20;
                            ust.BackColor = Color.Red;
                            ses.Play();
                            beslik.toplamAzalt('1', kolon);
                            dizi[nesneNo] = 0;
                            durum = false;

                        }
                        break;

                    case 3:
                        if (durum == false && dizi[nesneNo-1] == 1)
                        {
                            ust.Top = ust.Top - 20;
                            ust.BackColor = Color.Yellow;
                            ses.Play();
                            beslik.toplamArttir('1', kolon);
                            dizi[nesneNo] = 1;
                            durum = true;
                        }
                        else if (durum == true && dizi[nesneNo + 1] == 0)
                        {
                            ust.Top = ust.Top + 20;
                            ust.BackColor = Color.Red;
                            ses.Play();
                            beslik.toplamArttir('1', kolon);
                            dizi[nesneNo] = 0;
                            durum = false;

                        }
                        break;
                       






                }
            }

            public void ust_Click(object sender, EventArgs e)
            {

                oynat();

            }



        }




        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            beslik[] deneme = new beslik[14];
            birlik[,] deneme2 = new birlik[4,14];   


            for (int i = 0; i < 14; i++)
                deneme[i] = new beslik(this, i);

            for (int i = 0; i < 14; i++)
                for (int j = 0; j < 4; j++)
                    deneme2[j, i] = new birlik(this, i);

            //Label[] lbl = new Label[14];

            //for(int i = 0;i < 14; i++)
            //{
            //    lbl[i] = new Label();
            //    lbl[i].Size = new Size(16, 16);
            //    lbl[i].Location = new Point(58 + i*50, 2);
            //    lbl[i].BackColor = Color.Transparent;
            //    lbl[i].ForeColor = Color.White;
            //    lbl[i].Font = new Font("Microsoft Sans Serif", 9.5f, FontStyle.Bold);
            //    lbl[i].BringToFront();

            //}

            //for (int i = 0; i < 14; i++)
            //    panel14.Controls.Add(lbl[i]);

            //lbl[4].Text = "123";

        }

        private void button1_Click(object sender, EventArgs e)
        {

           
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Label deneme = new Label();
            deneme.Location = new Point(58, 2);
            deneme.BringToFront();
            this.Controls.Add(deneme);
            deneme.Text = "2324";
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Dispose();
            Form1 frm = new Form1();
            frm.Show();
        }
    }
}
