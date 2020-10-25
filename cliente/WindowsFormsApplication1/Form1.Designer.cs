namespace WindowsFormsApplication1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IP = new System.Windows.Forms.TextBox();
            this.nombre = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Consulta_1 = new System.Windows.Forms.RadioButton();
            this.LOG_IN = new System.Windows.Forms.Button();
            this.SIGN_IN = new System.Windows.Forms.Button();
            this.pwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Consulta_2 = new System.Windows.Forms.RadioButton();
            this.Consulta_3 = new System.Windows.Forms.RadioButton();
            this.desconectar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
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
            // IP
            // 
            this.IP.Location = new System.Drawing.Point(84, 52);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(130, 20);
            this.IP.TabIndex = 2;
            this.IP.Text = "192.168.56.101";
            this.IP.TextChanged += new System.EventHandler(this.IP_TextChanged);
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(133, 30);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(164, 20);
            this.nombre.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(287, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 31);
            this.button1.TabIndex = 4;
            this.button1.Text = "conectar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.Consulta_1);
            this.groupBox1.Controls.Add(this.LOG_IN);
            this.groupBox1.Controls.Add(this.SIGN_IN);
            this.groupBox1.Controls.Add(this.pwd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Consulta_2);
            this.groupBox1.Controls.Add(this.Consulta_3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.nombre);
            this.groupBox1.Location = new System.Drawing.Point(8, 207);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 202);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Peticion";
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
            // pwd
            // 
            this.pwd.Location = new System.Drawing.Point(163, 59);
            this.pwd.Name = "pwd";
            this.pwd.Size = new System.Drawing.Size(130, 20);
            this.pwd.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "PASSWORD";
            this.label3.Click += new System.EventHandler(this.label3_Click);
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
            // desconectar
            // 
            this.desconectar.Location = new System.Drawing.Point(44, 443);
            this.desconectar.Name = "desconectar";
            this.desconectar.Size = new System.Drawing.Size(75, 31);
            this.desconectar.TabIndex = 7;
            this.desconectar.Text = "desconectar";
            this.desconectar.UseVisualStyleBackColor = true;
            this.desconectar.Click += new System.EventHandler(this.desconectar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 562);
            this.Controls.Add(this.desconectar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.IP);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IP;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton Consulta_2;
        private System.Windows.Forms.RadioButton Consulta_3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SIGN_IN;
        private System.Windows.Forms.TextBox pwd;
        private System.Windows.Forms.Button LOG_IN;
        private System.Windows.Forms.RadioButton Consulta_1;
        private System.Windows.Forms.Button desconectar;
    }
}

