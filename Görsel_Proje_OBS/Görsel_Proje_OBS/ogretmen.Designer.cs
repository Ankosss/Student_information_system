namespace Görsel_Proje_OBS
{
    partial class ogretmen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel_bilgi = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.tb_ogrt_tel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_ogrt_soyad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_ogrt_sifre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_ogrt_ad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_ogrt_tc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_ogrt_no = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_not = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.tb_not_not = new System.Windows.Forms.TextBox();
            this.cb_not_tur = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_not_ogr_ad = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_not_ders = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel_bilgi.SuspendLayout();
            this.panel_not.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 363);
            this.panel1.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(0, 60);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(140, 30);
            this.button4.TabIndex = 3;
            this.button4.Text = "Çıkış";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(0, 30);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(140, 30);
            this.button3.TabIndex = 2;
            this.button3.Text = "Bilgileri Güncelle";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 30);
            this.button2.TabIndex = 1;
            this.button2.Text = "Not girişi";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(140, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 363);
            this.button1.TabIndex = 0;
            this.button1.Text = "=";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // panel_bilgi
            // 
            this.panel_bilgi.BackColor = System.Drawing.Color.White;
            this.panel_bilgi.Controls.Add(this.button5);
            this.panel_bilgi.Controls.Add(this.tb_ogrt_tel);
            this.panel_bilgi.Controls.Add(this.label5);
            this.panel_bilgi.Controls.Add(this.tb_ogrt_soyad);
            this.panel_bilgi.Controls.Add(this.label4);
            this.panel_bilgi.Controls.Add(this.tb_ogrt_sifre);
            this.panel_bilgi.Controls.Add(this.label6);
            this.panel_bilgi.Controls.Add(this.tb_ogrt_ad);
            this.panel_bilgi.Controls.Add(this.label3);
            this.panel_bilgi.Controls.Add(this.tb_ogrt_tc);
            this.panel_bilgi.Controls.Add(this.label2);
            this.panel_bilgi.Controls.Add(this.tb_ogrt_no);
            this.panel_bilgi.Controls.Add(this.label1);
            this.panel_bilgi.Location = new System.Drawing.Point(670, 352);
            this.panel_bilgi.Name = "panel_bilgi";
            this.panel_bilgi.Size = new System.Drawing.Size(340, 181);
            this.panel_bilgi.TabIndex = 1;
            this.panel_bilgi.Visible = false;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.button5.Location = new System.Drawing.Point(128, 224);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "Güncelle";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // tb_ogrt_tel
            // 
            this.tb_ogrt_tel.Location = new System.Drawing.Point(115, 169);
            this.tb_ogrt_tel.Name = "tb_ogrt_tel";
            this.tb_ogrt_tel.Size = new System.Drawing.Size(116, 20);
            this.tb_ogrt_tel.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(45, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Telefon";
            // 
            // tb_ogrt_soyad
            // 
            this.tb_ogrt_soyad.Location = new System.Drawing.Point(115, 143);
            this.tb_ogrt_soyad.Name = "tb_ogrt_soyad";
            this.tb_ogrt_soyad.Size = new System.Drawing.Size(116, 20);
            this.tb_ogrt_soyad.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(54, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Soyad";
            // 
            // tb_ogrt_sifre
            // 
            this.tb_ogrt_sifre.Location = new System.Drawing.Point(115, 91);
            this.tb_ogrt_sifre.Name = "tb_ogrt_sifre";
            this.tb_ogrt_sifre.Size = new System.Drawing.Size(116, 20);
            this.tb_ogrt_sifre.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(77, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "Ad";
            // 
            // tb_ogrt_ad
            // 
            this.tb_ogrt_ad.Location = new System.Drawing.Point(115, 117);
            this.tb_ogrt_ad.Name = "tb_ogrt_ad";
            this.tb_ogrt_ad.Size = new System.Drawing.Size(116, 20);
            this.tb_ogrt_ad.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(63, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Şifre";
            // 
            // tb_ogrt_tc
            // 
            this.tb_ogrt_tc.Location = new System.Drawing.Point(115, 65);
            this.tb_ogrt_tc.Name = "tb_ogrt_tc";
            this.tb_ogrt_tc.ReadOnly = true;
            this.tb_ogrt_tc.Size = new System.Drawing.Size(116, 20);
            this.tb_ogrt_tc.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(76, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "TC";
            // 
            // tb_ogrt_no
            // 
            this.tb_ogrt_no.Location = new System.Drawing.Point(115, 39);
            this.tb_ogrt_no.Name = "tb_ogrt_no";
            this.tb_ogrt_no.ReadOnly = true;
            this.tb_ogrt_no.Size = new System.Drawing.Size(116, 20);
            this.tb_ogrt_no.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(75, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "No";
            // 
            // panel_not
            // 
            this.panel_not.BackColor = System.Drawing.Color.White;
            this.panel_not.Controls.Add(this.button8);
            this.panel_not.Controls.Add(this.button6);
            this.panel_not.Controls.Add(this.tb_not_not);
            this.panel_not.Controls.Add(this.cb_not_tur);
            this.panel_not.Controls.Add(this.label10);
            this.panel_not.Controls.Add(this.label9);
            this.panel_not.Controls.Add(this.label8);
            this.panel_not.Controls.Add(this.cb_not_ogr_ad);
            this.panel_not.Controls.Add(this.dataGridView1);
            this.panel_not.Controls.Add(this.label7);
            this.panel_not.Controls.Add(this.cb_not_ders);
            this.panel_not.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_not.Location = new System.Drawing.Point(0, 0);
            this.panel_not.Name = "panel_not";
            this.panel_not.Size = new System.Drawing.Size(966, 363);
            this.panel_not.TabIndex = 2;
            this.panel_not.Visible = false;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(895, 167);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(59, 23);
            this.button8.TabIndex = 9;
            this.button8.Text = "Ekle";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(833, 167);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(56, 23);
            this.button6.TabIndex = 9;
            this.button6.Text = "Sil";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // tb_not_not
            // 
            this.tb_not_not.Location = new System.Drawing.Point(833, 127);
            this.tb_not_not.Name = "tb_not_not";
            this.tb_not_not.Size = new System.Drawing.Size(121, 20);
            this.tb_not_not.TabIndex = 8;
            // 
            // cb_not_tur
            // 
            this.cb_not_tur.FormattingEnabled = true;
            this.cb_not_tur.Items.AddRange(new object[] {
            "Vize",
            "Final",
            "Proje"});
            this.cb_not_tur.Location = new System.Drawing.Point(833, 91);
            this.cb_not_tur.Name = "cb_not_tur";
            this.cb_not_tur.Size = new System.Drawing.Size(121, 21);
            this.cb_not_tur.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(801, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Not";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(776, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Not Türü";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(765, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Öğrenci Ad";
            // 
            // cb_not_ogr_ad
            // 
            this.cb_not_ogr_ad.FormattingEnabled = true;
            this.cb_not_ogr_ad.Location = new System.Drawing.Point(833, 59);
            this.cb_not_ogr_ad.Name = "cb_not_ogr_ad";
            this.cb_not_ogr_ad.Size = new System.Drawing.Size(121, 21);
            this.cb_not_ogr_ad.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(176, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(583, 298);
            this.dataGridView1.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(176, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Ders Seçin";
            // 
            // cb_not_ders
            // 
            this.cb_not_ders.FormattingEnabled = true;
            this.cb_not_ders.Location = new System.Drawing.Point(176, 26);
            this.cb_not_ders.Name = "cb_not_ders";
            this.cb_not_ders.Size = new System.Drawing.Size(140, 21);
            this.cb_not_ders.TabIndex = 0;
            this.cb_not_ders.SelectedIndexChanged += new System.EventHandler(this.cb_not_ders_SelectedIndexChanged);
            // 
            // ogretmen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 363);
            this.Controls.Add(this.panel_bilgi);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_not);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ogretmen";
            this.Text = "Öğretmen Panel";
            this.Load += new System.EventHandler(this.ogretmen_Load);
            this.panel1.ResumeLayout(false);
            this.panel_bilgi.ResumeLayout(false);
            this.panel_bilgi.PerformLayout();
            this.panel_not.ResumeLayout(false);
            this.panel_not.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel panel_bilgi;
        private System.Windows.Forms.Panel panel_not;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox tb_ogrt_tel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_ogrt_soyad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_ogrt_ad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_ogrt_tc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_ogrt_no;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_ogrt_sifre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_not_ders;
        private System.Windows.Forms.TextBox tb_not_not;
        private System.Windows.Forms.ComboBox cb_not_tur;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cb_not_ogr_ad;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button6;
    }
}