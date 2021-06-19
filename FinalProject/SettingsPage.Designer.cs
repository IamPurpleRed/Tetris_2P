
namespace FinalProject
{
    partial class SettingsPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsPage));
            this.title = new System.Windows.Forms.Label();
            this.title_deco = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.drop_timer_block = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.drop_timer1 = new System.Windows.Forms.NumericUpDown();
            this.drop_timer2 = new System.Windows.Forms.NumericUpDown();
            this.apply_btn = new System.Windows.Forms.Button();
            this.reset_btn = new System.Windows.Forms.Button();
            this.drop_timer_block.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drop_timer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drop_timer2)).BeginInit();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(31, 20);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(144, 33);
            this.title.TabIndex = 0;
            this.title.Text = "SETTINGS";
            // 
            // title_deco
            // 
            this.title_deco.BackColor = System.Drawing.SystemColors.Highlight;
            this.title_deco.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_deco.Location = new System.Drawing.Point(15, 20);
            this.title_deco.Name = "title_deco";
            this.title_deco.Size = new System.Drawing.Size(10, 33);
            this.title_deco.TabIndex = 1;
            this.title_deco.Text = " ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("華康手札體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Player 1";
            // 
            // drop_timer_block
            // 
            this.drop_timer_block.Controls.Add(this.drop_timer2);
            this.drop_timer_block.Controls.Add(this.drop_timer1);
            this.drop_timer_block.Controls.Add(this.label1);
            this.drop_timer_block.Controls.Add(this.label3);
            this.drop_timer_block.Font = new System.Drawing.Font("華康手札體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drop_timer_block.Location = new System.Drawing.Point(22, 75);
            this.drop_timer_block.Name = "drop_timer_block";
            this.drop_timer_block.Size = new System.Drawing.Size(362, 120);
            this.drop_timer_block.TabIndex = 3;
            this.drop_timer_block.TabStop = false;
            this.drop_timer_block.Text = "方塊落下速度(毫秒)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("華康手札體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Player 2";
            // 
            // drop_timer1
            // 
            this.drop_timer1.Font = new System.Drawing.Font("華康手札體", 11F);
            this.drop_timer1.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.drop_timer1.InterceptArrowKeys = false;
            this.drop_timer1.Location = new System.Drawing.Point(223, 34);
            this.drop_timer1.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.drop_timer1.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.drop_timer1.Name = "drop_timer1";
            this.drop_timer1.Size = new System.Drawing.Size(120, 29);
            this.drop_timer1.TabIndex = 5;
            this.drop_timer1.TabStop = false;
            this.drop_timer1.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // drop_timer2
            // 
            this.drop_timer2.Font = new System.Drawing.Font("華康手札體", 11F);
            this.drop_timer2.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.drop_timer2.InterceptArrowKeys = false;
            this.drop_timer2.Location = new System.Drawing.Point(223, 70);
            this.drop_timer2.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.drop_timer2.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.drop_timer2.Name = "drop_timer2";
            this.drop_timer2.Size = new System.Drawing.Size(120, 29);
            this.drop_timer2.TabIndex = 6;
            this.drop_timer2.TabStop = false;
            this.drop_timer2.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // apply_btn
            // 
            this.apply_btn.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apply_btn.Location = new System.Drawing.Point(175, 215);
            this.apply_btn.Name = "apply_btn";
            this.apply_btn.Size = new System.Drawing.Size(85, 31);
            this.apply_btn.TabIndex = 4;
            this.apply_btn.Text = "APPLY";
            this.apply_btn.UseVisualStyleBackColor = true;
            this.apply_btn.Click += new System.EventHandler(this.apply_btn_Click);
            // 
            // reset_btn
            // 
            this.reset_btn.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset_btn.Location = new System.Drawing.Point(280, 215);
            this.reset_btn.Name = "reset_btn";
            this.reset_btn.Size = new System.Drawing.Size(85, 31);
            this.reset_btn.TabIndex = 5;
            this.reset_btn.Text = "RESET";
            this.reset_btn.UseVisualStyleBackColor = true;
            this.reset_btn.Click += new System.EventHandler(this.reset_btn_Click);
            // 
            // SettingsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 275);
            this.Controls.Add(this.reset_btn);
            this.Controls.Add(this.apply_btn);
            this.Controls.Add(this.drop_timer_block);
            this.Controls.Add(this.title_deco);
            this.Controls.Add(this.title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsPage";
            this.Opacity = 0.97D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.drop_timer_block.ResumeLayout(false);
            this.drop_timer_block.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drop_timer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drop_timer2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label title_deco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox drop_timer_block;
        private System.Windows.Forms.NumericUpDown drop_timer2;
        private System.Windows.Forms.NumericUpDown drop_timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button apply_btn;
        private System.Windows.Forms.Button reset_btn;
    }
}