# ArrangeMock [![Build status](https://ci.appveyor.com/api/projects/status/g28v083mu1widivv?svg=true)](https://ci.appveyor.com/project/chaitanyagurrapu/arrangemock)
## Make Mocking More Meaningful


ArrangeMock makes it possible to write mocking code using more descriptive method names than the ones provided by mocking frameworks.

For example, consider the following set up using Moq ...

```c#
var payrollSystemMock = new Mock<IPayrollSystem>();

payrollSystemMock.Setup(x => x.GetSalaryForEmployee(It.IsAny<string>()))
                 .Returns(5);

```

For veteran mockers this is probably self explanatory. But if you are new to Moq or mocking in general, this can take some getting used to. Especially, the `It.IsAny<string>()` part where we want to 
specify that we don't care about the input to the method.

We can do better. Using ArrangeMock, the same set up looks like so ...

```c#
var payrollSystemMock = new Mock<IPayrollSystem>();

payrollSystemMock.Arrange()
                 .SoThatWhenMethod(x => x.GetSalaryForEmployee(WithAnyArgument.OfType<string>()))
                 .IsCalled()
                 .ItReturns(5);

```

Or consider the following, more complex scenario - we need to set up a method to return a particular value and capture the arguments that were used to invoke this method. 
In Moq, this is usually done with a callback like so ...

```c#
var payrollSystemMock = new Mock<IPayrollSystem>();
var employeePassedToMethod = null;

payrollSystemMock.Setup(x => x.GetSalaryForEmployee(It.IsAny<string>()))
                 .Returns(5)
                 .Callback<string>(x => employeePassedToMethod = x);

```

Anyone who had to set up this scenario had to spend some time googling before discovering the "Callback" method and how it can be used. The same set up in ArrangeMock looks like so ...


```c#
var payrollSystemMock = new Mock<IPayrollSystem>();
var employeePassedToMethod = null;

payrollSystemMock.Arrange()
                 .SoThatWhenMethod(x => x.GetSalaryForEmployee(WithAnyArgument.OfType<string>()))
                 .IsCalled()
                 .ItReturns(5)
                 .AndTheArgumentsPassedIn()
                 .AreSavedTo(() => employeePassedToMethod);

```

This is a lot more intuitive and easy to read.

With ArrangeMock, the unfamiliar Moq method names, It.IsAny<T>() syntax and any other esoteric mocking setups are wrapped up in more descriptive and easy to read code.

While ArrangeMock wraps up the common mocking scenarios and patterns if you need to set up a scenario that is not aliased by ArrangeMock 
you still have the original Moq object which can be used as per normal.

### Setup 
#### Functions

With ArrangeMock, a function that doesn't take any arguments and returns a value can be mocked like so ...

```c#
var payrollSystemMock = new Mock<IPayrollSystem>();

payrollSystemMock.Arrange()
                 .SoThatWhenMethod(x => x.GetNextPayDate())
                 .IsCalled()
                 .ItReturns(new DateTime(2014,11,11));
```

With ArrangeMock, a function that takes an argument of type string and returns a value can be mocked like so ...

```c#
var payrollSystemMock = new Mock<IPayrollSystem>();

payrollSystemMock.Arrange()
                 .SoThatWhenMethod(x => x.GetSalaryForEmployee(WithAnyArgument.OfType<string>()))
                 .IsCalled()
                 .ItReturns(5);

payrollSystemMock.Object.GetSalaryForEmployee("Foo").ShouldBe(5);
```

### Verify
In Moq, the "Verify" method is used to assert that a method was called on the mock. In ArrangeMock, this function is performed
by the "Assert" method.

#### Functions

With ArrangeMock, given a method that doesnt't take any parameters, we can confirm that it was called at least once like so ...

```c#
var payrollSystemMock = new Mock<IPayrollSystem>();

payrollSystemMock.Arrange()
                 .SoThatWhenMethod(x => x.GetNextPayDate())
                 .IsCalled()
                 .ItReturns(new DateTime(2014,11,11));

payrollSystemMock.Assert()
                 .ThatMethod(x => x.GetNextPayDate())
                 .WasCalled();
```

### Processing Method Arguments
In Moq, the "Callback" method is used to take the arguments that are passed in to a method and process them further. In ArrangeMock,
this function is performed by the "TheArgumentsPassedIn" method.


#### Saving arguments.
With ArrangeMock, given a method that has one parameter, we can save the argument that was actually passed in like so ...

```c#
var payrollSystemMock = new Mock<IPayrollSystem>();
string passedInString = null;

payrollSystemMock.Arrange()
                 .SoThatWhenMethod(x => x.GetSalaryForEmployee(WithAnyArgument.OfType<string>()))
                 .IsCalled()
                 .TheArgumentsPassedIn()
                 .AreSavedTo(() => passedInString);
```
