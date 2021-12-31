namespace Demec_yeni
{
    partial class Kullanıcılar
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
            this.geridon = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MusteriSil = new System.Windows.Forms.Button();
            this.MusteriEkle = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // geridon
            // 
            this.geridon.BackColor = System.Drawing.SystemColors.Desktop;
            this.geridon.Location = new System.Drawing.Point(12, 12);
            this.geridon.Name = "geridon";
            this.geridon.Size = new System.Drawing.Size(83, 35);
            this.geridon.TabIndex = 17;
            this.geridon.Text = "GERİ DÖN";
            this.geridon.UseVisualStyleBackColor = false;
            this.geridon.Click += new System.EventHandler(this.geridon_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(23, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(257, 123);
            this.panel1.TabIndex = 16;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(78, 46);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(165, 20);
            this.textBox2.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(78, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(165, 20);
            this.textBox1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "KULLANICI: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(15, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ŞİFRE :";
            // 
            // MusteriSil
            // 
            this.MusteriSil.Location = new System.Drawing.Point(153, 198);
            this.MusteriSil.Name = "MusteriSil";
            this.MusteriSil.Size = new System.Drawing.Size(80, 37);
            this.MusteriSil.TabIndex = 15;
            this.MusteriSil.Text = "Kullanıcı Sil";
            this.MusteriSil.UseVisualStyleBackColor = true;
            this.MusteriSil.Click += new System.EventHandler(this.MusteriSil_Click);
            // 
            // MusteriEkle
            // 
            this.MusteriEkle.Location = new System.Drawing.Point(41, 196);
            this.MusteriEkle.Name = "MusteriEkle";
            this.MusteriEkle.Size = new System.Drawing.Size(94, 39);
            this.MusteriEkle.TabIndex = 13;
            this.MusteriEkle.Text = "Kullanıcı Ekle";
            this.MusteriEkle.UseVisualStyleBackColor = true;
            this.MusteriEkle.Click += new System.EventHandler(this.MusteriEkle_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(286, 48);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(335, 172);
            this.listView1.TabIndex = 18;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(15, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "YETKİ :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2"});
            this.comboBox1.Location = new System.Drawing.Point(78, 85);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(111, 21);
            this.comboBox1.TabIndex = 19;
            // 
            // Kullanıcılar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 287);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.geridon);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MusteriSil);
            this.Controls.Add(this.MusteriEkle);
            this.Name = "Kullanıcılar";
            this.Text = "Kullanıcılar";
            this.Load += new System.EventHandler(this.Kullanıcılar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button geridon;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button MusteriSil;
        private System.Windows.Forms.Button MusteriEkle;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}