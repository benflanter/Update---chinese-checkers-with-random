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
    public partial class GameForm : Form
    {
        GameConroller gameConroller;
        public GameForm(int num)
        {
            InitializeComponent();
            gameConroller = new GameConroller(this, num);
            this.Size = new Size( 170*2+55*13, 83+47*17+5);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            gameConroller.Draw(e.Graphics);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int col = (e.X - Board.STARTX + 10) / Piece.X_STEP;
            int row = (e.Y - Board.STARTY) / Piece.Y_STEP;

            gameConroller.Click(row, col);
            pictureBox1.Invalidate();
        }
    }
}
