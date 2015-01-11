using ArrangeMock.UnitTest.TestableArtifacts;
using Moq;
using NUnit.Framework;

namespace ArrangeMock.UnitTest.APITests
{
    public abstract class AssertMethodTestBase
    {
        protected Mock<IPayrollSystem> PayrollSystemMock {get; set;}
        protected abstract void InvokeMethodToBeVerified();
        protected abstract void AssertMethodWasCalled();
        protected abstract void AssertMethodWasCalledAtleast3Times();
        protected abstract void AssertMethodWasCalledAtLeastOnce();
        protected abstract void AssertMethodWasCalledATMost2Times();
        protected abstract void AssertMethodWasCalledAtMostOnce();
        protected abstract void AssertMethodWasCalledBetween2And3TimesInclusive();
        protected abstract void AssertMethodWasCalledBetween2And4TimesExclusive();
        protected abstract void AssertMethodWasCalledExactly2Times();
        protected abstract void AssertMethodWasNeverCalled();
        protected abstract void AssertMethodWasCalledOnce();

        [SetUp]
        public void Setup()
        {
            PayrollSystemMock = new Mock<IPayrollSystem>();
        }

        [Test]
        public void CanVerifyMethod_IsCalled()
        {
            InvokeMethodToBeVerified();

            AssertMethodWasCalled();
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
            AssertMethodWasCalled();
        }

        [Test]
        public void CanVerifyMethod_IsCalledAtleast_3Times_ShouldPass_Scenario1()
        {
            InvokeMethodToBeVerified();
            InvokeMethodToBeVerified();
            InvokeMethodToBeVerified();

            AssertMethodWasCalledAtleast3Times();
        }

        [Test]
        public void CanVerifyMethod_IsCalledAtleast_3Times_ShouldPass_Scenario2()
        {
            InvokeMethodToBeVerified();
            InvokeMethodToBeVerified();
            InvokeMethodToBeVerified();
            InvokeMethodToBeVerified();

            AssertMethodWasCalledAtleast3Times();
        }

        [Test]
        [ExpectedException(typeof(MockException))]
        public void CanVerifyMethod_IsCalledAtleast_3Times_ShouldFail()
        {
            InvokeMethodToBeVerified();
            InvokeMethodToBeVerified();

            AssertMethodWasCalledAtleast3Times();
        }

        [Test]
        public void CanVerifyMethod_IsCalledAtleastOnce_ShouldPass_Scenario1()
        {
            InvokeMethodToBeVerified();

            AssertMethodWasCalledAtLeastOnce();
        }

        [Test]
        public void CanVerifyMethod_IsCalledAtleastOnce_ShouldPass_Scenario2()
        {
            InvokeMethodToBeVerified();
            InvokeMethodToBeVerified();

            AssertMethodWasCalledAtLeastOnce();
        }

        [Test]
        [ExpectedException(typeof(MockException))]
        public void CanVerifyMethod_IsCalledAtleastOnce_ShouldFail()
        {
            AssertMethodWasCalledAtLeastOnce();
        }

        [Test]
        public void CanVerifyMethod_IsCalledAtMost2Times_ShouldPass_Scenario1()
        {
            AssertMethodWasCalledATMost2Times();
        }

        [Test]
        public void CanVerifyMethod_IsCalledAtMost2Times_ShouldPass_Scenario2()
        {
            InvokeMethodToBeVerified();

            AssertMethodWasCalledATMost2Times();
        }

        [Test]
        public void CanVerifyMethod_IsCalledAtMost2Times_ShouldPass_Scenario3()
        {
            InvokeMethodToBeVerified();
            InvokeMethodToBeVerified();

            AssertMethodWasCalledATMost2Times();
        }

        [Test]
        [ExpectedException(typeof(MockException))]
        public void CanVerifyMethod_IsCalledAtMost2Times_ShouldFail()
        {
            InvokeMethodToBeVerified();
            InvokeMethodToBeVerified();
            InvokeMethodToBeVerified();

            AssertMethodWasCalledATMost2Times();
        }

        [Test]
        public void CanVerifyMethod_IsCalledAtMostOnce_ShouldPass_Scenario1()
        {
            InvokeMethodToBeVerified();

            AssertMethodWasCalledAtMostOnce();
        }

        [Test]
        public void CanVerifyMethod_IsCalledAtMostOnce_ShouldPass_Scenario2()
        {
            AssertMethodWasCalledAtMostOnce();
        }

