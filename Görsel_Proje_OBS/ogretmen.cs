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
    public partial class ogretmen : Form
    {
        MySqlConnection baglan;
        public ogretmen()
        {
            InitializeComponent();
            baglan = new MySqlConnection("Server=localhost;Database=obs;user='root';Pwd='Umitcan123!';");
        }

        public string ogrt_tc, ogrt_no,ogr_ad,ogr_sad;

        private void temizle(Control ctl)
        {
            foreach (Control c in ctl.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                if (c.Controls.Count > 0)
                {
                    temizle(c);
                }
            }




        }


        /********************************/
        public void not_ekle(TextBox not, ComboBox tur)
        {
            baglan.Open();

            MySqlCommand sql = new MySqlCommand("Insert into not_bilgi (ogr_no,ders_no,not_not,not_tur) values (@ogr,@ders,@not,@ntur)", baglan);
            sql.Parameters.AddWithValue("@ogr", ogr_no_getir());
            sql.Parameters.AddWithValue("@ders", ders_id_getir(cb_not_ders));
            sql.Parameters.AddWithValue("@not", not.Text.ToString());
            sql.Parameters.AddWithValue("@ntur", tur.SelectedIndex);
            sql.ExecuteNonQuery();
            baglan.Close();
        }
        public void ogr_ad_parcala(ComboBox c)
        {
            string ad="";
            ogr_ad = ""; ogr_sad = "";
            int cursor = 0;
            string isim = c.Text.ToString();
            while (cursor != -1)
            {
                cursor = isim.IndexOf(" ", cursor);
                if (cursor != -1)
                {
                    ad += isim.Substring(0, cursor) + " ";
                    ogr_ad = ad.Substring(0, ad.Length - 1);
                    isim = isim.Remove(0, cursor);
                }
                else
                {
                    ogr_sad = isim.Trim();
                    break;
                }
            }
        }
        public int ogr_no_getir()
        {

            int id = -1;
            MySqlCommand sql = new MySqlCommand("Select ogr_no from ogr_bilgi where ogr_isim=@ad and ogr_soyisim=@sad", baglan);
            sql.Parameters.AddWithValue("@ad", ogr_ad);
            sql.Parameters.AddWithValue("@sad", ogr_sad);
            MySqlDataReader dr = sql.ExecuteReader();
            while (dr.Read())
            {
                id = int.Parse(dr["ogr_no"].ToString());
            }
            dr.Close();
            if (id==-1)
            {
                MessageBox.Show("Öğrenci numarası bulunamadı\nÖğrenci ad="+ogr_ad+"Öğrenci Soyad="+ogr_sad);
            }
            return id;
        }

        /********************************/
        public void sinif_getir()
        {
            baglan.Open();

            MySqlCommand sql = new MySqlCommand("Select * from not_bilgi where ders_no=@no",baglan);
            sql.Parameters.AddWithValue("@no",ders_id_getir(cb_not_ders));
            MySqlDataAdapter da = new MySqlDataAdapter(sql) ;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            baglan.Close();
        }
        public void ogr_getir(ComboBox ogr)
        {
            ogr.Items.Clear();
            string ad, soyad;
            baglan.Open();

            MySqlCommand sql = new MySqlCommand("Select * from ogr_bilgi where sinif_no=@no  ",baglan);
            sql.Parameters.AddWithValue("@no", sinif_no_getir(cb_not_ders));
            MySqlDataReader dr = sql.ExecuteReader();
            while(dr.Read())
            {
                ad = dr["ogr_isim"].ToString();
                soyad = dr["ogr_soyisim"].ToString();
                ogr.Items.Add(ad+" "+soyad);
            }

            baglan.Close();
        }
        public string sinif_no_getir(ComboBox ders)
        {
            String id = "";
            MySqlCommand sql = new MySqlCommand("Select sinif_no from ders where ders_ad=@ad", baglan);
            sql.Parameters.AddWithValue("@ad", ders.Text);
            MySqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {
                id = dr["sinif_no"].ToString();
            }
            dr.Close();
            return id;
        }
        public string ders_id_getir(ComboBox ders)
        {
            String id = "";
            MySqlCommand sql = new MySqlCommand("Select ders_no from ders where ders_ad=@ad",baglan);
            sql.Parameters.AddWithValue("@ad",ders.Text);
            MySqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {
                id = dr["ders_no"].ToString();
            }
            dr.Close();
            return id;
        }
        public void ogrt_no_getir()
        {
            baglan.Open();
            MySqlCommand sql = new MySqlCommand("Select ogrt_no from ogrt_bilgi where ogrt_tc=@tc", baglan);
            sql.Parameters.AddWithValue("@tc", ogrt_tc);
            MySqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {
                ogrt_no = dr["ogrt_no"].ToString();
            }
            dr.Close();
            baglan.Close();
        }
        public void verilen_ders_getir(ComboBox ders)
        {
            ders.Items.Clear();
            baglan.Open();

            MySqlCommand sql = new MySqlCommand("Select * from ders where ogrt_no=@no", baglan);
            sql.Parameters.AddWithValue("@no", ogrt_no);
            MySqlDataReader dr = sql.ExecuteReader();
            while (dr.Read())
            {
                ders.Items.Add(dr["ders_ad"].ToString());
            }
            dr.Close();
            baglan.Close();
        }
        public void ogrt_tc_sifre_kontrol()
        {
            String tc = "", sif = "";
            baglan.Open();

            MySqlCommand sql = new MySqlCommand("Select kul_tc,kul_sif from kul_bilgi where kul_tc=@tc", baglan);
            sql.Parameters.AddWithValue("@tc", ogrt_tc);
            MySqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {
                tc = dr["kul_tc"].ToString();
                sif = dr["kul_sif"].ToString();
            }
            if (tc == sif)
            {
                MessageBox.Show("TC kimlik numaranız ve Şifreniz aynı lütfen en yakın sürede güvenliğiniz için şifrenizi değiştiriniz.", "Dikkat");
            }
            dr.Close();
            baglan.Close();
        }
        public void bilgi_getir(TextBox no, TextBox tc, TextBox sif, TextBox ad, TextBox soyad, TextBox tel)
        {
            baglan.Open();

            MySqlCommand sql = new MySqlCommand("Select * from ogrt_bilgi", baglan);
            MySqlDataReader dr = sql.ExecuteReader();

            while (dr.Read())
            {
                no.Text = dr["ogrt_no"].ToString();
                tc.Text = dr["ogrt_tc"].ToString();
                ad.Text = dr["ogrt_isim"].ToString();
                soyad.Text = dr["ogrt_soyisim"].ToString();
                tel.Text = dr["ogrt_telefon"].ToString();
            }
            dr.Close();

            sql = new MySqlCommand("Select kul_sif from kul_bilgi where kul_tc=@tc", baglan);
            sql.Parameters.AddWithValue("@tc", ogrt_tc);
            dr = sql.ExecuteReader();
            while (dr.Read())
            {
                sif.Text = dr["kul_sif"].ToString();
            }
            dr.Close();
            baglan.Close();
        }
        public void bilgi_guncelle(TextBox no, TextBox tc, TextBox sif, TextBox ad, TextBox soyad, TextBox tel)
        {
            baglan.Open();

            MySqlCommand sql = new MySqlCommand("Update ogrt_bilgi set ogrt_isim=@ad,ogrt_soyisim=@soyad,ogrt_telefon=@tel  where ogrt_no=@no ", baglan);
            sql.Parameters.AddWithValue("@ad", ad.Text);
            sql.Parameters.AddWithValue("@soyad", soyad.Text);
            sql.Parameters.AddWithValue("@tel", tel.Text);
            sql.Parameters.AddWithValue("@no", no.Text);
            sql.ExecuteNonQuery();
            sql = new MySqlCommand("Update kul_bilgi set kul_sif=@sif where kul_tc=@tc", baglan);
            sql.Parameters.AddWithValue("@sif", sif.Text);
            sql.Parameters.AddWithValue("@tc", tc.Text);
            sql.ExecuteNonQuery();
            baglan.Close();
        }

        #region"Panel işlemleri"
        private void button1_Click(object sender, EventArgs e)
        {
            if (panel1.Width < 170)
            {
                timer1.Start();
            }
            else
            {
                timer2.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Width += 5;

            if (panel1.Width >= 170)
            {
                timer1.Stop();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            panel1.Width -= 5;
            if (panel1.Width == 30)
            {
                timer2.Stop();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Width = 500;
            if (panel_bilgi.Visible == false)
            {
                bilgi_getir(tb_ogrt_no, tb_ogrt_tc, tb_ogrt_sifre, tb_ogrt_ad, tb_ogrt_soyad, tb_ogrt_tel);
                panel_bilgi.Visible = true;
                panel_bilgi.Dock = DockStyle.Fill;
                panel_not.Visible = false;
            }
            else
            {
                temizle(this);
                panel_bilgi.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Width = 982;
            if (panel_not.Visible == false)
            {
                verilen_ders_getir(cb_not_ders);
                
                
                panel_not.Visible = true;
                panel_bilgi.Visible = false;
                panel_not.Dock = DockStyle.Fill;
            }
            else
            {
                temizle(this);
                panel_not.Visible = false;
            }
        }
        #endregion
        private void ogretmen_Load(object sender, EventArgs e)
        {
            ogrt_tc_sifre_kontrol();
            ogrt_no_getir();

        }

        private void cb_not_ders_SelectedIndexChanged(object sender, EventArgs e)
        {
            ogr_getir(cb_not_ogr_ad);
            sinif_getir();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ogr_ad_parcala(cb_not_ogr_ad);
            not_ekle(tb_not_not,cb_not_tur);
            sinif_getir();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bilgi_guncelle(tb_ogrt_no, tb_ogrt_tc, tb_ogrt_sifre, tb_ogrt_ad, tb_ogrt_soyad, tb_ogrt_tel);
            bilgi_getir(tb_ogrt_no, tb_ogrt_tc, tb_ogrt_sifre, tb_ogrt_ad, tb_ogrt_soyad, tb_ogrt_tel);
        }
    }
}
