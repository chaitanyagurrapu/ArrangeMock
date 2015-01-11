using System;
using System.Linq.Expressions;
using ArrangeMock.Interfaces;
using Moq;

namespace ArrangeMock
{
    internal partial class SoThatWhenProperty<T, TResult> : ISoThatWhenProperty<TResult>,
                                                            IPropertyGetReturns<TResult>,
                                                            IPropertySetReturns<TResult>
                                                            where T : class
    {
        private readonly Expression<Func<T, TResult>> _propertyToArrange;
        private Mock<T> _mockToArrange;
        private TResult _valueToReturn;

        internal SoThatWhenProperty(Mock<T> mockToArrange, Expression<Func<T, TResult>> propertyToArrange)
        {
            _mockToArrange = mockToArrange;
            _propertyToArrange = propertyToArrange;
        }


        public IPropertyGetReturns<TResult> IsAccessed()
        {
            return this;
        }

        public IPropertySetReturns<TResult> IsSet()
        {
            return this;
        }

        public void ItReturns(TResult valueToReturn)
        {
            _valueToReturn = valueToReturn;
            _mockToArrange.SetupGet(_propertyToArrange).Returns(_valueToReturn);
        }

        public void ItIsSavedTo(Expression<Func<TResult>> memberAccessExpression)
        {
            var saveToAssignmentAction = ExpressionConverter.ConvertMemberAccessFuncToAssignmentAction(memberAccessExpression);
            _mockToArrange.SetupSet(_propertyToArrange).Callback(saveToAssignmentAction);
        }
    }
}
