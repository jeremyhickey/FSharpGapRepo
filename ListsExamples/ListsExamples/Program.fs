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

//arithmetic operations on lists
//List.sum - the list element type must support the + operator and have a zero value
let sumOneToTen = List.sum [1 .. 10] //value is 55

//List.sumBy - computes the sum of a list with an operation applied to it
let sumOneToTenSquared = List.sumBy (fun elem -> elem*elem) [1 .. 10] //value = 385

//List.average computes the average of the elements of the list.  element type must support division without remainder,
// so ints won't work
let averageOfList = List.average [0.0; 1.0; 1.0; 2.0] //value = 1.0
//let averageOfList2 = List.average [0; 1; 2; 3] //compile time error

//****************************************************
//operating on list elements: List.iter and variations
//List.iter allows you to call a function on each item of a list
let list1 = [1; 2; 3]
let list2 = [4; 5; 6]

List.iter (fun x -> printfn "List.iter: element is %d" x) list1
//output:
//List.iter: element is 1
//List.iter: element is 2
//List.iter: element is 3

//List.iteri is like List.iter except the index of each item is passed as an argument to the function called
List.iteri(fun i x -> printfn "List.iteri: element %d is %d" i x) list1

//output:
//List.iteri: element 0 is 1
//List.iteri: element 1 is 2
//List.iteri: element 2 is 3

//List.iter2 operates on two lists, as does List.iteri2
List.iter2 (fun x y -> printfn "List.iter2: elements are %d %d" x y) list1 list2
List.iteri2 (fun i x y ->
               printfn "List.iteri2: element %d of list1 is %d element %d of list2 is %d"
                 i x i y)
            list1 list2
//output:
//List.iter2: elements are 1 4
//List.iter2: elements are 2 5
//List.iter2: elements are 3 6
//List.iteri2: element 0 of list1 is 1; element 0 of list2 is 4
//List.iteri2: element 1 of list1 is 2; element 1 of list2 is 5
//List.iteri2: element 2 of list1 is 3; element 2 of list2 is 6

//List.map allows you to do the same things as List.iter variations and pull data into a new list
let listOneToThree = [1; 2; 3]
let newListMapped = List.map (fun x -> x + 1) listOneToThree //adds one to each element and creates new list
printfn "%A" newListMapped
//output: [2; 3; 4]

let listUnATrois = [1; 2; 3]
let listQuatreASeize = [4; 5; 6]
let sumList = List.map2 (fun x y -> x + y) listUnATrois listQuatreASeize
printfn "%A" sumList
//output: [5; 7; 9]

let newListAddIndex = List.mapi (fun i x -> x + i) listOneToThree //adds index of element to its value and creates new list
printfn "%A" newListAddIndex
//output: [1; 3; 5]

//List.collect is like List.map but each element produces a new list and the lists are concatenated together
let collectList = List.collect (fun x -> [for i in 1..3 -> x * i]) listUnATrois //each element gets multiplied by the for index
printfn "%A" collectList
//output: [1; 2; 3; 2; 4; 6; 3; 6; 9]

//List.filter filters the list to satisfy a condition
let evenOnlyList = List.filter (fun x -> x % 2 = 0) [1; 2; 3; 4; 5; 6]
//produces [2; 4; 6]

//List.choose combines map and filter, enabling you to select and apply a function to elements matching your criterion
let listWords = [ "blame"; "It"; "On"; "the"; "rain" ]
let isCapitalized (string1:string) = System.Char.IsLower string1.[0]
let results = List.choose (fun elem ->
    match elem with
    | elem when isCapitalized elem -> Some(elem + "ses")
    | _ -> None) listWords
printfn "%A" results
//output: ["blameses"; "theses"; "rainses"]

//appending and concatenating lists
let list1to10 = List.append [1; 2; 3] [4; 5; 6; 7; 8; 9; 10]
let listResult = List.concat [ [1; 2; 3]; [4; 5; 6]; [7; 8; 9] ]
List.iter (fun elem -> printf "%d " elem) list1to10 //print each element.  output: 1 2 3 4 5 6 7 8 9 10
printfn ""
List.iter (fun elem -> printf "%d " elem) listResult //output: 1 2 3 4 5 6 7 8 9
printfn ""

//List.fold is like List.iter and List.map only you can pass a second accumulative argument that carries 
//info throughout and returns the final value of that extra parameter
let sumListNew list = List.fold (fun acc elem -> acc + elem) 0 list
printfn "Sum of the elements of list %A is %d." [ 1 .. 3 ] (sumListNew [ 1 .. 3 ])
//output: Sum of the elements of list [1; 2; 3] is 6.

//List.fold2 can be applied to two lists of equal size
let sumGreatest list1 list2 = List.fold2 (fun acc elem1 elem2 ->
                                              acc + max elem1 elem2) 0 list1 list2

let sum = sumGreatest [1; 2; 3] [3; 2; 1]
printfn "The sum of the greater of each pair of elements in the two lists is %d." sum
//result = 8

//use List.fold2 to use two lists of different type.  the function executed can use elements of each list for different things
type Transaction =
    | Deposit
    | Withdrawal

let transactionTypes = [Deposit; Deposit; Withdrawal]
let transactionAmounts = [100.00; 1000.00; 95.00 ]
let initialBalance = 200.00

let endingBalance = List.fold2 (fun acc elem1 elem2 ->  //acc begins with value of initial balance, elem1 
                                match elem1 with        //is transactionTypes list and elem2 is transactionAmounts list
                                | Deposit -> acc + elem2  //if transactionType is Deposit, add
                                | Withdrawal -> acc - elem2)  //if transactionType is Withdrawal, subtract
                                initialBalance
                                transactionTypes
                                transactionAmounts
printfn "%f" endingBalance //output: 1205.000000

//conversion between Lists and Sequences or Arrays
//built-in List.toSeq or List.ofSeq
//built-in List.toArray or List.ofArray


System.Console.ReadLine() |> ignore