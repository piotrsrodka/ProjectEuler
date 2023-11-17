/*
 * 
 *  Hearts
	Diamonds
	Clubs
	Spades

 * 
 */

namespace Euler
{
    public class Euler54 : IEulerProblem
    {
        private enum Suit
        {
            H, // Hearts,
            D, // Diamonds,
            C, // Clubs,
            S, // Spades
        }

        // Cards are represented as 2 characters, first is the value, second is the suit
        // 2H = 2 of Hearts
        // 2D = 2 of Diamonds
        // T is for 10
        // J is for Jack
        // Q is for Queen
        // K is for King
        // A is for Ace

        private class Card
        {
            public int Value { get; set; }
            public Suit Suit { get; set; }

            private string SuitToString(Suit suit)
            {
                return suit switch
                {
                    Suit.H => "♥",
                    Suit.D => "♦",
                    Suit.C => "♣",
                    Suit.S => "♠",
                    _ => "Unknown",
                };
            }

            public override string ToString()
            {
                string padRightValue = Value < 10 ? " " + Value : Value.ToString();
                return $"{padRightValue}{this.SuitToString(Suit)}";
            }
        }

        private Dictionary<string, int> CardValue = new Dictionary<string, int>()  {
            { "2", 2 },
            { "3", 3 },
            { "4", 4 },
            { "5", 5 },
            { "6", 6 },
            { "7", 7 },
            { "8", 8 },
            { "9", 9 },
            { "T", 10 },
            { "J", 11 },
            { "Q", 12 },
            { "K", 13 },
            { "A", 14 },
        };

        private class HandResult
        {
            public Rank Rank { get; set; }
            public List<Card> RemainingCards { get; set; }
            public Card CardForComparison { get; set; }

            public HandResult(Rank rank, List<Card> remainingCards, Card cardForComparison)
            {
                this.Rank = rank;
                this.RemainingCards = remainingCards;
                this.CardForComparison = cardForComparison;
            }
        }

        public void Start()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<Card> player1Hand = new List<Card>();
            List<Card> player2Hand = new List<Card>();
            int player1Wins = 0;
            int draws = 0;

