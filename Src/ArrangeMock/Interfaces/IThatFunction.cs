namespace ArrangeMock.Interfaces
{
    public interface IThatFunction<T>
    {
        void WasCalled();
        ITimes WasCalled(int numberOfTimesCalled);
    }
}