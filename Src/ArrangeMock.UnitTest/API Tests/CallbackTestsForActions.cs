using System;
using ArrangeMock.UnitTest.TestableInterfaces;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace ArrangeMock.UnitTest.APITests
{
    public class CallbackTestsForActions
    {
        private string TestPropertyToSaveStringIn { get; set; }

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
        public void ForAction_ArgumentOfReferenceType_IsSavedInProperty()
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

        [Test]
        public void ArgumentOfReferenceType_IsUsedToInvokeAction_Scenario1()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();
            string passedInString = null;

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.FinalisePaymentsForEmployee(WithAnyArgument.OfType<string>()))
                             .IsCalled()
                             .TheArgumentsPassedIn()
                             .AreUsedToInvokeAction<string>(x => passedInString = x );

            payrollSystemMock.Object.FinalisePaymentsForEmployee("Foo");

            passedInString.ShouldBe("Foo");
        }

        [Test]
        public void ArgumentOfReferenceType_IsUsedToInvokeAction_Scenario2()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.FinalisePaymentsForEmployee(WithAnyArgument.OfType<string>()))
                             .IsCalled()
                             .TheArgumentsPassedIn()
                             .AreUsedToInvokeAction<string>(TestActionThatTakesAStringParameter);

            payrollSystemMock.Object.FinalisePaymentsForEmployee("Foo");

            stringPassedToTestActionThatTakesAStringParameter.ShouldBe("Foo");
        }

        private string stringPassedToTestActionThatTakesAStringParameter;
        private void TestActionThatTakesAStringParameter(string passedInString)
        {
            stringPassedToTestActionThatTakesAStringParameter = passedInString;
        }
    }
}
