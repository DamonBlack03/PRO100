using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardDisplay.Pieces
{
    public abstract class Piece
    {
        public Color PieceColor { get; set; }
        public (int, int) Position { get; set; }
        public abstract bool CanMove((int, int) position);
    }
}
