using Appl_TestsUnitaires.Systemes;
using System.Collections.Generic;

namespace Appl_TestsUnitaires
{
    public class CombatParTour
    {
        private List<Systeme> _systems = new List<Systeme>();
        public CombatParTour(Objectif objectif)
        {
            _systems.Add(new SystemeAttaque());
            _systems.Add(new SystemeMouvement(objectif));
            _systems.Add(new SystemeMorgue());
        }

        public void SimulerUnTour(List<Personnage> personnages)
        {
            foreach(Systeme s in _systems)
            {
                s.Simuler(personnages);
            }
        }
    }
}
