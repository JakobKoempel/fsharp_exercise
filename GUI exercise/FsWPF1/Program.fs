open System
open System.Windows

open FsXaml

type myWindow = XAML<"myWindow.xaml">

[<STAThread; EntryPoint>]
let main _ = 
    let myWindow = myWindow ()

    let application = Application ()
    application.Run myWindow 
