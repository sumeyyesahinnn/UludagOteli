namespace UludagOteli
{
    partial class Odalar
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
            this.flowLayoutPanelOdalar = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnRezervasyonaGit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flowLayoutPanelOdalar
            // 
            this.flowLayoutPanelOdalar.Location = new System.Drawing.Point(1, 81);
            this.flowLayoutPanelOdalar.Name = "flowLayoutPanelOdalar";
            this.flowLayoutPanelOdalar.Size = new System.Drawing.Size(651, 503);
            this.flowLayoutPanelOdalar.TabIndex = 0;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(132)))), ((int)(((byte)(103)))));
            this.btnGuncelle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(67)))), ((int)(((byte)(50)))));
            this.btnGuncelle.FlatAppearance.BorderSize = 2;
            this.btnGuncelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuncelle.Location = new System.Drawing.Point(683, 94);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(118, 28);
            this.btnGuncelle.TabIndex = 0;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnRezervasyonaGit
            // 
            this.btnRezervasyonaGit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(132)))), ((int)(((byte)(103)))));
            this.btnRezervasyonaGit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(67)))), ((int)(((byte)(50)))));
            this.btnRezervasyonaGit.FlatAppearance.BorderSize = 2;
            this.btnRezervasyonaGit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRezervasyonaGit.Location = new System.Drawing.Point(683, 145);
            this.btnRezervasyonaGit.Name = "btnRezervasyonaGit";
            this.btnRezervasyonaGit.Size = new System.Drawing.Size(118, 28);
            this.btnRezervasyonaGit.TabIndex = 1;
            this.btnRezervasyonaGit.Text = "Rezerve et";
            this.btnRezervasyonaGit.UseVisualStyleBackColor = false;
            this.btnRezervasyonaGit.Click += new System.EventHandler(this.btnRezervasyonaGit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gabriola", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(67)))), ((int)(((byte)(50)))));
            this.label3.Location = new System.Drawing.Point(12, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 68);
            this.label3.TabIndex = 8;
            this.label3.Text = "Odalar";
            // 
            // Odalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(244)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(825, 623);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRezervasyonaGit);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.flowLayoutPanelOdalar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(650, 225);
            this.Name = "Odalar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Odalar";
            this.Load += new System.EventHandler(this.Odalar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelOdalar;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnRezervasyonaGit;
        private System.Windows.Forms.Label label3;
    }
}