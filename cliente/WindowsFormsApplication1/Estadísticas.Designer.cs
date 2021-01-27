namespace WindowsFormsApplication1
{
    partial class Estadísticas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Estadísticas));
            this.apuesta_tb = new System.Windows.Forms.TextBox();
            this.porcentaje = new System.Windows.Forms.Button();
            this.BENEFICIOS = new System.Windows.Forms.Button();
            this.beneficios_lbl = new System.Windows.Forms.Label();
            this.consultas = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.stats_1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.consultas.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // apuesta_tb
            // 
            this.apuesta_tb.Location = new System.Drawing.Point(34, 101);
            this.apuesta_tb.Name = "apuesta_tb";
            this.apuesta_tb.Size = new System.Drawing.Size(238, 20);
            this.apuesta_tb.TabIndex = 0;
            this.apuesta_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // porcentaje
            // 
            this.porcentaje.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.porcentaje.ForeColor = System.Drawing.Color.White;
            this.porcentaje.Location = new System.Drawing.Point(34, 127);
            this.porcentaje.Name = "porcentaje";
            this.porcentaje.Size = new System.Drawing.Size(238, 40);
            this.porcentaje.TabIndex = 1;
            this.porcentaje.Text = "Porcentaje de acierto";
            this.porcentaje.UseVisualStyleBackColor = true;
            this.porcentaje.Click += new System.EventHandler(this.porcentaje_Click);
            // 
            // BENEFICIOS
            // 
            this.BENEFICIOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BENEFICIOS.ForeColor = System.Drawing.Color.White;
            this.BENEFICIOS.Location = new System.Drawing.Point(34, 247);
            this.BENEFICIOS.Name = "BENEFICIOS";
            this.BENEFICIOS.Size = new System.Drawing.Size(238, 40);
            this.BENEFICIOS.TabIndex = 2;
            this.BENEFICIOS.Text = "Balance";
            this.BENEFICIOS.UseVisualStyleBackColor = true;
            this.BENEFICIOS.Click += new System.EventHandler(this.BENEFICIOS_Click);
            // 
            // beneficios_lbl
            // 
            this.beneficios_lbl.AutoSize = true;
            this.beneficios_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beneficios_lbl.ForeColor = System.Drawing.Color.White;
            this.beneficios_lbl.Location = new System.Drawing.Point(142, 298);
            this.beneficios_lbl.Name = "beneficios_lbl";
            this.beneficios_lbl.Size = new System.Drawing.Size(0, 16);
            this.beneficios_lbl.TabIndex = 3;
            // 
            // consultas
            // 
            this.consultas.Controls.Add(this.label9);
            this.consultas.Controls.Add(this.label8);
            this.consultas.Controls.Add(this.label1);
            this.consultas.Controls.Add(this.beneficios_lbl);
            this.consultas.Controls.Add(this.stats_1);
            this.consultas.Controls.Add(this.apuesta_tb);
            this.consultas.Controls.Add(this.BENEFICIOS);
            this.consultas.Controls.Add(this.porcentaje);
            this.consultas.Location = new System.Drawing.Point(28, 38);
            this.consultas.Name = "consultas";
            this.consultas.Size = new System.Drawing.Size(300, 388);
            this.consultas.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(31, 298);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 16);
            this.label9.TabIndex = 6;
            this.label9.Text = "Total ganado:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(31, 228);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(160, 16);
            this.label8.TabIndex = 5;
            this.label8.Text = "Calcula tus beneficios";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(31, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Introducir tipo de apuesta";
            // 
            // stats_1
            // 
            this.stats_1.AutoSize = true;
            this.stats_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stats_1.ForeColor = System.Drawing.Color.White;
            this.stats_1.Location = new System.Drawing.Point(41, 9);
            this.stats_1.Name = "stats_1";
            this.stats_1.Size = new System.Drawing.Size(211, 20);
            this.stats_1.TabIndex = 0;
            this.stats_1.Text = "Consulta tus estadísticas";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(380, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(508, 388);
            this.panel1.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(38, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(422, 106);
            this.label11.TabIndex = 2;
            this.label11.Text = resources.GetString("label11.Text");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(123, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(256, 20);
            this.label10.TabIndex = 1;
            this.label10.Text = "MEJORA TUS ESTADÍSTICAS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApplication1.Properties.Resources.graph;
            this.pictureBox1.Location = new System.Drawing.Point(49, 188);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(390, 126);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(28, 503);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(100, 100);
            this.panel2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(20, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "COLOR";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(156, 503);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(100, 100);
            this.panel3.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(6, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "PAR/IMPAR";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(287, 503);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(100, 100);
            this.panel4.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "PASA/FALTA";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label7);
            this.panel6.Location = new System.Drawing.Point(549, 503);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(100, 100);
            this.panel6.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(5, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "DOCENAS";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label6);
            this.panel7.Location = new System.Drawing.Point(421, 503);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(100, 100);
            this.panel7.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(5, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "COLUMNAS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(24, 471);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Apuestas que puedes consultar";
            // 
            // Estadísticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.fichas_2;
            this.ClientSize = new System.Drawing.Size(984, 682);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.consultas);
            this.MaximumSize = new System.Drawing.Size(1000, 721);
            this.MinimumSize = new System.Drawing.Size(1000, 721);
            this.Name = "Estadísticas";
            this.Text = "Estadísticas";
            this.Load += new System.EventHandler(this.Estadísticas_Load);
            this.consultas.ResumeLayout(false);
            this.consultas.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox apuesta_tb;
        private System.Windows.Forms.Button porcentaje;
        private System.Windows.Forms.Button BENEFICIOS;
        private System.Windows.Forms.Label beneficios_lbl;
        private System.Windows.Forms.Panel consultas;
        private System.Windows.Forms.Label stats_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}