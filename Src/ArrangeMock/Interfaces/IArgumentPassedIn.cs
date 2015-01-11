using System;
using System.Linq.Expressions;

namespace ArrangeMock.Interfaces
{
    public interface IArgumentPassedIn
    {
        void AreSavedTo<T>(Expression<Func<T>> memberAccessExpression);

        void AreUsedToInvokeAction<T>(Action<T> action);
        void AreUsedToInvokeAction<T1, T2>(Action<T1, T2> action);
        void AreUsedToInvokeAction<T1, T2, T3>(Action<T1, T2, T3> action);
        void AreUsedToInvokeAction<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action);
        void AreUsedToInvokeAction<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action);
        void AreUsedToInvokeAction<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> action);
        void AreUsedToInvokeAction<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> action);
        void AreUsedToInvokeAction<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> action);
        void AreUsedToInvokeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action);
        void AreUsedToInvokeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action);
        void AreUsedToInvokeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action);
        void AreUsedToInvokeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action);
        void AreUsedToInvokeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action);
        void AreUsedToInvokeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action);
        void AreUsedToInvokeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action);
        void AreUsedToInvokeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action);
    
    }
}