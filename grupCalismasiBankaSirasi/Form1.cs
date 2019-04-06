using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace grupCalismasiBankaSirasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int siraNo = 0, sayacGise=100, sayacFatura = 200, sayacKredi = 300, sayacParaCek = 400;
        string[] musteriAdGise = new string[100];
        string[] musteriAdFatura = new string[100];
        string[] musteriAdKredi = new string[100];
        string[] musteriAdParaCek = new string[100];
        private void comboIslemSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (comboIslemSec.SelectedIndex == 0)
            {
                siraNo = sayacGise;
                sayacGise += 1;

            }
            else if (comboIslemSec.SelectedIndex == 1)
            {
                siraNo = sayacFatura;
                sayacFatura += 1;
            }
            else if (comboIslemSec.SelectedIndex == 2)
            {
                siraNo = sayacKredi;
                sayacKredi += 1;
            }
            else if (comboIslemSec.SelectedIndex == 3)
            {
                siraNo = sayacParaCek;
                sayacParaCek += 1;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboIslemSec.Items.Add("Gişe İşlemleri");
            comboIslemSec.Items.Add("Fatura İşlemleri");
            comboIslemSec.Items.Add("Kredi İşlemleri");
            comboIslemSec.Items.Add("Para Çekme İşlemleri");
            progressBar1.Hide(); progressBar2.Hide(); progressBar3.Hide(); progressBar4.Hide();
        }
        Queue<int> musterilerGise = new Queue<int>();
        Queue<int> musterilerFatura = new Queue<int>();
        Queue<int> musterilerKredi = new Queue<int>();
        Queue<int> musterilerParaCek = new Queue<int>();
        // Queue<int> musteriler= new Queue<int>();
        private void btnNumaraAl_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Merhaba " +txtAd.Text.ToUpper() + "\nSıra Numaranız : " + siraNo);
            // sıra numarasına göre kuyruklara eleman ekleniyor..
            if (siraNo >= 100 && siraNo < 200)
            {
                musterilerGise.Enqueue(siraNo); 
            } else if (siraNo >= 200 && siraNo < 300)
            {
                musterilerFatura.Enqueue(siraNo); 
            } else if (siraNo >= 300 && siraNo < 400)
            {
                musterilerKredi.Enqueue(siraNo); 
            } else if (siraNo >= 400 && siraNo < 500)
            {
                musterilerParaCek.Enqueue(siraNo); 
            }
           
            // bütün kuyruklar listbox'a yazdırılıyor.
            foreach (int musteri in musterilerGise)
            {
                listBox1.Items.Add(musteri);        // kuyruğun herbir elemanı listbox!a atılır
            }
            foreach (int musteri in musterilerFatura)
            {
                listBox1.Items.Add(musteri);       
            }
            foreach (int musteri in musterilerKredi)
            {
                listBox1.Items.Add(musteri);       
            }
            foreach (int musteri in musterilerParaCek)
            {
                listBox1.Items.Add(musteri);        
            }

            comboIslemSec.Text = "";
            txtAd.Text = "";
        }
        private void btnBank1_Click(object sender, EventArgs e)     // bankacı bu butona tıklayınca sıradaki gişe işlemi müşterisini çağırıyor
        {
            
            progressBar1.Value = 0; 
            timer1.Enabled = true;  timer1.Interval = 1000;
            for (int i = 0; i < musterilerGise.Count; i++)
            {
                if (musterilerGise.ElementAt(i) >= 100 && musterilerGise.ElementAt(i) < 200)   // sıra numarası kontrolü ( gişe işlemleri için )
                {
                    txtBank1.Text = musterilerGise.ElementAt(i).ToString();
                    musterilerGise.Dequeue();
                    listBox1.Items.Clear();
                    // bütün kuyruklar listbox'a yazdırılıyor.
                    foreach (int musteri in musterilerGise)
                    {
                        listBox1.Items.Add(musteri);        
                    }
                    foreach (int musteri in musterilerFatura)
                    {
                        listBox1.Items.Add(musteri);
                    }
                    foreach (int musteri in musterilerKredi)
                    {
                        listBox1.Items.Add(musteri);
                    }
                    foreach (int musteri in musterilerParaCek)
                    {
                        listBox1.Items.Add(musteri);
                    }
                    comboIslemSec.Text = "";
                    break;      // döngüden çıkması için
                }
            }
        }
        private void btnBank2_Click(object sender, EventArgs e)
        {
            progressBar2.Value = 0; 
            timer2.Enabled = true; timer2.Interval = 1000;
            for (int i = 0; i < musterilerFatura.Count; i++)
            {
                if (musterilerFatura.ElementAt(i) >= 200 && musterilerFatura.ElementAt(i) < 300)   // sıra numarası kontrolü ( gişe işlemleri için )
                {
                    txtBank2.Text = musterilerFatura.ElementAt(i).ToString();
                    musterilerFatura.Dequeue();
                    listBox1.Items.Clear();
                    // bütün kuyruklar listbox'a yazdırılıyor.
                    foreach (int musteri in musterilerGise)
                    {
                        listBox1.Items.Add(musteri);
                    }
                    foreach (int musteri in musterilerFatura)
                    {
                        listBox1.Items.Add(musteri);
                    }
                    foreach (int musteri in musterilerKredi)
                    {
                        listBox1.Items.Add(musteri);
                    }
                    foreach (int musteri in musterilerParaCek)
                    {
                        listBox1.Items.Add(musteri);
                    }

                    comboIslemSec.Text = "";
                    break;      // döngüden çıkması için
                }
            }
        }

        private void btnBank3_Click(object sender, EventArgs e)
        {
            progressBar3.Value = 0; 
            timer3.Enabled = true; timer3.Interval = 1000;
            for (int i = 0; i < musterilerKredi.Count; i++)
            {
                if (musterilerKredi.ElementAt(i) >= 300 && musterilerKredi.ElementAt(i) < 400)   // sıra numarası kontrolü ( gişe işlemleri için )
                {
                    txtBank3.Text = musterilerKredi.ElementAt(i).ToString();
                    musterilerKredi.Dequeue();
                    listBox1.Items.Clear();
                    // bütün kuyruklar listbox'a yazdırılıyor.
                    foreach (int musteri in musterilerGise)
                    {
                        listBox1.Items.Add(musteri);
                    }
                    foreach (int musteri in musterilerFatura)
                    {
                        listBox1.Items.Add(musteri);
                    }
                    foreach (int musteri in musterilerKredi)
                    {
                        listBox1.Items.Add(musteri);
                    }
                    foreach (int musteri in musterilerParaCek)
                    {
                        listBox1.Items.Add(musteri);
                    }

                    comboIslemSec.Text = "";
                    break;      // döngüden çıkması için
                }
            }
        }

        private void btnBank4_Click(object sender, EventArgs e)
        {
            progressBar4.Value = 0; 
            timer4.Enabled = true; timer4.Interval = 1000;
            for (int i = 0; i < musterilerParaCek.Count; i++)
            {
                if (musterilerParaCek.ElementAt(i) >= 400 && musterilerParaCek.ElementAt(i) < 500)   // sıra numarası kontrolü ( gişe işlemleri için )
                {
                    txtBank4.Text = musterilerParaCek.ElementAt(i).ToString();
                    musterilerParaCek.Dequeue();
                    listBox1.Items.Clear();
                    // bütün kuyruklar listbox'a yazdırılıyor.
                    foreach (int musteri in musterilerGise)
                    {
                        listBox1.Items.Add(musteri);
                    }
                    foreach (int musteri in musterilerFatura)
                    {
                        listBox1.Items.Add(musteri);
                    }
                    foreach (int musteri in musterilerKredi)
                    {
                        listBox1.Items.Add(musteri);
                    }
                    foreach (int musteri in musterilerParaCek)
                    {
                        listBox1.Items.Add(musteri);
                    }
                    comboIslemSec.Text = "";
                    break;      // döngüden çıkması için
                }
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (txtBank1.Text != "")
            {
                if (progressBar1.Value < 200)
                {
                    progressBar1.Show();
                    lblB1.Text = "İŞLEMDE"; lblB1.ForeColor = Color.Red;
                    progressBar1.Value += 5;
                    progressBar1.PerformStep();
                }
                else
                {
                    lblB1.Text = "MÜSAİT"; lblB1.ForeColor = Color.Green;
                    txtBank1.Text = "";
                    progressBar1.Value = 0;
                    progressBar1.Hide();
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (txtBank2.Text != "")
            {
                if (progressBar2.Value < 200)
                {
                    progressBar2.Show();
                    lblB2.Text = "İŞLEMDE"; lblB2.ForeColor = Color.Red;
                    progressBar2.Value += 5;
                    progressBar2.PerformStep();
                }
                else
                {
                    lblB2.Text = "MÜSAİT"; lblB2.ForeColor = Color.Green;
                    txtBank2.Text = "";
                    progressBar2.Value = 0;
                    progressBar2.Hide();
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (txtBank3.Text != "")
            {
                if (progressBar3.Value < 200)
                {
                    progressBar3.Show();
                    lblB3.Text = "İŞLEMDE"; lblB3.ForeColor = Color.Red;
                    progressBar3.Value += 5;
                    progressBar3.PerformStep();
                }
                else
                {
                    lblB3.Text = "MÜSAİT"; lblB3.ForeColor = Color.Green;
                    txtBank3.Text = "";
                    progressBar3.Value = 0;
                    progressBar3.Hide();
                }
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (txtBank4.Text != "")
            {
                if (progressBar4.Value < 200)
                {
                    progressBar4.Show();
                    lblB4.Text = "İŞLEMDE"; lblB4.ForeColor = Color.Red;
                    progressBar4.Value += 5;
                    progressBar4.PerformStep();
                }
                else
                {
                    lblB4.Text = "MÜSAİT"; lblB4.ForeColor = Color.Green;
                    txtBank4.Text = "";
                    progressBar4.Value = 0;
                    progressBar4.Hide();
                }
            }
        }
    }
}
