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

We can do better. 
Using ArrangeMock, the same set up looks like so ...

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
string employeePassedToMethod = null;

payrollSystemMock.Setup(x => x.GetSalaryForEmployee(It.IsAny<string>()))
                 .Returns(5)
                 .Callback<string>(x => employeePassedToMethod = x);

```

Anyone who had to set up this scenario had to spend some time googling before discovering the "Callback" method and how it can be used. 
And any subsequent developer who hasn't seen the "Callback" method of Moq before will probably have to look it up as well.

The same set up in ArrangeMock looks like so ...

```c#
var payrollSystemMock = new Mock<IPayrollSystem>();
string employeePassedToMethod = null;

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

Using ArrangeMock along with such wonderful libraries as [Shouldly](https://github.com/shouldly/shouldly) (which was the inspiration for this project) allows us to write descriptive
tests that read like functional specifications of the application.

### Installation
[ArrangeMock on Nuget.org](https://www.nuget.org/packages/ArrangeMock/1.0.0)

### Contents
#### Setup Methods
[Method without any arguments](#method-without-any-arguments)

[Method with one argument](#method-with-one-argument)

[Method with more than one argument](#method-with-more-than-one-argument)

#### Setup properties
[Property get](#property-get)

[Property set with callback](#property-set-with-callback)

#### Verify
[Method was called](#method-was-called)

[Method was called at least x times](#method-was-called-at-least-x-times)

[Method was called at least once](#method-was-called-at-least-once)

[Method was called at most x times](#method-was-called-at-most-x-times)

[Method was called at most once](#method-was-called-at-most-once)

[Method was called between x and y times (inclusive)](#method-was-called-between-x-and-y-times-inclusive)

[Method was called between x and y times (exclusive)](#method-was-called-between-x-and-y-times-exclusive)

[Method was called exactly x times](#method-was-called-exactly-x-times)

[Method was never called](#method-was-never-called)

[Method was called once](#method-was-called-once)

#### Callback
[Saving arguments](#saving-arguments)

[Saving multiple arguments](#saving-multiple-arguments)

[Using arguments to invoke an action](#using-arguments-to-invoke-an-action)

[Using multiple arguments to invoke an action](#using-multiple-arguments-to-invoke-an-action)

### Setup methods
#### Method without any arguments

With ArrangeMock, a function that doesn't take any arguments and returns a value can be mocked like so ...

```c#
var payrollSystemMock = new Mock<IPayrollSystem>();

payrollSystemMock.Arrange()
                 .SoThatWhenMethod(x => x.GetNextPayDate())
                 .IsCalled()
                 .ItReturns(new DateTime(2014,11,11));
```

#### Method with one argument
With ArrangeMock, a function that takes an argument of type string and returns a value can be mocked like so ...

```c#
var payrollSystemMock = new Mock<IPayrollSystem>();

payrollSystemMock.Arrange()
                 .SoThatWhenMethod(x => x.GetSalaryForEmployee(WithAnyArgument.OfType<string>()))
                 .IsCalled()
                 .ItReturns(5);

payrollSystemMock.Object.GetSalaryForEmployee("Foo").ShouldBe(5);
```
#### Method with more than one argument
With ArrangeMock, a function that takes arguments of type string and int and returns a value can be mocked like so ...

```c#
var payrollSystemMock = new Mock<IPayrollSystem>();

payrollSystemMock.Arrange()
                 .SoThatWhenMethod(x => x.GetSalaryForEmployeeForYear(WithAnyArgument.OfType<string>(),
                                                                      WithAnyArgument.OfType<int>()))
                 .IsCalled()
                 .ItReturns(6);

payrollSystemMock.Object.GetSalaryForEmployeeForYear("Foo", 2014).ShouldBe(6);
```

### Setup properties
#### Property get

With ArrangeMock, the accessing of a property can be mocked like so ...

```c#
var payrollSystemMock = new Mock<IPayrollSystem>();

payrollSystemMock.Arrange()
                 .SoThatWhenProperty(x => x.IsOnline)
                 .IsAccessed()
                 .ItReturns(true);
```

#### Property set with callback

With ArrangeMock, when a property is set, the value provided to the setter can be saved locally like so ...

```c#
var payrollSystemMock = new Mock<IPayrollSystem>();

bool boolPassedToSet = false;

payrollSystemMock.Arrange()
                 .SoThatWhenProperty(x => x.IsOnline)
                 .IsSet()
                 .ItIsSavedTo(() => boolPassedToSet);
```

### Verify
In Moq, the "Verify" method is used to assert that a method was called on the mock. In ArrangeMock, this function is performed
by the "Assert" method.

#### Method was called

With ArrangeMock, given a method that doesn't take any parameters, we can confirm that it was called at least once like so ...

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

#### Method was called at least x times

With ArrangeMock, given a method that doesn't take any parameters, we can confirm that it was called at least 3 times like so ...

```c#
var payrollSystemMock = new Mock<IPayrollSystem>();

payrollSystemMock.Arrange()
                 .SoThatWhenMethod(x => x.GetNextPayDate())
                 .IsCalled()
                 .ItReturns(new DateTime(2014,11,11));

payrollSystemMock.Assert()
                 .ThatMethod(x => x.GetNextPayDate())
                 .WasCalled()
                 .AtLeast(3)
                 .Times();
```

#### Method was called at least once

With ArrangeMock, given a method that doesn't take any parameters, we can confirm that it was called at least once like so ...

```c#
var payrollSystemMock = new Mock<IPayrollSystem>();

payrollSystemMock.Arrange()
                 .SoThatWhenMethod(x => x.GetNextPayDate())
                 .IsCalled()
                 .ItReturns(new DateTime(2014,11,11));

payrollSystemMock.Assert()
                 .ThatMethod(x => x.GetNextPayDate())
                 .WasCalled()
                 .AtLeastOnce();
```

#### Method was called at most x times

With ArrangeMock, given a method that doesn't take any parameters, we can confirm that it was called at most 2 times like so ...

```c#
var payrollSystemMock = new Mock<IPayrollSystem>();

payrollSystemMock.Arrange()
                 .SoThatWhenMethod(x => x.GetNextPayDate())
                 .IsCalled()
                 .ItReturns(new DateTime(2014,11,11));

payrollSystemMock.Assert()
                 .ThatMethod(x => x.GetNextPayDate())
                 .WasCalledAtMost(2)
                 .Times();
```

#### Method was called at most once

With ArrangeMock, given a method that doesn't take any parameters, we can confirm that it was called at most once like so ...

```c#
var payrollSystemMock = new Mock<IPayrollSystem>();

payrollSystemMock.Arrange()
                 .SoThatWhenMethod(x => x.GetNextPayDate())
                 .IsCalled()
                 .ItReturns(new DateTime(2014,11,11));

payrollSystemMock.Assert()
                 .ThatMethod(x => x.GetNextPayDate())
                 .WasCalledAtMostOnce();
```
#### Method was called between x and y times (inclusive)

With ArrangeMock, given a method that doesn't take any parameters, we can confirm that it was called at least 2 and and no more than 3 times like so ...

```c#
var payrollSystemMock = new Mock<IPayrollSystem>();

payrollSystemMock.Arrange()
                 .SoThatWhenMethod(x => x.GetNextPayDate())
                 .IsCalled()
                 .ItReturns(new DateTime(2014,11,11));

payrollSystemMock.Assert()
                 .ThatMethod(x => x.GetNextPayDate())
                 .WasCalledBetween(2)
                 .And(3).TimesIncludingTheToAndFromValues();
```

#### Method was called between x and y times (exclusive)

With ArrangeMock, given a method that doesn't take any parameters, we can confirm that it was called more than 2 and less than 4 times like so ...

```c#
var payrollSystemMock = new Mock<IPayrollSystem>();

payrollSystemMock.Arrange()
                 .SoThatWhenMethod(x => x.GetNextPayDate())
                 .IsCalled()
                 .ItReturns(new DateTime(2014,11,11));

payrollSystemMock.Assert()
                 .ThatMethod(x => x.GetNextPayDate())
                 .WasCalledBetween(2)
                 .And(4).TimesExcludingTheToAndFromValues();
```

#### Method was called exactly x times

With ArrangeMock, given a method that doesn't take any parameters, we can confirm that it was called exactly 2 times like so ...

```c#
var payrollSystemMock = new Mock<IPayrollSystem>();

payrollSystemMock.Arrange()
                 .SoThatWhenMethod(x => x.GetNextPayDate())
                 .IsCalled()
                 .ItReturns(new DateTime(2014,11,11));

payrollSystemMock.Assert()
                 .ThatMethod(x => x.GetNextPayDate())
                 .WasCalled()
                 .Exactly(2)
                 .Times();
```

#### Method was never called

With ArrangeMock, given a method that doesn't take any parameters, we can confirm that it was never called like so ...

```c#
var payrollSystemMock = new Mock<IPayrollSystem>();

payrollSystemMock.Arrange()
                 .SoThatWhenMethod(x => x.GetNextPayDate())
                 .IsCalled()
                 .ItReturns(new DateTime(2014,11,11));

payrollSystemMock.Assert()
                 .ThatMethod(x => x.GetNextPayDate())
                 .WasNeverCalled();
```
#### Method was called once

With ArrangeMock, given a method that doesn't take any parameters, we can confirm that it was never called once like so ...

```c#
var payrollSystemMock = new Mock<IPayrollSystem>();

payrollSystemMock.Arrange()
                 .SoThatWhenMethod(x => x.GetNextPayDate())
                 .IsCalled()
                 .ItReturns(new DateTime(2014,11,11));

payrollSystemMock.Assert()
                 .ThatMethod(x => x.GetNextPayDate())
                 .WasCalled()
                 .Once();
```

### Callback
In Moq, the "Callback" method is used to take the arguments that are passed in to a method and process them further. In ArrangeMock,
this function is performed by the "TheArgumentsPassedIn" method.


#### Saving arguments
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

#### Saving multiple arguments
With ArrangeMock, given a method that has more than one parameter, we can save the argument that were actually passed in like so ...

```c#
var payrollSystemMock = new Mock<IPayrollSystem>();
string passedInString = null;
int passedInInt = 0;

payrollSystemMock.Arrange()
                 .SoThatWhenMethod(x => x.FinalisePaymentsForEmployeeForMonth(WithAnyArgument.OfType<string>(), WithAnyArgument.OfType<int>() ))
                 .IsCalled()
                 .TheArgumentsPassedIn()
                 .AreSavedTo(() => passedInString, 
                             () => passedInInt);
```

#### Using arguments to invoke an action
With ArrangeMock, given a method that has one parameter, we can use the argument that was actually passed in to invoke an action like so ...

```c#
var payrollSystemMock = new Mock<IPayrollSystem>();
string passedInString = null;

payrollSystemMock.Arrange()
                 .SoThatWhenMethod(x => x.GetSalaryForEmployee(WithAnyArgument.OfType<string>()))
                 .IsCalled()
                 .TheArgumentsPassedIn()
                 .AreUsedToInvokeAction<string>(x => passedInString = x );
```

#### Using multiple arguments to invoke an action
With ArrangeMock, given a method that has more than one parameter, we can use the arguments that were actually passed in to invoke an action like so ...

```c#
var payrollSystemMock = new Mock<IPayrollSystem>();
string passedInString = null;
int passedInInt = 0;

payrollSystemMock.Arrange()
                 .SoThatWhenMethod(x => x.GetSalaryForEmployeeForYear(WithAnyArgument.OfType<string>(), WithAnyArgument.OfType<int>()))
                 .IsCalled()
                 .TheArgumentsPassedIn()
                 .AreUsedToInvokeAction<string, int>((x, i) => { passedInString = x; passedInInt = i; });
```
