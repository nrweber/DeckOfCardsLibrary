# Deck of Cards Library

A simple and lightweight .NET 8 library for working with playing cards. This library provides a basic implementation of a standard poker deck with shuffling, drawing, and manipulation capabilities.

## Features

- Standard 52-card poker deck
- Optional jokers (54-card deck)
- Card shuffling (non-cryptographic)
- Stack-based operations (push/pop from top or bottom)
- Enumerable interface for iteration
- Peek functionality to view top card without removing

## Installation

Add the NuGet package to your project:

```bash
dotnet add package nic_weber.DeckOfCards
```

## Quick Start

```csharp
using nic_weber.DeckOfCards;

// Create a standard 52-card deck
var deck = new StandardPokerDeck(StartingStates.Standard52);

// Shuffle the deck
deck.Shuffle();

// Draw a card
Card? topCard = deck.Pop();
Console.WriteLine($"Drew: {topCard?.Value} of {topCard?.Suit}");

// Check how many cards remain
Console.WriteLine($"Cards remaining: {deck.CardsInDeck}");
```

## API Reference

### Card Record

Represents a single playing card:

```csharp
public record Card(Suits Suit, Values Value);
```

### Suits Enum

- `Club`
- `Spade` 
- `Heart`
- `Diamond`
- `Joker`

### Values Enum

- `Ace` (1) through `King` (13)
- `LowJoker`, `HighJoker`

### StandardPokerDeck Class

#### Constructors

```csharp
// Create an empty deck
var deck = new StandardPokerDeck(StartingStates.Empty);

// Create a standard 52-card deck
var deck = new StandardPokerDeck(StartingStates.Standard52);

// Create a 54-card deck with jokers
var deck = new StandardPokerDeck(StartingStates.Standard52WithJokers);
```

#### Methods

- `Card? Pop()` - Remove and return the top card
- `Card? Peek()` - View the top card without removing it
- `void PushTop(Card card)` - Add a card to the top of the deck
- `void PushBottom(Card card)` - Add a card to the bottom of the deck
- `void PushRandom(Card card)` - Add a card at a random position
- `void Shuffle()` - Shuffle the deck (not cryptographically secure)

#### Properties

- `int CardsInDeck` - Get the number of cards remaining in the deck

## Examples

### Basic Card Operations

```csharp
var deck = new StandardPokerDeck(StartingStates.Empty);

// Add some cards
deck.PushBottom(new Card(Suits.Spade, Values.Ace));
deck.PushTop(new Card(Suits.Heart, Values.King));

// Draw cards
var topCard = deck.Pop();    // King of Hearts
var nextCard = deck.Pop();   // Ace of Spades
```

### Iterating Over Cards

```csharp
var deck = new StandardPokerDeck(StartingStates.Standard52);

foreach (var card in deck)
{
    Console.WriteLine($"{card.Value} of {card.Suit}");
}
```

### Working with Jokers

```csharp
var deck = new StandardPokerDeck(StartingStates.Standard52WithJokers);
Console.WriteLine($"Deck has {deck.CardsInDeck} cards"); // 54 cards

// Check if a card is a joker
if (someCard.Suit == Suits.Joker)
{
    Console.WriteLine($"Found a {someCard.Value}!");
}
```

## Important Notes

⚠️ **Security Warning**: The shuffle implementation is NOT cryptographically secure and should not be used for any critical applications, gambling, or situations requiring true randomness.

## Requirements

- .NET 8.0 or later
- C# 11 or later

## Testing

The library includes comprehensive unit tests. Run them with:

```bash
dotnet test
```

## Contributing

Contributions are welcome! Please feel free to submit issues or pull requests.
