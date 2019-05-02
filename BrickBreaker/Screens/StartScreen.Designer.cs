namespace BrickBreaker
{
    partial class StartScreen
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
            this.anyButtonPB = new System.Windows.Forms.PictureBox();
            this.startScreenPB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.anyButtonPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startScreenPB)).BeginInit();
            this.SuspendLayout();
            // 
            // anyButtonPB
            // 
            this.anyButtonPB.Location = new System.Drawing.Point(290, 685);
            this.anyButtonPB.Name = "anyButtonPB";
            this.anyButtonPB.Size = new System.Drawing.Size(600, 70);
            this.anyButtonPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.anyButtonPB.TabIndex = 1;
            this.anyButtonPB.TabStop = false;
            // 
            // startScreenPB
            // 
            this.startScreenPB.Image = global::BrickBreaker.Properties.Resources.startScreenBG;
            this.startScreenPB.Location = new System.Drawing.Point(-3, -3);
            this.startScreenPB.Name = "startScreenPB";
            this.startScreenPB.Size = new System.Drawing.Size(1200, 800);
            this.startScreenPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.startScreenPB.TabIndex = 0;
            this.startScreenPB.TabStop = false;
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.anyButtonPB);
            this.Controls.Add(this.startScreenPB);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "StartScreen";
            this.Size = new System.Drawing.Size(1200, 800);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StartScreen_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.anyButtonPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startScreenPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox startScreenPB;
        private System.Windows.Forms.PictureBox anyButtonPB;
    }
}
