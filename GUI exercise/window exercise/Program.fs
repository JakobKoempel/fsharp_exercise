open System
open System.Windows

open window_exercise.File1

open FsXaml
open System.Windows.Controls.Primitives

type myWindow = XAML<"myWindow.xaml">

let toggleButton (button : Controls.Button) _ =
    button.IsEnabled <- not button.IsEnabled 

[<STAThread; EntryPoint>]
let main _ = 
    let myWindow = myWindow ()
    let Button1 = myWindow.myButton1
    let Button2 = myWindow.myButton2

    Button1.Click.Add (toggleButton Button2)
    Button2.Click.Add (fun _ -> printfn("%i") <| f 10)
    let application = Application ()
    application.Run myWindow
    0 

(*
xaml file needs to be a rsource and it has to be copied if newer (go to properties)
save xaml file first or it cant be read
*)