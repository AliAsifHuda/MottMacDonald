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
                default:
                    break;
            }
        }

        public void placeRobot(String command)
        {
            Tuple<int, int, String> location = Parser.extractCordinatesAndLocation(command);
            if (location.Item1 == -1)
            {
                return;
            }
            
            var newLocation = Tuple.Create(location.Item1,location.Item2);
            if (robotExists)
            {
                field[robotCurrentLocation] = "empty";
            }

            newLocation = Tuple.Create(location.Item1,location.Item2);
            field[newLocation] = location.Item3;
            robotCurrentLocation = newLocation;

            robotExists = true;
            Console.WriteLine(field[Tuple.Create(2,3)]);

        }

        public void placeWall(String command)
        {
            Tuple<int, int, String> location = Parser.extractCordinatesAndLocation(command);
            Tuple<int,int> targetLocation = Tuple.Create(location.Item1, location.Item2); 
            if (field[targetLocation] == "empty")
            {
                field[targetLocation] = "WALL";
            }
            Console.WriteLine(field[targetLocation]);
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
                    case "EAST":
                        if(x == 1) 
                        {
                            placeRobot("PLACE_ROBOT " + new String("5" + "," + y) + "," + "EAST");
                        } else { 
                            placeRobot("PLACE_ROBOT " + new String((x - 1) + "," + y) + "," + "EAST");
                        }
                        break;
                    case "WEST":
                        if(x == 5) 
                        {
                            placeRobot("PLACE_ROBOT " + new String("1" + "," + y) + "," + "WEST");
                        } else { 
                            placeRobot("PLACE_ROBOT " + new String((x + 1) + "," + y) + "," + "WEST");
                        }
                        break;
                }
            }
        }

        public static void Main(string[] args)
        {
            Game g = new Game();
            g.readCommand("PLACE_ROBOT 1,1,SOUTH");
            g.readCommand("PLACE_WALL 3,3");
            g.readCommand("REPORT");
            g.readCommand("MOVE");
            g.readCommand("REPORT");
        }
    }
}