using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ArrangeMock
{
    internal partial class ExpressionConverter
    {


        internal static Action<T1, T2> ConvertMemberAccessFuncsToAssignmentActionBlock<T1, T2>
        (
            Expression<Func<T1>> memberAccessFunc1, Expression<Func<T2>> memberAccessFunc2
        )
        {
            ValidateMemberAccessExpressions(memberAccessFunc1);
			ValidateMemberAccessExpressions(memberAccessFunc2);

            var memberAccessExpressionList = new List<MemberExpression>()
                                                                {
                                                                    memberAccessFunc1.Body as MemberExpression,
																	memberAccessFunc2.Body as MemberExpression
                                                                };

            var parameterExpressionList = GetParameterExpressionsFromMemberExpression(memberAccessExpressionList);
            var memberAssignmentExpressionList = memberAccessExpressionList.Zip(parameterExpressionList, Expression.Assign);

            var blockExpression = Expression.Block(memberAssignmentExpressionList);

            var lambda = Expression.Lambda<Action<T1, T2>>(blockExpression, parameterExpressionList);

            return lambda.Compile();
        }

        internal static Action<T1, T2, T3> ConvertMemberAccessFuncsToAssignmentActionBlock<T1, T2, T3>
        (
            Expression<Func<T1>> memberAccessFunc1, Expression<Func<T2>> memberAccessFunc2, Expression<Func<T3>> memberAccessFunc3
        )
        {
            ValidateMemberAccessExpressions(memberAccessFunc1);
			ValidateMemberAccessExpressions(memberAccessFunc2);
			ValidateMemberAccessExpressions(memberAccessFunc3);

            var memberAccessExpressionList = new List<MemberExpression>()
                                                                {
                                                                    memberAccessFunc1.Body as MemberExpression,
																	memberAccessFunc2.Body as MemberExpression,
																	memberAccessFunc3.Body as MemberExpression
                                                                };

            var parameterExpressionList = GetParameterExpressionsFromMemberExpression(memberAccessExpressionList);
            var memberAssignmentExpressionList = memberAccessExpressionList.Zip(parameterExpressionList, Expression.Assign);

            var blockExpression = Expression.Block(memberAssignmentExpressionList);

            var lambda = Expression.Lambda<Action<T1, T2, T3>>(blockExpression, parameterExpressionList);

            return lambda.Compile();
        }

        internal static Action<T1, T2, T3, T4> ConvertMemberAccessFuncsToAssignmentActionBlock<T1, T2, T3, T4>
        (
            Expression<Func<T1>> memberAccessFunc1, Expression<Func<T2>> memberAccessFunc2, Expression<Func<T3>> memberAccessFunc3, Expression<Func<T4>> memberAccessFunc4
        )
        {
            ValidateMemberAccessExpressions(memberAccessFunc1);
			ValidateMemberAccessExpressions(memberAccessFunc2);
			ValidateMemberAccessExpressions(memberAccessFunc3);
			ValidateMemberAccessExpressions(memberAccessFunc4);

            var memberAccessExpressionList = new List<MemberExpression>()
                                                                {
                                                                    memberAccessFunc1.Body as MemberExpression,
																	memberAccessFunc2.Body as MemberExpression,
																	memberAccessFunc3.Body as MemberExpression,
																	memberAccessFunc4.Body as MemberExpression
                                                                };

            var parameterExpressionList = GetParameterExpressionsFromMemberExpression(memberAccessExpressionList);
            var memberAssignmentExpressionList = memberAccessExpressionList.Zip(parameterExpressionList, Expression.Assign);

            var blockExpression = Expression.Block(memberAssignmentExpressionList);

            var lambda = Expression.Lambda<Action<T1, T2, T3, T4>>(blockExpression, parameterExpressionList);

            return lambda.Compile();
        }

        internal static Action<T1, T2, T3, T4, T5> ConvertMemberAccessFuncsToAssignmentActionBlock<T1, T2, T3, T4, T5>
        (
            Expression<Func<T1>> memberAccessFunc1, Expression<Func<T2>> memberAccessFunc2, Expression<Func<T3>> memberAccessFunc3, Expression<Func<T4>> memberAccessFunc4, Expression<Func<T5>> memberAccessFunc5
        )
        {
            ValidateMemberAccessExpressions(memberAccessFunc1);
			ValidateMemberAccessExpressions(memberAccessFunc2);
			ValidateMemberAccessExpressions(memberAccessFunc3);
			ValidateMemberAccessExpressions(memberAccessFunc4);
			ValidateMemberAccessExpressions(memberAccessFunc5);

            var memberAccessExpressionList = new List<MemberExpression>()
                                                                {
                                                                    memberAccessFunc1.Body as MemberExpression,
																	memberAccessFunc2.Body as MemberExpression,
																	memberAccessFunc3.Body as MemberExpression,
																	memberAccessFunc4.Body as MemberExpression,
																	memberAccessFunc5.Body as MemberExpression
                                                                };

            var parameterExpressionList = GetParameterExpressionsFromMemberExpression(memberAccessExpressionList);
            var memberAssignmentExpressionList = memberAccessExpressionList.Zip(parameterExpressionList, Expression.Assign);

            var blockExpression = Expression.Block(memberAssignmentExpressionList);

            var lambda = Expression.Lambda<Action<T1, T2, T3, T4, T5>>(blockExpression, parameterExpressionList);

            return lambda.Compile();
        }

        internal static Action<T1, T2, T3, T4, T5, T6> ConvertMemberAccessFuncsToAssignmentActionBlock<T1, T2, T3, T4, T5, T6>
        (
            Expression<Func<T1>> memberAccessFunc1, Expression<Func<T2>> memberAccessFunc2, Expression<Func<T3>> memberAccessFunc3, Expression<Func<T4>> memberAccessFunc4, Expression<Func<T5>> memberAccessFunc5, Expression<Func<T6>> memberAccessFunc6
        )
        {
            ValidateMemberAccessExpressions(memberAccessFunc1);
			ValidateMemberAccessExpressions(memberAccessFunc2);
			ValidateMemberAccessExpressions(memberAccessFunc3);
			ValidateMemberAccessExpressions(memberAccessFunc4);
			ValidateMemberAccessExpressions(memberAccessFunc5);
			ValidateMemberAccessExpressions(memberAccessFunc6);

            var memberAccessExpressionList = new List<MemberExpression>()
                                                                {
                                                                    memberAccessFunc1.Body as MemberExpression,
																	memberAccessFunc2.Body as MemberExpression,
																	memberAccessFunc3.Body as MemberExpression,
																	memberAccessFunc4.Body as MemberExpression,
																	memberAccessFunc5.Body as MemberExpression,
																	memberAccessFunc6.Body as MemberExpression
                                                                };

            var parameterExpressionList = GetParameterExpressionsFromMemberExpression(memberAccessExpressionList);
            var memberAssignmentExpressionList = memberAccessExpressionList.Zip(parameterExpressionList, Expression.Assign);

            var blockExpression = Expression.Block(memberAssignmentExpressionList);

            var lambda = Expression.Lambda<Action<T1, T2, T3, T4, T5, T6>>(blockExpression, parameterExpressionList);

            return lambda.Compile();
        }

        internal static Action<T1, T2, T3, T4, T5, T6, T7> ConvertMemberAccessFuncsToAssignmentActionBlock<T1, T2, T3, T4, T5, T6, T7>
        (
            Expression<Func<T1>> memberAccessFunc1, Expression<Func<T2>> memberAccessFunc2, Expression<Func<T3>> memberAccessFunc3, Expression<Func<T4>> memberAccessFunc4, Expression<Func<T5>> memberAccessFunc5, Expression<Func<T6>> memberAccessFunc6, Expression<Func<T7>> memberAccessFunc7
        )
        {
            ValidateMemberAccessExpressions(memberAccessFunc1);
			ValidateMemberAccessExpressions(memberAccessFunc2);
			ValidateMemberAccessExpressions(memberAccessFunc3);
			ValidateMemberAccessExpressions(memberAccessFunc4);
			ValidateMemberAccessExpressions(memberAccessFunc5);
			ValidateMemberAccessExpressions(memberAccessFunc6);
			ValidateMemberAccessExpressions(memberAccessFunc7);

            var memberAccessExpressionList = new List<MemberExpression>()
                                                                {
                                                                    memberAccessFunc1.Body as MemberExpression,
																	memberAccessFunc2.Body as MemberExpression,
																	memberAccessFunc3.Body as MemberExpression,
																	memberAccessFunc4.Body as MemberExpression,
																	memberAccessFunc5.Body as MemberExpression,
																	memberAccessFunc6.Body as MemberExpression,
																	memberAccessFunc7.Body as MemberExpression
                                                                };

            var parameterExpressionList = GetParameterExpressionsFromMemberExpression(memberAccessExpressionList);
            var memberAssignmentExpressionList = memberAccessExpressionList.Zip(parameterExpressionList, Expression.Assign);

            var blockExpression = Expression.Block(memberAssignmentExpressionList);

            var lambda = Expression.Lambda<Action<T1, T2, T3, T4, T5, T6, T7>>(blockExpression, parameterExpressionList);

            return lambda.Compile();
        }

        internal static Action<T1, T2, T3, T4, T5, T6, T7, T8> ConvertMemberAccessFuncsToAssignmentActionBlock<T1, T2, T3, T4, T5, T6, T7, T8>
        (
            Expression<Func<T1>> memberAccessFunc1, Expression<Func<T2>> memberAccessFunc2, Expression<Func<T3>> memberAccessFunc3, Expression<Func<T4>> memberAccessFunc4, Expression<Func<T5>> memberAccessFunc5, Expression<Func<T6>> memberAccessFunc6, Expression<Func<T7>> memberAccessFunc7, Expression<Func<T8>> memberAccessFunc8
        )
        {
            ValidateMemberAccessExpressions(memberAccessFunc1);
			ValidateMemberAccessExpressions(memberAccessFunc2);
			ValidateMemberAccessExpressions(memberAccessFunc3);
			ValidateMemberAccessExpressions(memberAccessFunc4);
			ValidateMemberAccessExpressions(memberAccessFunc5);
			ValidateMemberAccessExpressions(memberAccessFunc6);
			ValidateMemberAccessExpressions(memberAccessFunc7);
			ValidateMemberAccessExpressions(memberAccessFunc8);

            var memberAccessExpressionList = new List<MemberExpression>()
                                                                {
                                                                    memberAccessFunc1.Body as MemberExpression,
																	memberAccessFunc2.Body as MemberExpression,
																	memberAccessFunc3.Body as MemberExpression,
																	memberAccessFunc4.Body as MemberExpression,
																	memberAccessFunc5.Body as MemberExpression,
																	memberAccessFunc6.Body as MemberExpression,
																	memberAccessFunc7.Body as MemberExpression,
																	memberAccessFunc8.Body as MemberExpression
                                                                };

            var parameterExpressionList = GetParameterExpressionsFromMemberExpression(memberAccessExpressionList);
            var memberAssignmentExpressionList = memberAccessExpressionList.Zip(parameterExpressionList, Expression.Assign);

            var blockExpression = Expression.Block(memberAssignmentExpressionList);

            var lambda = Expression.Lambda<Action<T1, T2, T3, T4, T5, T6, T7, T8>>(blockExpression, parameterExpressionList);

            return lambda.Compile();
        }

        internal static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> ConvertMemberAccessFuncsToAssignmentActionBlock<T1, T2, T3, T4, T5, T6, T7, T8, T9>
        (
            Expression<Func<T1>> memberAccessFunc1, Expression<Func<T2>> memberAccessFunc2, Expression<Func<T3>> memberAccessFunc3, Expression<Func<T4>> memberAccessFunc4, Expression<Func<T5>> memberAccessFunc5, Expression<Func<T6>> memberAccessFunc6, Expression<Func<T7>> memberAccessFunc7, Expression<Func<T8>> memberAccessFunc8, Expression<Func<T9>> memberAccessFunc9
        )
        {
            ValidateMemberAccessExpressions(memberAccessFunc1);
			ValidateMemberAccessExpressions(memberAccessFunc2);
			ValidateMemberAccessExpressions(memberAccessFunc3);
			ValidateMemberAccessExpressions(memberAccessFunc4);
			ValidateMemberAccessExpressions(memberAccessFunc5);
			ValidateMemberAccessExpressions(memberAccessFunc6);
			ValidateMemberAccessExpressions(memberAccessFunc7);
			ValidateMemberAccessExpressions(memberAccessFunc8);
			ValidateMemberAccessExpressions(memberAccessFunc9);

            var memberAccessExpressionList = new List<MemberExpression>()
                                                                {
                                                                    memberAccessFunc1.Body as MemberExpression,
																	memberAccessFunc2.Body as MemberExpression,
																	memberAccessFunc3.Body as MemberExpression,
																	memberAccessFunc4.Body as MemberExpression,
																	memberAccessFunc5.Body as MemberExpression,
																	memberAccessFunc6.Body as MemberExpression,
																	memberAccessFunc7.Body as MemberExpression,
																	memberAccessFunc8.Body as MemberExpression,
																	memberAccessFunc9.Body as MemberExpression
                                                                };

            var parameterExpressionList = GetParameterExpressionsFromMemberExpression(memberAccessExpressionList);
            var memberAssignmentExpressionList = memberAccessExpressionList.Zip(parameterExpressionList, Expression.Assign);

            var blockExpression = Expression.Block(memberAssignmentExpressionList);

            var lambda = Expression.Lambda<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>>(blockExpression, parameterExpressionList);

            return lambda.Compile();
        }

        internal static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> ConvertMemberAccessFuncsToAssignmentActionBlock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
        (
            Expression<Func<T1>> memberAccessFunc1, Expression<Func<T2>> memberAccessFunc2, Expression<Func<T3>> memberAccessFunc3, Expression<Func<T4>> memberAccessFunc4, Expression<Func<T5>> memberAccessFunc5, Expression<Func<T6>> memberAccessFunc6, Expression<Func<T7>> memberAccessFunc7, Expression<Func<T8>> memberAccessFunc8, Expression<Func<T9>> memberAccessFunc9, Expression<Func<T10>> memberAccessFunc10
        )
        {
            ValidateMemberAccessExpressions(memberAccessFunc1);
			ValidateMemberAccessExpressions(memberAccessFunc2);
			ValidateMemberAccessExpressions(memberAccessFunc3);
			ValidateMemberAccessExpressions(memberAccessFunc4);
			ValidateMemberAccessExpressions(memberAccessFunc5);
			ValidateMemberAccessExpressions(memberAccessFunc6);
			ValidateMemberAccessExpressions(memberAccessFunc7);
			ValidateMemberAccessExpressions(memberAccessFunc8);
			ValidateMemberAccessExpressions(memberAccessFunc9);
			ValidateMemberAccessExpressions(memberAccessFunc10);

            var memberAccessExpressionList = new List<MemberExpression>()
                                                                {
                                                                    memberAccessFunc1.Body as MemberExpression,
																	memberAccessFunc2.Body as MemberExpression,
																	memberAccessFunc3.Body as MemberExpression,
																	memberAccessFunc4.Body as MemberExpression,
																	memberAccessFunc5.Body as MemberExpression,
																	memberAccessFunc6.Body as MemberExpression,
																	memberAccessFunc7.Body as MemberExpression,
																	memberAccessFunc8.Body as MemberExpression,
																	memberAccessFunc9.Body as MemberExpression,
																	memberAccessFunc10.Body as MemberExpression
                                                                };

            var parameterExpressionList = GetParameterExpressionsFromMemberExpression(memberAccessExpressionList);
            var memberAssignmentExpressionList = memberAccessExpressionList.Zip(parameterExpressionList, Expression.Assign);

            var blockExpression = Expression.Block(memberAssignmentExpressionList);

            var lambda = Expression.Lambda<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>(blockExpression, parameterExpressionList);

            return lambda.Compile();
        }

        internal static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> ConvertMemberAccessFuncsToAssignmentActionBlock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
        (
            Expression<Func<T1>> memberAccessFunc1, Expression<Func<T2>> memberAccessFunc2, Expression<Func<T3>> memberAccessFunc3, Expression<Func<T4>> memberAccessFunc4, Expression<Func<T5>> memberAccessFunc5, Expression<Func<T6>> memberAccessFunc6, Expression<Func<T7>> memberAccessFunc7, Expression<Func<T8>> memberAccessFunc8, Expression<Func<T9>> memberAccessFunc9, Expression<Func<T10>> memberAccessFunc10, Expression<Func<T11>> memberAccessFunc11
        )
        {
            ValidateMemberAccessExpressions(memberAccessFunc1);
			ValidateMemberAccessExpressions(memberAccessFunc2);
			ValidateMemberAccessExpressions(memberAccessFunc3);
			ValidateMemberAccessExpressions(memberAccessFunc4);
			ValidateMemberAccessExpressions(memberAccessFunc5);
			ValidateMemberAccessExpressions(memberAccessFunc6);
			ValidateMemberAccessExpressions(memberAccessFunc7);
			ValidateMemberAccessExpressions(memberAccessFunc8);
			ValidateMemberAccessExpressions(memberAccessFunc9);
			ValidateMemberAccessExpressions(memberAccessFunc10);
			ValidateMemberAccessExpressions(memberAccessFunc11);

            var memberAccessExpressionList = new List<MemberExpression>()
                                                                {
                                                                    memberAccessFunc1.Body as MemberExpression,
																	memberAccessFunc2.Body as MemberExpression,
																	memberAccessFunc3.Body as MemberExpression,
																	memberAccessFunc4.Body as MemberExpression,
																	memberAccessFunc5.Body as MemberExpression,
																	memberAccessFunc6.Body as MemberExpression,
																	memberAccessFunc7.Body as MemberExpression,
																	memberAccessFunc8.Body as MemberExpression,
																	memberAccessFunc9.Body as MemberExpression,
																	memberAccessFunc10.Body as MemberExpression,
																	memberAccessFunc11.Body as MemberExpression
                                                                };

            var parameterExpressionList = GetParameterExpressionsFromMemberExpression(memberAccessExpressionList);
            var memberAssignmentExpressionList = memberAccessExpressionList.Zip(parameterExpressionList, Expression.Assign);

            var blockExpression = Expression.Block(memberAssignmentExpressionList);

            var lambda = Expression.Lambda<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>(blockExpression, parameterExpressionList);

            return lambda.Compile();
        }

        internal static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> ConvertMemberAccessFuncsToAssignmentActionBlock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
        (
            Expression<Func<T1>> memberAccessFunc1, Expression<Func<T2>> memberAccessFunc2, Expression<Func<T3>> memberAccessFunc3, Expression<Func<T4>> memberAccessFunc4, Expression<Func<T5>> memberAccessFunc5, Expression<Func<T6>> memberAccessFunc6, Expression<Func<T7>> memberAccessFunc7, Expression<Func<T8>> memberAccessFunc8, Expression<Func<T9>> memberAccessFunc9, Expression<Func<T10>> memberAccessFunc10, Expression<Func<T11>> memberAccessFunc11, Expression<Func<T12>> memberAccessFunc12
        )
        {
            ValidateMemberAccessExpressions(memberAccessFunc1);
			ValidateMemberAccessExpressions(memberAccessFunc2);
			ValidateMemberAccessExpressions(memberAccessFunc3);
			ValidateMemberAccessExpressions(memberAccessFunc4);
			ValidateMemberAccessExpressions(memberAccessFunc5);
			ValidateMemberAccessExpressions(memberAccessFunc6);
			ValidateMemberAccessExpressions(memberAccessFunc7);
			ValidateMemberAccessExpressions(memberAccessFunc8);
			ValidateMemberAccessExpressions(memberAccessFunc9);
			ValidateMemberAccessExpressions(memberAccessFunc10);
			ValidateMemberAccessExpressions(memberAccessFunc11);
			ValidateMemberAccessExpressions(memberAccessFunc12);

            var memberAccessExpressionList = new List<MemberExpression>()
                                                                {
                                                                    memberAccessFunc1.Body as MemberExpression,
																	memberAccessFunc2.Body as MemberExpression,
																	memberAccessFunc3.Body as MemberExpression,
																	memberAccessFunc4.Body as MemberExpression,
																	memberAccessFunc5.Body as MemberExpression,
																	memberAccessFunc6.Body as MemberExpression,
																	memberAccessFunc7.Body as MemberExpression,
																	memberAccessFunc8.Body as MemberExpression,
																	memberAccessFunc9.Body as MemberExpression,
																	memberAccessFunc10.Body as MemberExpression,
																	memberAccessFunc11.Body as MemberExpression,
																	memberAccessFunc12.Body as MemberExpression
                                                                };

            var parameterExpressionList = GetParameterExpressionsFromMemberExpression(memberAccessExpressionList);
            var memberAssignmentExpressionList = memberAccessExpressionList.Zip(parameterExpressionList, Expression.Assign);

            var blockExpression = Expression.Block(memberAssignmentExpressionList);

            var lambda = Expression.Lambda<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>(blockExpression, parameterExpressionList);

            return lambda.Compile();
        }

        internal static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> ConvertMemberAccessFuncsToAssignmentActionBlock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
        (
            Expression<Func<T1>> memberAccessFunc1, Expression<Func<T2>> memberAccessFunc2, Expression<Func<T3>> memberAccessFunc3, Expression<Func<T4>> memberAccessFunc4, Expression<Func<T5>> memberAccessFunc5, Expression<Func<T6>> memberAccessFunc6, Expression<Func<T7>> memberAccessFunc7, Expression<Func<T8>> memberAccessFunc8, Expression<Func<T9>> memberAccessFunc9, Expression<Func<T10>> memberAccessFunc10, Expression<Func<T11>> memberAccessFunc11, Expression<Func<T12>> memberAccessFunc12, Expression<Func<T13>> memberAccessFunc13
        )
        {
            ValidateMemberAccessExpressions(memberAccessFunc1);
			ValidateMemberAccessExpressions(memberAccessFunc2);
			ValidateMemberAccessExpressions(memberAccessFunc3);
			ValidateMemberAccessExpressions(memberAccessFunc4);
			ValidateMemberAccessExpressions(memberAccessFunc5);
			ValidateMemberAccessExpressions(memberAccessFunc6);
			ValidateMemberAccessExpressions(memberAccessFunc7);
			ValidateMemberAccessExpressions(memberAccessFunc8);
			ValidateMemberAccessExpressions(memberAccessFunc9);
			ValidateMemberAccessExpressions(memberAccessFunc10);
			ValidateMemberAccessExpressions(memberAccessFunc11);
			ValidateMemberAccessExpressions(memberAccessFunc12);
			ValidateMemberAccessExpressions(memberAccessFunc13);

            var memberAccessExpressionList = new List<MemberExpression>()
                                                                {
                                                                    memberAccessFunc1.Body as MemberExpression,
																	memberAccessFunc2.Body as MemberExpression,
																	memberAccessFunc3.Body as MemberExpression,
																	memberAccessFunc4.Body as MemberExpression,
																	memberAccessFunc5.Body as MemberExpression,
																	memberAccessFunc6.Body as MemberExpression,
																	memberAccessFunc7.Body as MemberExpression,
																	memberAccessFunc8.Body as MemberExpression,
																	memberAccessFunc9.Body as MemberExpression,
																	memberAccessFunc10.Body as MemberExpression,
																	memberAccessFunc11.Body as MemberExpression,
																	memberAccessFunc12.Body as MemberExpression,
																	memberAccessFunc13.Body as MemberExpression
                                                                };

            var parameterExpressionList = GetParameterExpressionsFromMemberExpression(memberAccessExpressionList);
            var memberAssignmentExpressionList = memberAccessExpressionList.Zip(parameterExpressionList, Expression.Assign);

            var blockExpression = Expression.Block(memberAssignmentExpressionList);

            var lambda = Expression.Lambda<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>(blockExpression, parameterExpressionList);

            return lambda.Compile();
        }

        internal static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> ConvertMemberAccessFuncsToAssignmentActionBlock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
        (
            Expression<Func<T1>> memberAccessFunc1, Expression<Func<T2>> memberAccessFunc2, Expression<Func<T3>> memberAccessFunc3, Expression<Func<T4>> memberAccessFunc4, Expression<Func<T5>> memberAccessFunc5, Expression<Func<T6>> memberAccessFunc6, Expression<Func<T7>> memberAccessFunc7, Expression<Func<T8>> memberAccessFunc8, Expression<Func<T9>> memberAccessFunc9, Expression<Func<T10>> memberAccessFunc10, Expression<Func<T11>> memberAccessFunc11, Expression<Func<T12>> memberAccessFunc12, Expression<Func<T13>> memberAccessFunc13, Expression<Func<T14>> memberAccessFunc14
        )
        {
            ValidateMemberAccessExpressions(memberAccessFunc1);
			ValidateMemberAccessExpressions(memberAccessFunc2);
			ValidateMemberAccessExpressions(memberAccessFunc3);
			ValidateMemberAccessExpressions(memberAccessFunc4);
			ValidateMemberAccessExpressions(memberAccessFunc5);
			ValidateMemberAccessExpressions(memberAccessFunc6);
			ValidateMemberAccessExpressions(memberAccessFunc7);
			ValidateMemberAccessExpressions(memberAccessFunc8);
			ValidateMemberAccessExpressions(memberAccessFunc9);
			ValidateMemberAccessExpressions(memberAccessFunc10);
			ValidateMemberAccessExpressions(memberAccessFunc11);
			ValidateMemberAccessExpressions(memberAccessFunc12);
			ValidateMemberAccessExpressions(memberAccessFunc13);
			ValidateMemberAccessExpressions(memberAccessFunc14);

            var memberAccessExpressionList = new List<MemberExpression>()
                                                                {
                                                                    memberAccessFunc1.Body as MemberExpression,
																	memberAccessFunc2.Body as MemberExpression,
																	memberAccessFunc3.Body as MemberExpression,
																	memberAccessFunc4.Body as MemberExpression,
																	memberAccessFunc5.Body as MemberExpression,
																	memberAccessFunc6.Body as MemberExpression,
																	memberAccessFunc7.Body as MemberExpression,
																	memberAccessFunc8.Body as MemberExpression,
																	memberAccessFunc9.Body as MemberExpression,
																	memberAccessFunc10.Body as MemberExpression,
																	memberAccessFunc11.Body as MemberExpression,
																	memberAccessFunc12.Body as MemberExpression,
																	memberAccessFunc13.Body as MemberExpression,
																	memberAccessFunc14.Body as MemberExpression
                                                                };

            var parameterExpressionList = GetParameterExpressionsFromMemberExpression(memberAccessExpressionList);
            var memberAssignmentExpressionList = memberAccessExpressionList.Zip(parameterExpressionList, Expression.Assign);

            var blockExpression = Expression.Block(memberAssignmentExpressionList);

            var lambda = Expression.Lambda<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>(blockExpression, parameterExpressionList);

            return lambda.Compile();
        }

        internal static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> ConvertMemberAccessFuncsToAssignmentActionBlock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
        (
            Expression<Func<T1>> memberAccessFunc1, Expression<Func<T2>> memberAccessFunc2, Expression<Func<T3>> memberAccessFunc3, Expression<Func<T4>> memberAccessFunc4, Expression<Func<T5>> memberAccessFunc5, Expression<Func<T6>> memberAccessFunc6, Expression<Func<T7>> memberAccessFunc7, Expression<Func<T8>> memberAccessFunc8, Expression<Func<T9>> memberAccessFunc9, Expression<Func<T10>> memberAccessFunc10, Expression<Func<T11>> memberAccessFunc11, Expression<Func<T12>> memberAccessFunc12, Expression<Func<T13>> memberAccessFunc13, Expression<Func<T14>> memberAccessFunc14, Expression<Func<T15>> memberAccessFunc15
        )
        {
            ValidateMemberAccessExpressions(memberAccessFunc1);
			ValidateMemberAccessExpressions(memberAccessFunc2);
			ValidateMemberAccessExpressions(memberAccessFunc3);
			ValidateMemberAccessExpressions(memberAccessFunc4);
			ValidateMemberAccessExpressions(memberAccessFunc5);
			ValidateMemberAccessExpressions(memberAccessFunc6);
			ValidateMemberAccessExpressions(memberAccessFunc7);
			ValidateMemberAccessExpressions(memberAccessFunc8);
			ValidateMemberAccessExpressions(memberAccessFunc9);
			ValidateMemberAccessExpressions(memberAccessFunc10);
			ValidateMemberAccessExpressions(memberAccessFunc11);
			ValidateMemberAccessExpressions(memberAccessFunc12);
			ValidateMemberAccessExpressions(memberAccessFunc13);
			ValidateMemberAccessExpressions(memberAccessFunc14);
			ValidateMemberAccessExpressions(memberAccessFunc15);

            var memberAccessExpressionList = new List<MemberExpression>()
                                                                {
                                                                    memberAccessFunc1.Body as MemberExpression,
																	memberAccessFunc2.Body as MemberExpression,
																	memberAccessFunc3.Body as MemberExpression,
																	memberAccessFunc4.Body as MemberExpression,
																	memberAccessFunc5.Body as MemberExpression,
																	memberAccessFunc6.Body as MemberExpression,
																	memberAccessFunc7.Body as MemberExpression,
																	memberAccessFunc8.Body as MemberExpression,
																	memberAccessFunc9.Body as MemberExpression,
																	memberAccessFunc10.Body as MemberExpression,
																	memberAccessFunc11.Body as MemberExpression,
																	memberAccessFunc12.Body as MemberExpression,
																	memberAccessFunc13.Body as MemberExpression,
																	memberAccessFunc14.Body as MemberExpression,
																	memberAccessFunc15.Body as MemberExpression
                                                                };

            var parameterExpressionList = GetParameterExpressionsFromMemberExpression(memberAccessExpressionList);
            var memberAssignmentExpressionList = memberAccessExpressionList.Zip(parameterExpressionList, Expression.Assign);

            var blockExpression = Expression.Block(memberAssignmentExpressionList);

            var lambda = Expression.Lambda<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>>(blockExpression, parameterExpressionList);

            return lambda.Compile();
        }

        internal static Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> ConvertMemberAccessFuncsToAssignmentActionBlock<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
        (
            Expression<Func<T1>> memberAccessFunc1, Expression<Func<T2>> memberAccessFunc2, Expression<Func<T3>> memberAccessFunc3, Expression<Func<T4>> memberAccessFunc4, Expression<Func<T5>> memberAccessFunc5, Expression<Func<T6>> memberAccessFunc6, Expression<Func<T7>> memberAccessFunc7, Expression<Func<T8>> memberAccessFunc8, Expression<Func<T9>> memberAccessFunc9, Expression<Func<T10>> memberAccessFunc10, Expression<Func<T11>> memberAccessFunc11, Expression<Func<T12>> memberAccessFunc12, Expression<Func<T13>> memberAccessFunc13, Expression<Func<T14>> memberAccessFunc14, Expression<Func<T15>> memberAccessFunc15, Expression<Func<T16>> memberAccessFunc16
        )
        {
            ValidateMemberAccessExpressions(memberAccessFunc1);
			ValidateMemberAccessExpressions(memberAccessFunc2);
			ValidateMemberAccessExpressions(memberAccessFunc3);
			ValidateMemberAccessExpressions(memberAccessFunc4);
			ValidateMemberAccessExpressions(memberAccessFunc5);
			ValidateMemberAccessExpressions(memberAccessFunc6);
			ValidateMemberAccessExpressions(memberAccessFunc7);
			ValidateMemberAccessExpressions(memberAccessFunc8);
			ValidateMemberAccessExpressions(memberAccessFunc9);
			ValidateMemberAccessExpressions(memberAccessFunc10);
			ValidateMemberAccessExpressions(memberAccessFunc11);
			ValidateMemberAccessExpressions(memberAccessFunc12);
			ValidateMemberAccessExpressions(memberAccessFunc13);
			ValidateMemberAccessExpressions(memberAccessFunc14);
			ValidateMemberAccessExpressions(memberAccessFunc15);
			ValidateMemberAccessExpressions(memberAccessFunc16);

            var memberAccessExpressionList = new List<MemberExpression>()
                                                                {
                                                                    memberAccessFunc1.Body as MemberExpression,
																	memberAccessFunc2.Body as MemberExpression,
																	memberAccessFunc3.Body as MemberExpression,
																	memberAccessFunc4.Body as MemberExpression,
																	memberAccessFunc5.Body as MemberExpression,
																	memberAccessFunc6.Body as MemberExpression,
																	memberAccessFunc7.Body as MemberExpression,
																	memberAccessFunc8.Body as MemberExpression,
																	memberAccessFunc9.Body as MemberExpression,
																	memberAccessFunc10.Body as MemberExpression,
																	memberAccessFunc11.Body as MemberExpression,
																	memberAccessFunc12.Body as MemberExpression,
																	memberAccessFunc13.Body as MemberExpression,
																	memberAccessFunc14.Body as MemberExpression,
																	memberAccessFunc15.Body as MemberExpression,
																	memberAccessFunc16.Body as MemberExpression
                                                                };

            var parameterExpressionList = GetParameterExpressionsFromMemberExpression(memberAccessExpressionList);
            var memberAssignmentExpressionList = memberAccessExpressionList.Zip(parameterExpressionList, Expression.Assign);

            var blockExpression = Expression.Block(memberAssignmentExpressionList);

            var lambda = Expression.Lambda<Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>>(blockExpression, parameterExpressionList);

            return lambda.Compile();
        }
    }
}

