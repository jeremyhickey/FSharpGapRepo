namespace UnitTestingExample

type Person(name:string, age:int) = 
    
    let mutable internalAge = age

    new(name:string) = Person(name, 0)

    member this.Name = name

    member this.Age
        with get() = internalAge
        and set(value) = internalAge <- value

    member this.HasABirthday () = internalAge <- internalAge + 1

    member this.IsOfAge targetAge = internalAge >= targetAge

    override this.ToString () = 
        "Name: " + name + "\n" + "Age: " + (string)internalAge