using System;
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
            var validation = new BoardConfigurationValidation(width: 100, height: 100, position: negativeXPosition);
            Assert.False(validation.Validate(out message));
            Assert.Equal("X position '-1' cannot be negative", message);

            var outOfBoundXPosition = new XYPosition(x: 100, y: 10);
            validation = new BoardConfigurationValidation(width: 100, height: 100, position: outOfBoundXPosition);
            Assert.False(validation.Validate(out message));
            Assert.Equal("X position '100' is outside the board width bound '100'", message); // 0-start-index

            var negativeYPosition = new XYPosition(x: 10, y: -1);
             validation = new BoardConfigurationValidation(width: 100, height: 100, position: negativeYPosition);
            Assert.False(validation.Validate(out message));
            Assert.Equal("Y position '-1' cannot be negative", message);

            var outOfBoundYPosition = new XYPosition(x: 10, y: 100);
            validation = new BoardConfigurationValidation(width: 100, height: 100, position: outOfBoundYPosition);
            Assert.False(validation.Validate(out message));
            Assert.Equal("Y position '100' is outside the board height bound '100'", message); // 0-start-index
        }
    }
}
