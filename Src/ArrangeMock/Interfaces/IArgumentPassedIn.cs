using System;
using System.Linq.Expressions;

namespace ArrangeMock.Interfaces
{
    public interface IArgumentPassedIn
    {
        void AreSavedToLocalVariables<T>(Expression<Func<T>> localVariable);
    }
}