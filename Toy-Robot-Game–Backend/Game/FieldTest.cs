using Xunit;

namespace MottMacDonald 
{
    public class FieldTest
    {
        [Fact]
        public void DefaultFieldSizeIsTwentyFive() 
        {
            Field f = new Field();
            f.initialiseField();
            int size = f.getField().Count;
            Assert.Equal(25, size);
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