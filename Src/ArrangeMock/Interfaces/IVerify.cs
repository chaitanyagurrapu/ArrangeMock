using System;
using System.Linq.Expressions;

namespace ArrangeMock.Interfaces
{
    public interface IAssert<T> where T : class
    {
        IThatMethod ThatMethod<TResult>(Expression<Func<T,TResult>> methodToArrange);
        IThatMethod ThatMethod(Expression<Action<T>> methodToArrange);
    }
}