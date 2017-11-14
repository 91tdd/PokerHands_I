using System.Linq;

namespace PokerHands_I
{
    public class FlushHandler
    {
        private PokerHand _pokerHand;

        public FlushHandler(PokerHand pokerHand)
        {
            _pokerHand = pokerHand;
        }

        public bool IsFlush()
        {
            return _pokerHand._cards.All(c => c.Suit == _pokerHand._cards.First().Suit);
        }
    }
}