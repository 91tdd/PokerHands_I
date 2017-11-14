using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerHands_I
{
    [TestClass]
    public class PokerHandsTest
    {
        [TestMethod]
        public void Flush()
        {
            PokerResultShouldBe("2D,3D,4D,5D,7D", ResultType.Flush, 7);
        }

        [TestMethod]
        public void StraightFlush()
        {
            PokerResultShouldBe("3D,2D,4D,5D,6D", ResultType.StraightFlush, 6);
        }

        private static void PokerResultShouldBe(string cards, ResultType resultType, int expectedMaxNumbere)
        {
            PokerHand pokerHand = new PokerHand(cards);
            Assert.AreEqual(resultType, pokerHand.Type);
            Assert.AreEqual(expectedMaxNumbere, pokerHand.MaxCardNum);
        }
    }
}