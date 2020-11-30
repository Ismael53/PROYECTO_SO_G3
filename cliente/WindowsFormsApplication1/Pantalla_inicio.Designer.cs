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
            this.label1 = new System.Windows.Forms.Label();
            this.IP = new System.Windows.Forms.TextBox();
            this.registro = new System.Windows.Forms.GroupBox();
            this.desconectar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.connect_status = new System.Windows.Forms.TextBox();
            this.nombre = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Consulta_3 = new System.Windows.Forms.RadioButton();
            this.Consulta_2 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.pwd = new System.Windows.Forms.TextBox();
            this.SIGN_IN = new System.Windows.Forms.Button();
            this.LOG_IN = new System.Windows.Forms.Button();
            this.Consulta_1 = new System.Windows.Forms.RadioButton();
            this.mostrar_contrasenya = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.titulo = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.registro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.titulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(680, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // IP
            // 
            this.IP.Location = new System.Drawing.Point(717, 11);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(130, 20);
            this.IP.TabIndex = 2;
            this.IP.Text = "147.83.117.22";
            this.IP.TextChanged += new System.EventHandler(this.IP_TextChanged);
            // 
            // registro
            // 
            this.registro.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.registro.Controls.Add(this.mostrar_contrasenya);
            this.registro.Controls.Add(this.Consulta_1);
            this.registro.Controls.Add(this.LOG_IN);
            this.registro.Controls.Add(this.SIGN_IN);
            this.registro.Controls.Add(this.pwd);
            this.registro.Controls.Add(this.label3);
            this.registro.Controls.Add(this.Consulta_2);
            this.registro.Controls.Add(this.Consulta_3);
            this.registro.Controls.Add(this.label2);
            this.registro.Controls.Add(this.button2);
            this.registro.Controls.Add(this.nombre);
            this.registro.Location = new System.Drawing.Point(400, 150);
            this.registro.Name = "registro";
            this.registro.Size = new System.Drawing.Size(350, 200);
            this.registro.TabIndex = 6;
            this.registro.TabStop = false;
            // 
            // desconectar
            // 
            this.desconectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.desconectar.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desconectar.Location = new System.Drawing.Point(0, 314);
            this.desconectar.Name = "desconectar";
            this.desconectar.Size = new System.Drawing.Size(330, 165);
            this.desconectar.TabIndex = 7;
            this.desconectar.Text = "desconectar";
            this.desconectar.UseVisualStyleBackColor = true;
            this.desconectar.Click += new System.EventHandler(this.desconectar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(400, 434);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(350, 173);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(254, 651);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 30);
            this.button3.TabIndex = 11;
            this.button3.Text = "Jugar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // connect_status
            // 
            this.connect_status.ForeColor = System.Drawing.Color.Red;
            this.connect_status.Location = new System.Drawing.Point(872, 12);
            this.connect_status.Name = "connect_status";
            this.connect_status.Size = new System.Drawing.Size(100, 20);
            this.connect_status.TabIndex = 12;
            this.connect_status.Text = "Desconectado";
            this.connect_status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(160, 30);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(164, 20);
            this.nombre.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(131, 142);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Enviar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "NOMBRE";
            // 
            // Consulta_3
            // 
            this.Consulta_3.AutoSize = true;
            this.Consulta_3.Location = new System.Drawing.Point(222, 171);
            this.Consulta_3.Name = "Consulta_3";
            this.Consulta_3.Size = new System.Drawing.Size(75, 17);
            this.Consulta_3.TabIndex = 8;
            this.Consulta_3.TabStop = true;
            this.Consulta_3.Text = "Consulta 3";
            this.Consulta_3.UseVisualStyleBackColor = true;
            this.Consulta_3.CheckedChanged += new System.EventHandler(this.Consulta_3_CheckedChanged);
            // 
            // Consulta_2
            // 
            this.Consulta_2.AutoSize = true;
            this.Consulta_2.Location = new System.Drawing.Point(131, 171);
            this.Consulta_2.Name = "Consulta_2";
            this.Consulta_2.Size = new System.Drawing.Size(75, 17);
            this.Consulta_2.TabIndex = 7;
            this.Consulta_2.TabStop = true;
            this.Consulta_2.Text = "Consulta 2";
            this.Consulta_2.UseVisualStyleBackColor = true;
            this.Consulta_2.CheckedChanged += new System.EventHandler(this.Consulta_2_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "PASSWORD";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // pwd
            // 
            this.pwd.Location = new System.Drawing.Point(160, 60);
            this.pwd.Name = "pwd";
            this.pwd.Size = new System.Drawing.Size(130, 20);
            this.pwd.TabIndex = 7;
            // 
            // SIGN_IN
            // 
            this.SIGN_IN.Location = new System.Drawing.Point(131, 113);
            this.SIGN_IN.Name = "SIGN_IN";
            this.SIGN_IN.Size = new System.Drawing.Size(75, 23);
            this.SIGN_IN.TabIndex = 11;
            this.SIGN_IN.Text = "SIGN IN";
            this.SIGN_IN.UseVisualStyleBackColor = true;
            this.SIGN_IN.Click += new System.EventHandler(this.SIGN_IN_Click_1);
            // 
            // LOG_IN
            // 
            this.LOG_IN.Location = new System.Drawing.Point(222, 113);
            this.LOG_IN.Name = "LOG_IN";
            this.LOG_IN.Size = new System.Drawing.Size(75, 23);
            this.LOG_IN.TabIndex = 12;
            this.LOG_IN.Text = "LOG IN";
            this.LOG_IN.UseVisualStyleBackColor = true;
            this.LOG_IN.Click += new System.EventHandler(this.LOG_IN_Click_1);
            // 
            // Consulta_1
            // 
            this.Consulta_1.AutoSize = true;
            this.Consulta_1.Location = new System.Drawing.Point(28, 171);
            this.Consulta_1.Name = "Consulta_1";
            this.Consulta_1.Size = new System.Drawing.Size(75, 17);
            this.Consulta_1.TabIndex = 13;
            this.Consulta_1.TabStop = true;
            this.Consulta_1.Text = "Consulta 1";
            this.Consulta_1.UseVisualStyleBackColor = true;
            this.Consulta_1.CheckedChanged += new System.EventHandler(this.Consulta_1_CheckedChanged);
            // 
            // mostrar_contrasenya
            // 
            this.mostrar_contrasenya.AutoSize = true;
            this.mostrar_contrasenya.Location = new System.Drawing.Point(296, 66);
            this.mostrar_contrasenya.Name = "mostrar_contrasenya";
            this.mostrar_contrasenya.Size = new System.Drawing.Size(15, 14);
            this.mostrar_contrasenya.TabIndex = 12;
            this.mostrar_contrasenya.UseVisualStyleBackColor = true;
            this.mostrar_contrasenya.CheckedChanged += new System.EventHandler(this.mostrar_contrasenya_CheckedChanged);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(0, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(330, 165);
            this.button1.TabIndex = 4;
            this.button1.Text = "conectar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // titulo
            // 
            this.titulo.Controls.Add(this.label4);
            this.titulo.Location = new System.Drawing.Point(0, 0);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(329, 154);
            this.titulo.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(317, 51);
            this.label4.TabIndex = 14;
            this.label4.Text = "Gran Casino UPC";
            // 
            // Pantalla_inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 711);
            this.Controls.Add(this.titulo);
            this.Controls.Add(this.connect_status);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.desconectar);
            this.Controls.Add(this.registro);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.IP);
            this.Controls.Add(this.label1);
            this.Name = "Pantalla_inicio";
            this.Text = "Pantalla de inicio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.registro.ResumeLayout(false);
            this.registro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.titulo.ResumeLayout(false);
            this.titulo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IP;
        private System.Windows.Forms.GroupBox registro;
        private System.Windows.Forms.Button desconectar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox connect_status;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel titulo;
        private System.Windows.Forms.Label label4;
    }
}

