namespace ChineseCheckers.Model
{
    public class Move
    {
        private Piece originPiece;
        private int rowDest, colDest;
        public Move(Piece origin, int rowDest, int colDest)
        {
            this.originPiece = new Piece(origin.row,origin.col,origin.side);
            this.rowDest = rowDest;
            this.colDest = colDest;
        }

        public Piece GetOrigin()
        {
            return originPiece;
        }

        public int GetRow()
        {
            return rowDest;
        }

        public int GetCol()
        {
            return colDest;
        }
    }

}