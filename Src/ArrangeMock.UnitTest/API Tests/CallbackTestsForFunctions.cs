using System;
using ArrangeMock.UnitTest.TestableInterfaces;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace ArrangeMock.UnitTest.APITests
{
    public class CallbackTestsForFunctions
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
        public void ArgumentOfReferenceType_IsSavedInLocalVariable_AndReturnsValue()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();
            string passedInString = null;

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetSalaryForEmployee(WithAnyArgument.OfType<string>()))
                             .IsCalled()
                             .ItReturns(5)
                             .AndTheArgumentsPassedIn()
                             .AreSavedTo(() => passedInString);

            var returnValueFromMock = payrollSystemMock.Object.GetSalaryForEmployee("Foo");

            passedInString.ShouldBe("Foo");
            returnValueFromMock.ShouldBe(5);
        }

        [Test]
        public void ArgumentOfReferenceType_IsSavedInProperty_AndReturnsValue()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();
            TestPropertyToSaveStringIn = null;

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetSalaryForEmployee(WithAnyArgument.OfType<string>()))
                             .IsCalled()
                             .ItReturns(5)
                             .AndTheArgumentsPassedIn()
                             .AreSavedTo(() => TestPropertyToSaveStringIn);

            var returnValueFromMock = payrollSystemMock.Object.GetSalaryForEmployee("Foo");

            TestPropertyToSaveStringIn.ShouldBe("Foo");
            returnValueFromMock.ShouldBe(5);
        }
    }
}
