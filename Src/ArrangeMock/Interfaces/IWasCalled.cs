namespace ArrangeMock.Interfaces
{
    public interface IWasCalled
    {
        ITimes AtLeast(int number);
        void AtLeastOnce();
        ITimes Exactly(int number);
        void Once();
    }
}