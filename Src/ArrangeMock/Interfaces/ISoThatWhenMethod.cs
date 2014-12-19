namespace ArrangeMock.Interfaces
{
    public interface ISoThatWhenMethod<TResult>
    {
        void ItReturns(TResult valueToReturn);
    }
}
