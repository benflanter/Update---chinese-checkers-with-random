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
		private bool jumpWasMade;
        public Player player1, player2;
		public static byte [,] initmat =
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

        int[,] directions = { {-1,-1 },{-1,1},{1,1},{1,-1} };

        public Board(int totalNumberOfPlayers)
		{
            this.playerNum = totalNumberOfPlayers;
			if (totalNumberOfPlayers == 2)
			{
				player1 = new Player(true);
				player2 = new Player(false);
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
			jumpWasMade = false;
            Player player = piece.side ? player1 : player2;
			Player other_player = !piece.side ? player1 : player2;
			if (player.playerTurn)
			{
				if (MoveAble(piece, rowDest, colDest))
				{
					player.removePiece(piece);
					player.addPiece(rowDest, colDest, piece.side);
                    if (player.CheckPlayerWin())
                        return player;
					player.playerTurn = !player.playerTurn;
					other_player.playerTurn = !other_player.playerTurn;
					if (jumpWasMade)
						jumpWasMade = false;

                }
			}
            return null;
		}

		public bool MoveValid(Piece piece, int rowDest, int colDest)
		{
			if ( initmat[rowDest, colDest] != 0)
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

        public bool JumpValid(Piece piece, int rowDest, int colDest)
		{
            if (initmat[rowDest, colDest] != 0 && getPiece(rowDest, colDest) ==null)
			{
				if (piece.row - 2 == rowDest && piece.col - 2 == colDest)
				{
					if (getPiece(piece.row - 1, piece.col - 1) != null )
					{
                        return true;
					}
				}
				else if (piece.row + 2 == rowDest && piece.col + 2 == colDest)
				{
					if (getPiece(piece.row + 1, piece.col + 1) != null )
					{
                        return true;
                    }
				}

				else if (piece.row + 2 == rowDest && piece.col - 2 == colDest)
				{
					if (getPiece(piece.row + 1, piece.col - 1) != null )
					{
						return true;
					}
				}

				else if (piece.row - 2 == rowDest && piece.col + 2 == colDest)
				{
					if (getPiece(piece.row - 1, piece.col + 1) != null)
					{
						return true;
					}
				}
                return false;
            }
			return false;
        }

        public bool CheckJump(Piece piece, int x, int y)
        {
            if (piece.row + x >= 0 && piece.row + x < HEIGHT)
            {
                if (piece.col + y >= 0 && piece.col + y < WIDTH)
                    return JumpValid(piece, piece.row + x, piece.col + y);
                        
            }
            return false;
        }

		public bool DoubleJumpValid(Piece piece, int rowDest, int colDest)
		{
            jumpWasMade = false;
            Piece otherPiece;
            int up = 2, down = -2;
			if(CheckJump(piece, up, up))
			{
                otherPiece = new Piece(piece.row + up, piece.col + up, piece.side);
				if(CheckJump(otherPiece, up, up) && getPiece(otherPiece.row + (up/2), otherPiece.col + (up/2)) != null )
				{
                    jumpWasMade = true;
                    if (JumpValid(otherPiece, rowDest, colDest))
                    {
                        jumpWasMade = false;
                        return true;
                    }
                }
				jumpWasMade = false;
                if (CheckJump(otherPiece, up, down) && getPiece(otherPiece.row + (up / 2), otherPiece.col + (down / 2)) != null)
                {
                    jumpWasMade = true;
                    if (JumpValid(otherPiece, rowDest, colDest))
                    {
                        jumpWasMade = false;
                        return true;
                    }
                }
                jumpWasMade = false;
                if (CheckJump(otherPiece, down, down) && getPiece(otherPiece.row + (down / 2), otherPiece.col + (down / 2)) != null)
                {
                    jumpWasMade = true;
                    if (JumpValid(otherPiece, rowDest, colDest))
                    {
                        jumpWasMade = false;
                        return true;
                    }
                }
                jumpWasMade = false;
                if (CheckJump(otherPiece, down, up) && getPiece(otherPiece.row + (down / 2), otherPiece.col + (up / 2)) != null)
                {
                    jumpWasMade = true;
                    if (JumpValid(otherPiece, rowDest, colDest))
                    {
                        jumpWasMade = false;
                        return true;
                    }
                }
                jumpWasMade = false;
            }
            if (CheckJump(piece, down, up))
            {
                otherPiece = new Piece(piece.row + down, piece.col + up, piece.side);
                if (CheckJump(otherPiece, up, up) && getPiece(otherPiece.row + (up / 2), otherPiece.col + (up / 2)) != null)
                {
                    jumpWasMade = true;
                    if (JumpValid(otherPiece, rowDest, colDest))
                    {
                        jumpWasMade = false;
                        return true;
                    }
                }
                jumpWasMade = false;
                if (CheckJump(otherPiece, up, down) && getPiece(otherPiece.row + (up / 2), otherPiece.col + (down / 2)) != null)
                {
                    jumpWasMade = true;
                    if (JumpValid(otherPiece, rowDest, colDest))
                    {
                        jumpWasMade = false;
                        return true;
                    }
                }
                jumpWasMade = false;
                if (CheckJump(otherPiece, down, down) && getPiece(otherPiece.row + (down / 2), otherPiece.col + (down / 2)) != null)
                {
                    jumpWasMade = true;
                    if (JumpValid(otherPiece, rowDest, colDest))
                    {
                        jumpWasMade = false;
                        return true;
                    }
                }
                jumpWasMade = false;
                if (CheckJump(otherPiece, down, up) && getPiece(otherPiece.row + (down / 2), otherPiece.col + (up / 2)) != null)
                {
                    jumpWasMade = true;
                    if (JumpValid(otherPiece, rowDest, colDest))
                    {
                        jumpWasMade = false;
                        return true;
                    }
                }
                jumpWasMade = false;
            }
            if (CheckJump(piece, up, down))
            {
                otherPiece = new Piece(piece.row + up, piece.col + down, piece.side);
                if (CheckJump(otherPiece, up, up) && getPiece(otherPiece.row + (up / 2), otherPiece.col + (up / 2)) != null)
                {
                    jumpWasMade = true;
                    if (JumpValid(otherPiece, rowDest, colDest))
                    {
                        jumpWasMade = false;
                        return true;
                    }
                }
                jumpWasMade = false;
                if (CheckJump(otherPiece, up, down) && getPiece(otherPiece.row + (up / 2), otherPiece.col + (down / 2)) != null)
                {
                    jumpWasMade = true;
                    if (JumpValid(otherPiece, rowDest, colDest))
                    {
                        jumpWasMade = false;
                        return true;
                    }
                }
                jumpWasMade = false;
                if (CheckJump(otherPiece, down, down) && getPiece(otherPiece.row + (down / 2), otherPiece.col + (down / 2)) != null)
                {
                    jumpWasMade = true;
                    if (JumpValid(otherPiece, rowDest, colDest))
                    {
                        jumpWasMade = false;
                        return true;
                    }
                }
                jumpWasMade = false;
                if (CheckJump(otherPiece, down, up) && getPiece(otherPiece.row + (down / 2), otherPiece.col + (up / 2)) != null)
                {
                    jumpWasMade = true;
                    if (JumpValid(otherPiece, rowDest, colDest))
                    {
                        jumpWasMade = false;
                        return true;
                    }
                }
                jumpWasMade = false;
            }
            if (CheckJump(piece, down, down))
            {
                otherPiece = new Piece(piece.row + down, piece.col + down, piece.side);
                if (CheckJump(otherPiece, up, up) && getPiece(otherPiece.row + (up / 2), otherPiece.col + (up / 2)) != null)
                {
                    jumpWasMade = true;
                    if (JumpValid(otherPiece, rowDest, colDest))
                    {
                        jumpWasMade = false;
                        return true;
                    }
                }
                jumpWasMade = false;
                if (CheckJump(otherPiece, up, down) && getPiece(otherPiece.row + (up / 2), otherPiece.col + (down / 2)) != null)
                {
                    jumpWasMade = true;
                    if (JumpValid(otherPiece, rowDest, colDest))
                    {
                        jumpWasMade = false;
                        return true;
                    }
                }
                jumpWasMade = false;
                if (CheckJump(otherPiece, down, down) && getPiece(otherPiece.row + (down / 2), otherPiece.col + (down / 2)) != null)
                {
                    jumpWasMade = true;
                    if (JumpValid(otherPiece, rowDest, colDest))
                    {
                        jumpWasMade = false;
                        return true;
                    }
                }
                jumpWasMade = false;
                if (CheckJump(otherPiece, down, up) && getPiece(otherPiece.row + (down / 2), otherPiece.col + (up / 2)) != null)
                {
                    jumpWasMade = true;
                    if (JumpValid(otherPiece, rowDest, colDest))
                    {
                        jumpWasMade = false;
                        return true;
                    }
                }
                jumpWasMade = false;
            }
            return false;
        }

        public bool TripleJumpValid(Piece piece, int rowDest, int colDest)
        {
            Piece otherPiece;
            int up = 2, down = -2;
            if (CheckJump(piece, up, up))
            {
                otherPiece = new Piece(piece.row + up, piece.col + up, piece.side);
                if (DoubleJumpValid(otherPiece, rowDest, colDest) && getPiece(otherPiece.row + (up / 2), otherPiece.col + (up / 2)) != null)
                    return true;
            }
            if (CheckJump(piece, down, up))
            {
                otherPiece = new Piece(piece.row + down, piece.col + up, piece.side);
                if (DoubleJumpValid(otherPiece, rowDest, colDest) && getPiece(otherPiece.row + (down / 2), otherPiece.col + (up / 2)) != null)
                    return true;
            }
            if (CheckJump(piece, down, down))
            {
                otherPiece = new Piece(piece.row + down, piece.col + down, piece.side);
                if (DoubleJumpValid(otherPiece, rowDest, colDest)&& getPiece(otherPiece.row + (down / 2), otherPiece.col + (down / 2)) != null)
                    return true;
            }
            if (CheckJump(piece, up, down))
            {
                otherPiece = new Piece(piece.row + up, piece.col + down, piece.side);
                if (DoubleJumpValid(otherPiece, rowDest, colDest)&& getPiece(otherPiece.row + (up / 2), otherPiece.col + (down / 2)) != null)
                    return true;
            }
            return false;
        }

        public bool HopValid1(Piece piece, int rowDest, int colDest)
        {
            Piece otherPiece;
            int up = 2, down = -2;
            if (JumpValid(piece, rowDest, colDest))
                return true;
            if (!(CheckJump(piece, up, up)) && !(CheckJump(piece, down, up)) && !(CheckJump(piece, down, down)) && !(CheckJump(piece, up, down)))
                return false;
            if (CheckJump(piece, up, up))
            {
                otherPiece = new Piece(piece.row + up, piece.col + up, piece.side);
                if (getPiece(otherPiece.row + (up / 2), otherPiece.col + (up / 2)) != null)
                    if (HopValid1(otherPiece, rowDest, colDest))
                        return true;
            }
            if (CheckJump(piece, down, up))
            {
                otherPiece = new Piece(piece.row + down, piece.col + up, piece.side);
                if (getPiece(otherPiece.row + (down / 2), otherPiece.col + (up / 2)) != null)
                    if (HopValid1(otherPiece, rowDest, colDest))
                        return true;
            }
            if (CheckJump(piece, up, down))
            {
                otherPiece = new Piece(piece.row + up, piece.col + down, piece.side);
                if (getPiece(otherPiece.row + (up / 2), otherPiece.col + (down / 2)) != null)
                    if (HopValid1(otherPiece, rowDest, colDest))
                        return true;
            }
            if (CheckJump(piece, down, down))
            {
                otherPiece = new Piece(piece.row + down, piece.col + down, piece.side);
                if (getPiece(otherPiece.row + (down / 2), otherPiece.col + (down / 2)) != null)
                    if (HopValid1(otherPiece, rowDest, colDest))
                        return true;
            }
            return false;
        }

        public bool MoveAble(Piece piece, int rowDest, int colDest)
		{
            if (MoveValid(piece, rowDest, colDest))
                return true;
            //else if (JumpValid(piece, rowDest, colDest))
            //	return true;
            //else if (DoubleJumpValid(piece, rowDest, colDest))
            //{
            //             jumpWasMade = false;
            //             return true;
            //}
            //         else if (TripleJumpValid(piece, rowDest, colDest))
            //         {
            //             jumpWasMade = false;
            //             return true;
            //         }
            else
            {
                clearHelpMat();
                return HopValid(piece, rowDest, colDest);
            }
        }

        private void clearHelpMat()
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
            return piece.row >= 0 && piece.row <= HEIGHT && piece.col >= 0 && piece.col <= WIDTH;
        }
        public bool HopValid(Piece piece, int rowDest, int colDest)
        {
            if ( !IsLegal(piece) || initmat[piece.row, piece.col] == 0 || helpmat[piece.row, piece.col] == 1)
                return false;
            if (rowDest == piece.row && colDest == piece.col)
                return true;
            helpmat[piece.row, piece.col] = 1;
            for (int i = 0; i < directions.Length/2; i++)
            {
                int rowN = piece.row + directions[i, 0];
                int colN = piece.col + directions[i, 1];
                int rowN2 = rowN + directions[i, 0];
                int colN2 = colN + directions[i, 1];
                Piece piece1 = player1.getPiece(rowN, colN);
                Piece piece2 = player2.getPiece(rowN, colN);
                if (piece1 != null || piece2 != null)
                {
                    Piece piece11 = player1.getPiece(rowN2, colN2);
                    Piece piece21 = player2.getPiece(rowN2, colN2);
                    if (piece11 == null && piece21 == null)
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