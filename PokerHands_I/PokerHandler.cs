using System.Linq;

namespace PokerHands_I
{
    public class FlushHandler : IPokerHandler
    {
        private PokerHand _pokerHand;

        public FlushHandler(PokerHand pokerHand)
        {
            _pokerHand = pokerHand;
        }

        public bool IsMatch()
        {
            return _pokerHand._cards.All(c => c.Suit == _pokerHand._cards.First().Suit);
        }

        public void SetResult()
        {
            if (new StraightHandler(_pokerHand).IsMatch())
            {
                _pokerHand.Type = ResultType.StraightFlush;
            }
            else
            {
                _pokerHand.Type = ResultType.Flush;
            }
            _pokerHand.MaxCardNum = _pokerHand._cards.Max(c => c.Value);
        }
    }
}