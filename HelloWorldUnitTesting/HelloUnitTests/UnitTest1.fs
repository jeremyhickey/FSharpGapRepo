namespace UnitTest1

open Microsoft.VisualStudio.TestTools.UnitTesting
open HelloWorldUnitTesting.HelloWorld

[<TestClass>]
type Test_UnitTest1() =
    [<TestMethod>]        
    let shouldSayHello () = Assert.AreEqual("Hello World", sayHello "World")