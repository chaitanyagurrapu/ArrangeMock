using System;
using System.Linq.Expressions;
using ArrangeMock.Interfaces;
using Moq;

namespace ArrangeMock
{
    internal class ArrangeMock<T> : IArrange<T>, IAssert<T> where T : class
    {
        private Mock<T> _mockToArrange;

        internal ArrangeMock(Mock<T> mockToArrange)
        {
            _mockToArrange = mockToArrange;
        }

        public ISoThatWhenFunction<TResult> SoThatWhenMethod<TResult>(Expression<Func<T, TResult>> methodToArrange)
        {
            var soThatWhenToReturn = new SoThatWhenFunction<T,TResult>(_mockToArrange, methodToArrange);
            return soThatWhenToReturn;
        }

        public ISoThatWhenAction<T> SoThatWhenMethod(Expression<Action<T>> methodToArrange)
        {
            var soThatWhenToReturn = new SoThatWhenAction<T>(_mockToArrange, methodToArrange);
            return soThatWhenToReturn;
        }

        public ISoThatWhenProperty<TResult> SoThatWhenProperty<TResult>(Expression<Func<T, TResult>> propertyToArrange)
        {
            var soThatWhenToReturn = new SoThatWhenProperty<T,TResult>(_mockToArrange, propertyToArrange);
            return soThatWhenToReturn;
        }

        public IThatMethod ThatMethod<TResult>(Expression<Func<T, TResult>> methodToArrange)
        {
            var soThatWhenToReturn = new SoThatWhenFunction<T,TResult>(_mockToArrange, methodToArrange);
            return soThatWhenToReturn;
        }

        public IThatMethod ThatMethod(Expression<Action<T>> methodToArrange)
        {
            var soThatWhenToReturn = new SoThatWhenAction<T>(_mockToArrange, methodToArrange);
            return soThatWhenToReturn;
        }
    }
}
