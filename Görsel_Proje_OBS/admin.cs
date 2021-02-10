using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
namespace Görsel_Proje_OBS
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }
        MySqlConnection baglan = new MySqlConnection("Server=localhost;Database=obs;user='root';Pwd='Umitcan123!';");
        /***************************************/
        #region "GridView'a tabloları getirme"
        public void ogr_getir()
        {
            baglan.Open();
            MySqlCommand sql = new MySqlCommand("select * from ogr_bilgi", baglan);
            MySqlDataAdapter da = new MySqlDataAdapter(sql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }
        public void ogrt_getir()
        {
            baglan.Open();
            MySqlCommand sql = new MySqlCommand("select * from ogrt_bilgi", baglan);
            MySqlDataAdapter da = new MySqlDataAdapter(sql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }
        public void kul_getir()
        {
            baglan.Open();
            MySqlCommand sql = new MySqlCommand("select * from kul_bilgi", baglan);
            MySqlDataAdapter da = new MySqlDataAdapter(sql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }
        public void bolum_getir()
        {
            baglan.Open();
            MySqlCommand sql = new MySqlCommand("select * from bolum", baglan);
            MySqlDataAdapter da = new MySqlDataAdapter(sql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }
        public void ders_getir()
        {
            baglan.Open();
            MySqlCommand sql = new MySqlCommand("select * from ders", baglan);
            MySqlDataAdapter da = new MySqlDataAdapter(sql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }
        public void sinif_getir()
        {
            baglan.Open();
            MySqlCommand sql = new MySqlCommand("select * from sinif", baglan);
            MySqlDataAdapter da = new MySqlDataAdapter(sql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }
        public void not_getir()
        {
            baglan.Open();
            MySqlCommand sql = new MySqlCommand("SELECT  not_bilgi.not_no as 'Not no' ,ogr_bilgi.ogr_isim as 'Öğrenci Ad',ogr_bilgi.ogr_soyisim as 'Öğrenci Soyad', ders.ders_ad as 'Ders Ad', not_bilgi.not_not as 'Puan', not_t.not_ad as 'Türü' FROM(((obs.not_bilgi left JOIN ders ON not_bilgi.ders_no = ders.ders_no) left JOIN not_t ON not_bilgi.not_tur = not_t.not_no) left JOIN ogr_bilgi ON ogr_bilgi.ogr_no = not_bilgi.ogr_no);", baglan);
            MySqlDataAdapter da = new MySqlDataAdapter(sql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }
        #endregion//
        /***************************************/
        public void temizle()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox tbox = (TextBox)item;
                    tbox.Clear();
                }
            }
        }
        /***************************************/
        #region"Öğretmen işlemleri"
        public void ogrt_ekle()
        {
            baglan.Open();

            MySqlCommand sql = new MySqlCommand("Insert into ogrt_bilgi (ogrt_tc,ogrt_isim,ogrt_soyisim,ogrt_telefon) values (@tc,@ad,@soy,@tel);", baglan);
            sql.Parameters.AddWithValue("@tc", tb_ogrt_tc.Text);
            sql.Parameters.AddWithValue("@ad", tb_ogrt_ad.Text);
            sql.Parameters.AddWithValue("@soy", tb_ogrt_soy.Text);
            sql.Parameters.AddWithValue("@tel", tb_ogrt_tel.Text);
            sql.ExecuteNonQuery();
            sql.Cancel();
            baglan.Close();
        }
        public void ogrt_kul_ekle()
        {
            baglan.Open();
            MySqlCommand sql = new MySqlCommand("Insert into kul_bilgi (kul_tc,kul_sif,kul_gorev) values(@tc,@tc,@gorev)", baglan);
            sql.Parameters.AddWithValue("@tc", tb_ogrt_tc.Text);
            sql.Parameters.AddWithValue("gorev", "öğretmen");
            sql.ExecuteNonQuery();
            sql.Cancel();
            baglan.Close();
        }
        public void ogrt_sil(string x)
        {
            baglan.Open();
            string tc_no = "";


            MySqlCommand sql = new MySqlCommand("select ogrt_tc from ogrt_bilgi where ogrt_no=@no", baglan);
            sql.Parameters.AddWithValue("@no", x);
            MySqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {
                tc_no = dr["ogrt_tc"].ToString();
                MessageBox.Show(tc_no);
            }
            dr.Close();

            sql = new MySqlCommand("Delete from ogrt_bilgi where ogrt_no=@no", baglan);
            sql.Parameters.AddWithValue("@no", x);
            sql.ExecuteNonQuery();

            sql = new MySqlCommand("Delete from kul_bilgi where kul_tc=@tc", baglan);
            sql.Parameters.AddWithValue("@tc", tc_no);
            sql.ExecuteNonQuery();


            baglan.Close();
        }
        #endregion
        /***************************************/
        #region"Öğrenci İşlemleri"
        public void ogr_ekle()
        {
            //eğer silinmiş bir sınıf olursa sıkıntı olmasın diye comboboxtan gelen değerin sınıf idsini aldım.
            int sinif_no = 0;
            baglan.Open();
            MySqlCommand sql = new MySqlCommand("select sinif_no from Sinif where sinif_ad=@sinif", baglan);
            sql.Parameters.AddWithValue("@sinif", cb_ogr_sinif.Text);
            MySqlDataReader dr = sql.ExecuteReader();
            while (dr.Read())
            {
                sinif_no = Convert.ToInt32(dr["sinif_no"].ToString());
            }
            dr.Close();

            sql = new MySqlCommand("Insert into ogr_bilgi (ogr_tc,ogr_isim,ogr_soyisim,ogr_telefon,sinif_no) values (@tc,@ad,@soy,@tel,@sinif);", baglan);
            sql.Parameters.AddWithValue("@tc", tb_ogr_tc.Text);
            sql.Parameters.AddWithValue("@ad", tb_ogr_ad.Text);
            sql.Parameters.AddWithValue("@soy", tb_ogr_soyad.Text);
            sql.Parameters.AddWithValue("@tel", tb_ogr_tel.Text);
            sql.Parameters.AddWithValue("@sinif", sinif_no);
            sql.ExecuteNonQuery();
            baglan.Close();
        }
        public void sinif_doldur(ComboBox x)
        {
            x.Items.Clear();
            baglan.Open();

            MySqlCommand sql = new MySqlCommand("Select sinif_ad from sinif", baglan);
            MySqlDataReader dr = sql.ExecuteReader();
            while (dr.Read())
            {
                x.Items.Add(dr["sinif_ad"]);
            }
            dr.Close();
            baglan.Close();


        }
        public void ogr_kul_ekle()
        {
            baglan.Open();
            MySqlCommand sql = new MySqlCommand("Insert into kul_bilgi (kul_tc,kul_sif,kul_gorev) values(@tc,@tc,@gorev)", baglan);
            sql.Parameters.AddWithValue("@tc", tb_ogr_tc.Text);
            sql.Parameters.AddWithValue("gorev", "öğrenci");
            sql.ExecuteNonQuery();
            baglan.Close();
        }
        public void ogr_sil(string x)
        {
            baglan.Open();
            string tc_no = "";


            MySqlCommand sql = new MySqlCommand("select ogr_tc from ogr_bilgi where ogr_no=@no", baglan);
            sql.Parameters.AddWithValue("@no", x);
            MySqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {
                tc_no = dr["ogr_tc"].ToString();
                MessageBox.Show(tc_no);
            }
            dr.Close();

            sql = new MySqlCommand("Delete from ogr_bilgi where ogr_no=@no", baglan);
            sql.Parameters.AddWithValue("@no", x);
            sql.ExecuteNonQuery();

            sql = new MySqlCommand("Delete from kul_bilgi where kul_tc=@tc", baglan);
            sql.Parameters.AddWithValue("@tc", tc_no);
            sql.ExecuteNonQuery();


            baglan.Close();
        }
        #endregion
        /***************************************/
        #region"Kullanıcı İşlemleri"
        public void kul_ekle(TextBox tc, TextBox sif)
        {
            baglan.Open();
            MySqlCommand sql = new MySqlCommand("Insert into kul_bilgi (kul_tc,kul_sif,kul_gorev) values (@tc,@sif,@gorev);", baglan);
            sql.Parameters.AddWithValue("@tc", tc.Text);
            sql.Parameters.AddWithValue("@sif", sif.Text);
            sql.Parameters.AddWithValue("@gorev", "admin");
            sql.ExecuteNonQuery();
            baglan.Close();
        }
        public void kul_sil(string x)
        {
            baglan.Open();

            MySqlCommand sql = new MySqlCommand("Delete from kul_bilgi where kul_id=@no", baglan);
            sql.Parameters.AddWithValue("@no", x);
            sql.ExecuteNonQuery();

            baglan.Close();
        }
        #endregion
        /***************************************/
        #region"Bölüm İşlemleri"
        public void bolum_ekle(TextBox bolum)
        {
            baglan.Open();
            MySqlCommand sql = new MySqlCommand("Insert into bolum (bolum_ad) values (@bolum);", baglan);
            sql.Parameters.AddWithValue("@bolum", bolum.Text);
            sql.ExecuteNonQuery();
            baglan.Close();
        }

        public void bolum_sil(String x)
        {
            baglan.Open();

            MySqlCommand sql = new MySqlCommand("Delete from bolum where bolum_no=@no", baglan);
            sql.Parameters.AddWithValue("@no", x);
            sql.ExecuteNonQuery();

            baglan.Close();
        }
        #endregion
        /***************************************/
        #region"Sınıf İşlemleri"
        public void bolum_doldur()
        {
            cb_sinif_bolum.Items.Clear();
            baglan.Open();

            MySqlCommand sql = new MySqlCommand("Select bolum_ad from bolum", baglan);
            MySqlDataReader dr = sql.ExecuteReader();
            while (dr.Read())
            {
                cb_sinif_bolum.Items.Add(dr["bolum_ad"]);
            }

            baglan.Close();
        }
        public int bolum_id_bul(ComboBox x)
        {
            int bolum_id = 0;

            MySqlCommand sql = new MySqlCommand("Select bolum_no from bolum where bolum_ad=@ad", baglan);
            sql.Parameters.AddWithValue("@ad", x.Text);
            MySqlDataReader dr = sql.ExecuteReader();
            while (dr.Read())
            {
                bolum_id = int.Parse(dr["bolum_no"].ToString());
            }
            dr.Close();

            return bolum_id;
        }
        public void sinif_ekle(TextBox sinif_ad, ComboBox sinif_bolum)
        {
            baglan.Open();


            MySqlCommand sql = new MySqlCommand("Insert into sinif (sinif_ad,bolum_no) values (@sinif_ad,@bolum_no);", baglan);
            sql.Parameters.AddWithValue("@sinif_ad", sinif_ad.Text);
            sql.Parameters.AddWithValue("@bolum_no", bolum_id_bul(cb_sinif_bolum));
            sql.ExecuteNonQuery();

            baglan.Close();
        }
        public void sinif_sil(String x)
        {
            baglan.Open();

            MySqlCommand sql = new MySqlCommand("Delete from sinif where sinif_no=@no", baglan);
            sql.Parameters.AddWithValue("@no", x);
            sql.ExecuteNonQuery();

            baglan.Close();
        }

        #endregion
        /***************************************/
        #region"Ders İşlemleri"
        public int ogrt_id_bul()
        {
            int id = 0;

            MySqlCommand sql = new MySqlCommand("select ogrt_no from ogrt_bilgi where ogrt_isim=@ad and ogrt_soyisim=@sad",baglan);
            sql.Parameters.AddWithValue("@ad",ad);
            sql.Parameters.AddWithValue("@sad",soyad);
            MySqlDataReader dr = sql.ExecuteReader();
            if (dr.Read())
            {
                id = int.Parse(dr["ogrt_no"].ToString());
            }
            dr.Close();
            return id;
        }
        public void ogrt_ad_getir()
        {
            cb_ders_ogretmen.Items.Clear();
            baglan.Open();
            MySqlCommand sql = new MySqlCommand("Select ogrt_isim,ogrt_soyisim from ogrt_bilgi", baglan);
            MySqlDataReader dr = sql.ExecuteReader();
            while (dr.Read())
            {
                cb_ders_ogretmen.Items.Add(dr["ogrt_isim"].ToString() + " " + dr["ogrt_soyisim"].ToString());
            }
            dr.Close();
            baglan.Close();
        }
        public string ad = "", soyad = "";
        public string ogr_ad = "", ogr_sad = "";
        public void ogrt_parcala(ComboBox x)
        {
            ad = ""; soyad = "";
            int cursor = 0;
            string isim = x.Text.ToString();
            while (cursor != -1)
            {
                cursor = isim.IndexOf(" ", cursor);
                if (cursor != -1)
                {

                    ad += isim.Substring(0, cursor) + " ";
                    ad = ad.Substring(0, ad.Length - 1);
                    isim = isim.Remove(0, cursor);
                }
                else
                {
                    soyad = isim.Trim();
                    break;
                }
            }
        }
        public int sinif_no_getir(ComboBox c)
        {
            int no = 0;
            MySqlCommand sql = new MySqlCommand("select sinif_no from Sinif where sinif_ad=@sinif", baglan);
            sql.Parameters.AddWithValue("@sinif", c.Text);
            MySqlDataReader dr = sql.ExecuteReader();
            while (dr.Read())
            {
                no = Convert.ToInt32(dr["sinif_no"].ToString());
            }
            dr.Close();
            return no;
        }
        public int ogrt_no_getir()
        {
            MySqlDataReader dr = null;
            try
            {
                baglan.Open();

                MySqlCommand sql = new MySqlCommand("Select ogrt_no from ogrt_bilgi where ogrt_isim=@isim and ogrt_soyisim=@soy", baglan);
                sql.Parameters.AddWithValue("@isim", ad);
                sql.Parameters.AddWithValue("@soy", soyad);
                dr = sql.ExecuteReader();
                if (dr.Read())
                {
                    return int.Parse(dr["ogrt_no"].ToString());
                }
                else
                {
                    MessageBox.Show("Aradığınız Öğretmen bulunamadı.");
                    return 0;
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
                return 0;
            }
            finally
            {
                dr.Close();
                baglan.Close();
            }




        }


        public void ders_ekle(TextBox ad, ComboBox sınıf, ComboBox ogrt)
        {
            baglan.Open();
            MySqlCommand sql = new MySqlCommand("Insert into ders (ders_ad,ogrt_no,sinif_no) values (@ders,@ogrt,@sinif);", baglan);
            sql.Parameters.AddWithValue("@ders", ad.Text);
            sql.Parameters.AddWithValue("@ogrt", ogrt_id_bul());
            sql.Parameters.AddWithValue("@sinif", sinif_no_getir(sınıf));
            sql.ExecuteNonQuery();
            baglan.Close();
        }

        public void ders_sil(int id)
        {
            baglan.Open();

            MySqlCommand sql = new MySqlCommand("Delete from ders where ders_no=@id", baglan);
            sql.Parameters.AddWithValue("@id", id);
            sql.ExecuteNonQuery();

            baglan.Close();
        }
        public void not_sil(int id)
        {
            baglan.Open();

            MySqlCommand sql = new MySqlCommand("Delete from not_bilgi where not_no=@id", baglan);
            sql.Parameters.AddWithValue("@id", id);
            sql.ExecuteNonQuery();

            baglan.Close();
        }
        #endregion

        #region"Not İşlemleri"

        public void cb_ogrenci_getir(ComboBox c)
        {
            c.Items.Clear();
            baglan.Open();

            MySqlCommand sql = new MySqlCommand("select ogr_isim,ogr_soyisim from ogr_bilgi", baglan);
            MySqlDataReader dr = sql.ExecuteReader();
            while (dr.Read())
            {
                c.Items.Add(dr["ogr_isim"].ToString() + " " + dr["ogr_soyisim"].ToString());
            }
            dr.Close();

            baglan.Close();
        }
        public void cb_ders_getir(ComboBox c)
        {
            c.Items.Clear();
            baglan.Open();

            MySqlCommand sql = new MySqlCommand("Select ders_ad from ders", baglan);
            MySqlDataReader dr = sql.ExecuteReader();
            while (dr.Read())
            {
                c.Items.Add(dr["ders_ad"]);
            }
            dr.Close();
            baglan.Close();
        }
        public void ogr_ad_parcala(ComboBox c)
        {
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
            return id;
        }
        public int ders_no_getir(ComboBox c)
        {
            int deger = -1;
            MySqlCommand sql = new MySqlCommand("Select ders_no from ders where ders_ad=@ad", baglan);
            sql.Parameters.AddWithValue("@ad", c.Text.ToString());
            MySqlDataReader dr = sql.ExecuteReader();
            while (dr.Read())
            {
                deger = int.Parse(dr["ders_no"].ToString());
            }
            dr.Close();
            return deger;
        }
        public void not_ekle(TextBox not, ComboBox tur)
        {
            baglan.Open();

            MySqlCommand sql = new MySqlCommand("Insert into not_bilgi (ogr_no,ders_no,not_not,not_tur) values (@ogr,@ders,@not,@ntur)", baglan);
            sql.Parameters.AddWithValue("@ogr", ogr_no_getir());
            sql.Parameters.AddWithValue("@ders", ders_no_getir(cb_not_ders));
            sql.Parameters.AddWithValue("@not", not.Text.ToString());
            sql.Parameters.AddWithValue("@ntur", tur.SelectedIndex);
            sql.ExecuteNonQuery();
            baglan.Close();
        }


        #endregion

        #region"Buttonlar"
        private void button4_Click(object sender, EventArgs e)
        {

            if (panel_ogr.Visible == true)
            {
                panel_ogr.Visible = false;
                panel_ogr.Location = new Point(640, 404);
                dataGridView1.DataSource = null;

            }
            else
            {
                sinif_doldur(cb_ogr_sinif);
                ogr_getir();
                panel_ders.Visible = false;
                panel_ogrt.Visible = false;
                panel_bolum.Visible = false;
                panel_not.Visible = false;
                panel_kullanici.Visible = false;
                panel_ogr.Visible = true;
                panel_sinif.Visible = false;
                panel_ogr.Location = new Point(5, 6);
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {

            if (panel_ogrt.Visible == true)
            {
                panel_ogrt.Visible = false;
                panel_ogrt.Location = new Point(640, 404);
                dataGridView1.DataSource = null;

            }
            else
            {
                ogrt_getir();
                panel_ogrt.Visible = true;
                panel_bolum.Visible = false;
                panel_ders.Visible = false;
                panel_kullanici.Visible = false;
                panel_ogr.Visible = false;
                panel_sinif.Visible = false;
                panel_ogrt.Location = new Point(5, 6);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {

            if (panel_kullanici.Visible == true)
            {
                dataGridView1.DataSource = null;
                panel_kullanici.Visible = false;
                panel_kullanici.Location = new Point(640, 404);

            }
            else
            {
                kul_getir();
                panel_ogrt.Visible = false;
                panel_bolum.Visible = false;
                panel_kullanici.Visible = true;
                panel_not.Visible = false;
                panel_ders.Visible = false;
                panel_ogr.Visible = false;
                panel_sinif.Visible = false;
                panel_kullanici.Location = new Point(5, 6);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (panel_bolum.Visible == true)
            {
                panel_bolum.Visible = false;
                panel_bolum.Location = new Point(640, 404);
                dataGridView1.DataSource = null;

            }
            else
            {
                bolum_getir();
                panel_ogrt.Visible = false;
                panel_ders.Visible = false;
                panel_not.Visible = false;
                panel_bolum.Visible = true;
                panel_kullanici.Visible = false;
                panel_ogr.Visible = false;
                panel_sinif.Visible = false;
                panel_bolum.Location = new Point(5, 6);
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (panel_ders.Visible == true)
            {
                dataGridView1.DataSource = null;
                panel_ders.Visible = false;
                panel_ders.Location = new Point(640, 404);

            }
            else
            {
                ders_getir();
                sinif_doldur(cb_ders_sinif);
                ogrt_ad_getir();
                sinif_doldur(cb_ders_sinif);
                panel_ders.Visible = true;
                panel_ogrt.Visible = false;
                panel_bolum.Visible = false;
                panel_not.Visible = false;
                panel_kullanici.Visible = false;
                panel_ogr.Visible = false;
                panel_sinif.Visible = false;
                panel_ders.Location = new Point(5, 6);
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (panel_not.Visible == true)
            {
                dataGridView1.DataSource = null;
                panel_not.Visible = false;
                panel_not.Location = new Point(640, 404);

            }
            else
            {
                cb_ogrenci_getir(cb_not_ogr);
                not_getir();
                cb_ders_getir(cb_not_ders);

                panel_ogrt.Visible = false;
                panel_bolum.Visible = false;
                panel_kullanici.Visible = false;
                panel_ders.Visible = false;
                panel_ogr.Visible = false;
                panel_sinif.Visible = false;
                panel_not.Visible = true;
                panel_not.Location = new Point(5, 6);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (panel_sinif.Visible == true)
            {
                dataGridView1.DataSource = null;
                panel_sinif.Visible = false;
                panel_sinif.Location = new Point(640, 404);

            }
            else
            {
                sinif_getir();
                bolum_doldur();
                panel_ogrt.Visible = false;
                panel_not.Visible = false;
                panel_bolum.Visible = false;
                panel_kullanici.Visible = false;
                panel_ders.Visible = false;
                panel_ogr.Visible = false;
                panel_sinif.Visible = true;
                panel_sinif.Location = new Point(5, 6);
            }
        }
        private void button_ogrt_ekle_Click(object sender, EventArgs e)
        {
            ogrt_ekle();
            ogrt_kul_ekle();
            ogrt_getir();
        }
        private void button_ogrt_guncelle_Click(object sender, EventArgs e)
        {
            temizle();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            String sil_no = Interaction.InputBox("Silinecenk öğretmenin ogrt_no'su", "Öğretmen Sil", "orn:5", 0, 0);
            ogrt_sil(sil_no);
            ogrt_getir();
        }
        private void button10_Click(object sender, EventArgs e)
        {

            ogr_ekle();
            ogr_kul_ekle();
            ogr_getir();
        }
        private void admin_Load(object sender, EventArgs e)
        {

            bolum_doldur();
        }
        private void button12_Click(object sender, EventArgs e)
        {
            String sil_no = Interaction.InputBox("Silinecenk öğrencinin ogr_no'su", "Öğrenci Sil", "orn:5", 0, 0);
            ogr_sil(sil_no);
            ogr_getir();
        }
        private void button13_Click(object sender, EventArgs e)
        {
            kul_ekle(tb_kul_tc, tb_kul_sif);
            kul_getir();
        }
        private void button14_Click(object sender, EventArgs e)
        {

        }
        private void button15_Click(object sender, EventArgs e)
        {
            String sil_no = Interaction.InputBox("Silinecenk Kullanıcının kul_no'su", "Kullanıcı Sil", "orn:5", 0, 0);
            String sil_kul_gorev = "";
            String sil_kul_tc = "";
            String sil_ogr_no = "";
            String sil_ogrt_no = "";

            baglan.Open();

            MySqlCommand sql = new MySqlCommand("Select kul_tc,kul_gorev from kul_bilgi where kul_id=@id", baglan);
            sql.Parameters.AddWithValue("@id", sil_no);
            MySqlDataReader dr = sql.ExecuteReader();
            while (dr.Read())
            {
                sil_kul_tc = dr["kul_tc"].ToString();
                sil_kul_gorev = dr["kul_gorev"].ToString();
            }
            dr.Close();
            baglan.Close();
            if (sil_kul_gorev == "admin")
            {
                kul_sil(sil_no);
            }
            else if (sil_kul_gorev == "öğrenci")
            {
                baglan.Open();
                sql = new MySqlCommand("Select ogr_no from ogr_bilgi where ogr_tc=@tc", baglan);
                sql.Parameters.AddWithValue("@tc", sil_kul_tc);
                dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    sil_ogr_no = dr["ogr_no"].ToString();
                }
                dr.Close();
                baglan.Close();
                ogr_sil(sil_ogr_no);
            }
            else
            {
                baglan.Open();
                sql = new MySqlCommand("Select ogrt_no from ogrt_bilgi where ogrt_tc=@tc", baglan);
                sql.Parameters.AddWithValue("@tc", sil_kul_tc);
                dr = sql.ExecuteReader();
                while (dr.Read())
                {
                    sil_ogrt_no = dr["ogrt_no"].ToString();

                }
                dr.Close();
                baglan.Close();
                ogrt_sil(sil_ogrt_no);
            }
            kul_getir();
        }
        private void button18_Click(object sender, EventArgs e)
        {
            bolum_ekle(tb_bolum_ad);
            bolum_getir();

        }
        private void button16_Click(object sender, EventArgs e)
        {
            String sil_no = Interaction.InputBox("Silinecenk öğretmenin ogrt_no'su", "Öğretmen Sil", "orn:5", 0, 0);
            bolum_sil(sil_no);
            bolum_getir();

        }
        private void button21_Click(object sender, EventArgs e)
        {
            sinif_ekle(tb_sinif_ad, cb_sinif_bolum);
            sinif_getir();
        }
        private void button19_Click(object sender, EventArgs e)
        {
            String sil_no = Interaction.InputBox("Silinecenk öğretmenin ogrt_no'su", "Öğretmen Sil", "orn:5", 0, 0);
            sinif_sil(sil_no);
            sinif_getir();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            String sil_no = Interaction.InputBox("Silinecenk Dersin ders_id'si", "Ders Sil", "orn:5", 0, 0);
            ders_sil(int.Parse(sil_no));
            ders_getir();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            int not = int.Parse( tb_not_not.Text);
            if (not <= 100)
            {
                ogr_ad_parcala(cb_not_ogr);
                not_ekle(tb_not_not, cb_not_tur);
                not_getir();
            }
            else
            {
                MessageBox.Show("Not 100'den fazla olamaz lütfen tekrar deneyiniz.");
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel_sol.Width += 5;

            if (panel_sol.Width >= 170)
            {
                timer1.Stop();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            panel_sol.Width -= 5;
            if (panel_sol.Width == 40)
            {
                timer2.Stop();
            }
        }

        private void b1_Click(object sender, EventArgs e)
        {
            if (panel_sol.Width < 140)
            {
                timer1.Start();
            }
            else
            {
                timer2.Start();
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            String sil_no = Interaction.InputBox("Silinecenk Notun Not_no'sunu giriniz", "Not Sil", "orn:5", 0, 0);
            not_sil(int.Parse(sil_no));
            not_getir();
        }

        private void button26_Click(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {
            ogrt_parcala(cb_ders_ogretmen);
            ders_ekle(tb_ders_ad, cb_ders_sinif, cb_ders_ogretmen);
            ders_getir();
        }
        #endregion
    }
}