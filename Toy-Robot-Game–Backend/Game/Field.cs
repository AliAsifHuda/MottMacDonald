using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottMacDonald 
{
    /*
    * The field contains the cordinates as tuple and it contains a string.
    * The string indicates what the specific cordinate contains. This information
    * is stroed as a dictionary. If the cordinates has nothing in it (eg no wall 
    * nor a robot) then the cordinate is marked as empty (initial state). Otherwise
    * a wall or the direction of the robot is stored in the dictionary.
    */
    public class Field
    {        
        public const int dimension = 5;
        public Dictionary<Tuple<int, int>, String> field = new Dictionary<Tuple<int, int>, String>();
        
        public void InitialiseField(int fieldDimension = dimension) 
        {
            for (int x = 1; x <= fieldDimension; x++)
            {
                for (int y = 1; y <= fieldDimension; y++)
                {
                    field.Add(new Tuple<int, int>(x, y), "empty");
                }
                
            }
        }

        public Dictionary<Tuple<int, int>, String> GetField() {
            return field;
        }

    }
}