namespace ArrangeMock.Interfaces
{
    public interface ISoThatWhenAction<T>
    {
        IActionIsCalled<T> IsCalled();
    }
}
