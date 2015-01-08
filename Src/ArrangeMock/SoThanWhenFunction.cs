using System;
using System.Linq.Expressions;
using ArrangeMock.Interfaces;
using Moq;

namespace ArrangeMock
{
    internal class SoThatWhenFunction<T, TResult> : ISoThatWhenFunction<TResult>,
                                                   IFunctionIsCalled<TResult>,
                                                   IThatFunction<TResult>,
                                                   IArgumentPassedIn,
                                                   IItReturns
                                                   where T : class
    {
        private readonly Expression<Func<T, TResult>> _functionToArrange;
        private Mock<T> _mockToArrange;
        private Expression _functionToArrangeConvertedToMoqExpression;
        private Expression<Func<T, TResult>> _moqExpressionCastToOriginalType;
        private TResult _valueToReturn;

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

        public void WasCalled()
        {
            _mockToArrange.Verify(_moqExpressionCastToOriginalType);
        }

        public ITimes WasCalled(int numberOfTimesCalled)
        {
            throw new NotImplementedException();
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
