using System;
using System.Collections.Generic;
using System.Text;

namespace flarebattleship
{
    class BoardConfigurationValidation: IValidation
    {
        public BoardConfigurationValidation(int width, int height, IPosition position, Orientation orientation, int size, IEnumerable<BattleshipConfiguration> existingBattleshipConfigurations = null)
        {
            this.width = width;
            this.height = height;

            this.position = position;
            this.orientation = orientation;
            this.size = size;

            this.existingBattleshipConfigurations = existingBattleshipConfigurations;
        }

        public bool Validate(out string message)
        {
            var errorMessages = new StringBuilder();
            if (position is XYPosition xyPosition)
            {
                var boardPositionValidation = new BoardPositionValidation(width, height, position);
                string boardPositionValidationMessage;
                if (!boardPositionValidation.Validate(out boardPositionValidationMessage))
                {
                    errorMessages.Append(boardPositionValidationMessage+", ");
                }

                if (size <= 0)
                {
                    errorMessages.Append($"Size '{size}' cannot be negative, ");
                }

                string orientationAndSizeMessage;
                if (!ValidateOrientationAndSize(xyPosition, out orientationAndSizeMessage))
                {
                    errorMessages.Append(orientationAndSizeMessage+ ", ");
                }

                string existingBattleshipConfigurationsMessage;
                if (!ValidateExistingBattleshipConfigurations(xyPosition, out existingBattleshipConfigurationsMessage))
                {
                    errorMessages.Append(existingBattleshipConfigurationsMessage+ ", ");
                }

            }

            message = errorMessages.ToString().Trim(' ', ',');
            return errorMessages.Length == 0;
        }

        bool ValidateOrientationAndSize(XYPosition xyPosition, out string message)
        {
            message = "";
            switch (orientation)
            {
                case Orientation.Horizontal:
                    if (xyPosition.X + size >= width)
                    {
                        message = $"X + size ({xyPosition.X} + {size}) is bigger than width bound '{width}', ";
                        return false;
                    }
                    break;
                case Orientation.Vertical:
                    if (xyPosition.Y + size >= height)
                    {
                        message = $"Y + size ({xyPosition.Y} + {size}) is bigger than height bound '{height}', ";
                        return false;
                    }
                    break;
            }

            return true;
        }

        bool ValidateExistingBattleshipConfigurations(XYPosition xyPosition, out string message)
        {
            message = "";
            return true;
        }

        int width;
        int height;

        IPosition position;

        int size;

        Orientation orientation;

        IEnumerable<BattleshipConfiguration> existingBattleshipConfigurations;
    }
}