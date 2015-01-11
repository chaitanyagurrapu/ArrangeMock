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
        private int TestPropertyToSaveIntIn { get; set; }

        [Test]
        public void ArgumentOfReferenceType_IsSavedInLocalVariable()
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
        public void ArgumentOfReferenceType_IsSavedInProperty()
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
        public void TwoArgumentsOfReferenceType_IsSavedInLocalVariable()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();
            string passedInString = null;
            int passedInInt = 0;

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.FinalisePaymentsForEmployeeForMonth(WithAnyArgument.OfType<string>(), WithAnyArgument.OfType<int>() ))
                             .IsCalled()
                             .TheArgumentsPassedIn()
                             .AreSavedTo(() => passedInString, 
                                         () => passedInInt);

            payrollSystemMock.Object.FinalisePaymentsForEmployeeForMonth("Foo",3);

            passedInString.ShouldBe("Foo");
            passedInInt.ShouldBe(3);

        }

        [Test]
        public void TwoArgumentsOfReferenceType_IsSavedInProperty()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();
            TestPropertyToSaveStringIn = null;

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.FinalisePaymentsForEmployeeForMonth(WithAnyArgument.OfType<string>(), WithAnyArgument.OfType<int>()))
                             .IsCalled()
                             .TheArgumentsPassedIn()
                             .AreSavedTo(() => TestPropertyToSaveStringIn,
                                         () => TestPropertyToSaveIntIn);

            payrollSystemMock.Object.FinalisePaymentsForEmployeeForMonth("Foo",3);

            TestPropertyToSaveStringIn.ShouldBe("Foo");
            TestPropertyToSaveIntIn.ShouldBe(3);
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

        [Test]
        public void ArgumentOfReferenceType_IsUsedToInvokeActionWithTwoParameters_Scenario1()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();
            string passedInString = null;
            int passedInInt = 0;

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.FinalisePaymentsForEmployeeForMonth(WithAnyArgument.OfType<string>(), WithAnyArgument.OfType<int>()))
                             .IsCalled()
                             .TheArgumentsPassedIn()
                             .AreUsedToInvokeAction<string, int>((x, i) => { passedInString = x; passedInInt = i; });

            payrollSystemMock.Object.FinalisePaymentsForEmployeeForMonth("Foo",3);

            passedInString.ShouldBe("Foo");
            passedInInt.ShouldBe(3);
        }

        [Test]
        public void ArgumentOfReferenceType_IsUsedToInvokeActionWithTwoParameters_Scenario2()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.FinalisePaymentsForEmployeeForMonth(WithAnyArgument.OfType<string>(), WithAnyArgument.OfType<int>()))
                             .IsCalled()
                             .TheArgumentsPassedIn()
                             .AreUsedToInvokeAction<string,int>(TestActionThatTakesTwoStringParameter);

            payrollSystemMock.Object.FinalisePaymentsForEmployeeForMonth("Foo",3);

            string1PassedToTestActionThatTakesAStringParameter.ShouldBe("Foo");
            int2PassedToTestActionThatTakesAStringParameter.ShouldBe(3);
        }

        private string string1PassedToTestActionThatTakesAStringParameter;
        private int int2PassedToTestActionThatTakesAStringParameter;
        private void TestActionThatTakesTwoStringParameter(string passedInString1, int passedInInt2)
        {
            string1PassedToTestActionThatTakesAStringParameter = passedInString1;
            int2PassedToTestActionThatTakesAStringParameter = passedInInt2;
        }
    }
}
