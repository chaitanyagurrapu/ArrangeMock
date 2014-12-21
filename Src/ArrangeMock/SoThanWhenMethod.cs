using System;
using System.Linq.Expressions;
using ArrangeMock.Interfaces;
using Moq;

namespace ArrangeMock
{
    internal class SoThatWhenMethod<T,TResult> : ISoThatWhenMethod<TResult> where T : class
    {
        private readonly Expression<Func<T, TResult>> _methodToArrange;
        private Mock<T> _mockToArrange;

        internal SoThatWhenMethod(Mock<T> mockToArrange, Expression<Func<T, TResult>> methodToArrange)
        {
            _mockToArrange = mockToArrange;
            _methodToArrange = methodToArrange;
        }

        internal TResult ValueToReturn {get; set;}

        public void IsCalledItReturns(TResult valueToReturn)
        {
            ValueToReturn = valueToReturn;

            var convertedMethodToArrange = ExpressionConverter.ConvertArrangeMockExpressionToMoqExpression(_methodToArrange);
            var convertedMethodCastToOriginal = (Expression<Func<T, TResult>>)convertedMethodToArrange; 

            _mockToArrange.Setup(convertedMethodCastToOriginal).Returns(ValueToReturn);
        }

    }
}
