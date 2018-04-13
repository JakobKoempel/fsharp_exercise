open System

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

type Pcard = {
    suit : Suit
    value : Value   
} with  
    override this.ToString () = sprintf "%A of %A" this.value this.suit

let deck = List.init 52 (fun i -> {suit = enum (i / 13) 
                                   value = enum ((i % 13) + 1)})

for card in deck do printfn("%O") card
