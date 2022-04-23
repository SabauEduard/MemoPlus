using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memo_
{
    public partial class Form1 : Form
    {
        private readonly Random numar = new Random();
        int nr_click = 0;
        int ant = 0;
        int timp = 0;
        int ii, jj;
        int ivechi, jvechi;
        int perechi = 0;
        int[] ap = new int[20] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; 
        TextBox[,] t = new TextBox[5, 8];
        Button[,] b = new Button[5, 8];
        public Form1()
        {
            InitializeComponent();
        }
        public void b_Click(object sender, EventArgs eArgs)
        {
            
            ii = (Convert.ToInt32(((Button)sender).Top) - 100) / 63;
            jj = (Convert.ToInt32(((Button)sender).Left) - 150) / 63;
            b[ii, jj].Visible = false;
            nr_click++;
            t[ii, jj].SelectionLength = 0;
            if (nr_click == 1)
            {
               
                ant = Convert.ToInt32(((Button)sender).Tag);
                ivechi = ii;
                jvechi = jj;
            }
            else
            {

                int ok = 0; 
                nr_click = 0;
                int curent = Convert.ToInt32(((Button)sender).Tag);
                if (ant == curent)
                    for (int i = 0; i < 4; i++)
                        for (int j = 0; j < 8; j++)
                            if (Convert.ToInt32(b[i, j].Tag) == ant)
                            {
                                t[i, j].BackColor = Color.Green;
                                ok = 1;
                                perechi++;
                            }
                
               if(ok==0)
                {
                    timer1.Start();

                }
                
            }
            if (perechi == 32)
            {
                MessageBox.Show("Ai terminat in " + timp + " de secunde!!!");
                timer2.Stop();
            }
        }
            private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 8; j++)
                {
                    //butoane
                    b[i, j] = new Button();
                    b[i, j].Height = 60;
                    b[i, j].Width = 60;
                    b[i, j].Top = 100 + 63 * i;
                    b[i, j].Left = 150 + 63 * j;
                    b[i, j].Click += new EventHandler(b_Click);
                   
                    Controls.Add(b[i, j]);
                    //text boxuri
                    t[i, j] = new TextBox();
                    t[i, j].Multiline = true;
                    t[i, j].Height = 60;
                    t[i, j].Width = 60;                 
                    t[i, j].Top = 100 + 63 * i;
                    t[i, j].Left = 150 + 63 * j;
                    
                    int nr = numar.Next(65, 81);
                    int incercari = 0;
                    while ((ap[nr - 65] != 1 || ap[nr - 65] != 0) && incercari != 10)
                        {
                          nr = numar.Next(65, 81);
                        if (ap[nr - 65] == 1 || ap[nr - 65] == 0)
                            break; 
                        else incercari++;
                        
                        }
                    if(incercari==10)
                    {
                        for (int k = 0; k < 16; k++)
                            if (ap[k] == 0 || ap[k] == 1)
                            {
                                nr = k+65;
                                break;
                            }
                    }
                    ap[nr-65]++; 
                    char ch = Convert.ToChar(nr);
                    t[i, j].Text = Convert.ToString(ch);
                    t[i, j].TextAlign = HorizontalAlignment.Center;
                    t[i, j].Font = new Font(t[i, j].Font.FontFamily, 35);
                    t[i, j].ReadOnly = true;
                   
                    Controls.Add(t[i, j]);
                    b[i, j].Tag = nr - 65;

                }
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timp++;
            label2.Font = new Font(label2.Font.FontFamily, 27);
            label2.Text = Convert.ToString(timp);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            b[ii, jj].Visible = true;
            b[ivechi, jvechi].Visible = true;
            timer1.Stop();

        }
    }
}
