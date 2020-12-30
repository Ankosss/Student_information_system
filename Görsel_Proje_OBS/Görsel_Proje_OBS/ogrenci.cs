using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Görsel_Proje_OBS
{
    public partial class ogrenci : Form
    {
        public ogrenci()
        {
            InitializeComponent();
        }
        MySqlConnection baglan = new MySqlConnection("Server=localhost;Database=obs;user='root';Pwd='Umitcan123!';");
        public string ogr_no, ogr_tc, ogr_isim, ogr_soyisim, ogr_telefon;
        int bg_srg;
        public void guncelle()
        {
            baglan.Open();

            String sql = "Update ogr_bilgi set ogr_tc=@tc, ogr_isim=@ad,ogr_soyisim=@soyad,ogr_telefon=@tel  where ogr_no=@no ";
            MySqlCommand cmd = new MySqlCommand(sql, baglan);
            cmd.Parameters.AddWithValue("@no", textBox1.Text.ToString());
            cmd.Parameters.AddWithValue("@tc", textBox2.Text.ToString());
            cmd.Parameters.AddWithValue("@ad", textBox3.Text.ToString());
            cmd.Parameters.AddWithValue("@soyad", textBox4.Text.ToString());
            cmd.Parameters.AddWithValue("@tel", textBox5.Text.ToString());
            cmd.ExecuteNonQuery();
            baglan.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (panel1.Width < 130)
            {
                timer1.Start();
            }
            else
            {
                timer2.Start();
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (bg_srg == 0)
            {
                panel3.Visible = true;
                bg_srg = 1;
                textBox1.Text = ogr_no;
                textBox2.Text = ogr_tc;
                textBox3.Text = ogr_isim;
                textBox4.Text = ogr_soyisim;
                textBox5.Text = ogr_telefon;
            }
            else
            {
                panel3.Visible = false;
                bg_srg = 0;

            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            guncelle();
            bilgiler(ogr_tc);
            ad_tc_yazdır();
        }
        bool bilgiler(string tc)
        {
            baglan.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select * from ogr_bilgi where ogr_tc=@tc";
            cmd.Parameters.AddWithValue("@tc", ogr_tc);
            cmd.Connection = baglan;
            MySqlDataReader login = cmd.ExecuteReader();
            if (login.Read())
            {
                login.Close();
                login = cmd.ExecuteReader();
                while (login.Read())
                {

                    ogr_no = login["ogr_no"].ToString();
                    ogr_isim = login["ogr_isim"].ToString();
                    ogr_soyisim = login["ogr_soyisim"].ToString();
                    ogr_telefon = login["ogr_telefon"].ToString();
                }
                baglan.Close();
                login.Close();
                return true;
            }
            else
            {
                login.Close();
                baglan.Close();
                return false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {//programı kapat
            Application.Exit();
        }

        public void ad_tc_yazdır()
        {
            label1.Text = ogr_tc + " - " + ogr_isim + " " + ogr_soyisim;
        }
        private void ogrenci_Load(object sender, EventArgs e)
        {
            try
            {
                bilgiler(ogr_tc);
                ad_tc_yazdır();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata ile karşılaşıldı" + ex);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Width += 5;

            if (panel1.Width >= 160)
            {
                timer1.Stop();
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            panel1.Width -= 5;
            if (panel1.Width == 35)
            {
                timer2.Stop();
            }
        }
    }
}
