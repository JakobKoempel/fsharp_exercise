[<EntryPoint>]
let main _ =
    let aPromise =
        async {
            for i in 1..10 do printfn ("A%i") i
        }

    let bPromise = 
        async {
            for i in 1..10 do printfn ("B%i") i
        }

    Async.Parallel (seq { yield aPromise; yield bPromise }) |> Async.RunSynchronously |> ignore 
    //RunSynchronously waits for the async to end
    0