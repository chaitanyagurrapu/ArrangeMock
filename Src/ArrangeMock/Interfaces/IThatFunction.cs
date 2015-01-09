namespace ArrangeMock.Interfaces
{
    public interface IThatFunction
    {
        IWasCalled WasCalled();
        void WasCalledAtMostOnce();
        ITimes WasCalledAtMost(int number);
        void WasNeverCalled();
        IBetween WasCalledBetween(int number);
    }
}