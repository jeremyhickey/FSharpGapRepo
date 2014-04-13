//Working through examples in Functions as First-Class Values tutorial
//http://msdn.microsoft.com/en-us/library/dd233158.aspx

//Measures of a first-class value:
//You can bind an identifier to it (give it a name)
//You can store the value in a data structure, such as a list
//You can pass the value as an argument to a function
//You can return the value from a function

//The last two measures define "higher-order" functions

//*******************************************************************
//Give it a name

//Examples of naming/defining a string and int

let myString = "Whitespace"
let myInteger = 100

//Example of naming/defining a function

let squareThis = fun num -> num * num

//We've bound the identifier squareThis to the lambda expression fun num -> num * num

//Or the more concise syntax. . .
let squareConcise num = num * num

//*******************************************************************
//Store it in a data structure

//Examples: lists
//ints and strings

let intList = [ 8; 6; 7; 5; 3; 0; 9 ]
let stringList = [ "one_potato"; "two_potato"; "three_potato"; "four" ]

//You can't mix datatypes in a list
//i.e. let noNo = [ 13; "never_do_this" ]

//Function with the same signature can be stored in a list
let squareThisValue = fun n -> n * n
let doubleThisValue = fun n -> 2 * n

let functionList = [ squareThisValue; doubleThisValue ]

//Examples: tuples
//ints and strings
let integerTuple = ( 0, -273 )
let stringTuple = ( "five_potato", "six_potato", "seven_potato", "peanut_butter_dump_truck" )

//Tuples can have mixed datatypes
let mixedTypeTuple = ( 1, "zwei", 3 )

//Functions in tuples can have different signatures
let area = fun height width -> height * width

let functionTuple = ( squareThisValue, area )

//You can mix functions with ints, strings and other types in tuples
let freeForAll = ( 1 , "whointhewhatnow?", area )

//You can pull a function out of a tuple an apply it
let functionAndArgTuple = ( squareThisValue, myInteger )

//Use the fst (first) and snd (second) operators to extract elements from tuple, then apply fst to snd
System.Console.WriteLine((fst functionAndArgTuple)(snd functionAndArgTuple))
//output: 10000

//You get the same result when you make a tuple of values
let functionAndArgTuple2 = ((fun n -> n * n), 100)
System.Console.WriteLine((fst functionAndArgTuple2)(snd functionAndArgTuple2))

//*******************************************************************
//Pass the value as an argument

//Values of first-class status can be passed as arguments to functions
let myNumber = 3000

System.Console.WriteLine(squareThisValue myNumber);//output: 9000000

//This function concatenates a string with itself
let concatMe = fun str -> str + str
let salutation = "Allo"
System.Console.WriteLine(concatMe salutation)//output: AlloAllo

//In the following example, two functions and an integer are passed as values to the same function

let applyIt = fun op arg -> op arg

//Semd squareThisValue as function "op" and myNumber for the argument "arg" you want to apply the 
//function to.

System.Console.WriteLine(applyIt squareThisValue myNumber) //output: 9000000

//This kind of operation is what underlies map or filter operations in functional programming languages

//Mapping example
//recall the list from before - let intList = [ 8; 6; 7; 5; 3; 0; 9 ]
let squareMyList = List.map squareThisValue intList
printfn "%A" squareMyList //output: [64; 36; 49; 25; 9; 0; 81]

//inline definition of the function you want to apply
//the following returns true if thisNum is even; otherwise false
let amIEven = List.map (fun thisNum -> thisNum % 2 = 0) intList
printfn "%A" amIEven //output: [true; true; false; false; false; true; false]


//*******************************************************************
//Return the value from a function call

//checkFor is a function that takes one argument, item and returns a new function as its value.
//the returned function takes a list as its argument, and seaches for item in lst
//returns true or false if present or not, respectively

let checkFor item = 
    let functionToReturn = fun lst ->
                           List.exists (fun a -> a = item) lst
    functionToReturn

let integerList = [ 1; 2; 3; 4; 5; 6; 7 ] 
let stringListBwah = [ "one"; "two"; "three"]

//The returned function is given the name checkFor7.  
let checkFor7 = checkFor 7

System.Console.WriteLine(checkFor7 integerList)//output: True

//Same for strings
let checkForSeven = checkFor "seven"

System.Console.WriteLine(checkForSeven stringListBwah)//output: False


//Function compose takes two arguments. Each argument is a function  
//that takes one argument of the same type. The following declaration 
//uses lambda expresson syntax. 
let compose = 
    fun op1 op2 ->
        fun n ->
            op1 (op2 n)

//To clarify what you are returning, use a nested let expression: 
let compose2 = 
    fun op1 op2 ->
        //Use a let expression to build the function that will be returned. 
        let funToReturn = fun n ->
                            op1 (op2 n)
        //Then just return it.
        funToReturn

//Or, more concisely
let compose3 op1 op2 =
    let funToReturn = fun n ->
                        op1 (op2 n)
    funToReturn

let doubleAndSquare = compose squareThisValue doubleThisValue

System.Console.WriteLine(doubleAndSquare 3);//output: 36

//Simple guessing game
let makeGame target =
    let game = fun guess ->
        if guess = target then
            System.Console.WriteLine("Correct!")
        else
            System.Console.WriteLine("Wrong.")
    game

//Play game
let playGame = makeGame 7

playGame 2
playGame 9
playGame 7

//output:   Wrong.
//          Wrong.
//          Correct!


//*******************************************************************
//Curried functions

//Currying transforms a function that has more than one parameter into a series of embedded functions,
//each with a single parameter

let compose4 op1 op2 n = op1 (op2 n)

//The result is a function of one parameter that returns a function of one parameter that returns another
//function of one parameter as demonstrated here:

let compose4Curried = 
    fun op1 ->
        fun op2 ->
            fun n -> op1 (op2 n)

let doubleAndSquare2 = compose4 squareThisValue doubleThisValue

System.Console.WriteLine(doubleAndSquare2 3)//output: 36

//makeGame curried

let makeGameCurried target guess = 
    if guess = target then
        System.Console.WriteLine("Correct!")
    else
        System.Console.WriteLine("Wrong")

let playGame2 = makeGameCurried 7
playGame2 2
playGame2 9
playGame2 7



System.Console.ReadLine() |> ignore