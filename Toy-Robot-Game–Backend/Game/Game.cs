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

        /*
        * The readCommand method checks what the command contains. And then delegates the
        * the required action by c#al#l#ing the required method. 
        */
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

        /*
        * The placeRobot method parses the command and extracts the cordinates and location
        * for the robots target location. The parser class also check if the cordinates are in
        * bounds and that the direction is a valid one. If these conditions pass then the robot
        * is placed in the required cordinate and direction. 
        */
        public void placeRobot(String command)
        {
            Tuple<int, int, String> location = Parser.extractCordinatesAndLocation(command);            
            var newLocation = Tuple.Create(location.Item1,location.Item2);
            
            if (location.Item1 == -1 || field[newLocation] == "WALL")
                return;
                        
            if (robotExists)
                field[robotCurrentLocation] = "empty";
            
            field[newLocation] = location.Item3;
            robotCurrentLocation = newLocation;

            robotExists = true;
        }

        /*
        * The placeWall method parses the command and extracts the cordinates for the walls target
        * location. The parser class also check if the cordinates are in bounds and  valid. If these
        * conditions pass then the wall is placed in the required cordinate. 
        */
        public void placeWall(String command)
        {
            Tuple<int, int, String> location = Parser.extractCordinatesAndLocation(command);
            Tuple<int,int> targetLocation = Tuple.Create(location.Item1, location.Item2); 
            if (field[targetLocation] == "empty")
                field[targetLocation] = "WALL";
        }

        /*
        * The report simply logs the current location (ie cordinates and direction) of the robot.
        */
        public void report()
        {
            Console.WriteLine(robotCurrentLocation.Item1 + "," + 
                              robotCurrentLocation.Item2 + "," +
                              field[robotCurrentLocation]);
        }

        /*
        * The move command checks the direction of the robot. And the moves the robot in the
        * direction accordingly, this is done by calling the placeRobot.
        */
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

        /*
        * The turn command checks if the passed command is LEFT or Right. It then rotates the robot
        * accrodingly. It does this by using the placeRobot function.
        */
        public void turn(String leftOrRight)
        {
            String[] direction = new String[] { "NORTH", "EAST", "SOUTH", "WEST" };
            var currentDirection = field[robotCurrentLocation];
            var currentDirectionIndex = Array.IndexOf(direction, currentDirection); 
            var x, y = robotCurrentLocation.Item1;
            var y = robotCurrentLocation.Item2;
            
            if(leftOrRight == "RIGHT")
            {
                var newDirection = currentDirectionIndex + 1 == 4 ? 0 : currentDirectionIndex + 1;
                placeRobot("PLACE_ROBOT " + x + "," + y + "," + direction[newDirection]);
            } else
            {
                var newDirection = currentDirectionIndex - 1 == -1 ? 3 : currentDirectionIndex - 1;
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