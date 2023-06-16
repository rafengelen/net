using StringCalculatorKata;
namespace StringCalculatorKataTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Add_EmptyString_ReturnsZero()
        {
            //ARRANGE
            var result = StringCalculator.Add("");
            //ACT

            //ASSERT
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void Add_StringContainingSingleNumber_ReturnsTheNumberItself()
        {
            //ARRANGE
            var result = StringCalculator.Add("78");
            //ACT

            //ASSERT
            Assert.AreEqual(78, result);
        }
        [TestMethod]
        public void Add_TwoNumbersSeparatedByComma_ReturnsTheirSum()
        {
            //ARRANGE and ACT
            var result = StringCalculator.Add("78,32");

            //ASSERT
            Assert.AreEqual(110, result);
        }
        /*[TestMethod]
        public void Add_MoreThanThreeNumbersSeparatedByComma_ReturnsTheirSum()
        {
            //ARRANGE and ACT
            var result = StringCalculator.Add("78,32,10");

            //ASSERT
            Assert.AreEqual(120, result);
        }*/
        [DataTestMethod]
        [DataRow("1,2,3",6)]
        [DataRow("1,2,3,4", 10)]
        [DataRow("1,2,3,4,5", 15)]
        public void Add_MoreThanThreeNumbersSeparatedByComma_ReturnsTheirSum(string numbers, int result)
        {
            Assert.AreEqual(result, StringCalculator.Add(numbers));
        }

        [TestMethod]
        [DataRow("1,2,1000", 1003)]
        [DataRow("1,2,3,4,1001", 10)]
        public void Add_MoreThanThreeNumbersSeparatedByCommaOverThousand_ReturnsTheirSumWithoutThousand(string numbers, int result)
        {
            Assert.AreEqual(result, StringCalculator.Add(numbers));
        }

        [TestMethod]
        public void Add_StringContainingNegativeNumbers_ThrowsException()
        {
            //ARRANGE
            string input = "1,2,3,-5";
            //ACT + ASSERT
            Assert.ThrowsException<ArgumentException>(()=>StringCalculator.Add(input));
        }
    }
}