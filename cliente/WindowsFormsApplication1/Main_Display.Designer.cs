namespace WindowsFormsApplication1
{
    partial class Main_Display
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
            this.Menu = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.user_label = new System.Windows.Forms.Button();
            this.profile = new System.Windows.Forms.Button();
            this.partidas = new System.Windows.Forms.Panel();
            this.unir_partida = new System.Windows.Forms.Button();
            this.data_partidas = new System.Windows.Forms.DataGridView();
            this.partidas_button = new System.Windows.Forms.Button();
            this.Games = new System.Windows.Forms.Panel();
            this.ruleta = new System.Windows.Forms.Button();
            this.black_jack = new System.Windows.Forms.Button();
            this.poker = new System.Windows.Forms.Button();
            this.Jugar = new System.Windows.Forms.Button();
            this.Inicio = new System.Windows.Forms.Button();
            this.Logo = new System.Windows.Forms.Panel();
            this.logo_200 = new System.Windows.Forms.PictureBox();
            this.panelchildForm = new System.Windows.Forms.Panel();
            this.player_5 = new System.Windows.Forms.RichTextBox();
            this.player_3 = new System.Windows.Forms.RichTextBox();
            this.player_4 = new System.Windows.Forms.RichTextBox();
            this.player_2 = new System.Windows.Forms.RichTextBox();
            this.player_1 = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.partidas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_partidas)).BeginInit();
            this.Games.SuspendLayout();
            this.Logo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo_200)).BeginInit();
            this.panelchildForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.SystemColors.Desktop;
            this.Menu.Controls.Add(this.dataGridView1);
            this.Menu.Controls.Add(this.user_label);
            this.Menu.Controls.Add(this.profile);
            this.Menu.Controls.Add(this.partidas);
            this.Menu.Controls.Add(this.partidas_button);
            this.Menu.Controls.Add(this.button1);
            this.Menu.Controls.Add(this.Games);
            this.Menu.Controls.Add(this.Jugar);
            this.Menu.Controls.Add(this.Inicio);
            this.Menu.Controls.Add(this.Logo);
            this.Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(250, 711);
            this.Menu.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 555);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(250, 111);
            this.dataGridView1.TabIndex = 13;
            // 
            // user_label
            // 
            this.user_label.Dock = System.Windows.Forms.DockStyle.Top;
            this.user_label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.user_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_label.ForeColor = System.Drawing.Color.White;
            this.user_label.Location = new System.Drawing.Point(0, 510);
            this.user_label.Name = "user_label";
            this.user_label.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.user_label.Size = new System.Drawing.Size(250, 45);
            this.user_label.TabIndex = 12;
            this.user_label.Text = "USUARIOS CONECTADOS";
            this.user_label.UseVisualStyleBackColor = true;
            // 
            // profile
            // 
            this.profile.Dock = System.Windows.Forms.DockStyle.Top;
            this.profile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.profile.ForeColor = System.Drawing.Color.White;
            this.profile.Location = new System.Drawing.Point(0, 465);
            this.profile.Name = "profile";
            this.profile.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.profile.Size = new System.Drawing.Size(250, 45);
            this.profile.TabIndex = 11;
            this.profile.Text = "Perfil";
            this.profile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.profile.UseVisualStyleBackColor = true;
            // 
            // partidas
            // 
            this.partidas.Controls.Add(this.unir_partida);
            this.partidas.Controls.Add(this.data_partidas);
            this.partidas.Dock = System.Windows.Forms.DockStyle.Top;
            this.partidas.Location = new System.Drawing.Point(0, 335);
            this.partidas.Name = "partidas";
            this.partidas.Size = new System.Drawing.Size(250, 130);
            this.partidas.TabIndex = 10;
            // 
            // unir_partida
            // 
            this.unir_partida.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.unir_partida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.unir_partida.ForeColor = System.Drawing.Color.White;
            this.unir_partida.Location = new System.Drawing.Point(0, 85);
            this.unir_partida.Name = "unir_partida";
            this.unir_partida.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.unir_partida.Size = new System.Drawing.Size(250, 45);
            this.unir_partida.TabIndex = 11;
            this.unir_partida.Text = "Unirme";
            this.unir_partida.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.unir_partida.UseVisualStyleBackColor = true;
            this.unir_partida.Click += new System.EventHandler(this.unir_partida_Click);
            // 
            // data_partidas
            // 
            this.data_partidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_partidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data_partidas.Location = new System.Drawing.Point(0, 0);
            this.data_partidas.Name = "data_partidas";
            this.data_partidas.ReadOnly = true;
            this.data_partidas.Size = new System.Drawing.Size(250, 130);
            this.data_partidas.TabIndex = 10;
            // 
            // partidas_button
            // 
            this.partidas_button.Dock = System.Windows.Forms.DockStyle.Top;
            this.partidas_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.partidas_button.ForeColor = System.Drawing.Color.White;
            this.partidas_button.Location = new System.Drawing.Point(0, 290);
            this.partidas_button.Name = "partidas_button";
            this.partidas_button.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.partidas_button.Size = new System.Drawing.Size(250, 45);
            this.partidas_button.TabIndex = 9;
            this.partidas_button.Text = "Partidas";
            this.partidas_button.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.partidas_button.UseVisualStyleBackColor = true;
            this.partidas_button.Click += new System.EventHandler(this.partidas_button_Click);
            // 
            // Games
            // 
            this.Games.Controls.Add(this.ruleta);
            this.Games.Controls.Add(this.black_jack);
            this.Games.Controls.Add(this.poker);
            this.Games.Dock = System.Windows.Forms.DockStyle.Top;
            this.Games.Location = new System.Drawing.Point(0, 170);
            this.Games.Name = "Games";
            this.Games.Size = new System.Drawing.Size(250, 120);
            this.Games.TabIndex = 4;
            // 
            // ruleta
            // 
            this.ruleta.Dock = System.Windows.Forms.DockStyle.Top;
            this.ruleta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ruleta.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ruleta.Location = new System.Drawing.Point(0, 80);
            this.ruleta.Name = "ruleta";
            this.ruleta.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.ruleta.Size = new System.Drawing.Size(250, 40);
            this.ruleta.TabIndex = 2;
            this.ruleta.Text = "Ruleta";
            this.ruleta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ruleta.UseVisualStyleBackColor = true;
            this.ruleta.Click += new System.EventHandler(this.ruleta_Click);
            // 
            // black_jack
            // 
            this.black_jack.Dock = System.Windows.Forms.DockStyle.Top;
            this.black_jack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.black_jack.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.black_jack.Location = new System.Drawing.Point(0, 40);
            this.black_jack.Name = "black_jack";
            this.black_jack.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.black_jack.Size = new System.Drawing.Size(250, 40);
            this.black_jack.TabIndex = 1;
            this.black_jack.Text = "Black Jack";
            this.black_jack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.black_jack.UseVisualStyleBackColor = true;
            this.black_jack.Click += new System.EventHandler(this.black_jack_Click);
            // 
            // poker
            // 
            this.poker.Dock = System.Windows.Forms.DockStyle.Top;
            this.poker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.poker.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.poker.Location = new System.Drawing.Point(0, 0);
            this.poker.Name = "poker";
            this.poker.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.poker.Size = new System.Drawing.Size(250, 40);
            this.poker.TabIndex = 0;
            this.poker.Text = "Poker";
            this.poker.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.poker.UseVisualStyleBackColor = true;
            this.poker.Click += new System.EventHandler(this.poker_Click);
            // 
            // Jugar
            // 
            this.Jugar.Dock = System.Windows.Forms.DockStyle.Top;
            this.Jugar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Jugar.ForeColor = System.Drawing.Color.White;
            this.Jugar.Location = new System.Drawing.Point(0, 125);
            this.Jugar.Name = "Jugar";
            this.Jugar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Jugar.Size = new System.Drawing.Size(250, 45);
            this.Jugar.TabIndex = 3;
            this.Jugar.Text = "Jugar";
            this.Jugar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Jugar.UseVisualStyleBackColor = true;
            this.Jugar.Click += new System.EventHandler(this.Jugar_Click);
            // 
            // Inicio
            // 
            this.Inicio.Dock = System.Windows.Forms.DockStyle.Top;
            this.Inicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Inicio.ForeColor = System.Drawing.Color.White;
            this.Inicio.Location = new System.Drawing.Point(0, 80);
            this.Inicio.Name = "Inicio";
            this.Inicio.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Inicio.Size = new System.Drawing.Size(250, 45);
            this.Inicio.TabIndex = 1;
            this.Inicio.Text = "Inicio";
            this.Inicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Inicio.UseVisualStyleBackColor = true;
            this.Inicio.Click += new System.EventHandler(this.Inicio_Click);
            // 
            // Logo
            // 
            this.Logo.Controls.Add(this.logo_200);
            this.Logo.Dock = System.Windows.Forms.DockStyle.Top;
            this.Logo.Location = new System.Drawing.Point(0, 0);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(250, 80);
            this.Logo.TabIndex = 0;
            // 
            // logo_200
            // 
            this.logo_200.Image = global::WindowsFormsApplication1.Properties.Resources.logo_good_200;
            this.logo_200.Location = new System.Drawing.Point(12, 0);
            this.logo_200.Name = "logo_200";
            this.logo_200.Size = new System.Drawing.Size(232, 82);
            this.logo_200.TabIndex = 0;
            this.logo_200.TabStop = false;
            // 
            // panelchildForm
            // 
            this.panelchildForm.Controls.Add(this.player_5);
            this.panelchildForm.Controls.Add(this.player_3);
            this.panelchildForm.Controls.Add(this.player_4);
            this.panelchildForm.Controls.Add(this.player_2);
            this.panelchildForm.Controls.Add(this.player_1);
            this.panelchildForm.Controls.Add(this.pictureBox1);
            this.panelchildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelchildForm.Location = new System.Drawing.Point(250, 0);
            this.panelchildForm.Name = "panelchildForm";
            this.panelchildForm.Size = new System.Drawing.Size(984, 711);
            this.panelchildForm.TabIndex = 1;
            // 
            // player_5
            // 
            this.player_5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.player_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.player_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player_5.ForeColor = System.Drawing.Color.White;
            this.player_5.Location = new System.Drawing.Point(815, 158);
            this.player_5.Name = "player_5";
            this.player_5.Size = new System.Drawing.Size(134, 96);
            this.player_5.TabIndex = 9;
            this.player_5.Text = "";
            // 
            // player_3
            // 
            this.player_3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.player_3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.player_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player_3.ForeColor = System.Drawing.Color.White;
            this.player_3.Location = new System.Drawing.Point(427, 486);
            this.player_3.Name = "player_3";
            this.player_3.Size = new System.Drawing.Size(137, 72);
            this.player_3.TabIndex = 8;
            this.player_3.Text = "";
            // 
            // player_4
            // 
            this.player_4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.player_4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.player_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player_4.ForeColor = System.Drawing.Color.White;
            this.player_4.Location = new System.Drawing.Point(815, 456);
            this.player_4.Name = "player_4";
            this.player_4.Size = new System.Drawing.Size(134, 96);
            this.player_4.TabIndex = 7;
            this.player_4.Text = "";
            // 
            // player_2
            // 
            this.player_2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.player_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.player_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player_2.ForeColor = System.Drawing.Color.White;
            this.player_2.Location = new System.Drawing.Point(54, 462);
            this.player_2.Name = "player_2";
            this.player_2.Size = new System.Drawing.Size(158, 96);
            this.player_2.TabIndex = 6;
            this.player_2.Text = "";
            // 
            // player_1
            // 
            this.player_1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.player_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.player_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player_1.ForeColor = System.Drawing.Color.White;
            this.player_1.Location = new System.Drawing.Point(54, 149);
            this.player_1.Name = "player_1";
            this.player_1.Size = new System.Drawing.Size(158, 96);
            this.player_1.TabIndex = 5;
            this.player_1.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::WindowsFormsApplication1.Properties.Resources.Capturamesa_2;
            this.pictureBox1.Location = new System.Drawing.Point(133, 230);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(758, 238);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 666);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(250, 45);
            this.button1.TabIndex = 7;
            this.button1.Text = "Añadir a Partida";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main_Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1234, 711);
            this.Controls.Add(this.panelchildForm);
            this.Controls.Add(this.Menu);
            this.MinimumSize = new System.Drawing.Size(1250, 750);
            this.Name = "Main_Display";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_Display_FormClosed);
            this.Load += new System.EventHandler(this.Main_Display_Load);
            this.Menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.partidas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.data_partidas)).EndInit();
            this.Games.ResumeLayout(false);
            this.Logo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo_200)).EndInit();
            this.panelchildForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Menu;
        private System.Windows.Forms.Button Inicio;
        private System.Windows.Forms.Panel Logo;
        private System.Windows.Forms.Panel Games;
        private System.Windows.Forms.Button ruleta;
        private System.Windows.Forms.Button black_jack;
        private System.Windows.Forms.Button poker;
        private System.Windows.Forms.Button Jugar;
        private System.Windows.Forms.Panel panelchildForm;
        private System.Windows.Forms.Panel partidas;
        private System.Windows.Forms.Button partidas_button;
        private System.Windows.Forms.Button profile;
        private System.Windows.Forms.Button user_label;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox player_5;
        private System.Windows.Forms.RichTextBox player_3;
        private System.Windows.Forms.RichTextBox player_4;
        private System.Windows.Forms.RichTextBox player_2;
        private System.Windows.Forms.RichTextBox player_1;
        private System.Windows.Forms.PictureBox logo_200;
        private System.Windows.Forms.DataGridView data_partidas;
        private System.Windows.Forms.Button unir_partida;
        private System.Windows.Forms.Button button1;
    }
}