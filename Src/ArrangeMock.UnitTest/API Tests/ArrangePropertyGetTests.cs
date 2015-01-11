using System;
using ArrangeMock.UnitTest.TestableArtifacts;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace ArrangeMock.UnitTest.APITests
{
    public class ArrangePropertyGetTests
    {

        [Test]
        public void CanArrangePropertyGet_Scenario1()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenProperty(x => x.IsOnline)
                             .IsAccessed()
                             .ItReturns(true);

            payrollSystemMock.Object.IsOnline.ShouldBe(true);
        }

        [Test]
        public void CanArrangePropertyGet_Scenario2()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();
            var stubPaymentGateway = new PaymentGateway();


            payrollSystemMock.Arrange()
                             .SoThatWhenProperty(x => x.PaymentGateway)
                             .IsAccessed()
                             .ItReturns(stubPaymentGateway);

            payrollSystemMock.Object.PaymentGateway.ShouldBe(stubPaymentGateway);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsExceptionWhenPassedAMethodCall()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenProperty(x => x.GetSalaryForEmployee("Foo"))
                             .IsAccessed()
                             .ItReturns(5);
        }

    }
}
