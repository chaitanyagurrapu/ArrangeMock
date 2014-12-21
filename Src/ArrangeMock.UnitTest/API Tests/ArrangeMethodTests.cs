using System;
using System.Security.Cryptography.X509Certificates;
using ArrangeMock.Interfaces;
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
                             .IsCalledItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));
        }

        [Test]
        public void CanArrangeMethodWithAnyArgument()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetSalaryForEmployee(WithAnyArgument.OfType<string>()))
                             .IsCalledItReturns(5);

            payrollSystemMock.Object.GetSalaryForEmployee("Foo").ShouldBe(5);
        }

        [Test]
        [Ignore("Functionality Needs to be implemented")]
        public void CanArrangeMethodWithVoidReturnType()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();


            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.FinaliseAllPayments());
                             // TODO: Still need to work out this interface

            Assert.Fail();
        }

        [Test]
        [Ignore("Functionality Needs to be implemented")]
        public void CanArrangeMethodWithAnyArgumentsAndVoidReturnType()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();


            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.FinalisePaymentsForEmployee(WithAnyArgument.OfType<string>()));
                             // TODO: Still need to work out this interface

            Assert.Fail();
        }
    }
}
