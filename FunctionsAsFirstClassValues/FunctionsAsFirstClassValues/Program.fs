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

let myString = "erhmahgerd"
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
let stringTuple = ( "five_potato", "siz_potato", "seven_potato", "peanut_butter_dump_truck" )

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



System.Console.ReadLine() |> ignore