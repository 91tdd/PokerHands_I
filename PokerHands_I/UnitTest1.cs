using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerHands_I
{
    [TestClass]
    public class PokerHandsTest
    {
        [TestMethod]
        public void Flush()
        {
            PokerHand pokerHand = new PokerHand("2D,3D,4D,5D,7D");
            Assert.AreEqual(ResultType.Flush, pokerHand.Type);
            Assert.AreEqual(7, pokerHand.MaxCardNum);
        }
    }
}