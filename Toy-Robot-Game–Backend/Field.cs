using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottMacDonald 
{
    /*
    * The field contains the cordinates as numbers and it contains a string.
    * The string indicates what the specific cordinate contains. This information
    * is stroed as a dictionary. If the cordinates has nothing in it (eg no wall 
    * nor a robot) then the cordinate is marked as empty (initial state). Otherwise
    * a wall or the direction of the robot is stored in the dictionary.
    */
    public class Field
    {        
        public const int dimension = 5;
        public Dictionary<int, String> field = new Dictionary<int, String>();
        
        public void initialiseField(int fieldDimension = dimension) 
        {
            for (int i = 0; i < fieldDimension*fieldDimension; i++)
            {
                field.Add(i, "empty");
            }
        }
        
        public Tuple<int,int> getCordinatesFromIndex(int index)
        {
            int x = (index/dimension)+1;
            int y = (index%dimension)+1;
            
            return new Tuple<int,int>(x,y);
        } 

    }
}