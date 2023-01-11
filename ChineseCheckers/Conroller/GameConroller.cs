using ChineseCheckers.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChineseCheckers
{
    class GameConroller
    {
        public Board board;
        public Player turn;
        private Piece piece_choose;
        private GameForm gameForm;
        public GameConroller(GameForm gameForm, int num)
        {
            board = new Board(num);
            this.gameForm = gameForm;
            this.turn = board.player1;
            gameForm.labelTurn.ForeColor = Color.Black;

        }

        public void Click(int row, int col)
        {
            if (Board.initmat[row, col] == 0)
                col--;
            Piece piece = board.getPiece(row, col);
            if (piece != null)
                piece_choose = piece;
            else
            {
                if (piece_choose != null && piece_choose.side == turn.side)
                {
                    Player player = board.Move(piece_choose, row, col);
                    turn = (turn == board.player1 ? board.player2 : board.player1);
                    gameForm.labelTurn.ForeColor = turn == board.player1 ? Color.Black : Color.Red;
                    if (player != null)
                    {
                        // Game over
                        string mes = player.side ? "Gray player won" : "Red player won";
                        MessageBox.Show(mes, "Game over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.gameForm.Close();
                    }
                    else
                    {
                        piece_choose = null;
                        if (board.player2 is ComputerPlayer)
                        {
                            turn = board.player2;
                            (board.player2 as ComputerPlayer).MakeMove();
                            turn = board.player1;
                        }
                    }
                }
            }
        }

        public void Draw(Graphics graphics)
        {
            board.Draw(graphics);
            if (piece_choose != null && piece_choose.side == turn.side)
            {
                graphics.DrawEllipse(new Pen(Color.Green, 5), piece_choose.col * Piece.X_STEP + Board.STARTX - 10,
                                                             piece_choose.row * Piece.Y_STEP + Board.STARTY,
                                                             Piece.PieceSize + 6, Piece.PieceSize);


                List<Move> moves = turn.GetMovesForPiece(piece_choose);
                foreach(var move in moves) {
                int i = move.GetRow(), j = move.GetCol();
                graphics.DrawEllipse(new Pen(Color.Yellow, 5), j * Piece.X_STEP + Board.STARTX - 10,
                                                                i * Piece.Y_STEP + Board.STARTY,
                                                                 Piece.PieceSize + 6, Piece.PieceSize);
                          
                }
            }
        }
    }
}