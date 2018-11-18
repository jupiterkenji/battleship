using System;
using System.Text;

namespace flarebattleship
{
    class BoardPositionValidation: IValidation
    {
        public BoardPositionValidation(int width, int height, IPosition position)
       {
            this.width = width;
            this.height = height;

            this.position = position;
        }

        public bool Validate(out string message)
        {
            var errorMessages = new StringBuilder();
            if (position is XYPosition xyPosition)
            {
                if (xyPosition.X < 0)
                {
                    errorMessages.Append($"X position '{xyPosition.X}' cannot be negative, ");
                }

                if (xyPosition.X >= width)
                {
                    errorMessages.Append($"X position '{xyPosition.X}' is outside the board width bound '{width}', ");
                }

                if (xyPosition.Y < 0)
                {
                    errorMessages.Append($"Y position '{xyPosition.Y}' cannot be negative, ");
                }

                if (xyPosition.Y >= height)
                {
                    errorMessages.Append($"Y position '{xyPosition.Y}' is outside the board height bound '{height}', ");
                }
            }

            message = errorMessages.ToString().Trim(' ', ',');
            return errorMessages.Length == 0;
        }

        int width;

        int height;

        IPosition position;
    }
}