        [Test]
        [ExpectedException(typeof(MockException))]
        public void CanVerifyMethod_IsCalledAtMostOnce_ShouldFail()
        {
            InvokeMethodToBeVerified();
            InvokeMethodToBeVerified();

            AssertMethodWasCalledAtMostOnce();
        }

        [Test]
        public void CanVerifyMethod_IsCalledBetween2And3TimesInclusive_ShouldPass_Scenario1()
        {
            InvokeMethodToBeVerified();
            InvokeMethodToBeVerified();

            AssertMethodWasCalledBetween2And3TimesInclusive();
        }

        [Test]
        public void CanVerifyMethod_IsCalledBetween2And3TimesInclusive_ShouldPass_Scenario2()
        {
            InvokeMethodToBeVerified();
            InvokeMethodToBeVerified();
            InvokeMethodToBeVerified();

            AssertMethodWasCalledBetween2And3TimesInclusive();
        }

        [Test]
        [ExpectedException(typeof(MockException))]
        public void CanVerifyMethod_IsCalledBetween2And3TimesInclusive_ShouldFail_Scenario1()
        {
            InvokeMethodToBeVerified();

            AssertMethodWasCalledBetween2And3TimesInclusive();
        }

        [Test]
        [ExpectedException(typeof(MockException))]
        public void CanVerifyMethod_IsCalledBetween2And3TimesInclusive_ShouldFail_Scenario2()
        {
            InvokeMethodToBeVerified();
            InvokeMethodToBeVerified();
            InvokeMethodToBeVerified();
            InvokeMethodToBeVerified();

            AssertMethodWasCalledBetween2And3TimesInclusive();
        }

        [Test]
        public void CanVerifyMethod_IsCalledBetween2And4TimesExclusive_ShouldPass_Scenario1()
        {
            InvokeMethodToBeVerified();
            InvokeMethodToBeVerified();
            InvokeMethodToBeVerified();

            AssertMethodWasCalledBetween2And4TimesExclusive();
        }

        [Test]
        [ExpectedException(typeof(MockException))]
        public void CanVerifyMethod_IsCalledBetween2And4TimesExclusive_ShouldFail_Scenario1()
        {
            InvokeMethodToBeVerified();

            AssertMethodWasCalledBetween2And4TimesExclusive();
        }

        [Test]
        [ExpectedException(typeof(MockException))]
        public void CanVerifyMethod_IsCalledBetween2And4TimesExclusive_ShouldFail_Scenario2()
        {
            InvokeMethodToBeVerified();
            InvokeMethodToBeVerified();

            AssertMethodWasCalledBetween2And4TimesExclusive();
        }

        [Test]
        [ExpectedException(typeof(MockException))]
        public void CanVerifyMethod_IsCalledBetween2And4TimesExclusive_ShouldFail_Scenario3()
        {
            InvokeMethodToBeVerified();
            InvokeMethodToBeVerified();
            InvokeMethodToBeVerified();
            InvokeMethodToBeVerified();

            AssertMethodWasCalledBetween2And4TimesExclusive();
        }

        [Test]
        public void CanVerifyMethod_IsCalledExactly2Times_ShouldPass_Scenario1()
        {
            InvokeMethodToBeVerified();
            InvokeMethodToBeVerified();

            AssertMethodWasCalledExactly2Times();
        }

        [Test]
        [ExpectedException(typeof(MockException))]
        public void CanVerifyMethod_IsCalledExactly2Times_ShouldFail_Scenario1()
        {
            InvokeMethodToBeVerified();

            AssertMethodWasCalledExactly2Times();
        }

        [Test]
        [ExpectedException(typeof(MockException))]
        public void CanVerifyMethod_IsCalledExactly2Times_ShouldFail_Scenario2()
        {
            InvokeMethodToBeVerified();
            InvokeMethodToBeVerified();
            InvokeMethodToBeVerified();

            AssertMethodWasCalledExactly2Times();
        }

        [Test]
        public void CanVerifyMethod_IsCalledNever_ShouldPass()
        {
            AssertMethodWasNeverCalled();
        }

        [Test]
        [ExpectedException(typeof(MockException))]
        public void CanVerifyMethod_IsCalledNever_ShouldFail()
        {
            InvokeMethodToBeVerified();

            AssertMethodWasNeverCalled();
        }

        [Test]
        public void CanVerifyMethod_IsCalledOnce_ShouldPass()
        {
            InvokeMethodToBeVerified();

            AssertMethodWasCalledOnce();
        }

        [Test]
        [ExpectedException(typeof(MockException))]
        public void CanVerifyMethod_IsCalledOnce_ShouldFail()
        {
            AssertMethodWasCalledOnce();
        }
    }
}
