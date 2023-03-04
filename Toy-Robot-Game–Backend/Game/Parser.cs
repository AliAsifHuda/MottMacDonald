using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottMacDonald 
{
    /*
    * The parser class reads the string command and then extracts the cordinates and/or the
    * directions. ANd then return cordinates as int and direction as strings.
    */
    class Parser
    {        

        public static Tuple<int, int, String> extractCordinatesAndLocation(String command) 
        {
            String[] splitByComma = command.Split(' ');
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

    }
}