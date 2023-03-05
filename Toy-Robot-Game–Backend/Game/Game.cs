using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottMacDonald 
{
    public class Game
    {   
        private Dictionary<Tuple<int, int>, String> field;
        private Boolean robotExists = false;
        private Tuple<int, int> robotCurrentLocation = Tuple.Create(-1,-1);

        public Game()
        {
            Field f = new Field();
            f.initialiseField();
            field = f.getField();
        }

        public void readCommand(String command)
        {
            switch (command)
            {
                case string a when a.Contains("PLACE_ROBOT"):
                    placeRobot(command);
                    break;
                case string b when b.Contains("PLACE_WALL"):
                    placeWall(command);
                    break;
                case string c when c.Contains("REPORT"):
                    report();
                    break;
                case string d when d.Contains("MOVE"):
                    move();
                    break;
                case string d when (d.Contains("LEFT") || d.Contains("RIGHT")):
                    turn(command);
                    break;
                default:
                    break;
            }
        }

        public void placeRobot(String command)
        {
            Tuple<int, int, String> location = Parser.extractCordinatesAndLocation(command);            
            var newLocation = Tuple.Create(location.Item1,location.Item2);
            
            if (location.Item1 == -1 || field[newLocation] == "WALL")
            {
                return;
            }
            
            if (robotExists)
            {
                field[robotCurrentLocation] = "empty";
            }

            field[newLocation] = location.Item3;
            robotCurrentLocation = newLocation;

            robotExists = true;
        }

        public void placeWall(String command)
        {
            Tuple<int, int, String> location = Parser.extractCordinatesAndLocation(command);
            Tuple<int,int> targetLocation = Tuple.Create(location.Item1, location.Item2); 
            if (field[targetLocation] == "empty")
            {
                field[targetLocation] = "WALL";
            }
        }

        public void report()
        {
            Console.WriteLine(robotCurrentLocation.Item1 + "," + robotCurrentLocation.Item2 + "," + field[robotCurrentLocation]);
        }

        public void move()
        {
            if (robotExists)
            {
                var robotDirection = field[robotCurrentLocation];
                var x = robotCurrentLocation.Item1;
                var y = robotCurrentLocation.Item2;
                switch (robotDirection)
                {
                    case "NORTH":
                        if(y == 5) 
                        {
                            placeRobot("PLACE_ROBOT " + new String(x + ",1") + "," + "NORTH");
                        } else { 
                            placeRobot("PLACE_ROBOT " + new String(x + "," + (y + 1)) + "," + "NORTH");
                        }
                        break;
                    case "SOUTH":
                        if(y == 1) 
                        {
                            placeRobot("PLACE_ROBOT " + new String(x + ",5") + "," + "SOUTH");
                        } else { 
                            placeRobot("PLACE_ROBOT " + new String(x + "," + (y - 1)) + "," + "SOUTH");
                        }
                        break;
                    case "WEST":
                        if(x == 1) 
                        {
                            placeRobot("PLACE_ROBOT " + new String("5" + "," + y) + "," + "WEST");
                        } else { 
                            placeRobot("PLACE_ROBOT " + new String((x - 1) + "," + y) + "," + "WEST");
                        }
                        break;
                    case "EAST":
                        if(x == 5) 
                        {
                            placeRobot("PLACE_ROBOT " + new String("1" + "," + y) + "," + "EAST");
                        } else { 
                            placeRobot("PLACE_ROBOT " + new String((x + 1) + "," + y) + "," + "EAST");
                        }
                        break;
                }
            }
        }

        public void turn(String leftOrRight)
        {
            String[] direction = new String[] { "NORTH", "EAST", "SOUTH", "WEST" };
            var currentDirection = field[robotCurrentLocation];
            var x = robotCurrentLocation.Item1;
            var y = robotCurrentLocation.Item2;
            
            if(leftOrRight == "RIGHT")
            {
                var newDirection = Array.IndexOf(direction, currentDirection) + 1 == 4 ? 0 : Array.IndexOf(direction, currentDirection) + 1;
                placeRobot("PLACE_ROBOT " + x + "," + y + "," + direction[newDirection]);
            } else
            {
                var newDirection = Array.IndexOf(direction, currentDirection) - 1 == -1 ? 3 : Array.IndexOf(direction, currentDirection) - 1;
                placeRobot("PLACE_ROBOT " + x + "," + y + "," + direction[newDirection]);
            }

        }

        public static void Main(string[] args)
        {
            Game g = new Game();
            
            g.readCommand("PLACE_ROBOT 2,2,WEST");
            g.readCommand("PLACE_WALL 1,1");
            g.readCommand("PLACE_WALL 2,2");
            g.readCommand("PLACE_WALL 1,3");
            g.readCommand("LEFT");
            g.readCommand("LEFT");
            g.readCommand("MOVE");
            g.readCommand("REPORT");
        }
    }
}