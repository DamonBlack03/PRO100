using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardDisplay.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Color color, (int, int) position) : base(color, position) {}

        public override bool CanMove((int, int) position)
        {
            //if ((position.Item1 == this.Position.Item1 + 2))
            //{
            //    return true;
            //}
            //else if ((position.Item1 == Position.Item1 + 1) &&
            //         (position.Item2 == Position.Item2 || position.Item2 == Position.Item2 + 1 || position.Item2 == Position.Item2 - 1))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            return (
                        (position.Item1 == this.Position.Item1 + 2) ||
                        (
                            (position.Item1 == this.Position.Item1 + 1) && 
                            (position.Item2 == this.Position.Item2 || position.Item2 == this.Position.Item2 + 1 || position.Item2 == this.Position.Item2 - 1)
                        )
                    ) ? 
                    true : 
                    false;
            //ternary for fun cause why not
        }

    }
}
