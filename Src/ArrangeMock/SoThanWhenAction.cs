using System;
using System.Linq.Expressions;
using ArrangeMock.Interfaces;
using Moq;

namespace ArrangeMock
{
    internal class SoThatWhenAction<T> : ISoThatWhenAction<T>, 
                                         IActionIsCalled<T> 
                                         where T : class
    {
        private readonly Expression<Action<T>> _actionToArrange;
        private Mock<T> _mockToArrange;

        internal SoThatWhenAction(Mock<T> mockToArrange, Expression<Action<T>> actionToArrange)
        {
            _mockToArrange = mockToArrange;
            _actionToArrange = actionToArrange;
        }


        public IActionIsCalled<T> IsCalled()
        {
            return this;
        }

    }
}
