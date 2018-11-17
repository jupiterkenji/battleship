using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace flarebattleship.test
{
    public class XYBattleshipBuilderTest
    {
        [Fact]
        public void TestBuild_Horizonta()
        {
            var position = new XYPosition(x: 50, y: 50);

            var horizontalBattleship = BattleshipBuilderProvider.GetBuilder(Orientation.Horizontal).Build(position, 3);
            var horizontalBattleshipForTest = new XYBattleshipForTest(horizontalBattleship);
            var xyOccupiedPositions = horizontalBattleshipForTest
                .OccupiedPositionsForTest
                .Select(occupiedPosition => occupiedPosition.Position)
                .Cast<XYPosition>()
                .Select(occupiedPosition => $"{occupiedPosition.X},{occupiedPosition.Y}");
            Assert.Equal(new[] {"50,50", "51,50", "52,50"}, xyOccupiedPositions.ToArray());
        }

                [Fact]
        public void TestBuild_Vertical()
        {
            var position = new XYPosition(x: 50, y: 50);

            var verticalBattleship = BattleshipBuilderProvider.GetBuilder(Orientation.Vertical).Build(position, 3);
            var verticalBattleshipForTest = new XYBattleshipForTest(verticalBattleship);
            var xyOccupiedPositions = verticalBattleshipForTest
                .OccupiedPositionsForTest
                .Select(occupiedPosition => occupiedPosition.Position)
                .Cast<XYPosition>()
                .Select(occupiedPosition => $"{occupiedPosition.X},{occupiedPosition.Y}");
            Assert.Equal(new[] {"50,50", "50,51", "50,52"}, xyOccupiedPositions.ToArray());
        }
    }

    class XYBattleshipForTest: XYBattleship
    {
        public XYBattleshipForTest(XYBattleship battleship): base(Enumerable.Empty<IOccupiedPosition>())
        {
            this.CloneFrom(battleship);
        }

        public IEnumerable<IOccupiedPosition> OccupiedPositionsForTest => occupiedPositions;
    }
}
