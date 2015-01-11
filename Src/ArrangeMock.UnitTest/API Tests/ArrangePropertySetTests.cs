using System;
using ArrangeMock.UnitTest.TestableArtifacts;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace ArrangeMock.UnitTest.APITests
{
    public class ArrangePropertySetTests
    {

        private bool TestPropertyToSaveBoolIn { get; set; }
        private PaymentGateway TestPropertyToSaveObjectIn { get; set; }

        [Test]
        public void CanArrangePropertySet_Scenario1()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();
            bool boolPassedToSet = false;

            payrollSystemMock.Arrange()
                             .SoThatWhenProperty(x => x.IsOnline)
                             .IsSet()
                             .ItIsSavedTo(() => boolPassedToSet);

            payrollSystemMock.Object.IsOnline = true;
            boolPassedToSet.ShouldBe(true);
        }

        [Test]
        public void CanArrangePropertySet_Scenario2()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();
            PaymentGateway savedStubPaymentGateway = null;
            var stubPaymentGatewayUsedToSet = new PaymentGateway();

            payrollSystemMock.Arrange()
                             .SoThatWhenProperty(x => x.PaymentGateway)
                             .IsSet()
                             .ItIsSavedTo(() => savedStubPaymentGateway);

            payrollSystemMock.Object.PaymentGateway = stubPaymentGatewayUsedToSet;
            savedStubPaymentGateway.ShouldBe(stubPaymentGatewayUsedToSet);
        }

        [Test]
        public void CanArrangePropertySet_Scenario3()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenProperty(x => x.IsOnline)
                             .IsSet()
                             .ItIsSavedTo(() => TestPropertyToSaveBoolIn);

            payrollSystemMock.Object.IsOnline = true;
            TestPropertyToSaveBoolIn.ShouldBe(true);
        }

        [Test]
        public void CanArrangePropertySet_Scenario4()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();
            var stubPaymentGatewayUsedToSet = new PaymentGateway();

            payrollSystemMock.Arrange()
                             .SoThatWhenProperty(x => x.PaymentGateway)
                             .IsSet()
                             .ItIsSavedTo(() => TestPropertyToSaveObjectIn);

            payrollSystemMock.Object.PaymentGateway = stubPaymentGatewayUsedToSet;
            TestPropertyToSaveObjectIn.ShouldBe(stubPaymentGatewayUsedToSet);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsExceptionWhenPassedAMethodCall()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();
            int employeeReturnedFromMethod = 0;

            payrollSystemMock.Arrange()
                             .SoThatWhenProperty(x => x.GetSalaryForEmployee("Foo"))
                             .IsSet()
                             .ItIsSavedTo(() => employeeReturnedFromMethod);
        }

    }
}
