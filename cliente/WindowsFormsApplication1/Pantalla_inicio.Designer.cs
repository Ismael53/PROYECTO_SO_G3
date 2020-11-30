namespace WindowsFormsApplication1
{
    partial class Pantalla_inicio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.IP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mostrar_contrasenya = new System.Windows.Forms.CheckBox();
            this.Consulta_1 = new System.Windows.Forms.RadioButton();
            this.LOG_IN = new System.Windows.Forms.Button();
            this.SIGN_IN = new System.Windows.Forms.Button();
            this.pwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Consulta_2 = new System.Windows.Forms.RadioButton();
            this.Consulta_3 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.nombre = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.connect_status = new System.Windows.Forms.TextBox();
            this.jugar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.num_usuarios = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.desconn = new System.Windows.Forms.Button();
            this.loading_text = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1004, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // IP
            // 
            this.IP.Location = new System.Drawing.Point(1027, 12);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(130, 20);
            this.IP.TabIndex = 2;
            this.IP.Text = "192.168.56.102";
            this.IP.TextChanged += new System.EventHandler(this.IP_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(718, 288);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Check Password";
            // 
            // mostrar_contrasenya
            // 
            this.mostrar_contrasenya.AutoSize = true;
            this.mostrar_contrasenya.Location = new System.Drawing.Point(697, 287);
            this.mostrar_contrasenya.Name = "mostrar_contrasenya";
            this.mostrar_contrasenya.Size = new System.Drawing.Size(15, 14);
            this.mostrar_contrasenya.TabIndex = 12;
            this.mostrar_contrasenya.UseVisualStyleBackColor = true;
            this.mostrar_contrasenya.CheckedChanged += new System.EventHandler(this.mostrar_contrasenya_CheckedChanged);
            // 
            // Consulta_1
            // 
            this.Consulta_1.AutoSize = true;
            this.Consulta_1.Location = new System.Drawing.Point(697, 510);
            this.Consulta_1.Name = "Consulta_1";
            this.Consulta_1.Size = new System.Drawing.Size(75, 17);
            this.Consulta_1.TabIndex = 13;
            this.Consulta_1.TabStop = true;
            this.Consulta_1.Text = "Consulta 1";
            this.Consulta_1.UseVisualStyleBackColor = true;
            this.Consulta_1.CheckedChanged += new System.EventHandler(this.Consulta_1_CheckedChanged);
            // 
            // LOG_IN
            // 
            this.LOG_IN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LOG_IN.Location = new System.Drawing.Point(697, 397);
            this.LOG_IN.Name = "LOG_IN";
            this.LOG_IN.Size = new System.Drawing.Size(232, 40);
            this.LOG_IN.TabIndex = 12;
            this.LOG_IN.Text = "LOG IN";
            this.LOG_IN.UseVisualStyleBackColor = true;
            this.LOG_IN.Click += new System.EventHandler(this.LOG_IN_Click_1);
            // 
            // SIGN_IN
            // 
            this.SIGN_IN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SIGN_IN.Location = new System.Drawing.Point(697, 332);
            this.SIGN_IN.Name = "SIGN_IN";
            this.SIGN_IN.Size = new System.Drawing.Size(232, 40);
            this.SIGN_IN.TabIndex = 11;
            this.SIGN_IN.Text = "SIGN IN";
            this.SIGN_IN.UseVisualStyleBackColor = true;
            this.SIGN_IN.Click += new System.EventHandler(this.SIGN_IN_Click_1);
            // 
            // pwd
            // 
            this.pwd.Location = new System.Drawing.Point(697, 261);
            this.pwd.Name = "pwd";
            this.pwd.Size = new System.Drawing.Size(232, 20);
            this.pwd.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(693, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Password";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Consulta_2
            // 
            this.Consulta_2.AutoSize = true;
            this.Consulta_2.Location = new System.Drawing.Point(778, 510);
            this.Consulta_2.Name = "Consulta_2";
            this.Consulta_2.Size = new System.Drawing.Size(75, 17);
            this.Consulta_2.TabIndex = 7;
            this.Consulta_2.TabStop = true;
            this.Consulta_2.Text = "Consulta 2";
            this.Consulta_2.UseVisualStyleBackColor = true;
            this.Consulta_2.CheckedChanged += new System.EventHandler(this.Consulta_2_CheckedChanged);
            // 
            // Consulta_3
            // 
            this.Consulta_3.AutoSize = true;
            this.Consulta_3.Location = new System.Drawing.Point(859, 510);
            this.Consulta_3.Name = "Consulta_3";
            this.Consulta_3.Size = new System.Drawing.Size(75, 17);
            this.Consulta_3.TabIndex = 8;
            this.Consulta_3.TabStop = true;
            this.Consulta_3.Text = "Consulta 3";
            this.Consulta_3.UseVisualStyleBackColor = true;
            this.Consulta_3.CheckedChanged += new System.EventHandler(this.Consulta_3_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(693, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(778, 481);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Enviar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(697, 191);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(232, 20);
            this.nombre.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Location = new System.Drawing.Point(997, 214);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(187, 223);
            this.dataGridView1.TabIndex = 10;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(1163, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 25);
            this.button4.TabIndex = 16;
            this.button4.Text = "Close";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // connect_status
            // 
            this.connect_status.BackColor = System.Drawing.Color.Red;
            this.connect_status.ForeColor = System.Drawing.Color.White;
            this.connect_status.Location = new System.Drawing.Point(1163, 43);
            this.connect_status.Name = "connect_status";
            this.connect_status.Size = new System.Drawing.Size(75, 20);
            this.connect_status.TabIndex = 12;
            this.connect_status.Text = "Desconectado";
            this.connect_status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // jugar
            // 
            this.jugar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jugar.ForeColor = System.Drawing.Color.White;
            this.jugar.Location = new System.Drawing.Point(997, 464);
            this.jugar.Name = "jugar";
            this.jugar.Size = new System.Drawing.Size(187, 40);
            this.jugar.TabIndex = 11;
            this.jugar.Text = "Jugar";
            this.jugar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.jugar.UseVisualStyleBackColor = true;
            this.jugar.Visible = false;
            this.jugar.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.num_usuarios);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(970, 168);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 40);
            this.panel1.TabIndex = 20;
            // 
            // num_usuarios
            // 
            this.num_usuarios.AutoSize = true;
            this.num_usuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_usuarios.Location = new System.Drawing.Point(83, 20);
            this.num_usuarios.Name = "num_usuarios";
            this.num_usuarios.Size = new System.Drawing.Size(0, 13);
            this.num_usuarios.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Usuarios Connectados";
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(624, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(2, 500);
            this.label5.TabIndex = 21;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApplication1.Properties.Resources.logo_nice;
            this.pictureBox1.Location = new System.Drawing.Point(120, 248);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 150);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // desconn
            // 
            this.desconn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.desconn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desconn.Image = global::WindowsFormsApplication1.Properties.Resources.icon_diss;
            this.desconn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.desconn.Location = new System.Drawing.Point(120, 553);
            this.desconn.Margin = new System.Windows.Forms.Padding(0);
            this.desconn.Name = "desconn";
            this.desconn.Size = new System.Drawing.Size(232, 40);
            this.desconn.TabIndex = 18;
            this.desconn.Text = "Desconectar";
            this.desconn.UseVisualStyleBackColor = true;
            this.desconn.Click += new System.EventHandler(this.desconn_Click);
            // 
            // loading_text
            // 
            this.loading_text.AutoSize = true;
            this.loading_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loading_text.Location = new System.Drawing.Point(277, 457);
            this.loading_text.Name = "loading_text";
            this.loading_text.Size = new System.Drawing.Size(0, 13);
            this.loading_text.TabIndex = 23;
            // 
            // Pantalla_inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 711);
            this.Controls.Add(this.loading_text);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.jugar);
            this.Controls.Add(this.mostrar_contrasenya);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.Consulta_1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LOG_IN);
            this.Controls.Add(this.SIGN_IN);
            this.Controls.Add(this.connect_status);
            this.Controls.Add(this.pwd);
            this.Controls.Add(this.desconn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Consulta_2);
            this.Controls.Add(this.Consulta_3);
            this.Controls.Add(this.IP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nombre);
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(1250, 750);
            this.MinimumSize = new System.Drawing.Size(1250, 726);
            this.Name = "Pantalla_inicio";
            this.Text = "Pantalla de inicio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IP;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button jugar;
        private System.Windows.Forms.CheckBox mostrar_contrasenya;
        private System.Windows.Forms.RadioButton Consulta_1;
        private System.Windows.Forms.Button LOG_IN;
        private System.Windows.Forms.Button SIGN_IN;
        private System.Windows.Forms.TextBox pwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton Consulta_2;
        private System.Windows.Forms.RadioButton Consulta_3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox connect_status;
        private System.Windows.Forms.Button desconn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label num_usuarios;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label loading_text;
    }
}

