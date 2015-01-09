using ArrangeMock.UnitTest.TestableInterfaces;
using Moq;
using NUnit.Framework;

namespace ArrangeMock.UnitTest.APITests
{
    public class AssertMethodTestAction : AssertMethodTestBase
    {
        protected override void InvokeMethodToBeVerified()
        {
            PayrollSystemMock.Object.FinaliseAllPayments();
        }

        protected override void AssertMethodWasCalled()
        {
            PayrollSystemMock.Assert()
                .ThatMethod(x => x.FinaliseAllPayments())
                .WasCalled();
        }

        protected override void AssertMethodWasCalledAtleast3Times()
        {
            PayrollSystemMock.Assert()
                .ThatMethod(x => x.FinaliseAllPayments())
                .WasCalled()
                .AtLeast(3)
                .Times();
        }

        protected override void AssertMethodWasCalledAtLeastOnce()
        {
            PayrollSystemMock.Assert()
                .ThatMethod(x => x.FinaliseAllPayments())
                .WasCalled()
                .AtLeastOnce();
        }
        protected override void AssertMethodWasCalledATMost2Times()
        {
            PayrollSystemMock.Assert()
                .ThatMethod(x => x.FinaliseAllPayments())
                .WasCalledAtMost(2)
                .Times();
        }

        protected override void AssertMethodWasCalledAtMostOnce()
        {
            PayrollSystemMock.Assert()
                .ThatMethod(x => x.FinaliseAllPayments())
                .WasCalledAtMostOnce();
        }

        protected override void AssertMethodWasCalledBetween2And3TimesInclusive()
        {
            PayrollSystemMock.Assert()
                 .ThatMethod(x => x.FinaliseAllPayments())
                 .WasCalledBetween(2)
                 .And(3).TimesIncludingTheToAndFromValues();
        }

        protected override void AssertMethodWasCalledBetween2And4TimesExclusive()
        {
            PayrollSystemMock.Assert()
                             .ThatMethod(x => x.FinaliseAllPayments())
                             .WasCalledBetween(2)
                             .And(4).TimesExcludingTheToAndFromValues();
        }

        protected override void AssertMethodWasCalledExactly2Times()
        {
            PayrollSystemMock.Assert()
                             .ThatMethod(x => x.FinaliseAllPayments())
                             .WasCalled()
                             .Exactly(2).Times();
        }

        protected override void AssertMethodWasNeverCalled()
        {
            PayrollSystemMock.Assert()
                .ThatMethod(x => x.FinaliseAllPayments())
                .WasNeverCalled();
        }

        protected override void AssertMethodWasCalledOnce()
        {
            PayrollSystemMock.Assert()
                .ThatMethod(x => x.FinaliseAllPayments())
                .WasCalled()
                .Once();
        }
    }
}
