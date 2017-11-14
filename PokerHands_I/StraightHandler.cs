using System.Linq;

namespace PokerHands_I
{
    public class StraightHandler
    {
        private PokerHand _pokerHand;

        public StraightHandler(PokerHand pokerHand)
        {
            _pokerHand = pokerHand;
        }

        public bool IsStraight()
        {
            return _pokerHand._cards.Max(c => c.Value) - _pokerHand._cards.Min(c => c.Value) == 4;
        }
    }
}