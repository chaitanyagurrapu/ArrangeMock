namespace ArrangeMock.Interfaces
{
    public interface ISoThatWhenProperty<TResult>
    {
        IPropertyGetReturns<TResult> IsAccessed();

        IPropertySetReturns<TResult> IsSet();
    }
}
