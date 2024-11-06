using Appl_TestsUnitaires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_testUnitaire_FizzBuzz_NU
{
    [TestFixture]
  public class FizzBuzzNTestV2
    {
        [Test]
        [TestCase(15, "FizzBuzz")]
        [TestCase(3, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(7, "7")]
        public void GetOutput_Div3And5_ReturnFizzBuzz(int value, string expectedResult)
        {
            //arrange


            //Act
            var result = FizzBuzz.GetOutput(value);
            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
