# ArrangeMock [![Build status](https://ci.appveyor.com/api/projects/status/g28v083mu1widivv?svg=true)](https://ci.appveyor.com/project/chaitanyagurrapu/arrangemock)
## Make Mocking More Meaningful


ArrangeMock makes it possible to write mocking code using more descriptive method names than the ones provided by mocking frameworks.

For example, consider the following set up using Moq ...

```c#
var payrollSystemMock = new Mock<IPayrollSystem>();

payrollSystemMock.Setup(x => x.GetSalaryForEmployee(It.IsAny<string>()))
                 .Returns(5);

```

For veteran mockers this is as clear as daylight. But if you are new to Moq or mocking in general, this can take some getting used to. Especially, the `It.IsAny<string>()` part where we want to 
specify that we don't care about the input to the method.

We can do better. Using ArrangeMock, the same set up looks like so ...

```c#
var payrollSystemMock = new Mock<IPayrollSystem>();

payrollSystemMock.Arrange()
                 .SoThatWhenMethod(x => x.GetSalaryForEmployee(WithAnyArgument.OfType<string>()))
                 .IsCalled()
                 .ItReturns(5);

```



The unfamiliar Moq method names, It.IsAny<T>() syntax and any other esoteric mocking setups are wrapped up in more descriptive and easy to read code.

ArrangeMock wraps up the common mocking scenarios. But if you need to do some very specific set up that is not aliased by ArrangeMock, 
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



