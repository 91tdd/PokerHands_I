using System.Collections.Generic;
using System.Linq;

namespace PokerHands_I
{
    public class PokerHand
    {
        public IEnumerable<Card> _cards;

        private Dictionary<string, short> valueLookup = new Dictionary<string, short>
            {
                {"2", 2},
                {"3", 3},
                {"4", 4},
                {"5", 5},
                {"6", 6},
                {"7", 7},
                {"8", 8},
                {"9", 9},
                {"10", 10},
                {"J", 11},
                {"Q", 12},
                {"K", 13},
                {"A", 14},
            };

        public PokerHand(string cardsContent)
        {
            this._cards = cardsContent.Split(',')
                .Select(x =>
                new Card
                {
                    Suit = x.Substring(x.Length - 1, 1),
                    Value = valueLookup[x.Substring(0, x.Length - 1)]
                }).OrderBy(c => c.Value);

            this.Dealt();
        }

        public short MaxCardNum { get; set; }

        public ResultType Type { get; set; }

        private void Dealt()
        {
            new List<IPokerHandler>
            {
                new FlushHandler(this),
                new FourOfAKindHandler(this),
                new FullHouseHandler(this),
                new StraightHandler(this),
                new ThreeOfAKindHandler(this),
                new TwoPairHandler(this),
                new PairHandler(this),
                new HighCardHandler(this),
            }.First(x => x.IsMatch()).SetResult();
        }
    }
}