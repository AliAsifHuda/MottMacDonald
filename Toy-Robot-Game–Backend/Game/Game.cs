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
                default:
                    break;
            }
        }

        public void placeRobot(String command)
        {
            Tuple<int, int, String> location = (Parser.extractCordinatesAndLocation(command));
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

        public static void Main(string[] args)
        {
            Game g = new Game();
            g.readCommand("PLACE_ROBOT 2,3,NORTH");
            g.readCommand("PLACE_WALL 3,3");
        }
    }
}