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
        public string ogr_no, ogr_tc,ogr_sif, ogr_isim, ogr_soyisim, ogr_telefon;
        public void sifre_getir(TextBox sif)
        {
            baglan.Open();

            MySqlCommand sql = new MySqlCommand("Select kul_sif from kul_bilgi where kul_tc=@tc",baglan);
            sql.Parameters.AddWithValue("@tc",ogr_tc);
            MySqlDataReader dr = sql.ExecuteReader();
            while(dr.Read())
            {
                ogr_sif = dr["kul_sif"].ToString();
                sif.Text = dr["kul_sif"].ToString();
            }
            dr.Close();
            baglan.Close();
        }
        public void sifre_guncelle(TextBox sif)
        {
            baglan.Open();
            MySqlCommand sql = new MySqlCommand("Update kul_bilgi SET kul_sif=@sif where kul_tc=@tc",baglan);
            sql.Parameters.AddWithValue("@sif",sif.Text);
            sql.Parameters.AddWithValue("@tc",ogr_tc);
            sql.ExecuteNonQuery();

            baglan.Close();
        }
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
            if (panel3.Visible == false)
            {
                panel3.Dock = DockStyle.Fill;
                panel3.Visible = true;
                sifre_getir(tb_sif);
                tb_sif.Text = ogr_sif.ToString();
                textBox1.Text = ogr_no;
                textBox2.Text = ogr_tc;
                textBox3.Text = ogr_isim;
                textBox4.Text = ogr_soyisim;
                textBox5.Text = ogr_telefon;
                
            }
            else
            {
                panel3.Visible = false;
                panel3.Dock = DockStyle.None;

            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            guncelle();
            bilgiler(ogr_tc);
            sifre_guncelle(tb_sif);
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
        public void not_getir()
        {
            baglan.Open();

            MySqlCommand sql = new MySqlCommand("Select * from not_bilgi where ogr_no=@no",baglan);
            sql.Parameters.AddWithValue("@no",ogr_no);
            MySqlDataAdapter da = new MySqlDataAdapter(sql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            

            if (panel_not.Visible == false)
            {
                panel_not.Dock = DockStyle.Fill;
                panel_not.Visible = true;
                not_getir();
            }
            else
            {
                panel_not.Visible = false;
                panel_not.Dock = DockStyle.None;

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
