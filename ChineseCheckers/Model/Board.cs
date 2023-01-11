using ChineseCheckers.Model;
using System;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace ChineseCheckers
{
    public class Board
    {
        private int playerNum;
        public static int STARTX = 204;
        public static int STARTY = 72;
        public static int WIDTH = 25;
        public static int HEIGHT = 17;
        public Player player1, player2;
        public static byte[,] initmat =
        {
            { 0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,2,0,2,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,2,0,2,0,2,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,2,0,2,0,2,0,2,0,0,0,0,0,0,0,0,0 },
            { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1 },
            { 0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0 },
            { 0,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,0 },
            { 0,0,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,0,0 },
            { 0,0,0,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,0,0,0 },
            { 0,0,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,0,0 },
            { 0,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,0 },
            { 0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0 },
            { 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1 },
            { 0,0,0,0,0,0,0,0,0,3,0,3,0,3,0,3,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,3,0,3,0,3,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,3,0,3,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0 },
        };
        public byte[,] helpmat =
        {
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 }
        };

        public int[,] directions = { { -1, -1 }, { -1, 1 }, { 1, 1 }, { 1, -1 } };

        public Board(int totalNumberOfPlayers)
        {
            this.playerNum = totalNumberOfPlayers;
            if (totalNumberOfPlayers == 2)
            {
                player1 = new Player(true, this);
                player2 = new Player(false, this);
            }
            else if(totalNumberOfPlayers == 1)
            {
                player1 = new Player(true, this);
                player2 = new ComputerPlayer(false, this);
            }
        }
        public void Draw(Graphics graphics)
        {
            player1.Draw(graphics);
            player2.Draw(graphics);
        }
        public Piece getPiece(int row, int col)
        {
            Piece piece = player2.getPiece(row, col);
            if (piece == null)
                piece = player1.getPiece(row, col);

            return piece;
        }

        public Player Move(Piece piece, int rowDest, int colDest)
        {
            Player player = piece.side ? player1 : player2;
            Player other_player = !piece.side ? player1 : player2;

            if (MoveAble(piece, rowDest, colDest))
            {
                player.removePiece(piece);
                player.addPiece(rowDest, colDest, piece.side);
                if (player.CheckPlayerWin())
                    return player;
            }
            return null;
        }

        private bool MoveValid(Piece piece, int rowDest, int colDest)
        {
            if (initmat[rowDest, colDest] != 0 && getPiece(rowDest, colDest) == null)
            {
                if (rowDest == piece.row + 1 || rowDest == piece.row - 1 || rowDest == piece.row)
                {
                    if (colDest == piece.col + 1 || colDest == piece.col - 1 || colDest == piece.col)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool MoveAble(Piece piece, int rowDest, int colDest)
        {
            if (MoveValid(piece, rowDest, colDest))
            {
                return true;
            }
            else
            {
                clearHelpMat();
                return HopValid(piece, rowDest, colDest);
                
            }
        }

        public void clearHelpMat()
        {
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    helpmat[i, j] = 0;
                }
            }
        }

        private bool IsLegal(Piece piece)
        {
            return piece.row >= 0 && piece.row < HEIGHT && piece.col >= 0 && piece.col < WIDTH;
        }
        private bool HopValid(Piece piece, int rowDest, int colDest)
        {
            if (!IsLegal(piece) || initmat[piece.row, piece.col] == 0 || helpmat[piece.row, piece.col] == 1)
                return false;
            if (rowDest == piece.row && colDest == piece.col)
                return true;
            helpmat[piece.row, piece.col] = 1;
            for (int i = 0; i < directions.Length / 2; i++)
            {
                int rowN = piece.row + directions[i, 0];
                int colN = piece.col + directions[i, 1];
                int rowN2 = rowN + directions[i, 0];
                int colN2 = colN + directions[i, 1];
                if (getPiece(rowN, colN) != null)
                {
                    if (getPiece(rowN2, colN2) == null)
                    {
                        Piece pieceOther = new Piece(rowN2, colN2, piece.side);
                        if (HopValid(pieceOther, rowDest, colDest))
                            return true;
                    }
                }
            }
            return false;
        }
    }
}