using Xunit;

namespace MottMacDonald 
{
    public class FieldTest
    {
        [Fact]
        public void DefaultFieldSizeIsTwentyFive() 
        {
            Field f = new Field();
            f.InitialiseField();
            int size = f.GetField().Count;
            Assert.Equal(25, size);
        }

        [Fact]
        public void GetFieldCorrectlyReturnsField() 
        {
            Field f = new Field();
            f.InitialiseField();
            int size = f.GetField().Count;
            Assert.Equal(25, size);
        }

        [Theory]
        [InlineData(3)]
        public void FieldOfDifferentMatrixSizeShouldBeValid(int dimension)
        {
            Field f = new Field();
            f.InitialiseField(dimension);
            int size = f.GetField().Count;
            Assert.Equal(9, size);
        } 
    }
}