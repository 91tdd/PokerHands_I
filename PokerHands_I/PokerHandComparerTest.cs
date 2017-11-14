using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerHands_I
{
    [TestClass]
    public class PokerHandGameTest
    {
        [TestMethod]
        public void HighCard_Compare()
        {
            PokerHandGame pokerHandGame = new PokerHandGame("Black", "White");
            pokerHandGame.Play("2D,3S,4H,5S,8S", "3D,2S,6H,KS,8H");
            string actual = pokerHandGame.Output;
            Assert.AreEqual("White Win. -with high card: King", actual);
        }
    }
}
