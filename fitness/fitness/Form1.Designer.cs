namespace fitness
{
    partial class Form1
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
            this.uyeButon = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.kulAdiTxt = new System.Windows.Forms.TextBox();
            this.kulSifreTxt = new System.Windows.Forms.TextBox();
            this.kulYasTxt = new System.Windows.Forms.TextBox();
            this.kulAdSoyTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.kadinRadio = new System.Windows.Forms.RadioButton();
            this.erkekRadio = new System.Windows.Forms.RadioButton();
            this.kulId = new System.Windows.Forms.TextBox();
            this.sifreId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.kulBoyTxt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.kulKiloTxt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // uyeButon
            // 
            this.uyeButon.Location = new System.Drawing.Point(153, 375);
            this.uyeButon.Name = "uyeButon";
            this.uyeButon.Size = new System.Drawing.Size(75, 23);
            this.uyeButon.TabIndex = 0;
            this.uyeButon.Text = "Üye Ol";
            this.uyeButon.UseVisualStyleBackColor = true;
            this.uyeButon.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(444, 229);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(590, 260);
            this.dataGridView1.TabIndex = 1;
            // 
            // kulAdiTxt
            // 
            this.kulAdiTxt.Location = new System.Drawing.Point(153, 61);
            this.kulAdiTxt.Name = "kulAdiTxt";
            this.kulAdiTxt.Size = new System.Drawing.Size(152, 20);
            this.kulAdiTxt.TabIndex = 2;
            // 
            // kulSifreTxt
            // 
            this.kulSifreTxt.Location = new System.Drawing.Point(153, 100);
            this.kulSifreTxt.Name = "kulSifreTxt";
            this.kulSifreTxt.PasswordChar = '*';
            this.kulSifreTxt.Size = new System.Drawing.Size(152, 20);
            this.kulSifreTxt.TabIndex = 3;
            // 
            // kulYasTxt
            // 
            this.kulYasTxt.Location = new System.Drawing.Point(153, 181);
            this.kulYasTxt.Name = "kulYasTxt";
            this.kulYasTxt.Size = new System.Drawing.Size(152, 20);
            this.kulYasTxt.TabIndex = 5;
            // 
            // kulAdSoyTxt
            // 
            this.kulAdSoyTxt.Location = new System.Drawing.Point(153, 142);
            this.kulAdSoyTxt.Name = "kulAdSoyTxt";
            this.kulAdSoyTxt.Size = new System.Drawing.Size(152, 20);
            this.kulAdSoyTxt.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Kullanıcı Adı";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Şifre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Kullanıcı Adı Soyadı";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Yaş";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Cinsiyet";
            // 
            // kadinRadio
            // 
            this.kadinRadio.AutoSize = true;
            this.kadinRadio.Location = new System.Drawing.Point(156, 312);
            this.kadinRadio.Name = "kadinRadio";
            this.kadinRadio.Size = new System.Drawing.Size(52, 17);
            this.kadinRadio.TabIndex = 11;
            this.kadinRadio.TabStop = true;
            this.kadinRadio.Text = "Kadın";
            this.kadinRadio.UseVisualStyleBackColor = true;
            // 
            // erkekRadio
            // 
            this.erkekRadio.AutoSize = true;
            this.erkekRadio.Location = new System.Drawing.Point(230, 312);
            this.erkekRadio.Name = "erkekRadio";
            this.erkekRadio.Size = new System.Drawing.Size(53, 17);
            this.erkekRadio.TabIndex = 12;
            this.erkekRadio.TabStop = true;
            this.erkekRadio.Text = "Erkek";
            this.erkekRadio.UseVisualStyleBackColor = true;
            // 
            // kulId
            // 
            this.kulId.Location = new System.Drawing.Point(444, 61);
            this.kulId.Name = "kulId";
            this.kulId.Size = new System.Drawing.Size(152, 20);
            this.kulId.TabIndex = 14;
            // 
            // sifreId
            // 
            this.sifreId.Location = new System.Drawing.Point(622, 61);
            this.sifreId.Name = "sifreId";
            this.sifreId.PasswordChar = '*';
            this.sifreId.Size = new System.Drawing.Size(152, 20);
            this.sifreId.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(441, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Kullanıcı Adı";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(619, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Şifre";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Boy";
            // 
            // kulBoyTxt
            // 
            this.kulBoyTxt.Location = new System.Drawing.Point(153, 229);
            this.kulBoyTxt.Name = "kulBoyTxt";
            this.kulBoyTxt.Size = new System.Drawing.Size(152, 20);
            this.kulBoyTxt.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 273);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Kilo";
            // 
            // kulKiloTxt
            // 
            this.kulKiloTxt.Location = new System.Drawing.Point(153, 266);
            this.kulKiloTxt.Name = "kulKiloTxt";
            this.kulKiloTxt.Size = new System.Drawing.Size(152, 20);
            this.kulKiloTxt.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(822, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "Giriş";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1002, 554);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 23;
            this.button2.Text = "sil veritanı";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::fitness.Properties.Resources.anaSayfa1;
            this.pictureBox1.Location = new System.Drawing.Point(490, 189);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(501, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 589);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.kulKiloTxt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.kulBoyTxt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.sifreId);
            this.Controls.Add(this.kulId);
            this.Controls.Add(this.erkekRadio);
            this.Controls.Add(this.kadinRadio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kulYasTxt);
            this.Controls.Add(this.kulAdSoyTxt);
            this.Controls.Add(this.kulSifreTxt);
            this.Controls.Add(this.kulAdiTxt);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.uyeButon);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uyeButon;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox kulAdiTxt;
        private System.Windows.Forms.TextBox kulSifreTxt;
        private System.Windows.Forms.TextBox kulYasTxt;
        private System.Windows.Forms.TextBox kulAdSoyTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton kadinRadio;
        private System.Windows.Forms.RadioButton erkekRadio;
        private System.Windows.Forms.TextBox kulId;
        private System.Windows.Forms.TextBox sifreId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox kulBoyTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox kulKiloTxt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

