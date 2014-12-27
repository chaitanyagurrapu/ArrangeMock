namespace ArrangeMock.Interfaces
{
    public interface ISoThatWhenFunction<TResult>
    {
        IFunctionIsCalled<TResult> IsCalled();
    }
}
