//Workthrough of MSDN List documentation
//http://msdn.microsoft.com/en-us/library/dd233224.aspx

//*******************************
//Creating and initializing lists

//declaring a list
let listOneToFive = [1;2;3;4;5]

//declaring an empty list
let emptyList = []

//alternate syntax, possibly more readable but I can't see it
let listSixToTen = [
    6
    7
    8
    9
    10]

//you can have lists of the same type and lists of elements that derive from the same base type
//let controlList = Control list [new Button(); new CheckBox();]

//defining a list of using the range operator
let listOneToTen = [1..10]

//defining a list with a loop
let loopSquareExample = [for x in 1..10 -> x * x]

//********************************
//Operators for working with lists

//the cons (::) operator to add item to beginning of list
let listOrig = [4;5;6]
let num = 3
let newList = num :: listOrig

//concatenate lists with the @ operator
let newerList = listOrig @ newList

//properties of lists
let listOneTwoThree = [ 1; 2; 3 ]

//properties
printfn "list1.IsEmpty is %b" (listOneTwoThree.IsEmpty)
printfn "list1.Length is %d" (listOneTwoThree.Length)
printfn "list1.Head is %d" (listOneTwoThree.Head)
printfn "list1.Tail.Head is %d" (listOneTwoThree.Tail.Head)
printfn "list1.Tail.Tail.Head is %d" (listOneTwoThree.Tail.Tail.Head)
printfn "list1.Item(1) is %d" (listOneTwoThree.Item(1))

//***************************
//boolean operations of lists
//List.exists returns bool indicating whether or not a list contains a supplied element
let containsNumber number list = List.exists (fun elem -> elem = number) list
let list0to3 = [0 .. 3]
printfn "For list %A, contains zero is %b" list0to3 (containsNumber 0 list0to3)
//output: For list [0; 1; 2; 3], contains zero is true

//List.exists2 returns true if any elements in two list sharing the same index are a match
let isEqualElement list1 list2 = List.exists2 (fun elem1 elem2 -> elem1 = elem2) list1 list2
let list1to5 = [ 1 .. 5 ]
let list5to1 = [ 5 .. -1 .. 1 ]
if (isEqualElement list1to5 list5to1) then
    printfn "Lists %A and %A have at least one equal element at the same position." list1to5 list5to1
else
    printfn "Lists %A and %A do not have an equal element at the same position." list1to5 list5to1
//output: Lists [1; 2; 3; 4; 5] and [5; 4; 3; 2; 1] have at least one equal element at the same position.

//List.forall tests whether all elements of a list meet a particular condition
let isAllZeroes list = List.forall (fun elem -> elem = 0.0) list
printfn "%b" (isAllZeroes [0.0; 0.0]) //output: true
printfn "%b" (isAllZeroes [0.0; 1.0]) //output: false

//************************
//sort operations on lists can be used on many types and any type that implements IComparable (which must define
//a CompareTo function
//List.sort uses default comparison
let sortedList1 = List.sort [1; 4; 8; -2; 5]
printfn "%A" sortedList1  //output: [-2; 1; 4; 5; 8]

//List.sortBy uses a sort criterion, in this case we're dealing with absolute values of numbers
let sortedList2 = List.sortBy (fun elem -> abs elem) [1; 4; 8; -2; 5]
printfn "%A" sortedList2  //output: [1; -2; 4; 5; 8]

//List.sortWith can be used to sort lists one more than one field
type Person = {ID: int; Name: string}

let comparePeople person1 person2 = 
    if person1.ID < person2.ID then -1 else
    if person1.ID > person2.ID then 1 else
    if person1.Name < person2.Name then -1 else
    if person1.Name > person2.Name then 1 else
    0

let listOfPeople = [
    {ID = 4; Name = "Doc"}
    {ID = 2; Name = "Sleepy"}
    {ID = 3; Name = "Abraham"}
    {ID = 4; Name = "Abrahim"}
    ]

let sortedPersonList = List.sortWith comparePeople listOfPeople
printfn "%A" sortedPersonList

//***************
//searching lists
//List.find returns the first element that satisfies the criterion
let isDivisibleBy number elem = elem % number = 0
let result = List.find (isDivisibleBy 5) [ 1 .. 100 ]
printfn "%d " result //returns 5

//List.pick returns the key of a key value pair when searching by value. throws a KeyNotFound exception is none found
let valuesList = [ ("a", 1); ("b", 2); ("c", 3) ]

let resultPick = List.pick (fun elem ->
                    match elem with
                    | (value, 2) -> Some value
                    | _ -> None) valuesList
printfn "%A" resultPick  //output: "b"

//List.tryFind returns the first value that matches the criterion, or None if none is found
let list1d = [1; 3; 7; 9; 11; 13; 15; 19; 22; 29; 36]
let isEven x = x % 2 = 0
match List.tryFind isEven list1d with
| Some value -> printfn "The first even value is %d." value
| None -> printfn "There is no even value in the list." 
//output: The first even value is 22.

match List.tryFindIndex isEven list1d with
| Some value -> printfn "The first even value is at position %d." value
| None -> printfn "There is no even value in the list."
//output: The first even value is at position 8.





System.Console.ReadLine() |> ignore