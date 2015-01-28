namespace LR1
{
    partial class FrmDibuja
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
            this.gbDibujo = new System.Windows.Forms.GroupBox();
            this.pbDibujo = new System.Windows.Forms.PictureBox();
            this.gbEstados = new System.Windows.Forms.GroupBox();
            this.tvEstados = new System.Windows.Forms.TreeView();
            this.gbDibujo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDibujo)).BeginInit();
            this.gbEstados.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDibujo
            // 
            this.gbDibujo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gbDibujo.Controls.Add(this.pbDibujo);
            this.gbDibujo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDibujo.Location = new System.Drawing.Point(272, 27);
            this.gbDibujo.Name = "gbDibujo";
            this.gbDibujo.Size = new System.Drawing.Size(696, 511);
            this.gbDibujo.TabIndex = 0;
            this.gbDibujo.TabStop = false;
            this.gbDibujo.Text = "Dibujo";
            // 
            // pbDibujo
            // 
            this.pbDibujo.BackColor = System.Drawing.Color.White;
            this.pbDibujo.Location = new System.Drawing.Point(18, 33);
            this.pbDibujo.Name = "pbDibujo";
            this.pbDibujo.Size = new System.Drawing.Size(653, 468);
            this.pbDibujo.TabIndex = 0;
            this.pbDibujo.TabStop = false;
            // 
            // gbEstados
            // 
            this.gbEstados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gbEstados.Controls.Add(this.tvEstados);
            this.gbEstados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEstados.Location = new System.Drawing.Point(27, 27);
            this.gbEstados.Name = "gbEstados";
            this.gbEstados.Size = new System.Drawing.Size(214, 522);
            this.gbEstados.TabIndex = 1;
            this.gbEstados.TabStop = false;
            this.gbEstados.Text = "Estados";
            // 
            // tvEstados
            // 
            this.tvEstados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvEstados.Location = new System.Drawing.Point(19, 42);
            this.tvEstados.Name = "tvEstados";
            this.tvEstados.Size = new System.Drawing.Size(182, 459);
            this.tvEstados.TabIndex = 0;
            // 
            // FrmDibuja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(997, 577);
            this.Controls.Add(this.gbEstados);
            this.Controls.Add(this.gbDibujo);
            this.Name = "FrmDibuja";
            this.Text = "FrmDibuja";
            this.Load += new System.EventHandler(this.FrmDibuja_Load);
            this.gbDibujo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbDibujo)).EndInit();
            this.gbEstados.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDibujo;
        private System.Windows.Forms.PictureBox pbDibujo;
        private System.Windows.Forms.GroupBox gbEstados;
        private System.Windows.Forms.TreeView tvEstados;
    }
}