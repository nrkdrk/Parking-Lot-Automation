using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using Microsoft.SqlServer;

namespace otopark
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string filename;
        string openname="otopark.accdb";
        //Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Berk\Desktop\otopark\otopark.mdb

        OleDbConnection baglantı;
        OleDbCommand komut = new OleDbCommand();
        private void verigörüntüle()
        {
            listView1.Items.Clear();
            baglantı=new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + openname);
            baglantı.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglantı;
            komut.CommandText=("Select * from otopark");
            OleDbDataReader oku = komut.ExecuteReader();
            while(oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Aracin_Plakasi"].ToString();
                ekle.SubItems.Add(oku["Ad_Soyad"].ToString());
                ekle.SubItems.Add(oku["Telefon_Nümarasi"].ToString());
                ekle.SubItems.Add(oku["Aracin_Markasi"].ToString());
                ekle.SubItems.Add(oku["Aracin_Rengi"].ToString());
                ekle.SubItems.Add(oku["Aracin_Yeri"].ToString());
                ekle.SubItems.Add(oku["Aracin_Giris_Tarihi"].ToString());

                listView1.Items.Add(ekle);
            }
            baglantı.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            verigörüntüle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            OleDbCommand komut = new OleDbCommand("Insert into otopark (Aracin_Plakasi,Ad_Soyad,Telefon_Nümarasi,Aracin_Markasi,Aracin_Rengi,Aracin_Yeri,Aracin_Giris_Tarihi) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox7.Text.ToString() + "')", baglantı);
            komut.ExecuteNonQuery();
            baglantı.Close();
            verigörüntüle();
        }

        private void yedekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Yedeği kaydet";
            saveFileDialog1.CheckFileExists = false;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "ydk";
            saveFileDialog1.Filter = "YDK Dosyası (*.ydk)|*.ydk";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog1.FileName;
                File.Copy(openname, filename);
            }
            
        }

        private void geriYükleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Yedeği kaydet";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.DefaultExt = "ydk";
            openFileDialog1.Filter = "YDK Dosyası (*.ydk)|*.ydk";
            openFileDialog1.FilterIndex = 2;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string backupdest = "data/" + openFileDialog1.SafeFileName;
                string root = @"data";
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                File.Copy(openFileDialog1.FileName, backupdest);
                openname = backupdest;
                Properties.Settings.Default.openname = openname;
                Properties.Settings.Default.Save();
                verigörüntüle();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            openname = Properties.Settings.Default.openname;
            comboBox1.Text = Properties.Settings.Default.tema;
            //for (int i = 44; i > 0; i--)
            //{
            //    MessageBox.Show(i + " kere maşallah.");
            //}
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Beyaz Tema")
            {
            this.BackColor = System.Drawing.Color.White;
            button1.BackColor = Color.Gold;
            button2.BackColor = Color.Gold;
            button3.BackColor = Color.Gold;
            button4.BackColor = Color.Gold;
            textBox1.BackColor = Color.Gold;
            textBox2.BackColor = Color.Gold;
            textBox3.BackColor = Color.Gold;
            textBox4.BackColor = Color.Gold;
            textBox5.BackColor = Color.Gold;
            textBox6.BackColor = Color.Gold;
            textBox7.BackColor = Color.Gold;
            textBox8.BackColor = Color.Gold;
            textBox9.BackColor = Color.Gold;
            textBox10.BackColor = Color.Gold;
            listView1.BackColor = Color.Gold;
            menuStrip1.BackColor = Color.Gold;
            geriYükleToolStripMenuItem.BackColor = Color.Gold;
            yedekleToolStripMenuItem.BackColor = Color.Gold;

            }
            if (comboBox1.Text == "Mavi Tema")
            {
                this.BackColor = System.Drawing.Color.DarkCyan;
                button1.BackColor = Color.DarkSlateGray;
                button2.BackColor = Color.DarkSlateGray;
                button3.BackColor = Color.DarkSlateGray;
                button4.BackColor = Color.DarkSlateGray;
                textBox1.BackColor = Color.DarkSlateGray;
                textBox2.BackColor = Color.DarkSlateGray;
                textBox3.BackColor = Color.DarkSlateGray;
                textBox4.BackColor = Color.DarkSlateGray;
                textBox5.BackColor = Color.DarkSlateGray;
                textBox6.BackColor = Color.DarkSlateGray;
                textBox7.BackColor = Color.DarkSlateGray;
                textBox8.BackColor = Color.DarkSlateGray;
                textBox9.BackColor = Color.DarkSlateGray;
                textBox10.BackColor = Color.DarkSlateGray;
                listView1.BackColor = Color.DarkSlateGray;
                menuStrip1.BackColor = Color.DarkSlateGray;
                geriYükleToolStripMenuItem.BackColor = Color.DarkSlateGray;
                yedekleToolStripMenuItem.BackColor = Color.DarkSlateGray;
            }
            if (comboBox1.Text == "Yeşil Tema")
            {
                this.BackColor = System.Drawing.Color.DarkOliveGreen;
                button1.BackColor = Color.OliveDrab;
                button2.BackColor = Color.OliveDrab;
                button3.BackColor = Color.OliveDrab;
                button4.BackColor = Color.OliveDrab;
                textBox1.BackColor = Color.OliveDrab;
                textBox2.BackColor = Color.OliveDrab;
                textBox3.BackColor = Color.OliveDrab;
                textBox4.BackColor = Color.OliveDrab;
                textBox5.BackColor = Color.OliveDrab;
                textBox6.BackColor = Color.OliveDrab;
                textBox7.BackColor = Color.OliveDrab;
                textBox8.BackColor = Color.OliveDrab;
                textBox9.BackColor = Color.OliveDrab;
                textBox10.BackColor = Color.OliveDrab;
                listView1.BackColor = Color.OliveDrab;
                menuStrip1.BackColor = Color.OliveDrab;
                geriYükleToolStripMenuItem.BackColor = Color.OliveDrab;
                yedekleToolStripMenuItem.BackColor = Color.OliveDrab;
            }
            if (comboBox1.Text == "Lila Tema")
            {
                this.BackColor = System.Drawing.Color.MediumOrchid;
                button1.BackColor = Color.Purple;
                button2.BackColor = Color.Purple;
                button3.BackColor = Color.Purple;
                button4.BackColor = Color.Purple;
                textBox1.BackColor = Color.Purple;
                textBox2.BackColor = Color.Purple;
                textBox3.BackColor = Color.Purple;
                textBox4.BackColor = Color.Purple;
                textBox5.BackColor = Color.Purple;
                textBox6.BackColor = Color.Purple;
                textBox7.BackColor = Color.Purple;
                textBox8.BackColor = Color.Purple;
                textBox9.BackColor = Color.Purple;
                textBox10.BackColor = Color.Purple;
                listView1.BackColor = Color.Purple;
                menuStrip1.BackColor = Color.Purple;
                yedekleToolStripMenuItem.BackColor = Color.MediumOrchid;
                geriYükleToolStripMenuItem.BackColor = Color.MediumOrchid;
            }
            if (comboBox1.Text == "Kırmızı Tema")
            {
                this.BackColor = System.Drawing.Color.Maroon;
                button1.BackColor = Color.Firebrick;
                button2.BackColor = Color.Firebrick;
                button3.BackColor = Color.Firebrick;
                button4.BackColor = Color.Firebrick;
                textBox1.BackColor = Color.Firebrick;
                textBox2.BackColor = Color.Firebrick;
                textBox3.BackColor = Color.Firebrick;
                textBox4.BackColor = Color.Firebrick;
                textBox5.BackColor = Color.Firebrick;
                textBox6.BackColor = Color.Firebrick;
                textBox7.BackColor = Color.Firebrick;
                textBox8.BackColor = Color.Firebrick;
                textBox9.BackColor = Color.Firebrick;
                textBox10.BackColor = Color.Firebrick;
                listView1.BackColor = Color.Firebrick;
                menuStrip1.BackColor = Color.Firebrick;
                yedekleToolStripMenuItem.BackColor = Color.Firebrick;
                geriYükleToolStripMenuItem.BackColor = Color.Firebrick;
            }
            Properties.Settings.Default.tema = comboBox1.Text;
            Properties.Settings.Default.Save();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            komut.Connection = baglantı;
            komut.CommandText = "delete from otopark where Aracin_Plakasi='" + textBox8.Text+ "'";
            komut.ExecuteNonQuery();
            baglantı.Close();
            verigörüntüle();
            //DateTime.Today
            DateTime bugün = DateTime.Now;
            MessageBox.Show(bugün.ToString());

        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult a;
            a = MessageBox.Show("Uygulamayı sonlandırmak üzeresiniz, emin misiniz?", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (a == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult a;
            a = MessageBox.Show("Uygulamayı sonlandırmak üzeresiniz, emin misiniz?", " ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (a == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // listView1.Columns = System.Drawing.Color.Green;
            listView1.ForeColor = Color.Red;
            try
            {
                textBox8.Text = listView1.SelectedItems[0].SubItems[0].Text;
                textBox9.Text = listView1.SelectedItems[0].SubItems[0].Text;
                textBox10.Text = listView1.SelectedItems[0].SubItems[5].Text;
            }
            catch
            {

            }

        }

        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (var sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;

                using (var headerFont = new Font("Microsoft Sans Serif", 9, FontStyle.Regular))
                {
                    e.Graphics.FillRectangle(Brushes.Pink, e.Bounds);
                    e.Graphics.DrawString(e.Header.Text, headerFont,
                        Brushes.Black, e.Bounds, sf);
                }
            }
        }

    }
}
