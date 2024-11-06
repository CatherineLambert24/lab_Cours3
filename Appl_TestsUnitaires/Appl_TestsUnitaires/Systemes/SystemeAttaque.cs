using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appl_TestsUnitaires.Systemes
{
    // Un système qui blesse les personnages qui sont à porté d'attaque de chaque personnage
    class SystemeAttaque : Systeme
    {
        public void Simuler(List<Personnage> personnages)
        {
            foreach (var p in personnages)
            {
                var autresPersonnages = Utils.GetPersonnagesAProximite(p.X, p.Y, p.DistanceAttaque, personnages);
                // Le nombre de cibles n'est pas limité, un personnage blesse tout les autres personnages qui sont à porté
                foreach (var autrePersonnage in autresPersonnages)
                {
                    autrePersonnage.PointsDeVie -= p.ForceAttaque;
                }
            }
        }
    }
}
