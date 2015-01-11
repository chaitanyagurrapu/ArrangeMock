using System;
using System.Linq.Expressions;

namespace ArrangeMock.Interfaces
{
    public interface IArrange<T> where T : class
    {
        ISoThatWhenFunction<TResult> SoThatWhenMethod<TResult>(Expression<Func<T,TResult>> methodToArrange);
        ISoThatWhenAction<T> SoThatWhenMethod(Expression<Action<T>> methodToArrange);
        ISoThatWhenProperty<TResult> SoThatWhenProperty<TResult>(Expression<Func<T,TResult>> propertyToArrange);
    }
}
