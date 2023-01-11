namespace ChineseCheckers
{
    partial class MenuForm
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
            this.buttonOnePlayer = new System.Windows.Forms.Button();
            this.buttonTwoPlayers = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonOnePlayer
            // 
            this.buttonOnePlayer.Location = new System.Drawing.Point(127, 33);
            this.buttonOnePlayer.Name = "buttonOnePlayer";
            this.buttonOnePlayer.Size = new System.Drawing.Size(75, 23);
            this.buttonOnePlayer.TabIndex = 0;
            this.buttonOnePlayer.Text = "OnePlayer";
            this.buttonOnePlayer.UseVisualStyleBackColor = true;
            this.buttonOnePlayer.Click += new System.EventHandler(this.buttonOnePlayer_Click);
            // 
            // buttonTwoPlayers
            // 
            this.buttonTwoPlayers.Location = new System.Drawing.Point(127, 76);
            this.buttonTwoPlayers.Name = "buttonTwoPlayers";
            this.buttonTwoPlayers.Size = new System.Drawing.Size(75, 23);
            this.buttonTwoPlayers.TabIndex = 1;
            this.buttonTwoPlayers.Text = "Two Players";
            this.buttonTwoPlayers.UseVisualStyleBackColor = true;
            this.buttonTwoPlayers.Click += new System.EventHandler(this.buttonTwoPlayers_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(127, 122);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 231);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonTwoPlayers);
            this.Controls.Add(this.buttonOnePlayer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOnePlayer;
        private System.Windows.Forms.Button buttonTwoPlayers;
        private System.Windows.Forms.Button buttonExit;
    }
}