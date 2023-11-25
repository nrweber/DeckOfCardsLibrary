using System;
using System.Collections;

namespace DeckOfCards;


public enum StartingStates {
    Empty,
    Standard52,
    Standard52WithJokers
};

public class StandardPokerDeck : IEnumerable<Card>
{
    private List<Card> _stack = new();
    private Random _rnd = new();

    public int CardsInDeck { get => _stack.Count; }

    public StandardPokerDeck(StartingStates startingState)
    {
        if(startingState == StartingStates.Standard52 || startingState == StartingStates.Standard52WithJokers)
        {
            foreach(Suits suit in Enum.GetValues(typeof(Suits)))
            {
                if(suit == Suits.Joker)
                    continue;

                foreach(Values value in Enum.GetValues(typeof(Values)))
                {
                    if(value != Values.HighJoker && value != Values.LowJoker)
                        _stack.Add(new Card(suit, value));
                }
            }
        }

        if(startingState == StartingStates.Standard52WithJokers)
        {
            _stack.Add(new Card(Suits.Joker, Values.HighJoker));
            _stack.Add(new Card(Suits.Joker, Values.LowJoker));
        }
    }

    // Returns the card on the top of the stack
    public Card? Peek()
    {
        if(_stack.Count == 0)
            return null;

        return _stack[0];
    }

    // Removes the top card from the stack and returns it
    public Card? Pop()
    {
        if(_stack.Count == 0)
            return null;

        var card = _stack[0];
        _stack.RemoveAt(0);
        return card;
    }

    // Adds card to top
    public void PushTop(Card card)
    {
        _stack.Insert(0, card);
    }

    // Adds card to end of stack
    public void PushBottom(Card card)
    {
        _stack.Add(card);
    }

    //Adds card to a random spot
    public void PushRandom(Card card)
    {
        var index = _rnd.Next(0, _stack.Count);
        _stack.Insert(index, card);
    }

    //Shuffles the stack
    public void Shuffle()
    {
        //not a "perfect" Random Shuffle but it will do for my use
        _stack = _stack.OrderBy(a => _rnd.Next()).ToList();
        _stack = _stack.OrderBy(a => _rnd.Next()).ToList();
        _stack = _stack.OrderBy(a => _rnd.Next()).ToList();
    }

    public IEnumerator<Card> GetEnumerator()
    {
        return _stack.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

}
