using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChineseCheckers
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void buttonOnePlayer_Click(object sender, EventArgs e)
        {
            Hide();
            (new GameForm(1)).ShowDialog();
            Show();
        }

        private void buttonTwoPlayers_Click(object sender, EventArgs e)
        {
            Hide();
            (new GameForm(2)).ShowDialog();
            Show();

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
