using ChineseCheckers.Model;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace ChineseCheckers
{
	public class Player
	{
        protected Dictionary<int, Piece> pieces;
	    public bool side;
        private Piece scannedPiece; 
		protected Board board;
        

        public Player(bool side, Board board)
		{
			this.board = board;
			this.side = side;
			pieces = new Dictionary<int, Piece>();
			if (side) // up side
            {
				for (int i = 0; i < 4; i++)
					for (int j = 0; j < Board.WIDTH; j++)
					{
						if (Board.initmat[i, j] == 2)
							pieces.Add(i * Board.WIDTH + j, new Piece(i, j, side));
					}
			}
            else // down side
            {
				for (int i = Board.HEIGHT - 4; i < Board.HEIGHT; i++)
					for (int j = 0; j < Board.WIDTH; j++)
					{
						if (Board.initmat[i, j] == 3)
							pieces.Add(i * Board.WIDTH + j, new Piece(i, j, side));
					}
			}
		}
		public void Draw(Graphics graphics)
		{
			foreach (Piece piece in pieces.Values)
				piece.Draw(graphics);
		}
		public Piece getPiece(int row, int col)
		{
			int key = row * Board.WIDTH + col;
			if (!pieces.ContainsKey(key))
				return null;
			return pieces[key];
		}
		public void removePiece(Piece piece)
		{
			int key = piece.row * Board.WIDTH + piece.col;
			pieces.Remove(key);
		}
		public void addPiece(int rowDest, int colDest, bool side)
		{
			int key = rowDest * Board.WIDTH + colDest;
			pieces.Add(key, new Piece(rowDest, colDest, side));
		}
		public bool CheckPlayerWin()
		{
			Piece piece;
			if (this.side)
			{	//player is up, checking down
				for (int i = Board.HEIGHT - 4; i < Board.HEIGHT; i++)
				{
					for (int j = 0; j < Board.WIDTH; j++)
					{
						if (Board.initmat[i, j] == 3)
						{
							piece = getPiece(i, j);
							if (piece == null || piece.side != this.side)
								return false;
						}
					}
				}
				return true;
			}
			else
            {   //player is down, checking up
                for (int i = 0; i < 4; i++)
				{
					for (int j = 0; j < Board.WIDTH; j++)
					{
                        if(Board.initmat[i, j] == 2)
                        {
                            piece = getPiece(i, j);
                            if (piece == null|| piece.side != this.side)
                                return false;
                        }
                    }
				}
				return true;
            }
		}

        public List<Move> GetMoves()
        {
            List<Move> moves = new List<Move>();
            foreach (KeyValuePair<int, Piece> piece in pieces)
            {
                List<Move> nearMoves = GetNearMoves(piece.Value);
                List<Move> farMoves = GetFarMoves(piece.Value);
                if (nearMoves != null)
                    moves.AddRange(nearMoves);
                if (farMoves != null)
                    moves.AddRange(farMoves);
            }
            return moves;
        }

        public List<Move> GetMovesForPiece(Piece piece)
        {
            List<Move> moves = GetNearMoves(piece);
            moves.AddRange(GetFarMoves(piece));
            return moves;
        }

        private List<Move> GetNearMoves(Piece piece)
        {
            List<Move> moves = new List<Move>();
            for (int i = 0; i < board.directions.Length / 2; i++)
            {
                int row = piece.row + board.directions[i, 0];
                int col = piece.col + board.directions[i, 1];
                if (row >= 0 && row < Board.HEIGHT && col >= 0 && col < Board.WIDTH)
                {
                    if (Board.initmat[row, col] != 0 && board.getPiece(row, col) == null)
                        moves.Add(new Move(piece, row, col));
                }
            }
            return moves;
        }

        private List<Move> GetFarMoves(Piece piece)
        {
            List<Move> moves = new List<Move>();
            scannedPiece = piece;
            board.clearHelpMat();
            ScanFarMoves(piece, moves);
            return moves;
        }


        private void ScanFarMoves(Piece Piece, List<Move> moves)
        {
            if (board.helpmat[Piece.row, Piece.col] == 1 || Board.initmat[Piece.row, Piece.col] == 0)
                return;
            board.helpmat[Piece.row, Piece.col] = 1;
            for (int i = 0; i < board.directions.Length / 2; i++)
            {
                int row = Piece.row + board.directions[i, 0];
                int col = Piece.col + board.directions[i, 1];
                if (Islegal(row, col) && board.getPiece(row, col) != null)
                {
                    int nextRow = row + board.directions[i, 0];
                    int nextCol = col + board.directions[i, 1];
                    if (Islegal(nextRow, nextCol) && board.getPiece(nextRow, nextCol) == null)
                    {
                        Piece nextPiece = new Piece(nextRow, nextCol, Piece.side);
                        moves.Add(new Move(scannedPiece, nextRow, nextCol));
                        ScanFarMoves(nextPiece, moves);
                    }
                }
            }
            return;
        }

        private bool Islegal(int row, int col)
        {
            return row >= 0 && row < Board.HEIGHT && col >= 0 && col < Board.WIDTH && Board.initmat[row, col] != 0;
        }
    }
}