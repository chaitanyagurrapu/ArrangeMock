using System;
using System.Linq.Expressions;

namespace ArrangeMock.Interfaces
{
    public interface IPropertySetReturns<TResult>
    {
        void ItIsSavedTo(Expression<Func<TResult>> memberAccessExpression);
    }
}