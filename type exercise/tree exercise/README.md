# Tree structures in F#

In this program I implemented a sorted tree structure in F# using types. We can build the basis of a tree in a few lines in F# by creating a new type called 'SortTree'. (Note: the first letter of a type name is allways capitalized)

```fsharp
type SortTree = {
    value : int 
    left : SortTree option
    right : SortTree option
} 
```

In theory we could now go ahead and create a initialize a tree like this.

```fsharp
{value = 1 ; left = None ; right = Some ({value = 2 ; left = None ; right = None})}
```

It is obvious that it gets very confusing creating trees like that and the process isnt automatized yet.
Therefore we can write the insert method. 
The insert method takes an element, goes through the tree and inserts the new elements in the correct position. The rule for a soted
tree is simple. All the elements in the right part of a node must be equal or larger than the value of the node itself and vice versa
for the elements to the left. 
So in order to insert a elements into a sorted tree we have to go throught the tree starting at the base node. If the element to insert
is larger than the node value you go to the right node if it is smaller you go to the left node. You repeat that process until you find
an empty node where you can store the new element. In F# it looks like this. 

```fsharp
type SortTree = {
    value : int 
    left : SortTree option
    right : SortTree option
} with 
       member this.insert (num : int) : SortTree =
            let rec f (tree : SortTree option) (x : int) : SortTree =
                match tree with 
                | Some t -> if x < t.value then {t with left = Some (f t.left x)}
                            else {t with right = Some (f t.right x)}
                | None -> {value = x ; left = None ; right = None}
            f (Some this) num
```

After we have implemented the insert function, we can insert every element in a given list using a List.fold function. A random example
is shown below.

```fsharp
let tree : SortTree  = [1 ; 10 ; 15 ; 2 ; 3 ; 8] 
                       |> List.fold (fun (acc : SortTree) num -> acc.insert num) {value = 8 ; left = None ; right = None}
```

Another function I wrote is called 'toList'. It converts the tree back into a list using the in-order traversal. In-order means that the
left branch is printed out first, the node value second and finally the right branch. The list a sorted tree produces is therefore also
sorted thus the name.

```fsharp
type SortTree = {
    value : int 
    left : SortTree option
    right : SortTree option
} with 
       member this.toList =
            let rec f (tree : SortTree option) (list : int list) : int list =
                match tree with 
                | Some t -> f t.left list @ [t.value] @ f t.right list
                | None -> list
            f (Some this) []
```

We can also print out a tree using the print function but for larger trees the result gets quiet confusing. In the following code I
compared the output of both functions.

```fsharp
let tree : SortTree  = [1 ; 10 ; 15 ; 2 ; 3 ; 8] 
                       |> List.fold (fun (acc : SortTree) num -> acc.insert num) {value = 8 ; left = None ; right = None}

tree |> printfn "automatic print function of the tree in F# :\n%A \n"
tree.toList |> printfn "in-order traversal of the sorted tree presented in a list :\n%A"
```