            using (StreamReader streamReader = new StreamReader(@"Data\\poker54.txt"))
            {
                string data = streamReader.ReadToEnd();
                string[] deals = data.Split('\n');
                Console.WriteLine($"Number of read lines: {deals.Length}");
                string player1;
                string player2;
                

                foreach (var deal in deals)
                {
                    int sanityCheck = 0;

                    player1 = deal.Substring(0, 14);
                    player2 = deal.Substring(15, 14);

                    string[] player1Cards = player1.Split(' ');
                    string[] player2Cards = player2.Split(' ');

                    foreach (var card in player1Cards)
                    {
                        player1Hand.Add(new Card()
                        {
                            Value = CardValue[card[0].ToString()],
                            Suit = (Suit)Enum.Parse(typeof(Suit), card[1].ToString())
                        });
                    }

                    foreach (var card in player2Cards)
                    {
                        player2Hand.Add(new Card()
                        {
                            Value = CardValue[card[0].ToString()],
                            Suit = (Suit)Enum.Parse(typeof(Suit), card[1].ToString())
                        });
                    }

                    player1Hand.Sort((x, y) => x.Value.CompareTo(y.Value));
                    player2Hand.Sort((x, y) => x.Value.CompareTo(y.Value));

                    Console.Write($"\nP1: ");
                    player1Hand.ForEach((card) => Console.Write(card.ToString() + " "));

                    Console.Write($"    P2: ");
                    player2Hand.ForEach((card) => Console.Write(card.ToString() + " "));

                    Console.WriteLine();

                    HandResult player1Result = GetRank(player1Hand);
                    HandResult player2Result = GetRank(player2Hand);

                    // compare Ranks of two players
                    if (player1Result.Rank > player2Result.Rank)
                    {
                        Console.WriteLine($"Player 1 wins with {player1Result.Rank}");
                        player1Wins++;
                        sanityCheck++;
                    }
                    else if (player1Result.Rank < player2Result.Rank)
                    {
                        Console.WriteLine($"Player 2 wins with {player2Result.Rank}");
                    }
                    else
                    {
                        Console.WriteLine($"Draw: P1: {player1Result.Rank} and P2: {player2Result.Rank}");
                        // compare values of cards
                        // if values are equal, compare next highest card

                        if (player1Result.Rank == Rank.OnePair)
                        {
                            // compare pair values
                            if (player1Result.CardForComparison.Value > player2Result.CardForComparison.Value)
                            {
                                Console.WriteLine($"Player 1 wins with {player1Result.Rank}");
                                player1Wins++;
                                sanityCheck++;
                            }
                        }
                        else if (player1Result.Rank == Rank.ThreeOfAKind)
                        {
                            // compare pair values
                            if (player1Result.CardForComparison.Value > player2Result.CardForComparison.Value)
                            {
                                Console.WriteLine($"Player 1 wins with {player1Result.Rank}");
                                player1Wins++;
                                sanityCheck++;
                            }
                        }
                        else if (player1Result.Rank == Rank.FourOfAKind)
                        {
                            // compare pair values
                            if (player1Result.CardForComparison.Value > player2Result.CardForComparison.Value)
                            {
                                Console.WriteLine($"Player 1 wins with {player1Result.Rank}");
                                player1Wins++;
                                sanityCheck++;
                            }
                        }
                        else // we got None Rank, so compare remaining cards
                        {
                            List<Card> remainingHand1 = player1Result.RemainingCards.OrderBy(x => x.Value).ToList();
                            List<Card> remainingHand2 = player2Result.RemainingCards.OrderBy(x => x.Value).ToList();

                            while (remainingHand1.Count() > 0 && remainingHand2.Count() > 0)
                            {
                                if (remainingHand1.Max(x => x.Value) > remainingHand2.Max(x => x.Value))
                                {
                                    Console.WriteLine($"Player 1 wins with {player1Result.Rank}");
                                    player1Wins++;
                                    sanityCheck++;
                                    break;
                                }
                                else if (remainingHand1.Max(x => x.Value) < remainingHand2.Max(x => x.Value))
                                {
                                    Console.WriteLine($"Player 2 wins with {player2Result.Rank}");
                                    break;
                                }
                                else // draw
                                {
                                    remainingHand1.Remove(remainingHand1.Last());
                                    remainingHand2.Remove(remainingHand2.Last());

                                    if (remainingHand1.Count() == 0)
                                    {
                                        Console.WriteLine($"Still DRAW!");
                                        draws++;
                                    }
                                }
                            }
                        }
                    }

                    player1Hand.Clear();
                    player2Hand.Clear();

                    if (sanityCheck > 1)
                    {
                        throw new Exception("Sanity check failed");
                    }

                    sanityCheck = 0;
                }
            }

            Console.WriteLine($"Player 1 wins {player1Wins} times");
            Console.WriteLine($"Draws {draws} times");
        }

        // Poker hands are ranked by the following order:
        private enum Rank
        {
            None,
            HighCard, // Highest value card.
            OnePair, // Two cards of the same value.
            TwoPairs, // Two different pairs.
            ThreeOfAKind, // Three cards of the same value.
            Straight, // All cards are consecutive values.
            Flush, // All cards of the same suit.
            FullHouse, // Three of a kind and a pair.
            FourOfAKind, // Four cards of the same value.
            StraightFlush, // All cards are consecutive values of same suit.
            RoyalFlush, // Ten, Jack, Queen, King, Ace, in same suit.
        }

