
namespace FinalProject
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.start_btn = new System.Windows.Forms.Button();
            this.rule_btn = new System.Windows.Forms.Button();
            this.option_btn = new System.Windows.Forms.Button();
            this.exit_btn = new System.Windows.Forms.Button();
            this.countdown_timer = new System.Windows.Forms.Timer(this.components);
            this.countdown_img = new System.Windows.Forms.ImageList(this.components);
            this.result_pictureBox1 = new System.Windows.Forms.PictureBox();
            this.result_pictureBox2 = new System.Windows.Forms.PictureBox();
            this.game_timer = new System.Windows.Forms.Timer(this.components);
            this.p1_timer = new System.Windows.Forms.Timer(this.components);
            this.p2_timer = new System.Windows.Forms.Timer(this.components);
            this.linepop_img = new System.Windows.Forms.ImageList(this.components);
            this.linepop_picturebox2 = new System.Windows.Forms.PictureBox();
            this.linepop_picturebox1 = new System.Windows.Forms.PictureBox();
            this.combo_img = new System.Windows.Forms.ImageList(this.components);
            this.combo_pictureBox1 = new System.Windows.Forms.PictureBox();
            this.combo_pictureBox2 = new System.Windows.Forms.PictureBox();
            this.p1_combo_timer = new System.Windows.Forms.Timer(this.components);
            this.p1_linepop_timer = new System.Windows.Forms.Timer(this.components);
            this.KO_pictureBox1 = new System.Windows.Forms.PictureBox();
            this.KO_pictureBox2 = new System.Windows.Forms.PictureBox();
            this.KO_img = new System.Windows.Forms.ImageList(this.components);
            this.p1_KOtimer = new System.Windows.Forms.Timer(this.components);
            this.p2_KOtimer = new System.Windows.Forms.Timer(this.components);
            this.result_img = new System.Windows.Forms.ImageList(this.components);
            this.countdown_pictureBox1 = new System.Windows.Forms.PictureBox();
            this.countdown_pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timesup_timer = new System.Windows.Forms.Timer(this.components);
            this.ok_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.result_pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.result_pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linepop_picturebox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linepop_picturebox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KO_pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KO_pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countdown_pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countdown_pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // start_btn
            // 
            this.start_btn.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_btn.Location = new System.Drawing.Point(540, 300);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(120, 50);
            this.start_btn.TabIndex = 0;
            this.start_btn.Text = "START !";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // rule_btn
            // 
            this.rule_btn.Location = new System.Drawing.Point(550, 360);
            this.rule_btn.Name = "rule_btn";
            this.rule_btn.Size = new System.Drawing.Size(100, 35);
            this.rule_btn.TabIndex = 1;
            this.rule_btn.Text = "RULES";
            this.rule_btn.UseVisualStyleBackColor = true;
            this.rule_btn.Click += new System.EventHandler(this.rule_btn_Click);
            // 
            // option_btn
            // 
            this.option_btn.Location = new System.Drawing.Point(550, 405);
            this.option_btn.Name = "option_btn";
            this.option_btn.Size = new System.Drawing.Size(100, 35);
            this.option_btn.TabIndex = 2;
            this.option_btn.Text = "OPTION";
            this.option_btn.UseVisualStyleBackColor = true;
            this.option_btn.Click += new System.EventHandler(this.option_btn_Click);
            // 
            // exit_btn
            // 
            this.exit_btn.Location = new System.Drawing.Point(550, 450);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(100, 35);
            this.exit_btn.TabIndex = 3;
            this.exit_btn.Text = "EXIT";
            this.exit_btn.UseVisualStyleBackColor = true;
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            // 
            // countdown_timer
            // 
            this.countdown_timer.Interval = 1000;
            this.countdown_timer.Tick += new System.EventHandler(this.countdown_timer_Tick);
            // 
            // countdown_img
            // 
            this.countdown_img.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("countdown_img.ImageStream")));
            this.countdown_img.TransparentColor = System.Drawing.Color.Transparent;
            this.countdown_img.Images.SetKeyName(0, "countdown3.jpg");
            this.countdown_img.Images.SetKeyName(1, "countdown2.jpg");
            this.countdown_img.Images.SetKeyName(2, "countdown1.jpg");
            this.countdown_img.Images.SetKeyName(3, "countdown0.jpg");
            this.countdown_img.Images.SetKeyName(4, "ko.jpg");
            // 
            // result_pictureBox1
            // 
            this.result_pictureBox1.BackColor = System.Drawing.Color.Black;
            this.result_pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.result_pictureBox1.Location = new System.Drawing.Point(150, 200);
            this.result_pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.result_pictureBox1.Name = "result_pictureBox1";
            this.result_pictureBox1.Size = new System.Drawing.Size(200, 100);
            this.result_pictureBox1.TabIndex = 4;
            this.result_pictureBox1.TabStop = false;
            // 
            // result_pictureBox2
            // 
            this.result_pictureBox2.BackColor = System.Drawing.Color.Black;
            this.result_pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.result_pictureBox2.Location = new System.Drawing.Point(850, 200);
            this.result_pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.result_pictureBox2.Name = "result_pictureBox2";
            this.result_pictureBox2.Size = new System.Drawing.Size(200, 100);
            this.result_pictureBox2.TabIndex = 5;
            this.result_pictureBox2.TabStop = false;
            // 
            // game_timer
            // 
            this.game_timer.Interval = 1000;
            this.game_timer.Tick += new System.EventHandler(this.game_timer_Tick);
            // 
            // p1_timer
            // 
            this.p1_timer.Tick += new System.EventHandler(this.p1_timer_Tick);
            // 
            // linepop_img
            // 
            this.linepop_img.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("linepop_img.ImageStream")));
            this.linepop_img.TransparentColor = System.Drawing.Color.Transparent;
            this.linepop_img.Images.SetKeyName(0, "single.png");
            this.linepop_img.Images.SetKeyName(1, "double.png");
            this.linepop_img.Images.SetKeyName(2, "triple.png");
            this.linepop_img.Images.SetKeyName(3, "tetris.png");
            // 
            // linepop_picturebox2
            // 
            this.linepop_picturebox2.BackColor = System.Drawing.Color.Transparent;
            this.linepop_picturebox2.Location = new System.Drawing.Point(1100, 550);
            this.linepop_picturebox2.Name = "linepop_picturebox2";
            this.linepop_picturebox2.Size = new System.Drawing.Size(100, 50);
            this.linepop_picturebox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.linepop_picturebox2.TabIndex = 6;
            this.linepop_picturebox2.TabStop = false;
            // 
            // linepop_picturebox1
            // 
            this.linepop_picturebox1.Location = new System.Drawing.Point(400, 550);
            this.linepop_picturebox1.Name = "linepop_picturebox1";
            this.linepop_picturebox1.Size = new System.Drawing.Size(100, 50);
            this.linepop_picturebox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.linepop_picturebox1.TabIndex = 7;
            this.linepop_picturebox1.TabStop = false;
            // 
            // combo_img
            // 
            this.combo_img.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("combo_img.ImageStream")));
            this.combo_img.TransparentColor = System.Drawing.Color.Transparent;
            this.combo_img.Images.SetKeyName(0, "combo.png");
            this.combo_img.Images.SetKeyName(1, "combo1.png");
            this.combo_img.Images.SetKeyName(2, "combo2.png");
            this.combo_img.Images.SetKeyName(3, "combo3.png");
            this.combo_img.Images.SetKeyName(4, "combo4.png");
            this.combo_img.Images.SetKeyName(5, "combo5.png");
            this.combo_img.Images.SetKeyName(6, "combo6.png");
            this.combo_img.Images.SetKeyName(7, "combo7.png");
            this.combo_img.Images.SetKeyName(8, "combo8.png");
            this.combo_img.Images.SetKeyName(9, "combo9.png");
            this.combo_img.Images.SetKeyName(10, "combo10.png");
            this.combo_img.Images.SetKeyName(11, "combo11.png");
            this.combo_img.Images.SetKeyName(12, "combo12.png");
            this.combo_img.Images.SetKeyName(13, "combo13.png");
            this.combo_img.Images.SetKeyName(14, "combo14.png");
            this.combo_img.Images.SetKeyName(15, "combo15.png");
            this.combo_img.Images.SetKeyName(16, "combo16.png");
            this.combo_img.Images.SetKeyName(17, "combo17.png");
            this.combo_img.Images.SetKeyName(18, "combo18.png");
            this.combo_img.Images.SetKeyName(19, "combo19.png");
            this.combo_img.Images.SetKeyName(20, "combo20.png");
            // 
            // combo_pictureBox1
            // 
            this.combo_pictureBox1.Location = new System.Drawing.Point(25, 520);
            this.combo_pictureBox1.Name = "combo_pictureBox1";
            this.combo_pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.combo_pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.combo_pictureBox1.TabIndex = 8;
            this.combo_pictureBox1.TabStop = false;
            // 
            // combo_pictureBox2
            // 
            this.combo_pictureBox2.Location = new System.Drawing.Point(710, 520);
            this.combo_pictureBox2.Name = "combo_pictureBox2";
            this.combo_pictureBox2.Size = new System.Drawing.Size(80, 80);
            this.combo_pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.combo_pictureBox2.TabIndex = 9;
            this.combo_pictureBox2.TabStop = false;
            // 
            // p1_combo_timer
            // 
            this.p1_combo_timer.Interval = 1500;
            this.p1_combo_timer.Tick += new System.EventHandler(this.p1_combo_timer_Tick);
            // 
            // p1_linepop_timer
            // 
            this.p1_linepop_timer.Interval = 1500;
            this.p1_linepop_timer.Tick += new System.EventHandler(this.p1_linepop_timer_Tick);
            // 
            // KO_pictureBox1
            // 
            this.KO_pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.KO_pictureBox1.Location = new System.Drawing.Point(50, 290);
            this.KO_pictureBox1.Name = "KO_pictureBox1";
            this.KO_pictureBox1.Size = new System.Drawing.Size(75, 75);
            this.KO_pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.KO_pictureBox1.TabIndex = 10;
            this.KO_pictureBox1.TabStop = false;
            // 
            // KO_pictureBox2
            // 
            this.KO_pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.KO_pictureBox2.Location = new System.Drawing.Point(750, 290);
            this.KO_pictureBox2.Name = "KO_pictureBox2";
            this.KO_pictureBox2.Size = new System.Drawing.Size(75, 75);
            this.KO_pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.KO_pictureBox2.TabIndex = 11;
            this.KO_pictureBox2.TabStop = false;
            // 
            // KO_img
            // 
            this.KO_img.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("KO_img.ImageStream")));
            this.KO_img.TransparentColor = System.Drawing.Color.Transparent;
            this.KO_img.Images.SetKeyName(0, "ko1.png");
            this.KO_img.Images.SetKeyName(1, "ko2.png");
            this.KO_img.Images.SetKeyName(2, "ko3.png");
            this.KO_img.Images.SetKeyName(3, "ko4.png");
            this.KO_img.Images.SetKeyName(4, "ko5.png");
            // 
            // p1_KOtimer
            // 
            this.p1_KOtimer.Interval = 1000;
            this.p1_KOtimer.Tick += new System.EventHandler(this.p1_KOtimer_Tick);
            // 
            // p2_KOtimer
            // 
            this.p2_KOtimer.Interval = 1000;
            // 
            // result_img
            // 
            this.result_img.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("result_img.ImageStream")));
            this.result_img.TransparentColor = System.Drawing.Color.Transparent;
            this.result_img.Images.SetKeyName(0, "times_up.jpg");
            this.result_img.Images.SetKeyName(1, "win.jpg");
            this.result_img.Images.SetKeyName(2, "lose.jpg");
            this.result_img.Images.SetKeyName(3, "even.jpg");
            // 
            // countdown_pictureBox1
            // 
            this.countdown_pictureBox1.BackColor = System.Drawing.Color.Black;
            this.countdown_pictureBox1.Location = new System.Drawing.Point(200, 200);
            this.countdown_pictureBox1.Name = "countdown_pictureBox1";
            this.countdown_pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.countdown_pictureBox1.TabIndex = 12;
            this.countdown_pictureBox1.TabStop = false;
            // 
            // countdown_pictureBox2
            // 
            this.countdown_pictureBox2.BackColor = System.Drawing.Color.Black;
            this.countdown_pictureBox2.Location = new System.Drawing.Point(900, 200);
            this.countdown_pictureBox2.Name = "countdown_pictureBox2";
            this.countdown_pictureBox2.Size = new System.Drawing.Size(100, 100);
            this.countdown_pictureBox2.TabIndex = 13;
            this.countdown_pictureBox2.TabStop = false;
            // 
            // timesup_timer
            // 
            this.timesup_timer.Interval = 2000;
            this.timesup_timer.Tick += new System.EventHandler(this.timesup_timer_Tick);
            // 
            // ok_btn
            // 
            this.ok_btn.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ok_btn.Location = new System.Drawing.Point(540, 300);
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new System.Drawing.Size(120, 50);
            this.ok_btn.TabIndex = 14;
            this.ok_btn.Text = "OK";
            this.ok_btn.UseVisualStyleBackColor = true;
            this.ok_btn.Click += new System.EventHandler(this.ok_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 661);
            this.Controls.Add(this.ok_btn);
            this.Controls.Add(this.countdown_pictureBox2);
            this.Controls.Add(this.countdown_pictureBox1);
            this.Controls.Add(this.KO_pictureBox2);
            this.Controls.Add(this.KO_pictureBox1);
            this.Controls.Add(this.combo_pictureBox2);
            this.Controls.Add(this.combo_pictureBox1);
            this.Controls.Add(this.linepop_picturebox1);
            this.Controls.Add(this.linepop_picturebox2);
            this.Controls.Add(this.result_pictureBox2);
            this.Controls.Add(this.result_pictureBox1);
            this.Controls.Add(this.exit_btn);
            this.Controls.Add(this.option_btn);
            this.Controls.Add(this.rule_btn);
            this.Controls.Add(this.start_btn);
            this.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tetris 2P";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.result_pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.result_pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linepop_picturebox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linepop_picturebox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.combo_pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KO_pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KO_pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countdown_pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countdown_pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Button rule_btn;
        private System.Windows.Forms.Button option_btn;
        private System.Windows.Forms.Button exit_btn;
        private System.Windows.Forms.Timer countdown_timer;
        private System.Windows.Forms.ImageList countdown_img;
        private System.Windows.Forms.PictureBox result_pictureBox1;
        private System.Windows.Forms.PictureBox result_pictureBox2;
        private System.Windows.Forms.Timer game_timer;
        private System.Windows.Forms.Timer p1_timer;
        private System.Windows.Forms.Timer p2_timer;
        private System.Windows.Forms.ImageList linepop_img;
        private System.Windows.Forms.PictureBox linepop_picturebox2;
        private System.Windows.Forms.PictureBox linepop_picturebox1;
        private System.Windows.Forms.ImageList combo_img;
        private System.Windows.Forms.PictureBox combo_pictureBox1;
        private System.Windows.Forms.PictureBox combo_pictureBox2;
        private System.Windows.Forms.Timer p1_combo_timer;
        private System.Windows.Forms.Timer p1_linepop_timer;
        private System.Windows.Forms.PictureBox KO_pictureBox1;
        private System.Windows.Forms.PictureBox KO_pictureBox2;
        private System.Windows.Forms.ImageList KO_img;
        private System.Windows.Forms.Timer p1_KOtimer;
        private System.Windows.Forms.Timer p2_KOtimer;
        private System.Windows.Forms.ImageList result_img;
        private System.Windows.Forms.PictureBox countdown_pictureBox1;
        private System.Windows.Forms.PictureBox countdown_pictureBox2;
        private System.Windows.Forms.Timer timesup_timer;
        private System.Windows.Forms.Button ok_btn;
    }
}

