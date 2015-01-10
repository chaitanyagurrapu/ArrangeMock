using System;
using System.Linq.Expressions;
using ArrangeMock.Interfaces;
using Moq;

namespace ArrangeMock
{
    internal class SoThatWhenAction<T> : ISoThatWhenAction<T>, 
                                         IActionIsCalled<T>,
                                         IArgumentPassedIn,
                                         IBetween,
                                         IBetweenTimes,
                                         IThatMethod,
                                         IWasCalled,
                                         ITimes
                                         where T : class
    {
        private readonly Expression<Action<T>> _actionToArrange;
        private Expression<Action<T>> _moqExpressionCastToOriginalType;
        private Mock<T> _mockToArrange;
        private Expression _actionToArrangeConvertedToMoqExpression;
        private int wasCalledBetweenFromNumber;
        private int wasCalledBetweenToNumber;

        internal SoThatWhenAction(Mock<T> mockToArrange, Expression<Action<T>> actionToArrange)
        {
            _mockToArrange = mockToArrange;
            _actionToArrange = actionToArrange;
            _actionToArrangeConvertedToMoqExpression = ExpressionConverter.ConvertArrangeMockExpressionToMoqExpression(_actionToArrange);
            _moqExpressionCastToOriginalType = (Expression<Action<T>>)_actionToArrangeConvertedToMoqExpression;
        }


        public IActionIsCalled<T> IsCalled()
        {
            return this;
        }

        public IArgumentPassedIn TheArgumentsPassedIn()
        {
            return this;
        }

        public IWasCalled WasCalled()
        {
            _mockToArrange.Verify(_moqExpressionCastToOriginalType);
            return this;
        }

        public ITimes AtLeast(int number)
        {
            _mockToArrange.Verify(_moqExpressionCastToOriginalType, Moq.Times.AtLeast(number));
            return this;
        }

        public void AtLeastOnce()
        {
            _mockToArrange.Verify(_moqExpressionCastToOriginalType, Moq.Times.AtLeastOnce);
        }

        public ITimes WasCalledAtMost(int number)
        {
            _mockToArrange.Verify(_moqExpressionCastToOriginalType, Moq.Times.AtMost(number));
            return this;
        }

        public void WasCalledAtMostOnce()
        {
            _mockToArrange.Verify(_moqExpressionCastToOriginalType, Moq.Times.AtMostOnce());
        }

        public IBetween WasCalledBetween(int number)
        {
            wasCalledBetweenFromNumber = number;
            return this;
        }

        public IBetweenTimes And(int number)
        {
            wasCalledBetweenToNumber = number;
            return this;
        }

        public void TimesIncludingTheToAndFromValues()
        {
            _mockToArrange.Verify(_moqExpressionCastToOriginalType, Moq.Times.Between(wasCalledBetweenFromNumber,wasCalledBetweenToNumber, Range.Inclusive));
        }

        public void TimesExcludingTheToAndFromValues()
        {
            _mockToArrange.Verify(_moqExpressionCastToOriginalType, Moq.Times.Between(wasCalledBetweenFromNumber,wasCalledBetweenToNumber, Range.Exclusive));
        }

        public ITimes Exactly(int number)
        {
            _mockToArrange.Verify(_moqExpressionCastToOriginalType, Moq.Times.Exactly(number));
            return this;
        }

        public void WasNeverCalled()
        {
            _mockToArrange.Verify(_moqExpressionCastToOriginalType, Moq.Times.Never());
        }

        public void Once()
        {
            _mockToArrange.Verify(_moqExpressionCastToOriginalType, Moq.Times.Once());
        }

        public void Times()
        {
            // Do nothing. This just serves as a text to make the test more readably.
        }

        public void AreSavedTo<TArg>(Expression<Func<TArg>> memberAccessExpression)
        {
            var assignTolocalVariable = ExpressionConverter.ConvertMemberAccessFuncToAssignmentAction(memberAccessExpression);
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(assignTolocalVariable);
        }

        public void AreUsedToInvokeAction<T>(Action<T> action)
        {
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(action);
        }
    }
}
