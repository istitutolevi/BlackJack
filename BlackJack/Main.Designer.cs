namespace BlackJack
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.signblinker = new System.Windows.Forms.Timer(this.components);
            this.pcplay = new System.Windows.Forms.Timer(this.components);
            this.monoTheme1 = new BlackJack.UI.MonoControls.MonoTheme();
            this.start = new BlackJack.UI.MonoControls.MonoButton();
            this.pbScreen = new System.Windows.Forms.PictureBox();
            this.monoControlBox1 = new BlackJack.UI.MonoControls.MonoControlBox();
            this.msgbox2 = new System.Windows.Forms.Label();
            this.blackjacksign = new BlackJack.UI.MonoControls.MonoButton();
            this.myscore = new System.Windows.Forms.Label();
            this.holdbtn = new BlackJack.UI.MonoControls.MonoButton();
            this.msgbox1 = new System.Windows.Forms.Label();
            this.pcscore = new System.Windows.Forms.Label();
            this.hitbtn = new BlackJack.UI.MonoControls.MonoButton();
            this.monoTheme1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // signblinker
            // 
            this.signblinker.Interval = 500;
            this.signblinker.Tick += new System.EventHandler(this.signblinker_Tick);
            // 
            // pcplay
            // 
            this.pcplay.Interval = 700;
            this.pcplay.Tick += new System.EventHandler(this.pcpause_Tick);
            // 
            // monoTheme1
            // 
            this.monoTheme1.AcceptButton = null;
            this.monoTheme1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.monoTheme1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(31)))), ((int)(((byte)(40)))));
            this.monoTheme1.BorderRadius = 4;
            this.monoTheme1.CancelButton = null;
            this.monoTheme1.ControlBox = true;
            this.monoTheme1.ControlMode = false;
            this.monoTheme1.Controls.Add(this.start);
            this.monoTheme1.Controls.Add(this.pbScreen);
            this.monoTheme1.Controls.Add(this.monoControlBox1);
            this.monoTheme1.Controls.Add(this.msgbox2);
            this.monoTheme1.Controls.Add(this.blackjacksign);
            this.monoTheme1.Controls.Add(this.myscore);
            this.monoTheme1.Controls.Add(this.holdbtn);
            this.monoTheme1.Controls.Add(this.msgbox1);
            this.monoTheme1.Controls.Add(this.pcscore);
            this.monoTheme1.Controls.Add(this.hitbtn);
            this.monoTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monoTheme1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monoTheme1.ForeColor = System.Drawing.Color.White;
            this.monoTheme1.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(31)))), ((int)(((byte)(40)))));
            this.monoTheme1.HeaderHeight = 36;
            this.monoTheme1.Icon = ((System.Drawing.Icon)(resources.GetObject("monoTheme1.Icon")));
            this.monoTheme1.IsMdiContainer = false;
            this.monoTheme1.KeyPreview = false;
            this.monoTheme1.Location = new System.Drawing.Point(0, 0);
            this.monoTheme1.MainMenuStrip = null;
            this.monoTheme1.MinimizeBox = true;
            this.monoTheme1.Name = "monoTheme1";
            this.monoTheme1.Opacity = 1D;
            this.monoTheme1.Padding = new System.Windows.Forms.Padding(10, 40, 10, 9);
            this.monoTheme1.RightToLeftLayout = false;
            this.monoTheme1.RoundCorners = true;
            this.monoTheme1.ShowIcon = true;
            this.monoTheme1.ShowInTaskbar = true;
            this.monoTheme1.Sizable = true;
            this.monoTheme1.Size = new System.Drawing.Size(753, 476);
            this.monoTheme1.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.monoTheme1.SmartBounds = true;
            this.monoTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.monoTheme1.TabIndex = 11;
            this.monoTheme1.Text = "♣BLACKJACK♠";
            this.monoTheme1.TopMost = false;
            this.monoTheme1.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.monoTheme1.WindowState = System.Windows.Forms.FormWindowState.Normal;
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.Color.Transparent;
            this.start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.start.FillColor = System.Drawing.Color.White;
            this.start.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.start.Font = new System.Drawing.Font("News701 BT", 21.75F, System.Drawing.FontStyle.Italic);
            this.start.ForeColor = System.Drawing.Color.Black;
            this.start.Image = null;
            this.start.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.start.ImageSize = new System.Drawing.Size(46, 46);
            this.start.Location = new System.Drawing.Point(619, 380);
            this.start.Margin = new System.Windows.Forms.Padding(0);
            this.start.Name = "start";
            this.start.RoundCorners = true;
            this.start.Size = new System.Drawing.Size(121, 39);
            this.start.TabIndex = 4;
            this.start.Text = "PLAY";
            this.start.TextAlignment = System.Drawing.StringAlignment.Center;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // pbScreen
            // 
            this.pbScreen.Location = new System.Drawing.Point(18, 43);
            this.pbScreen.Name = "pbScreen";
            this.pbScreen.Size = new System.Drawing.Size(722, 325);
            this.pbScreen.TabIndex = 12;
            this.pbScreen.TabStop = false;
            // 
            // monoControlBox1
            // 
            this.monoControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.monoControlBox1.AutoRelocate = false;
            this.monoControlBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.monoControlBox1.BackColor2 = System.Drawing.Color.Gainsboro;
            this.monoControlBox1.EnableHoverHighlight = false;
            this.monoControlBox1.EnableMaximizeButton = true;
            this.monoControlBox1.EnableMinimizeButton = true;
            this.monoControlBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(254)))), ((int)(((byte)(255)))));
            this.monoControlBox1.ForeColor2 = System.Drawing.Color.DimGray;
            this.monoControlBox1.Location = new System.Drawing.Point(653, 0);
            this.monoControlBox1.Name = "monoControlBox1";
            this.monoControlBox1.Size = new System.Drawing.Size(100, 25);
            this.monoControlBox1.TabIndex = 11;
            this.monoControlBox1.Text = "monoControlBox1";
            // 
            // msgbox2
            // 
            this.msgbox2.AutoSize = true;
            this.msgbox2.BackColor = System.Drawing.Color.Transparent;
            this.msgbox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.msgbox2.ForeColor = System.Drawing.Color.White;
            this.msgbox2.Location = new System.Drawing.Point(189, 419);
            this.msgbox2.Name = "msgbox2";
            this.msgbox2.Size = new System.Drawing.Size(0, 15);
            this.msgbox2.TabIndex = 8;
            // 
            // blackjacksign
            // 
            this.blackjacksign.BackColor = System.Drawing.Color.Transparent;
            this.blackjacksign.Cursor = System.Windows.Forms.Cursors.Hand;
            this.blackjacksign.FillColor = System.Drawing.Color.White;
            this.blackjacksign.FillColor2 = System.Drawing.Color.White;
            this.blackjacksign.Font = new System.Drawing.Font("News701 BT", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.blackjacksign.ForeColor = System.Drawing.Color.Black;
            this.blackjacksign.Image = null;
            this.blackjacksign.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.blackjacksign.ImageSize = new System.Drawing.Size(46, 46);
            this.blackjacksign.Location = new System.Drawing.Point(397, 422);
            this.blackjacksign.Name = "blackjacksign";
            this.blackjacksign.RoundCorners = true;
            this.blackjacksign.Size = new System.Drawing.Size(344, 45);
            this.blackjacksign.TabIndex = 3;
            this.blackjacksign.Text = "♣BLACKJACK♠";
            this.blackjacksign.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // myscore
            // 
            this.myscore.AutoSize = true;
            this.myscore.BackColor = System.Drawing.Color.Transparent;
            this.myscore.Font = new System.Drawing.Font("Miramonte", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myscore.ForeColor = System.Drawing.Color.White;
            this.myscore.Location = new System.Drawing.Point(71, 371);
            this.myscore.Name = "myscore";
            this.myscore.Size = new System.Drawing.Size(38, 14);
            this.myscore.TabIndex = 6;
            this.myscore.Text = "ME(0)";
            this.myscore.Visible = false;
            // 
            // holdbtn
            // 
            this.holdbtn.BackColor = System.Drawing.Color.Transparent;
            this.holdbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.holdbtn.FillColor = System.Drawing.Color.White;
            this.holdbtn.FillColor2 = System.Drawing.Color.Silver;
            this.holdbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.holdbtn.ForeColor = System.Drawing.Color.Black;
            this.holdbtn.Image = null;
            this.holdbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.holdbtn.ImageSize = new System.Drawing.Size(46, 46);
            this.holdbtn.Location = new System.Drawing.Point(108, 419);
            this.holdbtn.Name = "holdbtn";
            this.holdbtn.RoundCorners = true;
            this.holdbtn.Size = new System.Drawing.Size(73, 34);
            this.holdbtn.TabIndex = 2;
            this.holdbtn.Text = "Hold";
            this.holdbtn.TextAlignment = System.Drawing.StringAlignment.Center;
            this.holdbtn.Visible = false;
            this.holdbtn.Click += new System.EventHandler(this.move_Click);
            // 
            // msgbox1
            // 
            this.msgbox1.AutoSize = true;
            this.msgbox1.BackColor = System.Drawing.Color.Transparent;
            this.msgbox1.Font = new System.Drawing.Font("Miramonte", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msgbox1.ForeColor = System.Drawing.Color.White;
            this.msgbox1.Location = new System.Drawing.Point(185, 380);
            this.msgbox1.Name = "msgbox1";
            this.msgbox1.Size = new System.Drawing.Size(65, 29);
            this.msgbox1.TabIndex = 10;
            this.msgbox1.Text = "MSG";
            this.msgbox1.Visible = false;
            // 
            // pcscore
            // 
            this.pcscore.AutoSize = true;
            this.pcscore.BackColor = System.Drawing.Color.Transparent;
            this.pcscore.Font = new System.Drawing.Font("Miramonte", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pcscore.ForeColor = System.Drawing.Color.White;
            this.pcscore.Location = new System.Drawing.Point(15, 371);
            this.pcscore.Name = "pcscore";
            this.pcscore.Size = new System.Drawing.Size(36, 14);
            this.pcscore.TabIndex = 5;
            this.pcscore.Text = "PC(0)";
            this.pcscore.Visible = false;
            // 
            // hitbtn
            // 
            this.hitbtn.BackColor = System.Drawing.Color.Transparent;
            this.hitbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.hitbtn.FillColor = System.Drawing.Color.White;
            this.hitbtn.FillColor2 = System.Drawing.Color.Silver;
            this.hitbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.hitbtn.ForeColor = System.Drawing.Color.Black;
            this.hitbtn.Image = null;
            this.hitbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hitbtn.ImageSize = new System.Drawing.Size(46, 46);
            this.hitbtn.Location = new System.Drawing.Point(18, 419);
            this.hitbtn.Name = "hitbtn";
            this.hitbtn.RoundCorners = true;
            this.hitbtn.Size = new System.Drawing.Size(73, 34);
            this.hitbtn.TabIndex = 0;
            this.hitbtn.Text = "Hit";
            this.hitbtn.TextAlignment = System.Drawing.StringAlignment.Center;
            this.hitbtn.Visible = false;
            this.hitbtn.Click += new System.EventHandler(this.move_Click);
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(753, 476);
            this.Controls.Add(this.monoTheme1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "♣BLACKJACK♠";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.monoTheme1.ResumeLayout(false);
            this.monoTheme1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UI.MonoControls.MonoButton hitbtn;
        private UI.MonoControls.MonoButton holdbtn;
        private UI.MonoControls.MonoButton blackjacksign;
        private UI.MonoControls.MonoButton start;
        private System.Windows.Forms.Label pcscore;
        private System.Windows.Forms.Label myscore;
        private System.Windows.Forms.Timer signblinker;
        private System.Windows.Forms.Label msgbox2;
        private System.Windows.Forms.Timer pcplay;
        private System.Windows.Forms.Label msgbox1;
        private UI.MonoControls.MonoTheme monoTheme1;
        private UI.MonoControls.MonoControlBox monoControlBox1;
        private System.Windows.Forms.PictureBox pbScreen;
    }
}

