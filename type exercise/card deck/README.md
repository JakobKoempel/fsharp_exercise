# Card deck type 

In this program I used enumeration in F# in order to create a card deck.  
First I created two types. The type 'Suit' and the type 'Value' and use enums in order to rank te different states.

```fsharp
type Suit = Spades = 0
          | Diamonds = 1
          | Clubs = 2
          | Hearts = 3
  

type Value = Ace = 1
           | Two = 2
           | Three = 3 
           | Four = 4
           | Five = 5
           | Six = 6
           | Seven = 7
           | Eight = 8
           | Nine = 9
           | Ten = 10
           | Jack = 11
           | Queen = 12
           | King = 13
```

Now I create the type 'Card' that combines both other types. 
When creating this type I also overrode the toString methode in order to make the output more ordered.

```sharp
type Card = {
    suit : Suit
    value : Value   
} with  
    override this.ToString () = sprintf "%A of %A" this.value this.suit
```

Because I used enums to create the types I can now create a whole deck of cards and store it in a list in one line of code.

```fsharp
let deck = List.init 52 (fun i -> {suit = enum (i / 13) 
                                   value = enum ((i % 13) + 1)})
```
