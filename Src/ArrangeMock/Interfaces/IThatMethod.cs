namespace ArrangeMock.Interfaces
{
    public interface IThatMethod
    {
        IWasCalled WasCalled();
        void WasCalledAtMostOnce();
        ITimes WasCalledAtMost(int number);
        void WasNeverCalled();
        IBetween WasCalledBetween(int number);
    }
}