namespace Client
{
    partial class LoadGames
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
            this.listBoxGames = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.gameBoardControl = new Client.GameBoardControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose Game";
            // 
            // listBoxGames
            // 
            this.listBoxGames.FormattingEnabled = true;
            this.listBoxGames.Location = new System.Drawing.Point(1, 25);
            this.listBoxGames.Name = "listBoxGames";
            this.listBoxGames.Size = new System.Drawing.Size(283, 95);
            this.listBoxGames.TabIndex = 1;
            this.listBoxGames.SelectedIndexChanged += new System.EventHandler(this.listBoxGames_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(100, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gameBoardControl
            // 
            this.gameBoardControl.Location = new System.Drawing.Point(135, 60);
            this.gameBoardControl.Name = "gameBoardControl";
            this.gameBoardControl.Size = new System.Drawing.Size(480, 410);
            this.gameBoardControl.TabIndex = 3;
            this.gameBoardControl.Load += new System.EventHandler(this.gameBoardControl_Load);
            // 
            // LoadGames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 167);
            this.Controls.Add(this.gameBoardControl);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBoxGames);
            this.Controls.Add(this.label1);
            this.Name = "LoadGames";
            this.Text = "LoadGames";
            this.Load += new System.EventHandler(this.LoadGames_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxGames;
        private System.Windows.Forms.Button button1;
        private GameBoardControl gameBoardControl;
    }
}