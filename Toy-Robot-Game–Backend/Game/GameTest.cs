using Xunit;

namespace MottMacDonald 
{
    public class GameTest
    {
        [Fact]
        public void ReadCommandIgnoresInvalidCommand()
        {
            Game game = new Game();
            game.ReadCommand("xyz 2,3,NORTH");
            var location = game.GetRobotLocation();

            Assert.Equal(Tuple.Create(-1,-1), location);
        }

        [Fact]
        public void ReadCommandCallsPlaceRobot() 
        {
            Game game = new Game();
            game.ReadCommand("PLACE_ROBOT 2,3,NORTH");
            var location = game.GetRobotLocation();
            
            Assert.Equal(Tuple.Create(2,3), location);
        }

        [Fact]
        public void ReadCommandCallsPlaceRobotTwice() 
        {
            Game game = new Game();
            game.ReadCommand("PLACE_ROBOT 2,3,NORTH");
            game.ReadCommand("PLACE_ROBOT 2,5,NORTH");
            var location = game.GetRobotLocation();
            
            Assert.Equal(Tuple.Create(2,5), location);
        }

        [Fact]
        public void ReadCommandCallsPlaceRobotInvalid() 
        {
            Game game = new Game();
            game.ReadCommand("PLACE_ROBOT 6,3,NORTH");
            var location = game.GetRobotLocation();
            
            Assert.Equal(Tuple.Create(-1,-1), location);
        }

        [Fact]
        public void ReadCommandCallsPlaceRobotInvalidDirection() 
        {
            Game game = new Game();
            game.ReadCommand("PLACE_ROBOT 6,3,CENTER");
            var location = game.GetRobotLocation();
            
            Assert.Equal(Tuple.Create(-1,-1), location);
        }

        [Fact]
        public void ReadCommandCallsPlaceRobotInvalidAtWallLoction() 
        {
            Game game = new Game();
            game.ReadCommand("PLACE_WALL 2,3");
            game.ReadCommand("PLACE_ROBOT 2,3,NORTH");
            var location = game.GetRobotLocation();
            
            Assert.Equal(Tuple.Create(-1,-1), location);
        }

        [Fact]
        public void ReadCommandCallsPlaceRobotInvalidAtWallLoctionThenValid() 
        {
            Game game = new Game();
            game.ReadCommand("PLACE_WALL 2,3");
            game.ReadCommand("PLACE_ROBOT 2,3,NORTH");            
            game.ReadCommand("PLACE_ROBOT 2,2,NORTH");
            var location = game.GetRobotLocation();
            
            Assert.Equal(Tuple.Create(2,2), location);
        }

        [Fact]
        public void moveCommandOnNonExistentRobot() 
        {
            Game game = new Game();
            game.ReadCommand("MOVE");
            var location = game.GetRobotLocation();
            
            Assert.Equal(Tuple.Create(-1,-1), location);
        }

        [Fact]
        public void moveCommandNorth() 
        {
            Game game = new Game();
            game.ReadCommand("PLACE_ROBOT 3,3,NORTH"); 
            game.ReadCommand("MOVE");
            var location = game.GetRobotLocation();
            
            Assert.Equal(Tuple.Create(3,4), location);
        }

        [Fact]
        public void moveCommandSouth() 
        {
            Game game = new Game();            
            game.ReadCommand("PLACE_ROBOT 3,3,SOUTH"); 
            game.ReadCommand("MOVE");
            var location = game.GetRobotLocation();
            
            Assert.Equal(Tuple.Create(3,2), location);
        }

        [Fact]
        public void turnLEFTCommandEast() 
        {
            Game game = new Game();
             game.ReadCommand("PLACE_ROBOT 3,3,EAST"); 
            game.ReadCommand("MOVE");
            var location = game.GetRobotLocation();
            
            Assert.Equal(Tuple.Create(4,3), location);
        }

        [Fact]
        public void turnRIGHTCommandWest() 
        {
            Game game = new Game(); 
            game.ReadCommand("PLACE_ROBOT 3,3,WEST"); 
            game.ReadCommand("MOVE");
            var location = game.GetRobotLocation();
            
            Assert.Equal(Tuple.Create(2,3), location);
        }
    }
}