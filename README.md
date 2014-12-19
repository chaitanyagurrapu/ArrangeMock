# Make Mocking More Meaningful

Arrange mock makes it possible to write mocking code using more descriptive method names than the ones provided by mocking frameworks.

For example, consider the following set up using Moq ...

```
var payrollSystemMock = new Mock<IPayrollSystem>();

payrollSystemMock.Setup(x => x.GetSalaryForEmployee(It.IsAny<string>()))
                 .Returns(5);

```

For veteran mockers this is as clear as daylight. But if you are new to Moq or mocking in general, this can take some getting used to. Especially, the `It.IsAny<string>()` part where we want to 
specify that we don't care about the input to the method.

We can do better. Using ArrangeMock, the same set up looks like so ...

```
var payrollSystemMock = new Mock<IPayrollSystem>();

payrollSystemMock.Arrange()
                 .SoThatWhenMethod(x => x.GetSalaryForEmployee(IsCalledWith.AnyArgumentOfType<string>()))
                 .ItReturns(5);

```

The unfamiliar Moq method names, It.IsAny<T>() syntax and any other esoteric mocking setups are wrapped up in more descriptive and easy to read code.

ArrangeMock wraps up the common mocking scenarios. But if you need to do some very specific set up that is not aliased by ArrangeMock, 
you still have the original Moq object which can be used as per normal.

