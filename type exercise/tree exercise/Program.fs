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
       
       member this.toList =
            let rec f (tree : SortTree option) (list : int list) : int list =
                match tree with 
                | Some t -> f t.left list @ [t.value] @ f t.right list
                | None -> list
            f (Some this) []
    
let tree : SortTree  = [1 ; 10 ; 15 ; 2 ; 3 ; 8] 
                       |> List.fold (fun (acc : SortTree) num -> acc.insert num) {value = 8 ; left = None ; right = None}

tree |> printfn "automatic print function of the tree in F# :\n%A \n"
tree.toList |> printfn "in-order traversal of the sorted tree presented in a list :\n%A"