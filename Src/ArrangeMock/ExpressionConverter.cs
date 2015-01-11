using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Moq;

namespace ArrangeMock
{
    internal partial class ExpressionConverter
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

            var returnType = arrangeMockMethodCallExpression.Method.ReturnType;
            if (arrangeMockMethodCallExpression.Method == CreateMethodCallWithTypeArguments(()=> WithAnyArgument.OfType<object>(), new [] { returnType }))
            {
                var moqItIsAnyTypeMethodinfo = CreateMethodCallWithTypeArguments(() => It.IsAny<object>(), new [] { returnType });
                var moqItIsAnyTypeStringMethod = Expression.Call(moqItIsAnyTypeMethodinfo);
                return moqItIsAnyTypeStringMethod;
            }

            return arrangeMockMethodCallExpression;
        }

        internal static MethodInfo CreateMethodCallWithTypeArguments(Expression<Func<object>>  methodToGet, params Type[] typeArguments)
        {
            var methodName = ((MethodCallExpression)methodToGet.Body).Method;
            var genericMethodDefinition = methodName.GetGenericMethodDefinition();
            var methodDefinitionWithTypeArguments = genericMethodDefinition.MakeGenericMethod(typeArguments);
            return methodDefinitionWithTypeArguments;
        }

        internal static Action<T> ConvertMemberAccessFuncToAssignmentAction<T>(Expression<Func<T>>  memberAccessFunc)
        {
            ValidateMemberAccessExpressions(memberAccessFunc);
            var memberAccessExpression = memberAccessFunc.Body as MemberExpression;

            var param = Expression.Parameter(memberAccessExpression.Type, "x");
            var assignmentExpression = Expression.Assign(memberAccessExpression, param);
            var lambda = Expression.Lambda<Action<T>>(assignmentExpression, new [] { param });
            return lambda.Compile();
        }


        internal static List<ParameterExpression> GetParameterExpressionsFromMemberExpression(IEnumerable<MemberExpression> memberExpressions)
        {
            var parameterExpressionList = new List<ParameterExpression>();

            var paramCounter = 1;
            foreach (var memberExpression in memberExpressions)
            {
                var param = Expression.Parameter(memberExpression.Type, "x" + paramCounter);
                parameterExpressionList.Add(param);
                paramCounter++;
            }
            return parameterExpressionList;
        }

        private static void ValidateMemberAccessExpressions<T>(Expression<Func<T>> memberAccessFunc)
        {
            var memberAccessExpression = memberAccessFunc.Body as MemberExpression;
            if (memberAccessExpression == null)
            {
                throw new ArgumentException("Expected the lambda to be a member access expression");
            }
        }

    }

}