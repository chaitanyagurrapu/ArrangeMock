namespace ArrangeMock.Interfaces
{
    public interface IFunctionIsCalled<TResult>
    {
        void ItReturns(TResult valueToReturn);
    }
}
