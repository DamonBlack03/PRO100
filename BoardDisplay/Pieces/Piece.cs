using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardDisplay.Pieces
{
    public abstract class Piece
    {
        public Piece(Color color, (int, int) position)
        {
            this.PieceColor = color;
            this.Position = position;
        }
        public Color PieceColor { get; set; }
        public (int, int) Position { get; set; }

        public abstract bool CanMove((int, int) position);
    }
}
