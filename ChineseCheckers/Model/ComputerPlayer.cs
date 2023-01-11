using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCheckers.Model
{
    class ComputerPlayer : Player
    {
        private Random random = new Random();
        

        public ComputerPlayer(bool side, Board board) :base(side, board)
		{
        }

        public void MakeMove()
        {
            List<Move> moves = GetMoves();
            int index = random.Next(0, moves.Count);
            if (moves.Count > 0)
            {
                removePiece(moves[index].GetOrigin());
                addPiece(moves[index].GetRow(), moves[index].GetCol(), side);
            }
        }
    }
}
