namespace LR1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCarga = new System.Windows.Forms.Button();
            this.rtbGramatica = new System.Windows.Forms.RichTextBox();
            this.btnObtenTabla = new System.Windows.Forms.Button();
            this.btnDibuja = new System.Windows.Forms.Button();
            this.btnAnaliza = new System.Windows.Forms.Button();
            this.txtbAnaliza = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtbGramaticaA = new System.Windows.Forms.RichTextBox();
            this.gBGramatica = new System.Windows.Forms.GroupBox();
            this.gBGramaticaA = new System.Windows.Forms.GroupBox();
            this.btnGenera = new System.Windows.Forms.Button();
            this.gBGramatica.SuspendLayout();
            this.gBGramaticaA.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCarga
            // 
            this.btnCarga.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCarga.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarga.Location = new System.Drawing.Point(47, 62);
            this.btnCarga.Name = "btnCarga";
            this.btnCarga.Size = new System.Drawing.Size(134, 41);
            this.btnCarga.TabIndex = 0;
            this.btnCarga.Text = "Carga Gramatica";
            this.btnCarga.UseVisualStyleBackColor = false;
            this.btnCarga.Click += new System.EventHandler(this.btnCarga_Click);
            // 
            // rtbGramatica
            // 
            this.rtbGramatica.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbGramatica.Location = new System.Drawing.Point(6, 21);
            this.rtbGramatica.Name = "rtbGramatica";
            this.rtbGramatica.Size = new System.Drawing.Size(156, 268);
            this.rtbGramatica.TabIndex = 1;
            this.rtbGramatica.Text = "";
            // 
            // btnObtenTabla
            // 
            this.btnObtenTabla.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnObtenTabla.Enabled = false;
            this.btnObtenTabla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObtenTabla.Location = new System.Drawing.Point(413, 62);
            this.btnObtenTabla.Name = "btnObtenTabla";
            this.btnObtenTabla.Size = new System.Drawing.Size(332, 41);
            this.btnObtenTabla.TabIndex = 2;
            this.btnObtenTabla.Text = "Obtener Tabla de Analisís Sintactico";
            this.btnObtenTabla.UseVisualStyleBackColor = false;
            this.btnObtenTabla.Click += new System.EventHandler(this.btnObtenTabla_Click);
            // 
            // btnDibuja
            // 
            this.btnDibuja.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDibuja.Enabled = false;
            this.btnDibuja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDibuja.Location = new System.Drawing.Point(51, 505);
            this.btnDibuja.Name = "btnDibuja";
            this.btnDibuja.Size = new System.Drawing.Size(332, 41);
            this.btnDibuja.TabIndex = 3;
            this.btnDibuja.Text = "Dibujar AFD a LR(0)";
            this.btnDibuja.UseVisualStyleBackColor = false;
            this.btnDibuja.Click += new System.EventHandler(this.btnDibuja_Click);
            // 
            // btnAnaliza
            // 
            this.btnAnaliza.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAnaliza.Enabled = false;
            this.btnAnaliza.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnaliza.Location = new System.Drawing.Point(147, 693);
            this.btnAnaliza.Name = "btnAnaliza";
            this.btnAnaliza.Size = new System.Drawing.Size(134, 41);
            this.btnAnaliza.TabIndex = 4;
            this.btnAnaliza.Text = "Analizar";
            this.btnAnaliza.UseVisualStyleBackColor = false;
            this.btnAnaliza.Click += new System.EventHandler(this.btnAnaliza_Click);
            // 
            // txtbAnaliza
            // 
            this.txtbAnaliza.Enabled = false;
            this.txtbAnaliza.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbAnaliza.Location = new System.Drawing.Point(147, 638);
            this.txtbAnaliza.Name = "txtbAnaliza";
            this.txtbAnaliza.Size = new System.Drawing.Size(148, 24);
            this.txtbAnaliza.TabIndex = 5;
            this.txtbAnaliza.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(413, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(836, 350);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tabla de Analisis Sintactico";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(413, 505);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(825, 305);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tabla de Acciones de Analisis Sintactico";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // rtbGramaticaA
            // 
            this.rtbGramaticaA.Enabled = false;
            this.rtbGramaticaA.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbGramaticaA.Location = new System.Drawing.Point(12, 36);
            this.rtbGramaticaA.Name = "rtbGramaticaA";
            this.rtbGramaticaA.Size = new System.Drawing.Size(148, 253);
            this.rtbGramaticaA.TabIndex = 8;
            this.rtbGramaticaA.Text = "";
            // 
            // gBGramatica
            // 
            this.gBGramatica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gBGramatica.Controls.Add(this.rtbGramatica);
            this.gBGramatica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBGramatica.Location = new System.Drawing.Point(28, 124);
            this.gBGramatica.Name = "gBGramatica";
            this.gBGramatica.Size = new System.Drawing.Size(169, 327);
            this.gBGramatica.TabIndex = 9;
            this.gBGramatica.TabStop = false;
            this.gBGramatica.Text = "Gramatica";
            // 
            // gBGramaticaA
            // 
            this.gBGramaticaA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gBGramaticaA.Controls.Add(this.rtbGramaticaA);
            this.gBGramaticaA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBGramaticaA.Location = new System.Drawing.Point(214, 124);
            this.gBGramaticaA.Name = "gBGramaticaA";
            this.gBGramaticaA.Size = new System.Drawing.Size(169, 327);
            this.gBGramaticaA.TabIndex = 10;
            this.gBGramaticaA.TabStop = false;
            this.gBGramaticaA.Text = "Gramatica Aumentada";
            // 
            // btnGenera
            // 
            this.btnGenera.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGenera.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenera.Location = new System.Drawing.Point(231, 62);
            this.btnGenera.Name = "btnGenera";
            this.btnGenera.Size = new System.Drawing.Size(134, 41);
            this.btnGenera.TabIndex = 11;
            this.btnGenera.Text = "Genera LR0";
            this.btnGenera.UseVisualStyleBackColor = false;
            this.btnGenera.Click += new System.EventHandler(this.btnGenera_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1276, 845);
            this.Controls.Add(this.btnGenera);
            this.Controls.Add(this.gBGramaticaA);
            this.Controls.Add(this.gBGramatica);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtbAnaliza);
            this.Controls.Add(this.btnAnaliza);
            this.Controls.Add(this.btnDibuja);
            this.Controls.Add(this.btnObtenTabla);
            this.Controls.Add(this.btnCarga);
            this.Name = "Form1";
            this.Text = "LR(0)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.gBGramatica.ResumeLayout(false);
            this.gBGramaticaA.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCarga;
        private System.Windows.Forms.RichTextBox rtbGramatica;
        private System.Windows.Forms.Button btnObtenTabla;
        private System.Windows.Forms.Button btnDibuja;
        private System.Windows.Forms.Button btnAnaliza;
        private System.Windows.Forms.TextBox txtbAnaliza;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtbGramaticaA;
        private System.Windows.Forms.GroupBox gBGramatica;
        private System.Windows.Forms.GroupBox gBGramaticaA;
        private System.Windows.Forms.Button btnGenera;
    }
}

