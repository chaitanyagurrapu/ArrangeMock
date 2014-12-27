using ArrangeMock.Interfaces;
using Moq;

namespace ArrangeMock
{
    public static class MoqExtensions
    {
        public static IArrange<T> Arrange<T>(this Mock<T> mockObjectToArrange) where T : class
        {
            return new ArrangeMock<T>(mockObjectToArrange);
        }

        public static IAssert<T> Assert<T>(this Mock<T> mockObjectToArrange) where T : class
        {
            return new ArrangeMock<T>(mockObjectToArrange);
        }
    }
}
