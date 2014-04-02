// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

[<EntryPoint>]
let main argv = 
    printfn "%A" argv

    let add x y =
        x + y
    let sum = add 2 2

    printf "%d" sum
    System.Console.ReadLine() |> ignore
    0 // return an integer exit code
