using ArrangeMock.Interfaces;
using Moq;

namespace ArrangeMock
{
    public static class ArrangeExtensions
    {
        public static IArrangeMockObject<T> Arrange<T>(this Mock<T> mockObjectToArrange) where T : class
        {
            return new ArrangeMock<T>(mockObjectToArrange);
        }
    }
}
