using Appl_TestsUnitaires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_TestsUnitaires_TestsNU
{
    [TestFixture]
    [Ignore("Ignorer jusqu'à l'exercice sur le jeu")]
    public class CombatParTour_Tests
    {
        private Personnage _personnage1;
        private Personnage _personnage2;
        private List<Personnage> _personnages = new List<Personnage>();
        private CombatParTour _combatParTour;

        [OneTimeSetUp]
        public void RouleAvantLesTests()
        {
            Objectif objectif = new ()
            {
                X = 4,
                Y = 0
            };
            _combatParTour = new CombatParTour(objectif);
        }

        [SetUp]
        public void RouleAvantChaqueTest()
        {
            // On reset les données de nos personnages à chaque exécution des tests
            _personnage1 = new()
            {
                X = 0,
                Y = 0,
                PointsDeVie = 10,
                DistanceAttaque = 1,
                ForceAttaque = 4,
                VitesseMouvement = 1,
                NumeroEquipe = 1
            };

            _personnage2 = new()
            {
                X = 1,
                Y = 0,
                PointsDeVie = 20,
                DistanceAttaque = 1,
                ForceAttaque = 2,
                VitesseMouvement = 1,
                NumeroEquipe = 2
            };
        }

        [TearDown]
        public void RouleApresChaqueTest()
        {
            _personnages.Clear();
        }

        [Test]
        public void AttaqueSimple()
        {
            // Arrange
            _personnages.Add(_personnage1);
            _personnages.Add(_personnage2);

            // Act
            _combatParTour.SimulerUnTour(_personnages);

            // Assert
            Assert.That(_personnage1.PointsDeVie, Is.EqualTo(8));
            Assert.That(_personnage2.PointsDeVie, Is.EqualTo(16));
        }

        [Test]
        // Ici, on a le personnage #2 qui peut attaquer à une distance de 2 et qui peut bleser le personnage #1, mais pas l'inverse
        [TestCase(-2, 0)]
        [TestCase(2, 0)]
        public void AttaqueADistance(int x, int y)
        {
            // Arrange
            _personnage2.DistanceAttaque = 2;
            _personnage2.X = x;
            _personnage2.Y = y;

            _personnages.Add(_personnage1);
            _personnages.Add(_personnage2);
            
            // Act
            _combatParTour.SimulerUnTour(_personnages);

            // Assert
            // Personnage #1 est blessé car la distance d'attaque de Personnage #2 est suffisante
            Assert.That(_personnage1.PointsDeVie, Is.EqualTo(8));
            // Personnage #2 n'est pas blessé car la distance d'attaque de Personnage #1 est insuffisante
            Assert.That(_personnage2.PointsDeVie, Is.EqualTo(20));
        }

        [Test]
        [TestCase(1, 0, 0, 1, 0)] // Déplacement simple vers l'objectif X:4, Y:0
        [TestCase(1, 0, 1, 1, 1)] // Déplacement simple vers l'objectif X:4, Y:0 en bougeant en X en premier (plus grande différence)
        [TestCase(1, 0, 6, 0, 5)] // Déplacement simple vers l'objectif X:4, Y:0 en bougeant en Y en premier (plus grande différence)
        [TestCase(3, 0, 0, 3, 0)] // Déplacement simple vers l'objectif X:4, Y:0 avec une plus grande vitesse
        [TestCase(12, 0, 0, 4, 0)] // Déplacement simple vers l'objectif X:4, Y:0 avec une très grande vitesse (il faut s'arrêter à l'objectif)
        public void Mouvement(int vitesse, int xPersonnage1Initial, int yPersonnage1Initial, int xPersonnage1Final, int yPersonnage1Final)
        {
            // Arrange
            _personnage1.VitesseMouvement = vitesse;
            _personnage1.X = xPersonnage1Initial;
            _personnage1.Y = yPersonnage1Initial;

            _personnages.Add(_personnage1);

            // Act
            _combatParTour.SimulerUnTour(_personnages);

            // Assert
            Assert.That(_personnage1.X, Is.EqualTo(xPersonnage1Final), "Le mouvement en X n'est pas bon");
            Assert.That(_personnage1.Y, Is.EqualTo(yPersonnage1Final), "Le mouvement en Y n'est pas bon");
        }

        [Test]
        public void MouvementBloque()
        {
            // Arrange
            _personnage1.X = 0;
            _personnage1.Y = 0;
            _personnage1.VitesseMouvement = 2;

            _personnage2.X = 2;
            _personnage2.Y = 0;
            _personnage2.VitesseMouvement = 2;

            _personnages.Add(_personnage1);
            _personnages.Add(_personnage2);

            // Act
            _combatParTour.SimulerUnTour(_personnages);

            // Assert
            // L'objectif est le même pour les deux personnages, X:4, Y:0
            // Comme le personnage 1 bouge en premier et qu'il veut se rendre en X:2, Y:0 où le personnage 2 est déjà présent, on veut qu'il soit bloqué après son premier déplacement
            Assert.That(_personnage1.X, Is.EqualTo(1), "Le mouvement en X du personnage 1 n'est pas bon");
            Assert.That(_personnage1.Y, Is.EqualTo(0), "Le mouvement en Y du personnage 1 n'est pas bon");
            // Le personnage 2 peut bouger normalement jusqu'à l'objectif en X:4, Y:0
            Assert.That(_personnage2.X, Is.EqualTo(4), "Le mouvement en X du personnage 2 n'est pas bon");
            Assert.That(_personnage2.Y, Is.EqualTo(0), "Le mouvement en Y du personnage 2 n'est pas bon");
        }

        [Test]
        // On se souvient que le personnage #1 attaque avec une force de 4 et le personnage #2 une force de 2
        // Dans touts les cas, on s'attend à ce que tous les personnages meurrent
        [TestCase(2, 0, 4, 0)]
        [TestCase(2, 0, 3, -1)]
        [TestCase(1, -1, 3, -1)]
        public void RetirePersonnagesSansVie(int pvPersonnage1Initial, int pvPersonnage1Final, int pvPersonnage2Initial, int pvPersonnage2Final)
        {
            // Arrange
            _personnage1.PointsDeVie = pvPersonnage1Initial;
            _personnage2.PointsDeVie = pvPersonnage2Initial;
            _personnages.Add(_personnage1);
            _personnages.Add(_personnage2);

            // Act
            _combatParTour.SimulerUnTour(_personnages);

            // Assert
            Assert.That(_personnage1.PointsDeVie, Is.EqualTo(pvPersonnage1Final));
            Assert.That(_personnage2.PointsDeVie, Is.EqualTo(pvPersonnage2Final));
            Assert.That(_personnages.Count, Is.EqualTo(0), "Les deux personnages devraient mourrir");
        }
    }
}
