namespace BoardDisplay.Models
{
    public class BoardPosition
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public BoardPosition(int row, int column)
        {
            Row = row;
            Column = column;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is BoardPosition other)
            {
                return Row == other.Row & Column == other.Column;
            }

            return false;
        }
    }
}
