using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerHands_I
{
    [TestClass]
    public class PokerHandGameTest
    {
        private PokerHandGame pokerHandGame = new PokerHandGame("Black", "White");

        [TestMethod]
        public void HighCard_Compare()
        {
            OutputShouldBe("2D,3S,4H,5S,8S", "3D,2S,6H,KS,8H", "White Win. -with high card: King");
        }

        [TestMethod]
        public void StraightFlush_Win_FourOfAKind()
        {
            OutputShouldBe("2D,3D,4D,5D,6D", "3D,3S,3H,3C,8H", "Black Win. -with straight flush");
        }

        [TestMethod]
        public void FourOfAKind_win_straight()
        {
            OutputShouldBe("2D,3D,4D,5D,6S", "3D,3S,3H,3C,8H", "White Win. -with four of a kind");
        }

        [TestMethod]
        public void FourOfAKind_win_fullHouse()
        {
            OutputShouldBe("2D,2S,2H,5D,5S", "3D,3S,3H,3C,8H", "White Win. -with four of a kind");
        }

        [TestMethod]
        public void fullHouse_compare()
        {
            OutputShouldBe("2D,2S,2H,10D,10S", "AD,AS,AH,3S,3H", "White Win. -with full house: Ace");
        }

        [TestMethod]
        public void flush_compare()
        {
            OutputShouldBe("2D,3D,6D,10D,8D", "QS,10S,9S,3S,2S", "White Win. -with flush: Queen");
        }

        private void OutputShouldBe(string firstPlayerCards, string secondPlayerCards, string expected)
        {
            pokerHandGame.Play(firstPlayerCards, secondPlayerCards);
            string actual = pokerHandGame.Output;
            Assert.AreEqual(expected, actual);
        }
    }
}