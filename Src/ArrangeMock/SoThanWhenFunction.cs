using System;
using System.Linq.Expressions;
using ArrangeMock.Interfaces;
using Moq;

namespace ArrangeMock
{
    internal class SoThatWhenFunction<T,TResult> : ISoThatWhenFunction<TResult>, 
                                                   IFunctionIsCalled<TResult>,
                                                   IThatFunction<TResult>
                                                   where T : class
    {
        private readonly Expression<Func<T, TResult>> _functionToArrange;
        private Mock<T> _mockToArrange;
        private Expression _functionToArrangeConvertedToMoqExpression;
        private Expression<Func<T, TResult>> _moqExpressionCastToOriginalType;
        private TResult ValueToReturn {get; set;}

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

        public void ItReturns(TResult valueToReturn)
        {
            ValueToReturn = valueToReturn;

            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Returns(ValueToReturn);
        }

        public void WasCalled()
        {
            _mockToArrange.Verify(_moqExpressionCastToOriginalType);
        }

        public ITimes WasCalled(int numberOfTimesCalled)
        {
            throw new NotImplementedException();
        }
    }
}
