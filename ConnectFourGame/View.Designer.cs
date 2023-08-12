namespace Client
{
    partial class View
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.gameBoardControl1 = new Client.GameBoardControl();
            this.NewGame = new System.Windows.Forms.Button();
            this.LoadGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.Coral;
            this.pnlButtons.Location = new System.Drawing.Point(149, 22);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(470, 35);
            this.pnlButtons.TabIndex = 1;
            this.pnlButtons.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlButtons_Paint);
            // 
            // gameBoardControl1
            // 
            this.gameBoardControl1.AutoSize = true;
            this.gameBoardControl1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gameBoardControl1.gameEnded = false;
            this.gameBoardControl1.isAnimating = false;
            this.gameBoardControl1.Location = new System.Drawing.Point(82, 53);
            this.gameBoardControl1.Name = "gameBoardControl1";
            this.gameBoardControl1.Size = new System.Drawing.Size(609, 432);
            this.gameBoardControl1.TabIndex = 0;
            this.gameBoardControl1.Load += new System.EventHandler(this.gameBoardControl1_Load);
            // 
            // NewGame
            // 
            this.NewGame.BackColor = System.Drawing.Color.DarkKhaki;
            this.NewGame.Location = new System.Drawing.Point(12, 135);
            this.NewGame.Name = "NewGame";
            this.NewGame.Size = new System.Drawing.Size(117, 60);
            this.NewGame.TabIndex = 2;
            this.NewGame.Text = "New Game";
            this.NewGame.UseVisualStyleBackColor = false;
            this.NewGame.Click += new System.EventHandler(this.NewGame_Click);
            // 
            // LoadGame
            // 
            this.LoadGame.BackColor = System.Drawing.Color.DarkKhaki;
            this.LoadGame.Location = new System.Drawing.Point(651, 135);
            this.LoadGame.Name = "LoadGame";
            this.LoadGame.Size = new System.Drawing.Size(117, 60);
            this.LoadGame.TabIndex = 3;
            this.LoadGame.Text = "Load Game";
            this.LoadGame.UseVisualStyleBackColor = false;
            this.LoadGame.Click += new System.EventHandler(this.LoadGame_Click);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Coral;
            this.ClientSize = new System.Drawing.Size(813, 487);
            this.Controls.Add(this.LoadGame);
            this.Controls.Add(this.NewGame);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.gameBoardControl1);
            this.Name = "View";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.View_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GameBoardControl gameBoardControl1;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button NewGame;
        private System.Windows.Forms.Button LoadGame;
    }
}

