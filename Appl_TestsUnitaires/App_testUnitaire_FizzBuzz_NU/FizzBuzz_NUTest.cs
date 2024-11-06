using Appl_TestsUnitaires;

namespace App_testUnitaire_FizzBuzz_NU
{
    public class FizzBuzz_NUTest
    {
        [Test]
        public void GetOutput_Div3And5_ReturnFizzBuzz()
        {
            //Arrange
            var valeur = 15;

            //Act

            var result = FizzBuzz.GetOutput(valeur);

            //Assert
            Assert.That(result, Is.EqualTo("FizzBuzz"));
            Assert.AreEqual(result, "FizzBuzz");
        }

        [Test]
        public void GetOutput_Div3ReturnFizzBuzz()
        {
            //Arrange
            var valeur = 3;

            //Act

            var result = FizzBuzz.GetOutput(valeur);

            //Assert
            Assert.That(result, Is.EqualTo("Fizz").IgnoreCase);
            //Assert.AreEqual(result, "FizzBuzz");
        }
        [Test]
        public void GetOutput_Div5_ReturnFizzBuzz()
        {
            //Arrange
            var valeur = 5;

            //Act

            var result = FizzBuzz.GetOutput(valeur);

            //Assert
            Assert.That(result, Is.EqualTo("Buzz").IgnoreCase);
        }
        [Test]
        public void GetOutputNOT_3div_Div5_ReturnFizzBuzz()
        {
            //Arrange
            var valeur = 7;

            //Act

            var result = FizzBuzz.GetOutput(valeur);

            //Assert
            Assert.AreEqual(result, ("7"));
        }

    }


    }