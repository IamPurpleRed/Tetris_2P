using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class AboutPage : Form
    {
        string[] special_thanks =
        {
            
        };

        public AboutPage()
        {
            InitializeComponent();

            for (int i = 0; i < special_thanks.Length; i++)
            {
                special_thanks_list.Text += special_thanks[i] + "    ";
                if (i > 0 && i % 5 == 0) special_thanks_list.Text += "\r\n";
            }
        }

        private void github_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/PurpleRed0602/Tetris_2P");
        }
    }
}
