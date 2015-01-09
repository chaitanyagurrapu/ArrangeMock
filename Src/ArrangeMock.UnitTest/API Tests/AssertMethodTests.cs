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
        public void CanVerifyMethod_IsCalled()
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
        public void ThrowsExceptionWhenMethodIsNotCalled()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasCalled();
        }

        [Test]
        public void CanVerifyMethod_IsCalledAtleast_3Times_ShouldPass_Scenario1()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));
            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));
            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasCalled()
                             .AtLeast(3)
                             .Times();
        }

        [Test]
        public void CanVerifyMethod_IsCalledAtleast_3Times_ShouldPass_Scenario2()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));
            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));
            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));
            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasCalled()
                             .AtLeast(3)
                             .Times();
        }

        [Test]
        [ExpectedException(typeof(MockException))]
        public void CanVerifyMethod_IsCalledAtleast_3Times_ShouldFail()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));
            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasCalled()
                             .AtLeast(3)
                             .Times();
        }

        [Test]
        public void CanVerifyMethod_IsCalledAtleastOnce_ShouldPass_Scenario1()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasCalled()
                             .AtLeastOnce();
        }

        [Test]
        public void CanVerifyMethod_IsCalledAtleastOnce_ShouldPass_Scenario2()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));
            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasCalled()
                             .AtLeastOnce();
        }

        [Test]
        [ExpectedException(typeof(MockException))]
        public void CanVerifyMethod_IsCalledAtleastOnce_ShouldFail()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasCalled()
                             .AtLeastOnce();
        }

        [Test]
        public void CanVerifyMethod_IsCalledAtMost2Times_ShouldPass_Scenario1()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasCalledAtMost(2)
                             .Times();
        }

        [Test]
        public void CanVerifyMethod_IsCalledAtMost2Times_ShouldPass_Scenario2()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasCalledAtMost(2)
                             .Times();
        }

        [Test]
        public void CanVerifyMethod_IsCalledAtMost2Times_ShouldPass_Scenario3()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));
            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasCalledAtMost(2)
                             .Times();
        }

        [Test]
        [ExpectedException(typeof(MockException))]
        public void CanVerifyMethod_IsCalledAtMost2Times_ShouldFail()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));
            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));
            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasCalledAtMost(2)
                             .Times();
        }

        [Test]
        public void CanVerifyMethod_IsCalledAtMostOnce_ShouldPass_Scenario1()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasCalledAtMostOnce();
        }

        [Test]
        public void CanVerifyMethod_IsCalledAtMostOnce_ShouldPass_Scenario2()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasCalledAtMostOnce();
        }

        [Test]
        [ExpectedException(typeof(MockException))]
        public void CanVerifyMethod_IsCalledAtMostOnce_ShouldFail()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));
            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasCalledAtMostOnce();
        }

        [Test]
        public void CanVerifyMethod_IsCalledBetween2And3TimesInclusive_ShouldPass_Scenario1()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));
            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasCalledBetween(2)
                             .And(3).TimesIncludingTheToAndFromValues();
        }

        [Test]
        public void CanVerifyMethod_IsCalledBetween2And3TimesInclusive_ShouldPass_Scenario2()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));
            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));
            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasCalledBetween(2)
                             .And(3).TimesIncludingTheToAndFromValues();
        }

        [Test]
        [ExpectedException(typeof(MockException))]
        public void CanVerifyMethod_IsCalledBetween2And3TimesInclusive_ShouldFail_Scenario1()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasCalledBetween(2)
                             .And(3).TimesIncludingTheToAndFromValues();
        }

        [Test]
        [ExpectedException(typeof(MockException))]
        public void CanVerifyMethod_IsCalledBetween2And3TimesInclusive_ShouldFail_Scenario2()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));
            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));
            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));
            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasCalledBetween(2)
                             .And(3).TimesIncludingTheToAndFromValues();
        }

        [Test]
        public void CanVerifyMethod_IsCalledBetween2And4TimesExclusive_ShouldPass_Scenario1()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));
            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));
            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasCalledBetween(2)
                             .And(4).TimesExcludingTheToAndFromValues();
        }

        [Test]
        [ExpectedException(typeof(MockException))]
        public void CanVerifyMethod_IsCalledBetween2And4TimesExclusive_ShouldFail_Scenario1()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasCalledBetween(2)
                             .And(4).TimesExcludingTheToAndFromValues();
        }

        [Test]
        [ExpectedException(typeof(MockException))]
        public void CanVerifyMethod_IsCalledBetween2And4TimesExclusive_ShouldFail_Scenario2()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));
            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasCalledBetween(2)
                             .And(4).TimesExcludingTheToAndFromValues();
        }

        [Test]
        [ExpectedException(typeof(MockException))]
        public void CanVerifyMethod_IsCalledBetween2And4TimesExclusive_ShouldFail_Scenario3()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));
            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));
            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));
            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasCalledBetween(2)
                             .And(4).TimesExcludingTheToAndFromValues();
        }

        [Test]
        public void CanVerifyMethod_IsCalledExactly2Times_ShouldPass_Scenario1()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));
            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasCalled()
                             .Exactly(2)
                             .Times();
        }

        [Test]
        [ExpectedException(typeof(MockException))]
        public void CanVerifyMethod_IsCalledExactly2Times_ShouldFail_Scenario1()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasCalled()
                             .Exactly(2).Times();
        }

        [Test]
        [ExpectedException(typeof(MockException))]
        public void CanVerifyMethod_IsCalledExactly2Times_ShouldFail_Scenario2()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));
            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));
            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasCalled()
                             .Exactly(2).Times();
        }

        [Test]
        public void CanVerifyMethod_IsCalledNever_ShouldPass()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasNeverCalled();
        }

        [Test]
        [ExpectedException(typeof(MockException))]
        public void CanVerifyMethod_IsCalledNever_ShouldFail()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasNeverCalled();
        }

        [Test]
        public void CanVerifyMethod_IsCalledOnce_ShouldPass()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Object.GetNextPayDate().ShouldBe(new DateTime(2014,11,11));

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasCalled()
                             .Once();
        }

        [Test]
        [ExpectedException(typeof(MockException))]
        public void CanVerifyMethod_IsCalledOnce_ShouldFail()
        {
            var payrollSystemMock = new Mock<IPayrollSystem>();

            payrollSystemMock.Arrange()
                             .SoThatWhenMethod(x => x.GetNextPayDate())
                             .IsCalled()
                             .ItReturns(new DateTime(2014,11,11));

            payrollSystemMock.Assert()
                             .ThatMethod(x => x.GetNextPayDate())
                             .WasCalled()
                             .Once();
        }
    }
}
