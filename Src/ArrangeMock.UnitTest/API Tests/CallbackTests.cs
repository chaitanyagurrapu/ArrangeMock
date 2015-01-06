using System;
using ArrangeMock.UnitTest.TestableInterfaces;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace ArrangeMock.UnitTest.APITests
{
    public class CallbackTests
    {
        [Test]
        [Ignore("Functionality Needs to be implemented")]
        public void ArgumentOfReferenceType_IsSavedBeforeIsCalled()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();
            string passedInString = null;


            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetSalaryForEmployee(WithAnyArgument.OfType<string>()))
                             .IsCalled()
                             .TheArgumentsPassedIn()
                             .AreSavedToLocalVariables(() => passedInString);

            payrollSystemMock.Object.GetSalaryForEmployee("Foo");

            passedInString.ShouldBe("Foo");
        }

        [Test]
        [Ignore("Functionality Needs to be implemented")]
        public void CanArrangeMethodWithAnyArgumentsAndVoidReturnType_AndUseCallbackToSaveArgument()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.FinalisePaymentsForEmployee(WithAnyArgument.OfType<string>()))
                             .IsCalled();
                             // TODO: Still need to work out this interface

            Assert.Fail();
        }
    }
}
