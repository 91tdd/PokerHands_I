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

        private void OutputShouldBe(string firstPlayerCards, string secondPlayerCards, string expected)
        {
            pokerHandGame.Play(firstPlayerCards, secondPlayerCards);
            string actual = pokerHandGame.Output;
            Assert.AreEqual(expected, actual);
        }
    }
}