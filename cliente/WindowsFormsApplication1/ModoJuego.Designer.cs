namespace WindowsFormsApplication1
{
    partial class ModoJuego
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
            this.Online_rb = new System.Windows.Forms.RadioButton();
            this.Individual_rb = new System.Windows.Forms.RadioButton();
            this.Poker = new System.Windows.Forms.Button();
            this.Ruleta = new System.Windows.Forms.Button();
            this.Black_Jack = new System.Windows.Forms.Button();
            this.User_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Online_rb
            // 
            this.Online_rb.AutoSize = true;
            this.Online_rb.Location = new System.Drawing.Point(87, 157);
            this.Online_rb.Name = "Online_rb";
            this.Online_rb.Size = new System.Drawing.Size(55, 17);
            this.Online_rb.TabIndex = 2;
            this.Online_rb.TabStop = true;
            this.Online_rb.Text = "Online";
            this.Online_rb.UseVisualStyleBackColor = true;
            // 
            // Individual_rb
            // 
            this.Individual_rb.AutoSize = true;
            this.Individual_rb.Location = new System.Drawing.Point(198, 157);
            this.Individual_rb.Name = "Individual_rb";
            this.Individual_rb.Size = new System.Drawing.Size(70, 17);
            this.Individual_rb.TabIndex = 3;
            this.Individual_rb.TabStop = true;
            this.Individual_rb.Text = "Individual";
            this.Individual_rb.UseVisualStyleBackColor = true;
            // 
            // Poker
            // 
            this.Poker.Location = new System.Drawing.Point(30, 207);
            this.Poker.Name = "Poker";
            this.Poker.Size = new System.Drawing.Size(75, 23);
            this.Poker.TabIndex = 4;
            this.Poker.Text = "Poker";
            this.Poker.UseVisualStyleBackColor = true;
            this.Poker.Click += new System.EventHandler(this.Poker_Click);
            // 
            // Ruleta
            // 
            this.Ruleta.Location = new System.Drawing.Point(139, 207);
            this.Ruleta.Name = "Ruleta";
            this.Ruleta.Size = new System.Drawing.Size(75, 23);
            this.Ruleta.TabIndex = 5;
            this.Ruleta.Text = "Ruleta";
            this.Ruleta.UseVisualStyleBackColor = true;
            this.Ruleta.Click += new System.EventHandler(this.Ruleta_Click);
            // 
            // Black_Jack
            // 
            this.Black_Jack.Location = new System.Drawing.Point(247, 207);
            this.Black_Jack.Name = "Black_Jack";
            this.Black_Jack.Size = new System.Drawing.Size(75, 23);
            this.Black_Jack.TabIndex = 6;
            this.Black_Jack.Text = "Black Jack";
            this.Black_Jack.UseVisualStyleBackColor = true;
            this.Black_Jack.Click += new System.EventHandler(this.Black_Jack_Click);
            // 
            // User_label
            // 
            this.User_label.AutoSize = true;
            this.User_label.Location = new System.Drawing.Point(27, 25);
            this.User_label.Name = "User_label";
            this.User_label.Size = new System.Drawing.Size(0, 13);
            this.User_label.TabIndex = 7;
            // 
            // ModoJuego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 320);
            this.Controls.Add(this.User_label);
            this.Controls.Add(this.Black_Jack);
            this.Controls.Add(this.Ruleta);
            this.Controls.Add(this.Poker);
            this.Controls.Add(this.Individual_rb);
            this.Controls.Add(this.Online_rb);
            this.Name = "ModoJuego";
            this.Text = "ModoJuego";
            this.Load += new System.EventHandler(this.ModoJuego_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton Online_rb;
        private System.Windows.Forms.RadioButton Individual_rb;
        private System.Windows.Forms.Button Poker;
        private System.Windows.Forms.Button Ruleta;
        private System.Windows.Forms.Button Black_Jack;
        private System.Windows.Forms.Label User_label;

    }
}