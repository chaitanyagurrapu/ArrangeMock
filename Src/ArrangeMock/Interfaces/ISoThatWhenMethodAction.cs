namespace ArrangeMock.Interfaces
{
    public interface ISoThatWhenMethodAction<TResult>
    {
        void ItReturns(TResult valueToReturn);
    }
}
