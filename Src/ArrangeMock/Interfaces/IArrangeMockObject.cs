using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ArrangeMock.Interfaces
{
    public interface IArrangeMockObject<T> where T : class
    {

        ISoThatWhenMethod<TResult> SoThatWhenMethod<TResult>(Expression<Func<T,TResult>> methodToArrange);
        ISoThatWhenMethod<T> SoThatWhenMethod(Expression<Action<T>> methodToArrange);

    }
}
