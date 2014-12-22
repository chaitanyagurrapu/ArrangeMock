using System;
using System.Linq.Expressions;
using System.Reflection;
using ArrangeMock.UnitTest.TestableInterfaces;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace ArrangeMock.UnitTest.InternalTests.ExpressionTests
{
    public class ExpressionArgumentTests
    {
        [Test]
        public void IsCalledWithAnyArgumentOfTypeIsConvertedToIsAnyOfT()
        {
            Expression<Func<IPayrollSystem,int>> arrangeMockExpression = x => x.GetSalaryForEmployee(WithAnyArgument.OfType<string>());

            var convertedExpression = ExpressionConverter.ConvertArrangeMockExpressionToMoqExpression(arrangeMockExpression);

            Expression<Func<IPayrollSystem,int>> expectedMoqExpression  = x => x.GetSalaryForEmployee(It.IsAny<string>());

            // TODO: Is there a better way of checking for equivalency between expressions rather than just using ToString()?
            convertedExpression.ToString().ShouldBe(expectedMoqExpression.ToString());
        }

        [Test]
        public void TestConvertArrangeMockMethodToMoqMethodExpression()
        {
            var moqItIsAnyTypeMethodinfo = typeof(It).GetMethod("IsAny").MakeGenericMethod(typeof(string));

            var anyArgumentOfTypeMethodinfo = typeof(WithAnyArgument).GetMethod("OfType").MakeGenericMethod(typeof(string));
            var arrangeMockAnyArgumentOfTypeStringMethod = Expression.Call(anyArgumentOfTypeMethodinfo);

            var conversionResult = ExpressionConverter.ConvertArrangeMockMethodExpressionToMoqMethodExpression(arrangeMockAnyArgumentOfTypeStringMethod);

            conversionResult.Method.ShouldBe(moqItIsAnyTypeMethodinfo);
        }

        [Test]
        public void CreationOfMethodsWithTypeArgumentsTest()
        {
            var result = ExpressionConverter.CreateMethodCallWithTypeArguments(() => It.IsAny<object>(), new[] { typeof(string) });
            var moqItIsAnyTypeMethodinfo = typeof(It).GetMethod("IsAny").MakeGenericMethod(typeof(string));
            result.ShouldBe(moqItIsAnyTypeMethodinfo);
        }
    }
}
