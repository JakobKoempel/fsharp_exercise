open System
open System.Windows

open FsXaml
open System.Windows.Controls.Primitives

type myWindow = XAML<"myWindow.xaml">

[<STAThread; EntryPoint>]
let main _ = 
    let myWindow = myWindow ()

    let application = Application ()
    application.Run myWindow 

(*
xaml file needs to be a rsource and it has to be copied if newer (go to properties)
save xaml file first or it cant be read
*)