using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class SettingsPage : Form
    {
        SoundPlayer system_player = new SoundPlayer();  // 音樂播放器
        public int p1_drop_timer, p2_drop_timer;

        public SettingsPage()
        {
            InitializeComponent();
        }

        public void importValue()
        {
            drop_timer1.Value = p1_drop_timer;
            drop_timer2.Value = p2_drop_timer;
        }

        private void apply_btn_Click(object sender, EventArgs e)
        {
            system_player.SoundLocation = "src/button.wav";
            system_player.Play();

            p1_drop_timer = Convert.ToInt32(drop_timer1.Value);
            p2_drop_timer = Convert.ToInt32(drop_timer2.Value);

            Close();
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            system_player.SoundLocation = "src/button.wav";
            system_player.Play();
            importValue();
        }
    }
}
