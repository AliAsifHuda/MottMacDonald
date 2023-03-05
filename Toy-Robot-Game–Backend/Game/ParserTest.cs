using Xunit;

namespace MottMacDonald 
{
    public class ParserTest
    {
        [Fact]
        public void PlaceRobotIsParsingX() 
        {
            Tuple<int, int, String> location = Parser.extractCordinatesAndLocation("PLACE_ROBOT 2,2,WEST");
            Assert.Equal(2, location.Item1);
        }

        [Fact]
        public void PlaceRobotIsParsingY() 
        {
            Tuple<int, int, String> location = Parser.extractCordinatesAndLocation("PLACE_ROBOT 2,2,WEST");
            Assert.Equal(2, location.Item2);
        }

        [Fact]
        public void PlaceRobotIsParsingDirection() 
        {
            Tuple<int, int, String> location = Parser.extractCordinatesAndLocation("PLACE_ROBOT 2,2,WEST");
            Assert.Equal("WEST", location.Item3);
        }

        [Fact]
        public void PlaceRobotIsParsingX1() 
        {
            Tuple<int, int, String> location = Parser.extractCordinatesAndLocation("PLACE_ROBOT 0,0,NORTH");
            Assert.Equal(0, location.Item1);
        }

        [Fact]
        public void PlaceRobotIsParsingY1() 
        {
            Tuple<int, int, String> location = Parser.extractCordinatesAndLocation("PLACE_ROBOT 0,0,NORTH");
            Assert.Equal(0, location.Item2);
        }

        [Fact]
        public void PlaceRobotIsParsingDirection1() 
        {
            Tuple<int, int, String> location = Parser.extractCordinatesAndLocation("PLACE_ROBOT 0,0,NORTH");
            Assert.Equal("NORTH", location.Item3);
        }

        [Fact]
        public void PlaceWallIsParsingX() 
        {
            Tuple<int, int, String> location = Parser.extractCordinatesAndLocation("PLACE_ROBOT 2,2");
            Assert.Equal(2, location.Item1);
        }

        [Fact]
        public void PlaceWallIsParsingY() 
        {
            Tuple<int, int, String> location = Parser.extractCordinatesAndLocation("PLACE_ROBOT 2,2");
            Assert.Equal(2, location.Item2);
        }

        [Fact]
        public void PlaceWallIsParsingDirection() 
        {
            Tuple<int, int, String> location = Parser.extractCordinatesAndLocation("PLACE_WALL 2,2");
            Assert.Equal("x", location.Item3);
        }

        [Fact]
        public void PlaceWallIsParsingX1() 
        {
            Tuple<int, int, String> location = Parser.extractCordinatesAndLocation("PLACE_WALL 0,0");
            Assert.Equal(0, location.Item1);
        }

        [Fact]
        public void PlaceWallIsParsingY1() 
        {
            Tuple<int, int, String> location = Parser.extractCordinatesAndLocation("PLACE_WALL 0,0");
            Assert.Equal(0, location.Item2);
        }

        [Fact]
        public void PlaceWallIsParsingDirection1() 
        {
            Tuple<int, int, String> location = Parser.extractCordinatesAndLocation("PLACE_WALL 0,0");
            Assert.Equal("x", location.Item3);
        }

        [Theory]
        [InlineData(3)]
        public void FieldOfDifferentMatrixSizeShouldBeValid(int dimension)
        {
            Field f = new Field();
            f.initialiseField(dimension);
            int size = f.getField().Count;
            Assert.Equal(9, size);
        } 
    }
}