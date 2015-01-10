using System;
using System.Data.SqlTypes;
using System.Linq.Expressions;
using ArrangeMock.Interfaces;
using Moq;

namespace ArrangeMock
{
    internal class SoThatWhenFunction<T, TResult> : ISoThatWhenFunction<TResult>,
                                                   IFunctionIsCalled<TResult>,
                                                   IThatMethod,
                                                   IArgumentPassedIn,
                                                   IWasCalled,
                                                   IBetween,
                                                   IBetweenTimes,
                                                   ITimes,
                                                   IItReturns
                                                   where T : class
    {
        private readonly Expression<Func<T, TResult>> _functionToArrange;
        private Mock<T> _mockToArrange;
        private Expression _functionToArrangeConvertedToMoqExpression;
        private Expression<Func<T, TResult>> _moqExpressionCastToOriginalType;
        private TResult _valueToReturn;
        private int wasCalledBetweenFromNumber;
        private int wasCalledBetweenToNumber;

        internal SoThatWhenFunction(Mock<T> mockToArrange, Expression<Func<T, TResult>> functionToArrange)
        {
            _mockToArrange = mockToArrange;
            _functionToArrange = functionToArrange;
            _functionToArrangeConvertedToMoqExpression = ExpressionConverter.ConvertArrangeMockExpressionToMoqExpression(_functionToArrange);
            _moqExpressionCastToOriginalType = (Expression<Func<T, TResult>>)_functionToArrangeConvertedToMoqExpression;
        }

        public IFunctionIsCalled<TResult> IsCalled()
        {
            return this;
        }

        public IItReturns ItReturns(TResult valueToReturn)
        {
            _valueToReturn = valueToReturn;
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Returns(_valueToReturn);
            return this;
        }

        public IArgumentPassedIn TheArgumentsPassedIn()
        {
            return this;
        }

        public IArgumentPassedIn AndTheArgumentsPassedIn()
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
            var saveToAssignmentAction = ExpressionConverter.ConvertMemberAccessFuncToAssignmentAction(memberAccessExpression);
            if (_valueToReturn != null)
            {
                _mockToArrange.Setup(_moqExpressionCastToOriginalType).Returns(_valueToReturn).Callback(saveToAssignmentAction);
            }
            else
            {
                _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(saveToAssignmentAction);
            }
        }

    }
}
