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

        [TestMethod]
        public void Straight()
        {
            PokerResultShouldBe("3D,2D,4H,5D,6D", ResultType.Straight, 6);
        }

        [TestMethod]
        public void FullHouse()
        {
            PokerResultShouldBe("3D,2D,3H,3S,2S", ResultType.FullHouse, 3);
        }

        [TestMethod]
        public void Four_Of_A_Kind()
        {
            PokerResultShouldBe("3D,3C,3H,3S,6S", ResultType.FourOfAKind, 3);
        }

        [TestMethod]
        public void Three_Of_A_Kind()
        {
            PokerResultShouldBe("3D,3C,3H,4D,6S", ResultType.ThreeOfAKind, 3);
        }

        [TestMethod]
        public void TwoPair()
        {
            PokerResultShouldBe("3D,3C,4H,4D,6S", ResultType.TwoPair, 4);
        }

        private static void PokerResultShouldBe(string cards, ResultType resultType, int expectedMaxNumbere)
        {
            PokerHand pokerHand = new PokerHand(cards);
            Assert.AreEqual(resultType, pokerHand.Type);
            Assert.AreEqual(expectedMaxNumbere, pokerHand.MaxCardNum);
        }
    }
}