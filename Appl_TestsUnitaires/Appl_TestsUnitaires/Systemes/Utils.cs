using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appl_TestsUnitaires.Systemes
{
    class Utils
    {
        public static Personnage GetPersonnageACetEndroit(int x, int y, List<Personnage> personnages)
        {
            foreach (var p in personnages)
            {
                if (p.X == x && p.Y == y)
                {
                    return p;
                }
            }
            return null;
        }

        public static List<Personnage> GetPersonnagesAProximite(int x, int y, int range, List<Personnage> personnages)
        {
            List<Personnage> result = new List<Personnage>();
            for (int xOffset = -range; xOffset <= range; xOffset++)
            {
                for (int yOffset = -range; yOffset < range; yOffset++)
                {
                    // On saute notre propre case
                    if (xOffset == 0 && yOffset == 0)
                    {
                        continue;
                    }
                    int xToTest = x + xOffset;
                    int yToTest = y + yOffset;

                    var c = GetPersonnageACetEndroit(xToTest, yToTest, personnages);
                    if (c != null)
                        result.Add(c);
                }
            }
            return result;
        }
    }
}
