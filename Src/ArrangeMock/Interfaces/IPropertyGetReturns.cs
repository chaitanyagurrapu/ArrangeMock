namespace ArrangeMock.Interfaces
{
    public interface IPropertyGetReturns<in TResult>
    {
        void ItReturns(TResult valueToReturn);

    }
}