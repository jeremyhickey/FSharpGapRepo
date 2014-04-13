//testing the quicksort code found here:
//http://ideasharp.net/c-vs-f-quicksort/

let rec qsort list = 
    match list with
    [] -> []
    | head :: tail ->
        let less, greater = List.partition ((>=) head) tail
        List.concat [qsort less; [head]; qsort greater]

//supplying the same function with lists of different datatypes
let intList = [52;87;3;45;99;23]
let floatList = [3.4;8.76;4.0;0.2]
let stringList = ["Peter";"Paul";"Mary";"Lucy"]

printfn "%A" (qsort intList)
printfn "%A" (qsort floatList)
printfn "%A" (qsort stringList)

//output:
//[3; 23; 45; 52; 87; 99]
//[0.2; 3.4; 4.0; 8.76]
//["Lucy"; "Mary"; "Paul"; "Peter"]
System.Console.ReadLine() |> ignore