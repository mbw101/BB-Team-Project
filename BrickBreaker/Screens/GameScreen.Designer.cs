namespace BrickBreaker
{
    partial class GameScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.life5Output = new System.Windows.Forms.Label();
            this.spacer = new System.Windows.Forms.Label();
            this.life1Output = new System.Windows.Forms.Label();
            this.life2Output = new System.Windows.Forms.Label();
            this.life3Output = new System.Windows.Forms.Label();
            this.life4Output = new System.Windows.Forms.Label();
            this.levelLabel = new System.Windows.Forms.Label();
            this.highscoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 16;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // life5Output
            // 
            this.life5Output.BackColor = System.Drawing.Color.Transparent;
            this.life5Output.Image = global::BrickBreaker.Properties.Resources.life;
            this.life5Output.Location = new System.Drawing.Point(471, 792);
            this.life5Output.Name = "life5Output";
            this.life5Output.Size = new System.Drawing.Size(33, 33);
            this.life5Output.TabIndex = 0;
            // 
            // spacer
            // 
            this.spacer.BackColor = System.Drawing.Color.White;
            this.spacer.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.spacer.Location = new System.Drawing.Point(1175, 0);
            this.spacer.Name = "spacer";
            this.spacer.Size = new System.Drawing.Size(25, 75);
            this.spacer.TabIndex = 1;
            // 
            // life1Output
            // 
            this.life1Output.BackColor = System.Drawing.Color.Transparent;
            this.life1Output.Image = global::BrickBreaker.Properties.Resources.life;
            this.life1Output.Location = new System.Drawing.Point(692, 792);
            this.life1Output.Name = "life1Output";
            this.life1Output.Size = new System.Drawing.Size(33, 33);
            this.life1Output.TabIndex = 2;
            // 
            // life2Output
            // 
            this.life2Output.BackColor = System.Drawing.Color.Transparent;
            this.life2Output.Image = global::BrickBreaker.Properties.Resources.life;
            this.life2Output.Location = new System.Drawing.Point(637, 792);
            this.life2Output.Name = "life2Output";
            this.life2Output.Size = new System.Drawing.Size(33, 33);
            this.life2Output.TabIndex = 3;
            // 
            // life3Output
            // 
            this.life3Output.BackColor = System.Drawing.Color.Transparent;
            this.life3Output.Image = global::BrickBreaker.Properties.Resources.life;
            this.life3Output.Location = new System.Drawing.Point(584, 792);
            this.life3Output.Name = "life3Output";
            this.life3Output.Size = new System.Drawing.Size(33, 33);
            this.life3Output.TabIndex = 4;
            // 
            // life4Output
            // 
            this.life4Output.BackColor = System.Drawing.Color.Transparent;
            this.life4Output.Image = global::BrickBreaker.Properties.Resources.life;
            this.life4Output.Location = new System.Drawing.Point(527, 792);
            this.life4Output.Name = "life4Output";
            this.life4Output.Size = new System.Drawing.Size(33, 33);
            this.life4Output.TabIndex = 5;
            // 
            // levelLabel
            // 
            this.levelLabel.BackColor = System.Drawing.Color.Transparent;
            this.levelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.levelLabel.Location = new System.Drawing.Point(1030, 787);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(170, 59);
            this.levelLabel.TabIndex = 6;
            this.levelLabel.Text = "LVL: " + (currentlevelnum + 1);
            // 
            // highscoreLabel
            // 
            this.highscoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.highscoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highscoreLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.highscoreLabel.Location = new System.Drawing.Point(369, 8);
            this.highscoreLabel.Name = "highscoreLabel";
            this.highscoreLabel.Size = new System.Drawing.Size(518, 67);
            this.highscoreLabel.TabIndex = 7;
            this.highscoreLabel.Text = "HIGHSCORE: 00000";
            // 
            // GameScreen
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.highscoreLabel);
            this.Controls.Add(this.levelLabel);
            this.Controls.Add(this.life4Output);
            this.Controls.Add(this.life3Output);
            this.Controls.Add(this.life2Output);
            this.Controls.Add(this.life1Output);
            this.Controls.Add(this.spacer);
            this.Controls.Add(this.life5Output);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(2533, 1565);
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(1200, 900);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.GameScreen_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label life5Output;
        private System.Windows.Forms.Label spacer;
        private System.Windows.Forms.Label life1Output;
        private System.Windows.Forms.Label life2Output;
        private System.Windows.Forms.Label life3Output;
        private System.Windows.Forms.Label life4Output;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.Label highscoreLabel;
    }
}