        // Get rank and remaining cards and card for comparison
        private HandResult GetRank(List<Card> hand)
        {
            if (hand.Count != 5)
            {
                throw new Exception("Hand must contain 5 cards");
            }

            if (isRoyalFlush(hand))
            {
                return new HandResult(Rank.RoyalFlush, hand, null);
            }

            if (isStraightFlush(hand))
            {
                return new HandResult(Rank.StraightFlush, hand, null);
            }

            var fourOfAKindCard = isFourOfAKind(hand);
            if (fourOfAKindCard != null)
            {
                return new HandResult(Rank.FourOfAKind, hand, fourOfAKindCard);
            }

            if (isFullHouse(hand))
            {
                return new HandResult(Rank.FullHouse, hand, null);
            }

            if (isFlush(hand))
            {
                return new HandResult(Rank.Flush, hand, null);
            }

            Card straightCard = isStraight(hand);
            if (straightCard != null)
            {
                return new HandResult(Rank.Straight, hand, straightCard);
            }

            var threeOfAKindCard = isThreeOfAKind(hand);
            if (threeOfAKindCard != null)
            {
                return new HandResult(Rank.ThreeOfAKind, hand, threeOfAKindCard);
            }

            var twoPairs = isTwoPairs(hand);
            if (twoPairs != null)
            {
                return new HandResult(Rank.TwoPairs, hand, twoPairs);
            }

            Card onePairCard = isOnePair(hand);
            if (onePairCard != null)
            {
                return new HandResult(Rank.OnePair, hand, onePairCard);
            }

            return new HandResult(Rank.None, hand, null);
        }

        private Card isTwoPairs(List<Card> hand)
        {
            var pairCard = isNOfAKind(hand, 2, true);

            if (pairCard != null)
            {
                List<Card> handWithoutPair = hand.Where(card => card.Value != pairCard.Value).ToList();

                Card card = isNOfAKind(handWithoutPair, 2, true);
                
                if (card != null)
                {
                    hand.RemoveAll(c => c.Value == pairCard.Value || c.Value == card.Value);
                    return hand.First();
                }
            }

            return null;
        }

        private bool isFullHouse(List<Card> hand)
        {
            var threeOfAKindCard = isNOfAKind(hand, 3, true);

            if (threeOfAKindCard != null)
            {
                List<Card> handWithoutThreeOfAKind = hand.Where(card => card.Value != threeOfAKindCard.Value).ToList();

                if (isNOfAKind(handWithoutThreeOfAKind, 2, true) != null)
                {
                    return true;
                }
            }

            return false;
        }

        private Card isOnePair(List<Card> hand)
        {
            return isNOfAKind(hand, 2);
        }

        // returns the winning card of n of a kind and removes it from the hand returning the remaining cards for comparison
        private Card isNOfAKind(List<Card> hand, int n, bool keepHand = false)
        {
            int previousValue = hand[0].Value;
            int counter = 1;

            for (int i = 1; i < hand.Count; i++)
            {
                if (hand[i].Value == previousValue)
                {
                    counter++;
                }
                else
                {
                    counter = 1;
                }

                if (counter == n)
                {
                    var winningCard = new Card { Value = hand[i].Value, Suit = hand[i].Suit };
                    
                    if (!keepHand)
                    {
                        hand.RemoveAll(c => c.Value == winningCard.Value);
                    }
                     
                    return winningCard;
                }

                previousValue = hand[i].Value;
            }

            return null;
        }

        private Card isThreeOfAKind(List<Card> hand)
        {
            return isNOfAKind(hand, 3);            
        }

        private Card isFourOfAKind(List<Card> hand)
        {
            return isNOfAKind(hand, 4);
        }

        private bool isStraightFlush(List<Card> hand)
        {
            if (isFlush(hand) && isStraight(hand) != null)
            {
                return true;
            }

            return false;
        }

        private bool isRoyalFlush(List<Card> hand)
        {
            if (isFlush(hand) && isStraight(hand) != null)
            {
                if (hand[0].Value == 10)
                {
                    return true;
                }
            }

            return false;
        }

        private Card isStraight(List<Card> hand)
        {
            int previousValue = hand[0].Value;

            for (int i = 1; i < hand.Count; i++)
            {
                if (hand[i].Value != previousValue + 1)
                {
                    return null;
                }

                previousValue = hand[i].Value;
            }

            return hand.Last();
        }

        private bool isFlush(List<Card> hand)
        {
            Suit suit = hand[0].Suit;

            foreach (var card in hand)
            {
                if (card.Suit != suit)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
