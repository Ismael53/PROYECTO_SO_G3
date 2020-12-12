namespace WindowsFormsApplication1
{
    partial class Poker
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
            this.label1 = new System.Windows.Forms.Label();
            this.hide_chat = new System.Windows.Forms.Button();
            this.main_chat = new System.Windows.Forms.RichTextBox();
            this.enviar_chat = new System.Windows.Forms.Button();
            this.chat_text = new System.Windows.Forms.TextBox();
            this.chat_background = new System.Windows.Forms.Panel();
            this.chat_background.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(923, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // hide_chat
            // 
            this.hide_chat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hide_chat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hide_chat.ForeColor = System.Drawing.Color.White;
            this.hide_chat.Location = new System.Drawing.Point(897, 3);
            this.hide_chat.Name = "hide_chat";
            this.hide_chat.Size = new System.Drawing.Size(75, 39);
            this.hide_chat.TabIndex = 4;
            this.hide_chat.Text = "Ocultar Chat";
            this.hide_chat.UseVisualStyleBackColor = true;
            this.hide_chat.Visible = false;
            // 
            // main_chat
            // 
            this.main_chat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.main_chat.BackColor = System.Drawing.SystemColors.Desktop;
            this.main_chat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.main_chat.Location = new System.Drawing.Point(9, 3);
            this.main_chat.Name = "main_chat";
            this.main_chat.ReadOnly = true;
            this.main_chat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.main_chat.Size = new System.Drawing.Size(436, 96);
            this.main_chat.TabIndex = 3;
            this.main_chat.Text = "";
            // 
            // enviar_chat
            // 
            this.enviar_chat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.enviar_chat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enviar_chat.ForeColor = System.Drawing.Color.White;
            this.enviar_chat.Location = new System.Drawing.Point(897, 115);
            this.enviar_chat.Name = "enviar_chat";
            this.enviar_chat.Size = new System.Drawing.Size(75, 23);
            this.enviar_chat.TabIndex = 1;
            this.enviar_chat.Text = "Enviar";
            this.enviar_chat.UseVisualStyleBackColor = true;
            this.enviar_chat.Click += new System.EventHandler(this.enviar_chat_Click);
            // 
            // chat_text
            // 
            this.chat_text.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chat_text.Location = new System.Drawing.Point(9, 118);
            this.chat_text.Name = "chat_text";
            this.chat_text.Size = new System.Drawing.Size(882, 20);
            this.chat_text.TabIndex = 0;
            this.chat_text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chat_text_KeyDown_1);
            // 
            // chat_background
            // 
            this.chat_background.Controls.Add(this.hide_chat);
            this.chat_background.Controls.Add(this.main_chat);
            this.chat_background.Controls.Add(this.enviar_chat);
            this.chat_background.Controls.Add(this.chat_text);
            this.chat_background.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chat_background.Location = new System.Drawing.Point(0, 561);
            this.chat_background.Name = "chat_background";
            this.chat_background.Size = new System.Drawing.Size(984, 150);
            this.chat_background.TabIndex = 4;
            // 
            // Poker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 711);
            this.Controls.Add(this.chat_background);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(984, 561);
            this.Name = "Poker";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.poker_Load);
            this.chat_background.ResumeLayout(false);
            this.chat_background.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button hide_chat;
        private System.Windows.Forms.RichTextBox main_chat;
        private System.Windows.Forms.Button enviar_chat;
        private System.Windows.Forms.TextBox chat_text;
        private System.Windows.Forms.Panel chat_background;

    }
}