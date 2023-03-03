using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottMacDonald 
{
    public class Game
    {        
        public Game()
        {
            Field field = new Field();
            field.initialiseField();
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
            //TODO
        }

        public static void Main(string[] args)
        {
            Game g = new Game();
            g.readCommand("PLACE_ROBOT 2,3,NORTH");
        }
    }
}