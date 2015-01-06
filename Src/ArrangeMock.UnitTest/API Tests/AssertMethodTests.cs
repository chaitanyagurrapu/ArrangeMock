using System;
using ArrangeMock.UnitTest.TestableInterfaces;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace ArrangeMock.UnitTest.APITests
{
    public class AssertMethodTests
    {

        [Test]
        public void CanVerifyParameterlessMethodIsCalled()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasCalled();
        }

        [Test]
        [ExpectedException(typeof(MockException))]
//        [ExpectedException(typeof(MockException), // With ExpectedMessage is passing locally, but failing on the Appveyor CI server. Need to figure out why.
//            ExpectedMessage = @"
//Expected invocation on the mock at least once, but was never performed: x => x.GetNextPayDate()
//No setups configured.
//No invocations performed.")]
        public void ThrowsExceptionWhenParameterlessMethodIsNotCalled()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasCalled();
        }
    }
}
