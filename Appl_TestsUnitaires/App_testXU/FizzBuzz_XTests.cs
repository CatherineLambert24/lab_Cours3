using Appl_TestsUnitaires;
using System.Security.Cryptography.X509Certificates;
namespace App_testXU
{
    public class FizzBuzz_XTests
    {
        [Theory]
        [InlineData(15, "FizzBuzz")]
        [InlineData(3, "Fizz")]
        [InlineData(5, "Buzz")]
        [InlineData(7, "7")]
        public void GetOutPut_Div3AND5_ReturnFizzBuzz(int valeur, string expected)
        {
            //arrange
          
            //act
            var result = FizzBuzz.GetOutput(valeur);
            //assert
            Assert.Equal(expected, result);
        }
    }
}