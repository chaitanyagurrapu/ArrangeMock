using System;
using System.Linq.Expressions;
using ArrangeMock.Interfaces;
using Moq;

namespace ArrangeMock
{
    internal class ArrangeMock<T> : IArrangeMockObject<T> where T : class
    {
        private Mock<T> _mockToArrange;

        internal ArrangeMock(Mock<T> mockToArrange)
        {
            _mockToArrange = mockToArrange;
        }

        public ISoThatWhenMethod<TResult> SoThatWhenMethod<TResult>(Expression<Func<T, TResult>> methodToArrange)
        {
            var soThatWhenToReturn = new SoThatWhenMethod<T,TResult>(_mockToArrange, methodToArrange);
            return soThatWhenToReturn;
        }

        public ISoThatWhenMethod<T> SoThatWhenMethod(Expression<Action<T>> methodToArrange)
        {
            throw new NotImplementedException();
        }
    }
}
