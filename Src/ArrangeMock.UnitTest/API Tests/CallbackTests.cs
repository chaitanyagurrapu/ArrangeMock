using System;
using ArrangeMock.UnitTest.TestableInterfaces;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace ArrangeMock.UnitTest.APITests
{
    public class CallbackTests
    {
        private string TestPropertyToSaveStringIn { get; set; }

        [Test]
        public void ArgumentOfReferenceType_IsSavedInLocalVariable()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();
            string passedInString = null;

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetSalaryForEmployee(WithAnyArgument.OfType<string>()))
                             .IsCalled()
                             .TheArgumentsPassedIn()
                             .AreSavedTo(() => passedInString);

            payrollSystemMock.Object.GetSalaryForEmployee("Foo");

            passedInString.ShouldBe("Foo");
        }

        [Test]
        public void ArgumentOfReferenceType_IsSavedInProperty()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();
            TestPropertyToSaveStringIn = null;

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetSalaryForEmployee(WithAnyArgument.OfType<string>()))
                             .IsCalled()
                             .TheArgumentsPassedIn()
                             .AreSavedTo(() => TestPropertyToSaveStringIn);

            payrollSystemMock.Object.GetSalaryForEmployee("Foo");

            TestPropertyToSaveStringIn.ShouldBe("Foo");
        }

        [Test]
        public void ForAction_ArgumentOfReferenceType_IsSavedInLocalVariable()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();
            string passedInString = null;

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.FinalisePaymentsForEmployee(WithAnyArgument.OfType<string>()))
                             .IsCalled()
                             .TheArgumentsPassedIn()
                             .AreSavedTo(() => passedInString);

            payrollSystemMock.Object.FinalisePaymentsForEmployee("Foo");

            passedInString.ShouldBe("Foo");
        }

        [Test]
        public void For_Action_ArgumentOfReferenceType_IsSavedInProperty()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();
            TestPropertyToSaveStringIn = null;

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.FinalisePaymentsForEmployee(WithAnyArgument.OfType<string>()))
                             .IsCalled()
                             .TheArgumentsPassedIn()
                             .AreSavedTo(() => TestPropertyToSaveStringIn);

            payrollSystemMock.Object.FinalisePaymentsForEmployee("Foo");

            TestPropertyToSaveStringIn.ShouldBe("Foo");
        }
    }
}
