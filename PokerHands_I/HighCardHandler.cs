using System.Linq;

namespace PokerHands_I
{
    internal class HighCardHandler : IPokerHandler
    {
        private readonly PokerHand _pokerHand;

        public HighCardHandler(PokerHand pokerHand)
        {
            _pokerHand = pokerHand;
        }

        public bool IsMatch()
        {
            return true;
        }

        public void SetResult()
        {
            _pokerHand.Type = ResultType.HighCard;
            _pokerHand.MaxCardNum = _pokerHand._cards.Max(x => x.Value);
        }
    }
}