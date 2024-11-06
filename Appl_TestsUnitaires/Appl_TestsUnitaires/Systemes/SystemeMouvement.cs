using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appl_TestsUnitaires.Systemes
{
    // Un système qui déplace les personnages vers l'objectif
    class SystemeMouvement : Systeme
    {
        Objectif _objectif;

        internal SystemeMouvement(Objectif objectif)
        {
            _objectif = objectif;
        }

        public void Simuler(List<Personnage> personnages)
        {
            foreach (var p in personnages)
            {
                // Notes:
                // On veut que les personnages se déplacent vers l'objectif
                // Ils ne peuvent pas se déplacer en diagonale!
                // Ils se déplacent d'abord dans l'axe avec la plus grande distance de l'objectif: s'il est plus loin en Y, il bouge en Y, sinon en X. En cas d'égalité, on choisit X.
                // Ne pas oublier que les personnages ont une vitesse de déplacement, mais qu'ils ne peuvent pas passer au travers d'un autre personnage
                // Une fois que les personnages se déplacent bien sans vérifier s'ils sont bloqués (J'ai fait une première série de tests), il faudrait faire une vérification avant de bouger... (J'ai fait un test pour ça aussi)
                // ATTENTION!: Utils.GetPersonnageACetEndroit devrait faire un bon travail pour vérifier si il y a quelqu'un!
                //
                // TODO: Maintenant que j'ai écrit mes tests, je peux écrire le code!
            }
        }
    }
}
