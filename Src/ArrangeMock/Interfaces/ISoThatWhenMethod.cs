namespace ArrangeMock.Interfaces
{
    public interface ISoThatWhenMethod<TResult>
    {
        void IsCalledItReturns(TResult valueToReturn);
    }
}
