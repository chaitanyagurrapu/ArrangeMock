namespace ArrangeMock
{
    public static class WithAnyArgument
    {
        public static T OfType<T>()
        {
            return default(T);
        }
    }
}
