using System;
using System.Text;

namespace flarebattleship
{
    class BoardValidation: BoardConfigurationValidation
    {
        public BoardValidation(Board board, IPosition position)
            : base(board.Width, board.Height, position)
        {
        }
    }
}