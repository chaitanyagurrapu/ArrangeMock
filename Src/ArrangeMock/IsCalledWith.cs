namespace ArrangeMock
{
    public static class IsCalledWith
    {
        public static T AnyArgumentOfType<T>()
        {
            return default(T);
        }
    }
}
