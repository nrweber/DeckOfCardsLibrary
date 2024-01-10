namespace nic_weber.DeckOfCards.Test;

public class StandardPokerDeckTest
{
    [Fact]
    public void Empty_StartsWithZeroCards()
    {
        StandardPokerDeck deck = new(StartingStates.Empty);

        Assert.Equal(0, deck.CardsInDeck);
    }

    [Fact]
    public void Standard52_StartsWith52()
    {
        StandardPokerDeck deck = new(StartingStates.Standard52);

        Assert.Equal(52, deck.CardsInDeck);
    }
    
    [Fact]
    public void Standard52WithJokers_StartsWith54()
    {
        StandardPokerDeck deck = new(StartingStates.Standard52WithJokers);

        Assert.Equal(54, deck.CardsInDeck);
    }


    [Fact]
    public void PopOnEmptyDeckReturnsNull()
    {
        StandardPokerDeck deck = new(StartingStates.Empty);
        Assert.Null(deck.Pop());
    }

    [Fact]
    public void PeekOnEmptyDeckReturnsNull()
    {
        StandardPokerDeck deck = new(StartingStates.Empty);
        Assert.Null(deck.Peek());
    }

    [Fact]
    public void PushCardsFront_PopReturnsCardsInOpisiteOrder()
    {
        StandardPokerDeck deck = new(StartingStates.Empty);

        Card card1 = new(Suits.Spade, Values.Ace);
        Card card2 = new(Suits.Diamond, Values.Five);
        Card card3 = new(Suits.Heart, Values.King);


        Assert.Equal(0, deck.CardsInDeck);

        deck.PushTop(card1);
        deck.PushTop(card2);
        deck.PushTop(card3);

        Assert.Equal(3, deck.CardsInDeck);

        Assert.Equal(card3, deck.Pop());
        Assert.Equal(card2, deck.Pop());
        Assert.Equal(card1, deck.Pop());

        Assert.Equal(0, deck.CardsInDeck);
    }

    [Fact]
    public void PushCardsBottom_PopReturnsCardsInSameOrder()
    {
        StandardPokerDeck deck = new(StartingStates.Empty);

        Card card1 = new(Suits.Spade, Values.Ace);
        Card card2 = new(Suits.Diamond, Values.Five);
        Card card3 = new(Suits.Heart, Values.King);


        Assert.Equal(0, deck.CardsInDeck);

        deck.PushBottom(card1);
        deck.PushBottom(card2);
        deck.PushBottom(card3);

        Assert.Equal(3, deck.CardsInDeck);

        Assert.Equal(card1, deck.Pop());
        Assert.Equal(card2, deck.Pop());
        Assert.Equal(card3, deck.Pop());

        Assert.Equal(0, deck.CardsInDeck);
    }

    [Fact]
    public void PeekReturnsTopCardButDoesNotRemoveIt()
    {
        StandardPokerDeck deck = new(StartingStates.Empty);

        Card card1 = new(Suits.Spade, Values.Ace);
        Card card2 = new(Suits.Diamond, Values.Five);
        Card card3 = new(Suits.Heart, Values.King);


        Assert.Equal(0, deck.CardsInDeck);

        deck.PushBottom(card1);
        deck.PushBottom(card2);
        deck.PushBottom(card3);

        Assert.Equal(3, deck.CardsInDeck);

        Assert.Equal(card1, deck.Peek());

        Assert.Equal(3, deck.CardsInDeck);

        Assert.Equal(card1, deck.Pop());

        Assert.Equal(2, deck.CardsInDeck);
    }

    //Method contains a random number so I only check to make sure
    //the card is in the deck
    [Fact]
    public void PushRandomPutsTheCardSomewhereInTheDeck()
    {
        StandardPokerDeck deck = new(StartingStates.Empty);

        Card card1 = new(Suits.Spade, Values.Ace);
        Card card2 = new(Suits.Diamond, Values.Five);


        Assert.Equal(0, deck.CardsInDeck);

        deck.PushBottom(card1);
        deck.PushBottom(card1);
        deck.PushBottom(card1);
        deck.PushRandom(card2);

        Assert.True(deck.Pop() == card2 || deck.Pop() == card2 || deck.Pop() == card2 || deck.Pop() == card2);
    }

    // Not really a good test for a shuffle but this will make sure that it runs without crashing at least
    [Fact]
    public void AfterShuffleAllCardsAreStillThere()
    {
        StandardPokerDeck deck = new(StartingStates.Standard52);
        deck.Shuffle();

        Assert.Equal(52, deck.CardsInDeck);
    }
    
    [Fact]
    public void CanIterateOverTheDeck()
    {
        StandardPokerDeck deck = new(StartingStates.Empty);

        Card card1 = new(Suits.Spade, Values.Ace);
        Card card2 = new(Suits.Diamond, Values.Five);
        Card card3 = new(Suits.Heart, Values.King);


        Assert.Equal(0, deck.CardsInDeck);

        deck.PushBottom(card1);
        deck.PushBottom(card2);
        deck.PushBottom(card3);

        Assert.Equal(3, deck.CardsInDeck);

        List<Card> fromDeck = new();
        foreach(var card in deck)
            fromDeck.Add(card);

        Assert.Equal(card1, fromDeck[0]);
        Assert.Equal(card2, fromDeck[1]);
        Assert.Equal(card3, fromDeck[2]);
    }

}
