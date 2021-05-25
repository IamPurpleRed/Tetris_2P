﻿using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Form1 : Form
    {
        SoundPlayer player = new SoundPlayer();  // 音樂播放器

        /* 建立兩個玩家(Player類別的實例) */
        Player p1 = new Player(125, 100);
        Player p2 = new Player(825, 100);

        /* time_left區塊 */
        Label time_title = new Label();
        ProgressBar time_bar = new ProgressBar();
        Label time_left = new Label();
        int min = 2, sec = 0;  // 剩餘時間(數字型態)

        public Form1()
        {
            InitializeComponent();

            /* 印出grids */
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Controls.Add(p1.grids[i, j]);
                    Controls.Add(p2.grids[i, j]);
                }
            }

            /* 印出next */
            Controls.Add(p1.next_title);
            Controls.Add(p2.next_title);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Controls.Add(p1.next[i, j]);
                    Controls.Add(p2.next[i, j]);
                }
            }

            /* 印出hold */
            Controls.Add(p1.hold_title);
            Controls.Add(p2.hold_title);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Controls.Add(p1.hold[i, j]);
                    Controls.Add(p2.hold[i, j]);
                }
            }

            /* 印出bar */
            Controls.Add(p1.bar);
            Controls.Add(p2.bar);

            /* 印出分數 */
            Controls.Add(p1.score_title);
            Controls.Add(p1.score_text);
            Controls.Add(p2.score_title);
            Controls.Add(p2.score_text);

            /* countdown相關設定 */
            countdown_pictureBox1.Visible = false;
            countdown_pictureBox2.Visible = false;

            /* time_left區塊相關設定 */
            time_title.Text = "TIME";
            time_title.TextAlign = ContentAlignment.MiddleCenter;
            time_title.Width = 80;
            time_title.Height = 30;
            time_title.Left = 560;
            time_title.Top = 0;
            time_title.Visible = true;
            Controls.Add(time_title);
            time_bar.Minimum = 0;
            time_bar.Maximum = 120;
            time_bar.Width = 200;
            time_bar.Height = 5;
            time_bar.Left = 500;
            time_bar.Top =30;
            time_bar.Visible = true;
            Controls.Add(time_bar);
            time_left.Text = "02 : 00";
            time_left.Font = new Font("Goudy Stout", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            time_left.TextAlign = ContentAlignment.MiddleCenter;
            time_left.Width = 200;
            time_left.Height = 50;
            time_left.Left = 500;
            time_left.Top = 35;
            time_left.Visible = true;
            Controls.Add(time_left);

            initPage();
        }

        /* 每次回到主畫面(按鈕出現)時都要做的事情 */
        void initPage()
        {
            /* 四個按鈕 */
            start_btn.BackColor = Color.Lime;
            start_btn.ForeColor = Color.White;
            exit_btn.BackColor = Color.Red;
            exit_btn.ForeColor = Color.White;
            start_btn.Visible = true;
            rule_btn.Visible = true;
            option_btn.Visible = true;
            exit_btn.Visible = true;

            /* 剩餘時間初始 */
            min = 2;
            sec = 0;
            time_left.Text = "02 : 00";
            time_bar.Value = 120;

            /* 兩個玩家的方塊掉落速度初始 */
            p1_timer.Interval = p1.drop_timer;
            p2_timer.Interval = p2.drop_timer;
        }

        /* 四個按鈕的function */
        private void start_btn_Click(object sender, EventArgs e)
        {
            player.SoundLocation = "src/button.wav";
            player.Play();
            start_btn.Visible = false;
            rule_btn.Visible = false;
            option_btn.Visible = false;
            exit_btn.Visible = false;
            countdownFunc();
            Focus();
        }

        private void rule_btn_Click(object sender, EventArgs e)
        {
            player.SoundLocation = "src/button.wav";
            player.Play();
        }

        private void option_btn_Click(object sender, EventArgs e)
        {
            player.SoundLocation = "src/button.wav";
            player.Play();
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            player.SoundLocation = "src/button.wav";
            player.Play();
            Close();
        }

        /* 有關倒數相關的變數和function */
        int coundown_tick = 0;
        void countdownFunc()
        {
            countdown_timer.Enabled = true;
        }

        private void countdown_timer_Tick(object sender, EventArgs e)
        {
            if (coundown_tick == 0)
            {
                player.SoundLocation = "src/countdown.wav";
                player.Play();
                countdown_pictureBox1.Visible = true;
                countdown_pictureBox2.Visible = true;
            }
            if (coundown_tick <= 3)
            {
                countdown_pictureBox1.Image = coundown_img.Images[coundown_tick];
                countdown_pictureBox2.Image = coundown_img.Images[coundown_tick];
            }
            else
            {
                countdown_timer.Stop();
                coundown_tick = 0;
                countdown_pictureBox1.Visible = false;
                countdown_pictureBox2.Visible = false;
                gamePlaying();
            }
            coundown_tick++;
        }


        /* 遊戲進行中function */
        void gamePlaying()
        {
            /* 生成第一個掉落的方塊類型和位置 */
            p1.block_type = (p1.rd.Next(0, 7) + 1) * 10 + 1;
            p2.block_type = (p2.rd.Next(0, 7) + 1) * 10 + 1;
            p1.block_row = Player.init_block_row;
            p1.block_col = Player.init_block_col;
            p2.block_row = Player.init_block_row;
            p2.block_col = Player.init_block_col;

            /* 生成第一個掉落的方塊預測降落位置 */
            p1.predict_block_row = p1.block_row;
            p1.predict_block_col = p1.block_col;
            p1.predictBlock(p1.block_row, p1.block_col, p1.block_type);
            p1.showGrids();
            // TODO: p2

            /* 生成下一個掉落的方塊類型 */
            p1.next_block_type = (p1.rd.Next(0, 7) + 1) * 10 + 1;
            p2.next_block_type = (p1.rd.Next(0, 7) + 1) * 10 + 1;
            p1.updateNext(p1.next_block_type);
            // TODO: p2.updateNext(p2.next_block_type);

            /* 開啟兩個玩家的timer */
            p1_timer.Start();
            p2_timer.Start();

            player.SoundLocation = "src/Tetris Battle Music.wav";
            player.Play();
            game_timer.Enabled = true;
        }


        private void game_timer_Tick(object sender, EventArgs e)
        {
            time_left.Text = (Convert.ToString(min)).PadLeft(2, '0') + " : " + (Convert.ToString(sec)).PadLeft(2, '0');
            if (min == 0 && sec == 0)
            {
                time_bar.Value = 0;
                game_timer.Stop();
                // TODO: 遊戲結束function
            }
            else if (sec == 0)
            {
                min--;
                sec = 59;
            }
            else
            {
                sec--;
                time_bar.Value--;
            }
        }

        private void p1_timer_Tick(object sender, EventArgs e)
        {
            if (p1.directionY(p1.block_row, p1.block_col, p1.block_type))
            {
                p1.eraseBlock(p1.block_row, p1.block_col, p1.block_type);
                p1.block_row++;
                p1.updateBlock(p1.block_row, p1.block_col, p1.block_type);
                p1.showGrids();
            }
            else p1BlockSet();
        }

        // p1目前方塊已經就定位後的function
        void p1BlockSet()
        {
            int pop_result = p1.fullLineCheck() + p1.updateCombo();  // 本次消掉行數 & combo加成
            p1.score += pop_result;  // 加分
            p1.score_text.Text = Convert.ToString(p1.score);  // 更新記分板數字
            p2.recievePressure(pop_result);  // 傳送壓力給對手
            p1.showGrids();

            /* 圖片顯示 */
            if (p1.line_pop > 0)
            {
                p1_linepop_timer.Stop();
                p1_linepop_timer.Start();
                linepop_picturebox1.Visible = true;
                linepop_picturebox1.Image = linepop_img.Images[p1.line_pop - 1];
            }

            if (p1.combo > 20)
            {
                p1_combo_timer.Stop();
                p1_combo_timer.Start();
                combo_pictureBox1.Visible = true;
                combo_pictureBox1.Image = combo_img.Images[0];
            }
            else if (p1.combo >= 1)
            {
                p1_combo_timer.Stop();
                p1_combo_timer.Start();
                combo_pictureBox1.Visible = true;
                combo_pictureBox1.Image = combo_img.Images[p1.combo];
            }

            /* 下一個方塊就緒 */
            p1.has_hold = false;
            p1.block_type = p1.next_block_type;
            p1.next_block_type = (p1.rd.Next(0, 7) + 1) * 10 + 1;
            p1.updateNext(p1.next_block_type);
            p1.block_row = Player.init_block_row;
            p1.block_col = Player.init_block_col;
            p1.predict_block_row = p1.block_row;
            p1.predict_block_col = p1.block_col;
            p1.predictBlock(p1.block_row, p1.block_col, p1.block_type);
            p1.showGrids();
        }

        private void p1_linepop_timer_Tick(object sender, EventArgs e)
        {
            p1_linepop_timer.Stop();
            linepop_picturebox1.Visible = false;
        }

        private void p1_combo_timer_Tick(object sender, EventArgs e)
        {
            p1_combo_timer.Stop();
            combo_pictureBox1.Visible = false;
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                if (p1.directionX(p1.block_row, p1.block_col, p1.block_type, -1))
                {
                    p1.eraseBlock(p1.block_row, p1.block_col, p1.block_type);
                    p1.block_col--;
                    p1.updateBlock(p1.block_row, p1.block_col, p1.block_type);
                    p1.predict_block_row = p1.block_row;
                    p1.predict_block_col = p1.block_col;
                    p1.predictBlock(p1.block_row, p1.block_col, p1.block_type);
                    p1.showGrids();
                }
            }
            if (e.KeyCode == Keys.D)
            {
                if (p1.directionX(p1.block_row, p1.block_col, p1.block_type, 1))
                {
                    p1.eraseBlock(p1.block_row, p1.block_col, p1.block_type);
                    p1.block_col++;
                    p1.updateBlock(p1.block_row, p1.block_col, p1.block_type);
                    p1.predict_block_row = p1.block_row;
                    p1.predict_block_col = p1.block_col;
                    p1.predictBlock(p1.block_row, p1.block_col, p1.block_type);
                    p1.showGrids();
                }
            }
            if (e.KeyCode == Keys.W)
            {
                int tmp_row = p1.block_row, tmp_col = p1.block_col, tmp_type = p1.block_type;  // 先記錄原本block_row & block_col & block_type位置
                p1.block_type = p1.rotateBlock(p1.block_row, p1.block_col, p1.block_type);
                p1.eraseBlock(tmp_row, tmp_col, tmp_type);
                p1.updateBlock(p1.block_row, p1.block_col, p1.block_type);
                p1.predict_block_row = p1.block_row;
                p1.predict_block_col = p1.block_col;
                p1.predictBlock(p1.block_row, p1.block_col, p1.block_type);
                p1.showGrids();
            }
            if (e.KeyCode == Keys.S)
            {
                p1_timer.Interval = 100;
            }
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.CapsLock)
            {
                while (p1.directionY(p1.block_row, p1.block_col, p1.block_type))
                {
                    p1.eraseBlock(p1.block_row, p1.block_col, p1.block_type);
                    p1.block_row++;
                    p1.updateBlock(p1.block_row, p1.block_col, p1.block_type);
                }
                p1.showGrids();
                p1BlockSet();
            }
            if ((e.KeyCode == Keys.B || e.KeyCode == Keys.Tab) && !p1.has_hold)
            {
                p1.has_hold = true;

                // 第一次hold: 直接把現有的放進hold，換成下一個
                if (p1.holding == 0)
                {
                    p1.eraseBlock(p1.block_row, p1.block_col, p1.block_type);
                    p1.holding = p1.block_type;  // 有可能不為 X1 的格式 (例如32, 42...)
                    p1.block_type = p1.next_block_type;
                    p1.next_block_type = (p1.rd.Next(0, 7) + 1) * 10 + 1;
                    p1.updateNext(p1.next_block_type);
                    p1.holding = p1.updateHold(p1.holding);  // 修正回 X1 的格式
                    p1.block_row = Player.init_block_row;
                    p1.block_col = Player.init_block_col;
                    p1.predict_block_row = p1.block_row;
                    p1.predict_block_col = p1.block_col;
                    p1.predictBlock(p1.block_row, p1.block_col, p1.block_type);
                    p1.showGrids();
                }

                // 之後的hold: 把現有的跟hold住的互換
                else
                {
                    p1.eraseBlock(p1.block_row, p1.block_col, p1.block_type);
                    int swap = p1.holding;
                    p1.holding = p1.updateHold(p1.block_type);
                    p1.block_type = swap;
                    p1.block_row = Player.init_block_row;
                    p1.block_col = Player.init_block_col;
                    p1.predict_block_row = p1.block_row;
                    p1.predict_block_col = p1.block_col;
                    p1.predictBlock(p1.block_row, p1.block_col, p1.block_type);
                    p1.showGrids();
                }
            }
        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
            {
                p1_timer.Interval = p1.drop_timer;
            }
            // TODO: p2快速下滑 if (e.KeyCode == Keys.Down)
        }



    }

    public class Player
    {
        /* grid相關變數 */
        public Label[,] grids = new Label[20, 10];  // 宣告類型為Label的陣列, 高度20, 寬度10
        bool[,] full = new bool[24, 10];  // 檢查每個格子是否有方塊
        Color[,] grids_color = new Color[24, 10];
        int grid_x, grid_y;  // 最左上的格子座標, 會從最左上的格子[0, 0]開始建立

        /* next區塊相關變數 */
        public Label next_title = new Label();
        public Label[,] next = new Label[4, 3];  // 宣告類型為Label的陣列, 高度20, 寬度10
        int next_x, next_y;  // 最左上的格子座標, 會從最左上的格子開始建立

        /* hold區塊相關變數 */
        public Label hold_title = new Label();
        public Label[,] hold = new Label[4, 3];  // 宣告類型為Label的陣列, 高度20, 寬度10
        int hold_x, hold_y;  // 最左上的格子座標, 會從最左上的格子開始建立

        /* bar相關變數 */
        public VerticalProgressBar bar = new VerticalProgressBar();
        int vpb_x, vpb_y;

        /*分數區塊相關變數*/
        public Label score_title = new Label();
        public Label score_text = new Label();
        public int score = 0;
        public int line_pop = 0;
        public int combo = -1;  // 若無消行，combo設為-1

        /* 遊戲進行時相關變數 */
        public Random rd = new Random();
        public int drop_timer = 1000;  // 方塊掉落速度
        public int block_type;  // 目前方塊的類型(1~7)
        public static int init_block_row = 4, init_block_col = 4;  // 新方塊產生時的生成位置(會分別指派給block_row & block_col)
        public int block_row, block_col;  // 目前方塊的位置(row: 0~23, col: 0~9)
        public int predict_block_row, predict_block_col;  // 預測目前方塊會降落的位置(row: 0~23, col: 0~9)
        public int next_block_type;  // 下一個方塊的類型(1~7)
        public int holding = 0;  // 目前hold的方塊類型(若無則為0)
        public bool has_hold = false;  // 本次是否已經使用過hold

        /* functions */
        // constructor
        public Player(int x, int y)
        {
            grid_x = x;
            grid_y = y;
            next_x = grid_x + 275;
            next_y = grid_y + 75;
            hold_x = grid_x - 100;
            hold_y = grid_y + 75;
            vpb_x = x + 250;
            vpb_y = y;

            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    full[i, j] = false;
                    grids_color[i, j] = Color.Black;
                }
            }

            createGrids();
            createNext();
            createHold();
            createVProgressBar();
            createScoreZone();
        }

        // 建立每個grid的屬性
        public void createGrids()
        {
            int x = grid_x, y = grid_y;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    grids[i, j] = new Label();  // 每個成員均為一個新的Label物件
                    grids[i, j].Width = 25;
                    grids[i, j].Height = 25;
                    grids[i, j].Left = x;
                    grids[i, j].Top =y;
                    grids[i, j].BackColor = Color.Black;  // 背景顏色為黑色
                    grids[i, j].BorderStyle = BorderStyle.FixedSingle;  // 邊界
                    grids[i, j].Visible = true;
                    x += 25;  // x加25準備給下一格使用
                }
                x = grid_x;  // 換下一行時, x要回到25
                y += 25;  // 換下一行時, y要加25
            }
        }

        // 顯示grids
        public void showGrids()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                    grids[i, j].BackColor = grids_color[i + 4, j];
            }
        }

        // 建立每個next的屬性
        public void createNext()
        {
            next_title.Text = "NEXT";
            next_title.TextAlign = ContentAlignment.MiddleCenter;
            next_title.Width = 75;
            next_title.Height = 30;
            next_title.Left = next_x;
            next_title.Top = next_y - 30;
            next_title.Visible = true;

            int x = next_x, y = next_y;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    next[i, j] = new Label();  // 每個成員均為一個新的Label物件
                    next[i, j].Width = 25;
                    next[i, j].Height = 25;
                    next[i, j].Left =x;
                    next[i, j].Top = y;
                    next[i, j].BackColor = Color.Black;  // 背景顏色為黑色
                    next[i, j].BorderStyle = BorderStyle.FixedSingle;  // 邊界
                    next[i, j].Visible = true;
                    x += 25;  // x加25準備給下一格使用
                }

                x = next_x;  // 換下一行時, x要回到25
                y += 25;  // 換下一行時, y要加25
            }
        }

        // 建立每個hold的屬性
        public void createHold()
        {
            hold_title.Text = "HOLD";
            hold_title.TextAlign = ContentAlignment.MiddleCenter;
            hold_title.Width = 75;
            hold_title.Height = 30;
            hold_title.Left = hold_x;
            hold_title.Top = hold_y - 30;
            hold_title.Visible = true;

            int x = hold_x, y = hold_y;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    hold[i, j] = new Label();  // 每個成員均為一個新的Label物件
                    hold[i, j].Width = 25;
                    hold[i, j].Height = 25;
                    hold[i, j].Left = x;
                    hold[i, j].Top = y;
                    hold[i, j].BackColor = Color.Black;  // 背景顏色為黑色
                    hold[i, j].BorderStyle = BorderStyle.FixedSingle;  // 邊界
                    hold[i, j].Visible = true;
                    x += 25;  // x加25準備給下一格使用
                }

                x = hold_x;  // 換下一行時, x要回到25
                y += 25;  // 換下一行時, y要加25
            }
        }

        // 更新next方塊
        public void updateNext(int type)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 3; j++)
                    next[i, j].BackColor = Color.Black;

            switch (type)
            {
                case 11:
                    next[0, 1].BackColor = next[1, 1].BackColor = next[2, 1].BackColor = next[3, 1].BackColor = Color.FromArgb(78, 192, 255);
                    break;
                case 21:
                    next[1, 1].BackColor = next[1, 2].BackColor = next[2, 1].BackColor = next[2, 2].BackColor = Color.FromArgb(255, 231, 53);
                    break;
                case 31:
                    next[1, 0].BackColor = next[1, 1].BackColor = next[2, 1].BackColor = next[2, 2].BackColor = Color.FromArgb(237, 74, 95);
                    break;
                case 41:
                    next[2, 0].BackColor = next[2, 1].BackColor = next[1, 1].BackColor = next[1, 2].BackColor = Color.FromArgb(145, 255, 57);
                    break;
                case 51:
                    next[1, 0].BackColor = next[2, 0].BackColor = next[1, 1].BackColor = next[1, 2].BackColor = Color.FromArgb(255, 179, 60);
                    break;
                case 61:
                    next[1, 0].BackColor = next[1, 1].BackColor = next[1, 2].BackColor = next[2, 2].BackColor = Color.FromArgb(85, 120, 255);
                    break;
                case 71:
                    next[1, 1].BackColor = next[2, 0].BackColor = next[2, 1].BackColor = next[2, 2].BackColor = Color.FromArgb(255, 110, 228);
                    break;
            }
        }

        // 更新hold方塊
        public int updateHold(int type)
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 3; j++)
                    hold[i, j].BackColor = Color.Black;

            switch (type)
            {
                case 11:
                case 12:
                    hold[0, 1].BackColor = hold[1, 1].BackColor = hold[2, 1].BackColor = hold[3, 1].BackColor = Color.FromArgb(78, 192, 255);
                    return 11;

                case 21:
                    hold[1, 1].BackColor = hold[1, 2].BackColor = hold[2, 1].BackColor = hold[2, 2].BackColor = Color.FromArgb(255, 231, 53);
                    return 21;

                case 31:
                case 32:
                    hold[1, 0].BackColor = hold[1, 1].BackColor = hold[2, 1].BackColor = hold[2, 2].BackColor = Color.FromArgb(237, 74, 95);
                    return 31;

                case 41:
                case 42:
                    hold[2, 0].BackColor = hold[2, 1].BackColor = hold[1, 1].BackColor = hold[1, 2].BackColor = Color.FromArgb(145, 255, 57);
                    return 41;

                case 51:
                case 52:
                case 53:
                case 54:
                    hold[1, 0].BackColor = hold[2, 0].BackColor = hold[1, 1].BackColor = hold[1, 2].BackColor = Color.FromArgb(255, 179, 60);
                    return 51;

                case 61:
                case 62:
                case 63:
                case 64:
                    hold[1, 0].BackColor = hold[1, 1].BackColor = hold[1, 2].BackColor = hold[2, 2].BackColor = Color.FromArgb(85, 120, 255);
                    return 61;

                case 71:
                case 72:
                case 73:
                case 74:
                    hold[1, 1].BackColor = hold[2, 0].BackColor = hold[2, 1].BackColor = hold[2, 2].BackColor = Color.FromArgb(255, 110, 228);
                    return 71;

                default: return 0;
            }
        }

        // 建立每個bar的屬性
        public void createVProgressBar()
        {
            bar.Minimum = 0;
            bar.Maximum = 20;
            bar.Value = 0;
            bar.Width = 10;
            bar.Height = 500;
            bar.Left = vpb_x;
            bar.Top = vpb_y;
            bar.Visible = true;
        }

        // 建立每個分數區塊的屬性
        public void createScoreZone()
        {
            score_title.Text = "Lines\r\nSent";
            score_text.Text = "0";
            score_title.TextAlign = ContentAlignment.MiddleCenter;
            score_text.TextAlign = ContentAlignment.MiddleCenter;
            score_title.Width = 60;
            score_title.Height = 60;
            score_text.Width = 60;
            score_text.Height = 30;
            score_text.ForeColor = Color.Orange;
            score_text.Font = new Font("Comic Sans MS", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            score_title.Left = grid_x - 60;
            score_title.Top = grid_y + 240;
            score_text.Left = grid_x - 60;
            score_text.Top = grid_y + 300;
            score_title.Visible = true;
            score_text.Visible = true;
        }

        // NOTE: 1x: I, 2x: O, 3x: Z, 4x: S, 5x: L, 6x: J, 7x: T
        // 更新方塊位置
        public void updateBlock(int r, int c, int type)
        {
            switch (type)
            {
                // I
                case 11:
                    full[r, c] = full[r - 1, c] = full[r - 2, c] = full[r - 3, c] = true;
                    grids_color[r, c] = grids_color[r - 1, c] = grids_color[r - 2, c] = grids_color[r - 3, c] = Color.FromArgb(78, 192, 255);
                    break;
                case 12:
                    full[r, c] = full[r, c + 1] = full[r, c + 2] = full[r, c + 3] = true;
                    grids_color[r, c] = grids_color[r, c + 1] = grids_color[r, c + 2] = grids_color[r, c + 3] = Color.FromArgb(78, 192, 255);
                    break;

                // O
                case 21:
                    full[r, c] = full[r, c + 1] = full[r - 1, c] = full[r - 1, c + 1] = true;
                    grids_color[r, c] = grids_color[r, c + 1] = grids_color[r - 1, c] = grids_color[r - 1, c + 1] = Color.FromArgb(255, 231, 53);
                    break;

                // Z
                case 31:
                    full[r, c] = full[r, c + 1] = full[r - 1, c] = full[r - 1, c - 1] = true;
                    grids_color[r, c] = grids_color[r, c + 1] = grids_color[r - 1, c] = grids_color[r - 1, c - 1] = Color.FromArgb(237, 74, 95);
                    break;
                case 32:
                    full[r, c] = full[r + 1, c] = full[r, c + 1] = full[r - 1, c + 1] = true;
                    grids_color[r, c] = grids_color[r + 1, c] = grids_color[r, c + 1] = grids_color[r - 1, c + 1] = Color.FromArgb(237, 74, 95);
                    break;

                // S
                case 41:
                    full[r, c] = full[r, c - 1] = full[r - 1, c] = full[r - 1, c + 1] = true;
                    grids_color[r, c] = grids_color[r, c - 1] = grids_color[r - 1, c] = grids_color[r - 1, c + 1] = Color.FromArgb(145, 255, 57);
                    break;
                case 42:
                    full[r, c] = full[r - 1, c] = full[r, c + 1] = full[r + 1, c + 1] = true;
                    grids_color[r, c] = grids_color[r - 1, c] = grids_color[r, c + 1] = grids_color[r + 1, c + 1] = Color.FromArgb(145, 255, 57);
                    break;

                // L
                case 51:
                    full[r, c] = full[r - 1, c] = full[r - 1, c + 1] = full[r - 1, c + 2] = true;
                    grids_color[r, c] = grids_color[r - 1, c] = grids_color[r - 1, c + 1] = grids_color[r - 1, c + 2] = Color.FromArgb(255, 179, 60);
                    break;
                case 52:
                    full[r, c] = full[r, c + 1] = full[r + 1, c + 1] = full[r + 2, c + 1] = true;
                    grids_color[r, c] = grids_color[r, c + 1] = grids_color[r + 1, c + 1] = grids_color[r + 2, c + 1] = Color.FromArgb(255, 179, 60);
                    break;
                case 53:
                    full[r, c] = full[r + 1, c] = full[r + 1, c - 1] = full[r + 1, c - 2] = true;
                    grids_color[r, c] = grids_color[r + 1, c] = grids_color[r + 1, c - 1] = grids_color[r + 1, c - 2] = Color.FromArgb(255, 179, 60);
                    break;
                case 54:
                    full[r, c] = full[r, c - 1] = full[r - 1, c - 1] = full[r - 2, c - 1] = true;
                    grids_color[r, c] = grids_color[r, c - 1] = grids_color[r - 1, c - 1] = grids_color[r - 2, c - 1] = Color.FromArgb(255, 179, 60);
                    break;

                // J
                case 61:
                    full[r, c] = full[r - 1, c] = full[r - 1, c - 1] = full[r - 1, c - 2] = true;
                    grids_color[r, c] = grids_color[r - 1, c] = grids_color[r - 1, c - 1] = grids_color[r - 1, c - 2] = Color.FromArgb(85, 120, 255);
                    break;
                case 62:
                    full[r, c] = full[r, c + 1] = full[r - 1, c + 1] = full[r - 2, c + 1] = true;
                    grids_color[r, c] = grids_color[r, c + 1] = grids_color[r - 1, c + 1] = grids_color[r - 2, c + 1] = Color.FromArgb(85, 120, 255);
                    break;
                case 63:
                    full[r, c] = full[r + 1, c] = full[r + 1, c + 1] = full[r + 1, c + 2] = true;
                    grids_color[r, c] = grids_color[r + 1, c] = grids_color[r + 1, c + 1] = grids_color[r + 1, c + 2] = Color.FromArgb(85, 120, 255);
                    break;
                case 64:
                    full[r, c] = full[r, c - 1] = full[r + 1, c - 1] = full[r + 2, c - 1] = true;
                    grids_color[r, c] = grids_color[r, c - 1] = grids_color[r + 1, c - 1] = grids_color[r + 2, c - 1] = Color.FromArgb(85, 120, 255);
                    break;

                // T
                case 71:
                    full[r, c] = full[r, c - 1] = full[r, c + 1] = full[r - 1, c] = true;
                    grids_color[r, c] = grids_color[r, c - 1] = grids_color[r, c + 1] = grids_color[r - 1, c] = Color.FromArgb(255, 110, 228);
                    break;
                case 72:
                    full[r, c] = full[r + 1, c] = full[r, c + 1] = full[r - 1, c] = true;
                    grids_color[r, c] = grids_color[r + 1, c] = grids_color[r, c + 1] = grids_color[r - 1, c] = Color.FromArgb(255, 110, 228);
                    break;
                case 73:
                    full[r, c] = full[r, c - 1] = full[r, c + 1] = full[r + 1, c] = true;
                    grids_color[r, c] = grids_color[r, c - 1] = grids_color[r, c + 1] = grids_color[r + 1, c] = Color.FromArgb(255, 110, 228);
                    break;
                case 74:
                    full[r, c] = full[r, c - 1] = full[r + 1, c] = full[r - 1, c] = true;
                    grids_color[r, c] = grids_color[r, c - 1] = grids_color[r + 1, c] = grids_color[r - 1, c] = Color.FromArgb(255, 110, 228);
                    break;
            }
        }

        // 更新方塊(下降一格)之前要先把舊有的位置移除
        public void eraseBlock(int r, int c, int type)
        {
            switch (type)
            {
                // I
                case 11:
                    full[r, c] = full[r - 1, c] = full[r - 2, c] = full[r - 3, c] = false;
                    grids_color[r, c] = grids_color[r - 1, c] = grids_color[r - 2, c] = grids_color[r - 3, c] = Color.Black;
                    break;
                case 12:
                    full[r, c] = full[r, c + 1] = full[r, c + 2] = full[r, c + 3] = false;
                    grids_color[r, c] = grids_color[r, c + 1] = grids_color[r, c + 2] = grids_color[r, c + 3] = Color.Black;
                    break;

                // O
                case 21:
                    full[r, c] = full[r - 1, c] = full[r, c + 1] = full[r - 1, c + 1] = false;
                    grids_color[r, c] = grids_color[r - 1, c] = grids_color[r, c + 1] = grids_color[r - 1, c + 1] = Color.Black;
                    break;

                // Z
                case 31:
                    full[r, c] = full[r - 1, c] = full[r - 1, c - 1] = full[r, c + 1] = false;
                    grids_color[r, c] = grids_color[r - 1, c] = grids_color[r - 1, c - 1] = grids_color[r, c + 1] = Color.Black;
                    break;
                case 32:
                    full[r, c] = full[r + 1, c] = full[r, c + 1] = full[r - 1, c + 1] = false;
                    grids_color[r, c] = grids_color[r + 1, c] = grids_color[r, c + 1] = grids_color[r - 1, c + 1] = Color.Black;
                    break;

                // S
                case 41:
                    full[r, c] = full[r, c - 1] = full[r - 1, c] = full[r - 1, c + 1] = false;
                    grids_color[r, c] = grids_color[r, c - 1] = grids_color[r - 1, c] = grids_color[r - 1, c + 1] = Color.Black;
                    break;
                case 42:
                    full[r, c] = full[r - 1, c] = full[r, c + 1] = full[r + 1, c + 1] = false;
                    grids_color[r, c] = grids_color[r - 1, c] = grids_color[r, c + 1] = grids_color[r + 1, c + 1] = Color.Black;
                    break;

                // L
                case 51:
                    full[r, c] = full[r - 1, c] = full[r - 1, c + 1] = full[r - 1, c + 2] = false;
                    grids_color[r, c] = grids_color[r - 1, c] = grids_color[r - 1, c + 1] = grids_color[r - 1, c + 2] = Color.Black;
                    break;
                case 52:
                    full[r, c] = full[r, c + 1] = full[r + 1, c + 1] = full[r + 2, c + 1] = false;
                    grids_color[r, c] = grids_color[r, c + 1] = grids_color[r + 1, c + 1] = grids_color[r + 2, c + 1] = Color.Black;
                    break;
                case 53:
                    full[r, c] = full[r + 1, c] = full[r + 1, c - 1] = full[r + 1, c - 2] = false;
                    grids_color[r, c] = grids_color[r + 1, c] = grids_color[r + 1, c - 1] = grids_color[r + 1, c - 2] = Color.Black;
                    break;
                case 54:
                    full[r, c] = full[r, c - 1] = full[r - 1, c - 1] = full[r - 2, c - 1] = false;
                    grids_color[r, c] = grids_color[r, c - 1] = grids_color[r - 1, c - 1] = grids_color[r - 2, c - 1] = Color.Black;
                    break;

                // J
                case 61:
                    full[r, c] = full[r - 1, c] = full[r - 1, c - 1] = full[r - 1, c - 2] = false;
                    grids_color[r, c] = grids_color[r - 1, c] = grids_color[r - 1, c - 1] = grids_color[r - 1, c - 2] = Color.Black;
                    break;
                case 62:
                    full[r, c] = full[r, c + 1] = full[r - 1, c + 1] = full[r - 2, c + 1] = false;
                    grids_color[r, c] = grids_color[r, c + 1] = grids_color[r - 1, c + 1] = grids_color[r - 2, c + 1] = Color.Black;
                    break;
                case 63:
                    full[r, c] = full[r + 1, c] = full[r + 1, c + 1] = full[r + 1, c + 2] = false;
                    grids_color[r, c] = grids_color[r + 1, c] = grids_color[r + 1, c + 1] = grids_color[r + 1, c + 2] = Color.Black;
                    break;
                case 64:
                    full[r, c] = full[r, c - 1] = full[r + 1, c - 1] = full[r + 2, c - 1] = false;
                    grids_color[r, c] = grids_color[r, c - 1] = grids_color[r + 1, c - 1] = grids_color[r + 2, c - 1] = Color.Black;
                    break;

                // T
                case 71:
                    full[r, c] = full[r, c - 1] = full[r, c + 1] = full[r - 1, c] = false;
                    grids_color[r, c] = grids_color[r, c - 1] = grids_color[r, c + 1] = grids_color[r - 1, c] = Color.Black;
                    break;
                case 72:
                    full[r, c] = full[r, c + 1] = full[r + 1, c] = full[r - 1, c] = false;
                    grids_color[r, c] = grids_color[r, c + 1] = grids_color[r + 1, c] = grids_color[r - 1, c] = Color.Black;
                    break;
                case 73:
                    full[r, c] = full[r, c - 1] = full[r, c + 1] = full[r + 1, c] = false;
                    grids_color[r, c] = grids_color[r, c - 1] = grids_color[r, c + 1] = grids_color[r + 1, c] = Color.Black;
                    break;
                case 74:
                    full[r, c] = full[r, c - 1] = full[r - 1, c] = full[r + 1, c] = false;
                    grids_color[r, c] = grids_color[r, c - 1] = grids_color[r - 1, c] = grids_color[r + 1, c] = Color.Black;
                    break;
            }
        }

        // 偵測方塊在y軸方向有沒有觸底，還沒觸底則回傳true
        public bool directionY(int r, int c, int type)
        {
            switch (type)
            {
                // I
                case 11:
                    if (r != 23 && !full[r + 1, c]) return true;
                    else return false;
                case 12:
                    if (r != 23 && !full[r + 1, c] && !full[r + 1, c + 1] && !full[r + 1, c + 2] && !full[r + 1, c + 3]) return true;
                    else return false;

                // O
                case 21:
                    if (r != 23 && !full[r + 1, c] && !full[r + 1, c + 1]) return true;
                    else return false;

                // Z
                case 31:
                    if (r != 23 && !full[r + 1, c] && !full[r + 1, c + 1] && !full[r, c - 1]) return true;
                    else return false;
                case 32:
                    if (r != 22 && !full[r + 2, c] && !full[r + 1, c + 1]) return true;
                    else return false;

                // S
                case 41:
                    if (r != 23 && !full[r + 1, c] && !full[r + 1, c - 1] && !full[r, c + 1]) return true;
                    else return false;
                case 42:
                    if (r != 22 && !full[r + 1, c] && !full[r + 2, c + 1]) return true;
                    else return false;

                // L
                case 51:
                    if (r != 23 && !full[r + 1, c] && !full[r, c + 1] && !full[r, c + 2]) return true;
                    else return false;
                case 52:
                    if (r != 21 && !full[r + 1, c] && !full[r + 3, c + 1]) return true;
                    else return false;
                case 53:
                    if (r != 22 && !full[r + 2, c] && !full[r + 2, c - 1] && !full[r + 2, c - 2]) return true;
                    else return false;
                case 54:
                    if (r != 23 && !full[r + 1, c] && !full[r + 1, c - 1]) return true;
                    else return false;

                // J
                case 61:
                    if (r != 23 && !full[r + 1, c] && !full[r, c - 1] && !full[r, c - 2]) return true;
                    else return false;
                case 62:
                    if (r != 23 && !full[r + 1, c] && !full[r + 1, c + 1]) return true;
                    else return false;
                case 63:
                    if (r != 22 && !full[r + 2, c] && !full[r + 2, c + 1] && !full[r + 2, c + 2]) return true;
                    else return false;
                case 64:
                    if (r != 21 && !full[r + 1, c] && !full[r + 3, c - 1]) return true;
                    else return false;

                // T
                case 71:
                    if (r != 23 && !full[r + 1, c] && !full[r + 1, c + 1] && !full[r + 1, c - 1]) return true;
                    else return false;
                case 72:
                    if (r != 22 && !full[r + 2, c] && !full[r + 1, c + 1]) return true;
                    else return false;
                case 73:
                    if (r != 22 && !full[r + 2, c] && !full[r + 1, c + 1] && !full[r + 1, c - 1]) return true;
                    else return false;
                case 74:
                    if (r != 22 && !full[r + 2, c] && !full[r + 1, c - 1]) return true;
                    else return false;

                default:
                    return false;
            }
        }

        // 偵測方塊在x軸方向有沒有碰壁，若沒碰壁則回傳true
        public bool directionX(int r, int c, int type, int d)
        {
            switch (type)
            {
                // I
                case 11:
                    if (d == -1)
                    {
                        if (c != 0 && !full[r, c - 1] && !full[r - 1, c - 1] && !full[r - 2, c - 1] && !full[r - 3, c - 1]) return true;
                        else return false;
                    }
                    else
                    {
                        if (c != 9 && !full[r, c + 1] && !full[r - 1, c + 1] && !full[r - 2, c + 1] && !full[r - 3, c + 1]) return true;
                        else return false;
                    }
                case 12:
                    if (d == -1)
                    {
                        if (c != 0 && !full[r, c - 1]) return true;
                        else return false;
                    }
                    else
                    {
                        if (c != 6 && !full[r, c + 4]) return true;
                        else return false;
                    }

                // O
                case 21:
                    if (d == -1)
                    {
                        if (c != 0 && !full[r, c - 1] && !full[r - 1, c - 1]) return true;
                        else return false;
                    }
                    else
                    {
                        if (c != 8 && !full[r, c + 2] && !full[r - 1, c + 2]) return true;
                        else return false;
                    }

                // Z
                case 31:
                    if (d == -1)
                    {
                        if (c != 1 && !full[r, c - 1] && !full[r - 1, c - 2]) return true;
                        else return false;
                    }
                    else
                    {
                        if (c != 8 && !full[r, c + 2] && !full[r - 1, c + 1]) return true;
                        else return false;
                    }
                case 32:
                    if (d == -1)
                    {
                        if (c != 0 && !full[r, c - 1] && !full[r - 1, c] && !full[r + 1, c - 1]) return true;
                        else return false;
                    }
                    else
                    {
                        if (c != 8 && !full[r, c + 2] && !full[r - 1, c + 2] && !full[r + 1, c + 1]) return true;
                        else return false;
                    }

                // S
                case 41:
                    if (d == -1)
                    {
                        if (c != 1 && !full[r, c - 2] && !full[r - 1, c - 1]) return true;
                        else return false;
                    }
                    else
                    {
                        if (c != 8 && !full[r, c + 1] && !full[r - 1, c + 2]) return true;
                        else return false;
                    }
                case 42:
                    if (d == -1)
                    {
                        if (c != 0 && !full[r, c - 1] && !full[r - 1, c - 1] && !full[r + 1, c]) return true;
                        else return false;
                    }
                    else
                    {
                        if (c != 8 && !full[r, c + 2] && !full[r - 1, c + 1] && !full[r + 1, c + 2]) return true;
                        else return false;
                    }

                // L
                case 51:
                    if (d == -1)
                    {
                        if (c != 0 && !full[r, c - 1] && !full[r - 1, c - 1]) return true;
                        else return false;
                    }
                    else
                    {
                        if (c != 7 && !full[r, c + 1] && !full[r - 1, c + 3]) return true;
                        else return false;
                    }
                case 52:
                    if (d == -1)
                    {
                        if (c != 0 && !full[r, c - 1] && !full[r + 1, c] && !full[r + 2, c]) return true;
                        else return false;
                    }
                    else
                    {
                        if (c != 8 && !full[r, c + 2] && !full[r + 1, c + 2] && !full[r + 2, c + 2]) return true;
                        else return false;
                    }
                case 53:
                    if (d == -1)
                    {
                        if (c != 2 && !full[r, c - 1] && !full[r + 1, c - 3]) return true;
                        else return false;
                    }
                    else
                    {
                        if (c != 9 && !full[r, c + 1] && !full[r + 1, c + 1]) return true;
                        else return false;
                    }
                case 54:
                    if (d == -1)
                    {
                        if (c != 1 && !full[r, c - 2] && !full[r - 1, c - 2] && !full[r - 2, c - 2]) return true;
                        else return false;
                    }
                    else
                    {
                        if (c != 9 && !full[r, c + 1] && !full[r - 1, c] && !full[r - 2, c]) return true;
                        else return false;
                    }

                // J
                case 61:
                    if (d == -1)
                    {
                        if (c != 2 && !full[r, c - 1] && !full[r - 1, c - 3]) return true;
                        else return false;
                    }
                    else
                    {
                        if (c != 9 && !full[r, c + 1] && !full[r - 1, c + 1]) return true;
                        else return false;
                    }
                case 62:
                    if (d == -1)
                    {
                        if (c != 0 && !full[r, c - 1] && !full[r - 1, c] && !full[r - 2, c]) return true;
                        else return false;
                    }
                    else
                    {
                        if (c != 8 && !full[r, c + 2] && !full[r - 1, c + 2] && !full[r - 2, c + 2]) return true;
                        else return false;
                    }
                case 63:
                    if (d == -1)
                    {
                        if (c != 0 && !full[r, c - 1] && !full[r + 1, c - 1]) return true;
                        else return false;
                    }
                    else
                    {
                        if (c != 7 && !full[r, c + 1] && !full[r + 1, c + 3]) return true;
                        else return false;
                    }
                case 64:
                    if (d == -1)
                    {
                        if (c != 1 && !full[r, c - 2] && !full[r + 1, c - 2] && !full[r + 2, c - 2]) return true;
                        else return false;
                    }
                    else
                    {
                        if (c != 9 && !full[r, c + 1] && !full[r + 1, c] && !full[r + 2, c]) return true;
                        else return false;
                    }

                // T
                case 71:
                    if (d == -1)
                    {
                        if (c != 1 && !full[r, c - 2] && !full[r - 1, c - 1]) return true;
                        else return false;
                    }
                    else
                    {
                        if (c != 8 && !full[r, c + 2] && !full[r - 1, c + 1]) return true;
                        else return false;
                    }
                case 72:
                    if (d == -1)
                    {
                        if (c != 0 && !full[r, c - 1] && !full[r - 1, c - 1] && !full[r + 1, c - 1]) return true;
                        else return false;
                    }
                    else
                    {
                        if (c != 8 && !full[r, c + 2] && !full[r - 1, c + 1] && !full[r + 1, c + 1]) return true;
                        else return false;
                    }
                case 73:
                    if (d == -1)
                    {
                        if (c != 1 && !full[r, c - 2] && !full[r + 1, c - 1]) return true;
                        else return false;
                    }
                    else
                    {
                        if (c != 8 && !full[r, c + 2] && !full[r + 1, c + 1]) return true;
                        else return false;
                    }
                case 74:
                    if (d == -1)
                    {
                        if (c != 1 && !full[r, c - 2] && !full[r - 1, c - 1] && !full[r + 1, c - 1]) return true;
                        else return false;
                    }
                    else
                    {
                        if (c != 9 && !full[r, c + 1] && !full[r - 1, c + 1] && !full[r + 1, c + 1]) return true;
                        else return false;
                    }

                default:
                    return false;
            }
        }

        // 旋轉方塊
        public int rotateBlock(int r, int c, int type)
        {
            switch (type)
            {
                // I
                case 11:
                    if (c <= 8 && c >= 2 && !full[r - 2, c - 2] && !full[r - 2, c - 1] && !full[r - 2, c + 1])
                    {
                        block_row = r - 2;
                        block_col = c - 2;
                        return 12;
                    }
                    else return 11;
                case 12:
                    if (r <= 21 && !full[r - 1, c + 2] && !full[r + 1, c + 2] && !full[r + 2, c + 2])
                    {
                        block_row = r + 2;
                        block_col = c + 2;
                        return 11;
                    }
                    else return 12;

                // O
                case 21: return 21;

                // Z
                case 31:
                    if (!full[r - 1, c + 1] && !full[r - 2, c + 1])
                    {
                        block_row = r - 1;
                        return 32;
                    }
                    else return 31;
                case 32:
                    if (c >= 1 && !full[r, c - 1] && !full[r + 1, c + 1])
                    {
                        block_row = r + 1;
                        return 31;
                    }
                    else return 32;

                // S
                case 41:
                    if (!full[r - 1, c - 1] && !full[r - 2, c - 1])
                    {
                        block_row = r - 1;
                        block_col = c - 1;
                        return 42;
                    }
                    else return 41;
                case 42:
                    if (c <= 7 && !full[r + 1, c] && !full[r, c + 2])
                    {
                        block_row = r + 1;
                        block_col = c + 1;
                        return 41;
                    }
                    else return 42;

                // L
                case 51:
                    if (!full[r - 2, c] && !full[r - 2, c + 1] && !full[r, c + 1])
                    {
                        block_row = r - 2;
                        return 52;
                    }
                    else return 51;
                case 52:
                    if (c <= 7 && !full[r + 1, c + 2] && !full[r + 2, c] && !full[r + 2, c + 2])
                    {
                        block_row = r + 1;
                        block_col = c + 2;
                        return 53;
                    }
                    else return 52;
                case 53:
                    if (!full[r, c - 1] && !full[r - 1, c - 1])
                    {
                        block_row = r + 1;
                        return 54;
                    }
                    else return 53;
                case 54:
                    if (c >= 2 && !full[r, c - 2] && !full[r - 1, c - 2] && !full[r - 1, c])
                    {
                        block_col = c - 2;
                        return 51;
                    }
                    else return 54;

                // J
                case 61:
                    if (!full[r, c - 1] && !full[r, c - 2] && !full[r - 2, c - 1])
                    {
                        block_col = c - 2;
                        return 62;
                    }
                    else return 61;
                case 62:
                    if (c <= 7 && !full[r - 1, c] && !full[r, c + 2])
                    {
                        block_row = r - 1;
                        return 63;
                    }
                    else return 62;
                case 63:
                    if (!full[r, c + 1] && !full[r - 1, c + 1] && !full[r - 1, c + 2])
                    {
                        block_row = r - 1;
                        block_col = c + 2;
                        return 64;
                    }
                    else return 63;
                case 64:
                    if (c >= 2 && !full[r + 1, c] && !full[r + 2, c] && !full[r + 1, c - 2])
                    {
                        block_row = r + 2;
                        return 61;
                    }
                    else return 64;

                // T
                case 71:
                    if (!full[r - 2, c] && !full[r - 1, c + 1])
                    {
                        block_row = r - 1;
                        return 72;
                    }
                    else return 71;
                case 72:
                    if (c >= 1 && !full[r, c - 1]) return 73;
                    else return 72;
                case 73:
                    if (!full[r - 1, c]) return 74;
                    else return 73;
                case 74:
                    if (c <= 8 && !full[r + 1, c - 1] && !full[r + 1, c + 1])
                    {
                        block_row = r + 1;
                        return 71;
                    }
                    else return 74;

                default:
                    return 0;
            }
        }

        // 預測方塊降落位置
        public void predictBlock(int r, int c, int type)
        {
            predict_block_row = r;
            while (directionY(predict_block_row, c, type))
                predict_block_row++;

            /* 把舊的洗掉 */
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 10; j++)
                    if (!full[i, j]) grids_color[i, j] = Color.Black;
            }

            switch (type)
            {
                // I
                case 11:
                    if (!full[predict_block_row, c]) grids_color[predict_block_row, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row - 1, c]) grids_color[predict_block_row - 1, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row - 2, c]) grids_color[predict_block_row - 2, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row - 3, c]) grids_color[predict_block_row - 3, c] = Color.FromArgb(223, 223, 223);
                    break;
                case 12:
                    if (!full[predict_block_row, c]) grids_color[predict_block_row, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row, c + 1]) grids_color[predict_block_row, c + 1] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row, c + 2]) grids_color[predict_block_row, c + 2] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row, c + 3]) grids_color[predict_block_row, c + 3] = Color.FromArgb(223, 223, 223);
                    break;

                // O
                case 21:
                    if (!full[predict_block_row, c]) grids_color[predict_block_row, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row, c + 1]) grids_color[predict_block_row, c + 1] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row - 1, c]) grids_color[predict_block_row - 1, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row - 1, c + 1]) grids_color[predict_block_row - 1, c + 1] = Color.FromArgb(223, 223, 223);
                    break;

                // Z
                case 31:
                    if (!full[predict_block_row, c]) grids_color[predict_block_row, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row, c + 1]) grids_color[predict_block_row, c + 1] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row - 1, c]) grids_color[predict_block_row - 1, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row - 1, c - 1]) grids_color[predict_block_row - 1, c - 1] = Color.FromArgb(223, 223, 223);
                    break;
                case 32:
                    if (!full[predict_block_row, c]) grids_color[predict_block_row, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row + 1, c]) grids_color[predict_block_row + 1, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row, c + 1]) grids_color[predict_block_row, c + 1] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row - 1, c + 1]) grids_color[predict_block_row - 1, c + 1] = Color.FromArgb(223, 223, 223);
                    break;

                // S
                case 41:
                    if (!full[predict_block_row, c]) grids_color[predict_block_row, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row, c - 1]) grids_color[predict_block_row, c - 1] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row - 1, c]) grids_color[predict_block_row - 1, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row - 1, c + 1]) grids_color[predict_block_row - 1, c + 1] = Color.FromArgb(223, 223, 223);
                    break;
                case 42:
                    if (!full[predict_block_row, c]) grids_color[predict_block_row, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row - 1, c]) grids_color[predict_block_row - 1, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row, c + 1]) grids_color[predict_block_row, c + 1] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row + 1, c + 1]) grids_color[predict_block_row + 1, c + 1] = Color.FromArgb(223, 223, 223);
                    break;

                // L
                case 51:
                    if (!full[predict_block_row, c]) grids_color[predict_block_row, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row - 1, c]) grids_color[predict_block_row - 1, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row - 1, c + 1]) grids_color[predict_block_row - 1, c + 1] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row - 1, c + 2]) grids_color[predict_block_row - 1, c + 2] = Color.FromArgb(223, 223, 223);
                    break;
                case 52:
                    if (!full[predict_block_row, c]) grids_color[predict_block_row, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row, c + 1]) grids_color[predict_block_row, c + 1] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row + 1, c + 1]) grids_color[predict_block_row + 1, c + 1] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row + 2, c + 1]) grids_color[predict_block_row + 2, c + 1] = Color.FromArgb(223, 223, 223);
                    break;
                case 53:
                    if (!full[predict_block_row, c]) grids_color[predict_block_row, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row + 1, c]) grids_color[predict_block_row + 1, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row + 1, c - 1]) grids_color[predict_block_row + 1, c - 1] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row + 1, c - 2]) grids_color[predict_block_row + 1, c - 2] = Color.FromArgb(223, 223, 223);
                    break;
                case 54:
                    if (!full[predict_block_row, c]) grids_color[predict_block_row, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row, c - 1]) grids_color[predict_block_row, c - 1] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row - 1, c - 1]) grids_color[predict_block_row - 1, c - 1] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row - 2, c - 1]) grids_color[predict_block_row - 2, c - 1] = Color.FromArgb(223, 223, 223);
                    break;

                // J
                case 61:
                    if (!full[predict_block_row, c]) grids_color[predict_block_row, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row - 1, c]) grids_color[predict_block_row - 1, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row - 1, c - 1]) grids_color[predict_block_row - 1, c - 1] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row - 1, c - 2]) grids_color[predict_block_row - 1, c - 2] = Color.FromArgb(223, 223, 223);
                    break;
                case 62:
                    if (!full[predict_block_row, c]) grids_color[predict_block_row, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row, c + 1]) grids_color[predict_block_row, c + 1] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row - 1, c + 1]) grids_color[predict_block_row - 1, c + 1] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row - 2, c + 1]) grids_color[predict_block_row - 2, c + 1] = Color.FromArgb(223, 223, 223);
                    break;
                case 63:
                    if (!full[predict_block_row, c]) grids_color[predict_block_row, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row + 1, c]) grids_color[predict_block_row + 1, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row + 1, c + 1]) grids_color[predict_block_row + 1, c + 1] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row + 1, c + 2]) grids_color[predict_block_row + 1, c + 2] = Color.FromArgb(223, 223, 223);
                    break;
                case 64:
                    if (!full[predict_block_row, c]) grids_color[predict_block_row, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row, c - 1]) grids_color[predict_block_row, c - 1] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row + 1, c - 1]) grids_color[predict_block_row + 1, c - 1] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row + 2, c - 1]) grids_color[predict_block_row + 2, c - 1] = Color.FromArgb(223, 223, 223);
                    break;

                // T
                case 71:
                    if (!full[predict_block_row, c]) grids_color[predict_block_row, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row, c - 1]) grids_color[predict_block_row, c - 1] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row, c + 1]) grids_color[predict_block_row, c + 1] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row - 1, c]) grids_color[predict_block_row - 1, c] = Color.FromArgb(223, 223, 223);
                    break;
                case 72:
                    if (!full[predict_block_row, c]) grids_color[predict_block_row, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row + 1, c]) grids_color[predict_block_row + 1, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row, c + 1]) grids_color[predict_block_row, c + 1] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row - 1, c]) grids_color[predict_block_row - 1, c] = Color.FromArgb(223, 223, 223);
                    break;
                case 73:
                    if (!full[predict_block_row, c]) grids_color[predict_block_row, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row, c - 1]) grids_color[predict_block_row, c - 1] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row, c + 1]) grids_color[predict_block_row, c + 1] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row + 1, c]) grids_color[predict_block_row + 1, c] = Color.FromArgb(223, 223, 223);
                    break;
                case 74:
                    if (!full[predict_block_row, c]) grids_color[predict_block_row, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row, c - 1]) grids_color[predict_block_row, c - 1] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row + 1, c]) grids_color[predict_block_row + 1, c] = Color.FromArgb(223, 223, 223);
                    if (!full[predict_block_row - 1, c]) grids_color[predict_block_row - 1, c] = Color.FromArgb(223, 223, 223);
                    break;
            }
        }

        // 檢查並回傳本次得分
        public int fullLineCheck()
        {
            int full_line = 0;  // 記錄這一次消了幾行(會影響分數)
            for (int i = 23; i >= 0; i--)
            {
                int row_sum = 0;  // 紀錄 row i 中的10格有幾格方塊
                for (int j = 0; j <10; j++)
                    if (full[i, j]) row_sum++;

                if (row_sum == 10)
                {
                    full_line++;
                    for (int j = 0; j < 10; j++)
                        full[i, j] = false;

                    for (int r = i; r >= 1; r--)
                    {
                        for (int c = 0; c < 10; c++)
                        {
                            full[r, c] = full[r - 1, c];
                            grids_color[r, c] = grids_color[r - 1, c];
                        }
                        for (int c = 0; c < 10; c++)
                        {
                            full[0, c] = false;
                            grids_color[0, c] = Color.Black;
                        }
                    }
                    i++;
                }
            }

            line_pop = full_line;
            if (full_line == 0)
            {
                combo = -1;
                return 0;
            }
            else if (full_line == 1)
            {
                combo++;
                return 0;
            }
            else if (full_line == 2)
            {
                combo++;
                return 1;
            }
            else if (full_line == 3)
            {
                combo++;
                return 2;
            }
            else if (full_line == 4)
            {
                combo++;
                return 4;
            }
            else return 0;
        }

        // 更新分數和combo數
        WMPLib.WindowsMediaPlayer sound_player = new WMPLib.WindowsMediaPlayer();
        public int updateCombo()
        {
            if (combo == 0)
            {
                sound_player.URL = "src/pop.wav";
                sound_player.controls.play();
                return 0;
            }
            else if (combo == 1)
            {
                sound_player.URL = "src/combo1.wav";
                sound_player.controls.play();
                return 1;
            }
            else if (combo == 2)
            {
                sound_player.URL = "src/combo2.wav";
                sound_player.controls.play();
                return 1;
            }
            else if (combo == 3)
            {
                sound_player.URL = "src/combo3.wav";
                sound_player.controls.play();
                return 2;
            }
            else if (combo == 4)
            {
                sound_player.URL = "src/combo4.wav";
                sound_player.controls.play();
                return 2;
            }
            else if (combo == 5)
            {
                sound_player.URL = "src/combo5.wav";
                sound_player.controls.play();
                return 3;
            }
            else if (combo == 6)
            {
                sound_player.URL = "src/combo6.wav";
                sound_player.controls.play();
                return 3;
            }
            else if (combo >= 7)
            {
                sound_player.URL = "src/combo7.wav";
                sound_player.controls.play();
                return 4;
            }
            else return 0;
        }

        // 接收對手壓力值到壓力條
        public void recievePressure(int p)
        {
            if (bar.Value + p > 20) bar.Value = 20;
            else bar.Value += p;
        }

        // TODO: 壓力條的壓力釋放 & 抵銷
    }

    public class VerticalProgressBar : ProgressBar
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x04;
                return cp;
            }
        }
    }
}
