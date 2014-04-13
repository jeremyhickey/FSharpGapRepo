//Tests for my Person class using F# MsTest
//http://blogs.msdn.com/b/fsharpteam/archive/2012/09/24/online-project-templates-nuget-and-unit-testing-with-f-in-vs2012.aspx

namespace UnitTestProject1

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open UnitTestingExample

[<TestClass>]
type UnitTest() = 
    [<TestMethod>]
    member x.TestMethodCreatePerson1 () = 
        let person1 = Person("John", 44)
        Assert.AreEqual(person1.Age, 44)
        Assert.AreEqual(person1.Name, "John")
    
    [<TestMethod>]
    member x.TestMethodCreatePerson2 () = 
        let person2 = Person("Louise")
        Assert.AreEqual(person2.Name, "Louise")
        Assert.AreEqual(person2.Age, 0)

    [<TestMethod>]
    member x.TestMethodChangeAge () = 
        let person3 = Person("Mary", 17)
        person3.Age <- 22
        Assert.AreEqual(person3.Age, 22)

    [<TestMethod>]
    member x.TestMethodIncrementAge () = 
        let person4 = Person("Jiminy", 99)
        person4.HasABirthday()
        Assert.AreEqual(person4.Age, 100)