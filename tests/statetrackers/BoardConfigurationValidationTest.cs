using System;
using System.Linq;
using Xunit;

namespace flarebattleship.test
{
    public class BoardConfigurationValidationTest
    {
        [Fact]
        public void Validate()
        {
            string message;

            var negativeXPosition = new XYPosition(x: -1, y: 10);
            var validation = new BoardConfigurationValidation(width: 100, height: 100, position: negativeXPosition, orientation: Orientation.Horizontal, size: 2);
            Assert.False(validation.Validate(out message));
            Assert.Equal("X position '-1' cannot be negative", message);

            var outOfBoundXPosition = new XYPosition(x: 100, y: 10);
            validation = new BoardConfigurationValidation(width: 100, height: 100, position: outOfBoundXPosition, orientation: Orientation.Horizontal, size: 2);
            Assert.False(validation.Validate(out message));
            Assert.Contains("X position '100' is outside the board width bound '100'", message); // 0-start-index

            var negativeYPosition = new XYPosition(x: 10, y: -1);
             validation = new BoardConfigurationValidation(width: 100, height: 100, position: negativeYPosition, orientation: Orientation.Horizontal, size: 2);
            Assert.False(validation.Validate(out message));
            Assert.Equal("Y position '-1' cannot be negative", message);

            var outOfBoundYPosition = new XYPosition(x: 10, y: 100);
            validation = new BoardConfigurationValidation(width: 100, height: 100, position: outOfBoundYPosition, orientation: Orientation.Horizontal, size: 2);
            Assert.False(validation.Validate(out message));
            Assert.Equal("Y position '100' is outside the board height bound '100'", message); // 0-start-index
        }
    }
}
