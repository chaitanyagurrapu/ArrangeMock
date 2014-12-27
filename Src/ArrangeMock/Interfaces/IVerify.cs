using System;
using System.Linq.Expressions;

namespace ArrangeMock.Interfaces
{
    public interface IAssert<T> where T : class
    {
        IThatFunction<TResult> ThatMethod<TResult>(Expression<Func<T,TResult>> methodToArrange);
        IThatAction<T> ThatMethod(Expression<Action<T>> methodToArrange);
    }
}