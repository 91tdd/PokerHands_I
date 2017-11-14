using System;

namespace PokerHands_I
{
    internal class ThreeOfAKindHandler : IPokerHandler
    {
        private readonly PokerHand _pokerHand;

        public ThreeOfAKindHandler(PokerHand pokerHand)
        {
            _pokerHand = pokerHand;
        }

        public bool IsMatch()
        {
            throw new NotImplementedException();
        }

        public void SetResult()
        {
            throw new NotImplementedException();
        }
    }
}