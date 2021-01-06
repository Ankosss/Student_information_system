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
    public partial class Form1 : Form
    {
        int cevap = 0;
        public string gorev, tcno, sifre;
        MySqlConnection baglan;
        public Form1()
        {
            InitializeComponent();
            baglan = new MySqlConnection("Server=localhost;Database=obs;user='root';Pwd='Umitcan123!';");
        }
        public void rastgele_sayi()
        {
            Random rnd = new Random();
            int rs1 = rnd.Next(0, 10);
            int rs2 = rnd.Next(0, 10);
            cevap = rs1 + rs2;
            r_sayi.Text = rs1 + " + " + rs2;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            rastgele_sayi();
            try
            {
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
            finally
            {
                baglan.Close();
            }


        }
        public bool giris_gogrulama(String tc, String sif)
        {
            baglan.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select * from kul_bilgi where kul_tc=@tc AND kul_sif=@sif";
            cmd.Parameters.AddWithValue("@tc", tc);
            cmd.Parameters.AddWithValue("@sif", sif);
            cmd.Connection = baglan;
            MySqlDataReader login = cmd.ExecuteReader();
            if (login.Read())
            {
                login.Close();
                tcno = tc;
                sifre = sif;

                cmd.CommandText = "select kul_gorev from kul_bilgi where kul_tc=@tcc";
                cmd.Parameters.AddWithValue("@tcc", tc);
                login = cmd.ExecuteReader();
                while (login.Read())
                {
                    gorev = login["kul_gorev"].ToString();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                sif.PasswordChar = '*';
                
            }
            else
            {
                sif.PasswordChar = '\0';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String rrs_knt = r_sayi_knt.Text.ToString();
            if (tc_no.Text != "" && sif.Text != "" && rrs_knt != "")
            {
                int rs_knt = int.Parse(rrs_knt);
                if (cevap == rs_knt)
                {
                    string kul_tc = tc_no.Text.ToString();
                    string kul_sif = sif.Text.ToString();
                    bool a = giris_gogrulama(kul_tc, kul_sif);
                    if (a)
                    {
                        tcno = kul_tc;
                        MessageBox.Show(" Giriş Başarılı");
                        if (gorev == "admin")
                        {
                            ogrenci ogr = new ogrenci();
                            ogr.ogr_tc = tcno;
                            ogr.Show();

                            
                            ogretmen ogrt = new ogretmen();
                            ogrt.ogrt_tc = tcno;
                            ogrt.Show();

                            admin adm = new admin();
                            adm.Show();
                            this.Hide();
                        }
                        else if (gorev == "öğrenci")
                        {
                            ogrenci ogr = new ogrenci();
                            ogr.ogr_tc = tcno;
                            ogr.Show();
                            this.Hide();

                        }
                        else
                        {
                            
                            ogretmen ogrt = new ogretmen();
                            ogrt.ogrt_tc = tcno;
                            ogrt.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Bilgilerinizi Kontrol edin");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Toplama işlemini düzgün bir şekilde yapınız.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen alanları doldurunuz.");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            rastgele_sayi();
        }
    }
}
