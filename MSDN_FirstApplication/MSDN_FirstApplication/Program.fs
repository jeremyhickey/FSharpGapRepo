//http://msdn.microsoft.com/en-us/library/dd233160.aspx

//to define and bind identifiers, use the 'let' keyword
let anInt = 5
let aString = "Hello" 

//perform a simple calculation and bind anIntSquared to the result 
let anIntSquared = anInt * anInt

System.Console.WriteLine(anInt)
System.Console.WriteLine(aString)
System.Console.WriteLine(anIntSquared)

//define a squaring function
let square n = n * n

//call the function to calculate the square of anInt, which has the value 5
let result = square anInt

//display the result
System.Console.WriteLine(result)

//define and call a recursive function
let rec factorial n = 
    if n = 0 
    then 1 
    else n * factorial (n - 1)
System.Console.WriteLine(factorial anInt)

//using tuples
let turnChoices = ("right", "left")
System.Console.WriteLine(turnChoices)

let intAndSquare = (anInt, square anInt)
System.Console.WriteLine(intAndSquare)

//defining lists
let bffs = [ "Susan"; "Kerry"; "Linda"; "Maria" ] 

//bffs is immutable, so we can't add to the list
//however, we can create a new copy of the list and add a value to it using the "cons" operator (::)
let newBffs = "Katie" :: bffs

//use a print function to display list contents
//note, the first list has not changed
printfn "%A" bffs
printfn "%A" newBffs

//creating and using a class

//this creates a constructor that takes two arguments
type Person(name:string, age:int) = 
    
    //use the 'let mutable'
    let mutable internalAge = age

    //declare a second constructor that takes only one argument
    //this constructor calls the two-argument constructor passing 0 for age
    new(name:string) = Person(name, 0)

    //read-only properties
    member this.Name = name

    //read-write properties
    member this.Age
        with get() = internalAge
        and set(value) = internalAge <- value

    //instance methods
    member this.HasABirthday () = internalAge <- internalAge + 1

    member this.IsOfAge targetAge = internalAge >= targetAge

    //override the ToString method of the Person class
    override this.ToString () = 
        "Name: " + name + "\n" + "Age: " + (string)internalAge

 
//testing the Person class 
let person1 = Person("John", 43)
let person2 = Person("Mary")

//change Mary's age
person2.Age <- 15

//John has a birthday
person1.HasABirthday()

System.Console.WriteLine(person1.ToString())
System.Console.WriteLine(person2.ToString())

//call IsOfAge function to determine if Mary is 18
System.Console.WriteLine(person2.IsOfAge(18))

//keep the console window open
System.Console.ReadLine() |> ignore

