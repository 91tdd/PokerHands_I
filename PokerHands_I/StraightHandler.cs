using System.Linq;

namespace PokerHands_I
{
    public class StraightHandler : IPokerHandler
    {
        private PokerHand _pokerHand;

        public StraightHandler(PokerHand pokerHand)
        {
            _pokerHand = pokerHand;
        }

        public bool IsMatch()
        {
            return _pokerHand._cards.Max(c => c.Value) - _pokerHand._cards.Min(c => c.Value) == 4;
        }

        public void SetResult()
        {
            _pokerHand.Type = ResultType.Straight;
            _pokerHand.MaxCardNum = _pokerHand._cards.Max(c => c.Value);
        }
    }
}