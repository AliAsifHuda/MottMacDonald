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
                default:
                    break;
            }
        }

        public void placeRobot(String command)
        {
            Tuple<int, int, String> location = (parser(command));
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

        private Tuple<int, int, String> parser(String s)
        {
            String[] splitByComma = s.Split(' ');
            //String command = splitByComma[0];

            var remaining = new String(splitByComma[1]);
            var cordinatesAndDirection = remaining.Split(',');

            var x = Int32.Parse(cordinatesAndDirection[0]);
            var y = Int32.Parse(cordinatesAndDirection[1]);
            var facing = cordinatesAndDirection[2];
            
            if(x > 5 || y > 5 || (facing != "NORTH" && facing != "SOUTH" && facing !=  "EAST" && facing !=  "WEST"))
                return new Tuple<int, int, String>(-1, -1, "-1"); 

            return new Tuple<int, int, String>(x, y, facing);
            
        }

        public static void Main(string[] args)
        {
            Game g = new Game();
            g.readCommand("PLACE_ROBOT 2,3,NORTH");
            g.readCommand("PLACE_ROBOT 2,3,NORTH");
        }
    }
}