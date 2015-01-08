using System;
using ArrangeMock.UnitTest.TestableInterfaces;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace ArrangeMock.UnitTest.APITests
{
    public class ArrangeMethodTests
    {

        [Test]
        public void CanArrangeParameterlessMethod()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));
        }
        
        [Test]
        public void CanArrangeMethodWithAnyArgument()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetSalaryForEmployee(WithAnyArgument.OfType<string>()))
                             .IsCalled()
                             .ItReturns(5);

            payrollSystemMock.Object.GetSalaryForEmployee("Foo").ShouldBe(5);
        }

        [Test]
        public void CanArrangeMethodWithTwoAnyArguments()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetSalaryForEmployeeForYear(WithAnyArgument.OfType<string>(),
                                                                                  WithAnyArgument.OfType<int>()))
                             .IsCalled()
                             .ItReturns(6);

            payrollSystemMock.Object.GetSalaryForEmployeeForYear("Foo", 2014).ShouldBe(6);
        }

        [Test]
        public void CanArrangeMethodWithThreeAnyArguments()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetSalaryForEmployeeForPeriod(WithAnyArgument.OfType<string>(),
                                                                                    WithAnyArgument.OfType<DateTime>(),
                                                                                    WithAnyArgument.OfType<DateTime>()))
                             .IsCalled()
                             .ItReturns(6);

            payrollSystemMock.Object
                             .GetSalaryForEmployeeForPeriod("Foo", DateTime.Now.AddYears(-2), DateTime.Now.AddYears(-1))
                             .ShouldBe(6);
        }

    }
}
