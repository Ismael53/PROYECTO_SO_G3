namespace WindowsFormsApplication1
{
    partial class Perfil
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
            this.deposito_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ingreso = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ingresar_btn = new System.Windows.Forms.Button();
            this.perfil_lbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.mostrar_contrasenya = new System.Windows.Forms.CheckBox();
            this.eliminar = new System.Windows.Forms.Button();
            this.pwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.TextBox();
            this.account_panel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.delete_panel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.account_panel.SuspendLayout();
            this.delete_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // deposito_tb
            // 
            this.deposito_tb.Location = new System.Drawing.Point(34, 97);
            this.deposito_tb.Name = "deposito_tb";
            this.deposito_tb.Size = new System.Drawing.Size(232, 20);
            this.deposito_tb.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(34, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total disponible";
            // 
            // ingreso
            // 
            this.ingreso.Location = new System.Drawing.Point(34, 167);
            this.ingreso.Name = "ingreso";
            this.ingreso.Size = new System.Drawing.Size(232, 20);
            this.ingreso.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(34, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Introduzca una cantidad";
            // 
            // ingresar_btn
            // 
            this.ingresar_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ingresar_btn.ForeColor = System.Drawing.Color.LimeGreen;
            this.ingresar_btn.Location = new System.Drawing.Point(34, 238);
            this.ingresar_btn.Name = "ingresar_btn";
            this.ingresar_btn.Size = new System.Drawing.Size(232, 40);
            this.ingresar_btn.TabIndex = 4;
            this.ingresar_btn.Text = "Ingresar";
            this.ingresar_btn.UseVisualStyleBackColor = true;
            this.ingresar_btn.Click += new System.EventHandler(this.ingresar_btn_Click);
            // 
            // perfil_lbl
            // 
            this.perfil_lbl.AutoSize = true;
            this.perfil_lbl.Location = new System.Drawing.Point(49, 47);
            this.perfil_lbl.Name = "perfil_lbl";
            this.perfil_lbl.Size = new System.Drawing.Size(0, 13);
            this.perfil_lbl.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(54, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Check Password";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // mostrar_contrasenya
            // 
            this.mostrar_contrasenya.AutoSize = true;
            this.mostrar_contrasenya.Location = new System.Drawing.Point(34, 193);
            this.mostrar_contrasenya.Name = "mostrar_contrasenya";
            this.mostrar_contrasenya.Size = new System.Drawing.Size(15, 14);
            this.mostrar_contrasenya.TabIndex = 20;
            this.mostrar_contrasenya.UseVisualStyleBackColor = true;
            this.mostrar_contrasenya.CheckedChanged += new System.EventHandler(this.mostrar_contrasenya_CheckedChanged);
            // 
            // eliminar
            // 
            this.eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eliminar.ForeColor = System.Drawing.Color.Red;
            this.eliminar.Location = new System.Drawing.Point(34, 238);
            this.eliminar.Name = "eliminar";
            this.eliminar.Size = new System.Drawing.Size(232, 40);
            this.eliminar.TabIndex = 19;
            this.eliminar.Text = "Eliminar mi cuenta";
            this.eliminar.UseVisualStyleBackColor = true;
            this.eliminar.Click += new System.EventHandler(this.eliminar_Click);
            // 
            // pwd
            // 
            this.pwd.Location = new System.Drawing.Point(34, 167);
            this.pwd.Name = "pwd";
            this.pwd.Size = new System.Drawing.Size(232, 20);
            this.pwd.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(30, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(30, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Username";
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(34, 97);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(232, 20);
            this.nombre.TabIndex = 16;
            // 
            // account_panel
            // 
            this.account_panel.Controls.Add(this.label5);
            this.account_panel.Controls.Add(this.ingresar_btn);
            this.account_panel.Controls.Add(this.deposito_tb);
            this.account_panel.Controls.Add(this.label2);
            this.account_panel.Controls.Add(this.label1);
            this.account_panel.Controls.Add(this.ingreso);
            this.account_panel.Location = new System.Drawing.Point(140, 136);
            this.account_panel.Name = "account_panel";
            this.account_panel.Size = new System.Drawing.Size(300, 400);
            this.account_panel.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.LimeGreen;
            this.label5.Location = new System.Drawing.Point(113, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "Crédito";
            // 
            // delete_panel
            // 
            this.delete_panel.Controls.Add(this.label7);
            this.delete_panel.Controls.Add(this.label6);
            this.delete_panel.Controls.Add(this.eliminar);
            this.delete_panel.Controls.Add(this.mostrar_contrasenya);
            this.delete_panel.Controls.Add(this.nombre);
            this.delete_panel.Controls.Add(this.label4);
            this.delete_panel.Controls.Add(this.pwd);
            this.delete_panel.Controls.Add(this.label3);
            this.delete_panel.Location = new System.Drawing.Point(550, 136);
            this.delete_panel.Name = "delete_panel";
            this.delete_panel.Size = new System.Drawing.Size(300, 400);
            this.delete_panel.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(94, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "Tramitar baja";
            // 
            // Perfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.fichas_2;
            this.ClientSize = new System.Drawing.Size(1000, 721);
            this.Controls.Add(this.delete_panel);
            this.Controls.Add(this.account_panel);
            this.Controls.Add(this.perfil_lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Perfil";
            this.Text = "Perfil";
            this.Load += new System.EventHandler(this.Perfil_Load);
            this.account_panel.ResumeLayout(false);
            this.account_panel.PerformLayout();
            this.delete_panel.ResumeLayout(false);
            this.delete_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox deposito_tb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ingreso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ingresar_btn;
        private System.Windows.Forms.Label perfil_lbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox mostrar_contrasenya;
        private System.Windows.Forms.Button eliminar;
        private System.Windows.Forms.TextBox pwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nombre;
        private System.Windows.Forms.Panel account_panel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel delete_panel;
        private System.Windows.Forms.Label label7;
    }
}