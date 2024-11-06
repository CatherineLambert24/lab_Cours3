using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appl_TestsUnitaires.Systemes
{
    // Un système qui retire les personnages qui n'ont plus de points de vie
    class SystemeMorgue : Systeme
    {
        public void Simuler(List<Personnage> personnages)
        {
            for (int i = personnages.Count - 1; i > 0; i--)
            {
                if (personnages[i].PointsDeVie < 0)
                {
                    personnages.RemoveAt(i);
                }
            }
        }
    }
}
