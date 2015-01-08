namespace ArrangeMock.Interfaces
{
    public interface IFunctionIsCalled<TResult>
    {
        IItReturns ItReturns(TResult valueToReturn);
        IArgumentPassedIn TheArgumentsPassedIn();
    }
}
