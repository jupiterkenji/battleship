using System;
using Xunit;

namespace flarebattleship.test
{
    public class XYPositionTest
    {
        [Fact]
        public void TestSetAndGet()
        {
            var position = new XYPosition(x: 10, y: 20);
            Assert.Equal(10, position.X);
            Assert.Equal(20, position.Y);
        }

        [Fact]
        public void TestCompare()
        {
            var equalPosition = new XYPosition(x: 10, y: 20);
            var notEqualXPosition = new XYPosition(x: 0, y: 20);
            var notEqualYPosition = new XYPosition(x: 10, y: 0);
            var notEqualPosition = new XYPosition(x: 0, y: 0);
            
            var position = new XYPosition(x: 10, y: 20);

            Assert.True(position.Equals(equalPosition));
            Assert.False(position.Equals(notEqualXPosition));
            Assert.False(position.Equals(notEqualYPosition));
            Assert.False(position.Equals(notEqualPosition));
        }
    }
}
