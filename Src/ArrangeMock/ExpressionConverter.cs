using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Moq;

namespace ArrangeMock
{
    internal class ExpressionConverter
    {
        internal static Expression ConvertArrangeMockExpressionToMoqExpression(Expression arrangeMockExpression)
        {
            if (!(arrangeMockExpression is LambdaExpression))
            {
                throw new ArgumentException("Expected lambda expression during conversion from ArrangeMock to Mock");
            }

            var expressionAsLambda = (LambdaExpression)arrangeMockExpression;

            if (!(expressionAsLambda.Body is MethodCallExpression))
            {
                throw new ArgumentException("Expected lambda expression body to be a method call during conversion from ArrangeMock to Mock");
            }

            var methodCall = (MethodCallExpression)expressionAsLambda.Body;

            var argumentsToMethodCall = methodCall.Arguments;
            var argumentsToNewMethod = new List<Expression>();

            foreach (var argument in argumentsToMethodCall)
            {
                if (argument is MethodCallExpression)
                {
                    var argumentAsMethodCall = (MethodCallExpression) argument;
                    var convertToMoqMethodCall = ConvertArrangeMockMethodExpressionToMoqMethodExpression(argumentAsMethodCall);
                    argumentsToNewMethod.Add(convertToMoqMethodCall);
                }
                else
                {
                    argumentsToNewMethod.Add(argument);
                }
            }

            var newMethodCall = Expression.Call(methodCall.Object, methodCall.Method, argumentsToNewMethod);

            var newLambda = Expression.Lambda(newMethodCall,expressionAsLambda.Parameters);

            return newLambda;
        }

        internal static MethodCallExpression ConvertArrangeMockMethodExpressionToMoqMethodExpression(MethodCallExpression arrangeMockMethodCallExpression)
        {

            if (arrangeMockMethodCallExpression.Method == typeof(WithAnyArgument).GetMethod("OfType").MakeGenericMethod(arrangeMockMethodCallExpression.Method.ReturnType))
            {
                var moqItIsAnyTypeMethodinfo = typeof(It).GetMethod("IsAny").MakeGenericMethod(arrangeMockMethodCallExpression.Method.ReturnType);
                var moqItIsAnyTypeStringMethod = Expression.Call(moqItIsAnyTypeMethodinfo);
                return moqItIsAnyTypeStringMethod;
            }

            return arrangeMockMethodCallExpression;
        }
    }

}