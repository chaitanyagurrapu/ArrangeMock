using System;
using System.Linq.Expressions;

namespace ArrangeMock
{
    internal partial class SoThatWhenAction<T> 
    {

        public void AreUsedToInvokeAction<T1, T2>(Action<T1, T2> action)
        {
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(action);
        }

        public void AreSavedTo<T1, T2>(Expression<Func<T1>> memberAccessExpression1, Expression<Func<T2>> memberAccessExpression2)
        {
            var assignTolocalVariable = ExpressionConverter.ConvertMemberAccessFuncsToAssignmentActionBlock(memberAccessExpression1, memberAccessExpression2);
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(assignTolocalVariable);
        }

        public void AreUsedToInvokeAction<T1, T2, T3>(Action<T1, T2, T3> action)
        {
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(action);
        }

        public void AreSavedTo<T1, T2, T3>(Expression<Func<T1>> memberAccessExpression1, Expression<Func<T2>> memberAccessExpression2, Expression<Func<T3>> memberAccessExpression3)
        {
            var assignTolocalVariable = ExpressionConverter.ConvertMemberAccessFuncsToAssignmentActionBlock(memberAccessExpression1, memberAccessExpression2, memberAccessExpression3);
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(assignTolocalVariable);
        }

        public void AreUsedToInvokeAction<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action)
        {
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(action);
        }

        public void AreSavedTo<T1, T2, T3, T4>(Expression<Func<T1>> memberAccessExpression1, Expression<Func<T2>> memberAccessExpression2, Expression<Func<T3>> memberAccessExpression3, Expression<Func<T4>> memberAccessExpression4)
        {
            var assignTolocalVariable = ExpressionConverter.ConvertMemberAccessFuncsToAssignmentActionBlock(memberAccessExpression1, memberAccessExpression2, memberAccessExpression3, memberAccessExpression4);
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(assignTolocalVariable);
        }

        public void AreUsedToInvokeAction<T1, T2, T3, T4, T5>(Action<T1, T2, T3, T4, T5> action)
        {
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(action);
        }

        public void AreSavedTo<T1, T2, T3, T4, T5>(Expression<Func<T1>> memberAccessExpression1, Expression<Func<T2>> memberAccessExpression2, Expression<Func<T3>> memberAccessExpression3, Expression<Func<T4>> memberAccessExpression4, Expression<Func<T5>> memberAccessExpression5)
        {
            var assignTolocalVariable = ExpressionConverter.ConvertMemberAccessFuncsToAssignmentActionBlock(memberAccessExpression1, memberAccessExpression2, memberAccessExpression3, memberAccessExpression4, memberAccessExpression5);
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(assignTolocalVariable);
        }

        public void AreUsedToInvokeAction<T1, T2, T3, T4, T5, T6>(Action<T1, T2, T3, T4, T5, T6> action)
        {
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(action);
        }

        public void AreSavedTo<T1, T2, T3, T4, T5, T6>(Expression<Func<T1>> memberAccessExpression1, Expression<Func<T2>> memberAccessExpression2, Expression<Func<T3>> memberAccessExpression3, Expression<Func<T4>> memberAccessExpression4, Expression<Func<T5>> memberAccessExpression5, Expression<Func<T6>> memberAccessExpression6)
        {
            var assignTolocalVariable = ExpressionConverter.ConvertMemberAccessFuncsToAssignmentActionBlock(memberAccessExpression1, memberAccessExpression2, memberAccessExpression3, memberAccessExpression4, memberAccessExpression5, memberAccessExpression6);
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(assignTolocalVariable);
        }

        public void AreUsedToInvokeAction<T1, T2, T3, T4, T5, T6, T7>(Action<T1, T2, T3, T4, T5, T6, T7> action)
        {
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(action);
        }

        public void AreSavedTo<T1, T2, T3, T4, T5, T6, T7>(Expression<Func<T1>> memberAccessExpression1, Expression<Func<T2>> memberAccessExpression2, Expression<Func<T3>> memberAccessExpression3, Expression<Func<T4>> memberAccessExpression4, Expression<Func<T5>> memberAccessExpression5, Expression<Func<T6>> memberAccessExpression6, Expression<Func<T7>> memberAccessExpression7)
        {
            var assignTolocalVariable = ExpressionConverter.ConvertMemberAccessFuncsToAssignmentActionBlock(memberAccessExpression1, memberAccessExpression2, memberAccessExpression3, memberAccessExpression4, memberAccessExpression5, memberAccessExpression6, memberAccessExpression7);
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(assignTolocalVariable);
        }

        public void AreUsedToInvokeAction<T1, T2, T3, T4, T5, T6, T7, T8>(Action<T1, T2, T3, T4, T5, T6, T7, T8> action)
        {
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(action);
        }

        public void AreSavedTo<T1, T2, T3, T4, T5, T6, T7, T8>(Expression<Func<T1>> memberAccessExpression1, Expression<Func<T2>> memberAccessExpression2, Expression<Func<T3>> memberAccessExpression3, Expression<Func<T4>> memberAccessExpression4, Expression<Func<T5>> memberAccessExpression5, Expression<Func<T6>> memberAccessExpression6, Expression<Func<T7>> memberAccessExpression7, Expression<Func<T8>> memberAccessExpression8)
        {
            var assignTolocalVariable = ExpressionConverter.ConvertMemberAccessFuncsToAssignmentActionBlock(memberAccessExpression1, memberAccessExpression2, memberAccessExpression3, memberAccessExpression4, memberAccessExpression5, memberAccessExpression6, memberAccessExpression7, memberAccessExpression8);
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(assignTolocalVariable);
        }

        public void AreUsedToInvokeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action)
        {
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(action);
        }

        public void AreSavedTo<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Expression<Func<T1>> memberAccessExpression1, Expression<Func<T2>> memberAccessExpression2, Expression<Func<T3>> memberAccessExpression3, Expression<Func<T4>> memberAccessExpression4, Expression<Func<T5>> memberAccessExpression5, Expression<Func<T6>> memberAccessExpression6, Expression<Func<T7>> memberAccessExpression7, Expression<Func<T8>> memberAccessExpression8, Expression<Func<T9>> memberAccessExpression9)
        {
            var assignTolocalVariable = ExpressionConverter.ConvertMemberAccessFuncsToAssignmentActionBlock(memberAccessExpression1, memberAccessExpression2, memberAccessExpression3, memberAccessExpression4, memberAccessExpression5, memberAccessExpression6, memberAccessExpression7, memberAccessExpression8, memberAccessExpression9);
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(assignTolocalVariable);
        }

        public void AreUsedToInvokeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action)
        {
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(action);
        }

        public void AreSavedTo<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Expression<Func<T1>> memberAccessExpression1, Expression<Func<T2>> memberAccessExpression2, Expression<Func<T3>> memberAccessExpression3, Expression<Func<T4>> memberAccessExpression4, Expression<Func<T5>> memberAccessExpression5, Expression<Func<T6>> memberAccessExpression6, Expression<Func<T7>> memberAccessExpression7, Expression<Func<T8>> memberAccessExpression8, Expression<Func<T9>> memberAccessExpression9, Expression<Func<T10>> memberAccessExpression10)
        {
            var assignTolocalVariable = ExpressionConverter.ConvertMemberAccessFuncsToAssignmentActionBlock(memberAccessExpression1, memberAccessExpression2, memberAccessExpression3, memberAccessExpression4, memberAccessExpression5, memberAccessExpression6, memberAccessExpression7, memberAccessExpression8, memberAccessExpression9, memberAccessExpression10);
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(assignTolocalVariable);
        }

        public void AreUsedToInvokeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action)
        {
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(action);
        }

        public void AreSavedTo<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Expression<Func<T1>> memberAccessExpression1, Expression<Func<T2>> memberAccessExpression2, Expression<Func<T3>> memberAccessExpression3, Expression<Func<T4>> memberAccessExpression4, Expression<Func<T5>> memberAccessExpression5, Expression<Func<T6>> memberAccessExpression6, Expression<Func<T7>> memberAccessExpression7, Expression<Func<T8>> memberAccessExpression8, Expression<Func<T9>> memberAccessExpression9, Expression<Func<T10>> memberAccessExpression10, Expression<Func<T11>> memberAccessExpression11)
        {
            var assignTolocalVariable = ExpressionConverter.ConvertMemberAccessFuncsToAssignmentActionBlock(memberAccessExpression1, memberAccessExpression2, memberAccessExpression3, memberAccessExpression4, memberAccessExpression5, memberAccessExpression6, memberAccessExpression7, memberAccessExpression8, memberAccessExpression9, memberAccessExpression10, memberAccessExpression11);
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(assignTolocalVariable);
        }

        public void AreUsedToInvokeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action)
        {
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(action);
        }

        public void AreSavedTo<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Expression<Func<T1>> memberAccessExpression1, Expression<Func<T2>> memberAccessExpression2, Expression<Func<T3>> memberAccessExpression3, Expression<Func<T4>> memberAccessExpression4, Expression<Func<T5>> memberAccessExpression5, Expression<Func<T6>> memberAccessExpression6, Expression<Func<T7>> memberAccessExpression7, Expression<Func<T8>> memberAccessExpression8, Expression<Func<T9>> memberAccessExpression9, Expression<Func<T10>> memberAccessExpression10, Expression<Func<T11>> memberAccessExpression11, Expression<Func<T12>> memberAccessExpression12)
        {
            var assignTolocalVariable = ExpressionConverter.ConvertMemberAccessFuncsToAssignmentActionBlock(memberAccessExpression1, memberAccessExpression2, memberAccessExpression3, memberAccessExpression4, memberAccessExpression5, memberAccessExpression6, memberAccessExpression7, memberAccessExpression8, memberAccessExpression9, memberAccessExpression10, memberAccessExpression11, memberAccessExpression12);
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(assignTolocalVariable);
        }

        public void AreUsedToInvokeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action)
        {
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(action);
        }

        public void AreSavedTo<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Expression<Func<T1>> memberAccessExpression1, Expression<Func<T2>> memberAccessExpression2, Expression<Func<T3>> memberAccessExpression3, Expression<Func<T4>> memberAccessExpression4, Expression<Func<T5>> memberAccessExpression5, Expression<Func<T6>> memberAccessExpression6, Expression<Func<T7>> memberAccessExpression7, Expression<Func<T8>> memberAccessExpression8, Expression<Func<T9>> memberAccessExpression9, Expression<Func<T10>> memberAccessExpression10, Expression<Func<T11>> memberAccessExpression11, Expression<Func<T12>> memberAccessExpression12, Expression<Func<T13>> memberAccessExpression13)
        {
            var assignTolocalVariable = ExpressionConverter.ConvertMemberAccessFuncsToAssignmentActionBlock(memberAccessExpression1, memberAccessExpression2, memberAccessExpression3, memberAccessExpression4, memberAccessExpression5, memberAccessExpression6, memberAccessExpression7, memberAccessExpression8, memberAccessExpression9, memberAccessExpression10, memberAccessExpression11, memberAccessExpression12, memberAccessExpression13);
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(assignTolocalVariable);
        }

        public void AreUsedToInvokeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action)
        {
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(action);
        }

        public void AreSavedTo<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Expression<Func<T1>> memberAccessExpression1, Expression<Func<T2>> memberAccessExpression2, Expression<Func<T3>> memberAccessExpression3, Expression<Func<T4>> memberAccessExpression4, Expression<Func<T5>> memberAccessExpression5, Expression<Func<T6>> memberAccessExpression6, Expression<Func<T7>> memberAccessExpression7, Expression<Func<T8>> memberAccessExpression8, Expression<Func<T9>> memberAccessExpression9, Expression<Func<T10>> memberAccessExpression10, Expression<Func<T11>> memberAccessExpression11, Expression<Func<T12>> memberAccessExpression12, Expression<Func<T13>> memberAccessExpression13, Expression<Func<T14>> memberAccessExpression14)
        {
            var assignTolocalVariable = ExpressionConverter.ConvertMemberAccessFuncsToAssignmentActionBlock(memberAccessExpression1, memberAccessExpression2, memberAccessExpression3, memberAccessExpression4, memberAccessExpression5, memberAccessExpression6, memberAccessExpression7, memberAccessExpression8, memberAccessExpression9, memberAccessExpression10, memberAccessExpression11, memberAccessExpression12, memberAccessExpression13, memberAccessExpression14);
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(assignTolocalVariable);
        }

        public void AreUsedToInvokeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action)
        {
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(action);
        }

        public void AreSavedTo<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(Expression<Func<T1>> memberAccessExpression1, Expression<Func<T2>> memberAccessExpression2, Expression<Func<T3>> memberAccessExpression3, Expression<Func<T4>> memberAccessExpression4, Expression<Func<T5>> memberAccessExpression5, Expression<Func<T6>> memberAccessExpression6, Expression<Func<T7>> memberAccessExpression7, Expression<Func<T8>> memberAccessExpression8, Expression<Func<T9>> memberAccessExpression9, Expression<Func<T10>> memberAccessExpression10, Expression<Func<T11>> memberAccessExpression11, Expression<Func<T12>> memberAccessExpression12, Expression<Func<T13>> memberAccessExpression13, Expression<Func<T14>> memberAccessExpression14, Expression<Func<T15>> memberAccessExpression15)
        {
            var assignTolocalVariable = ExpressionConverter.ConvertMemberAccessFuncsToAssignmentActionBlock(memberAccessExpression1, memberAccessExpression2, memberAccessExpression3, memberAccessExpression4, memberAccessExpression5, memberAccessExpression6, memberAccessExpression7, memberAccessExpression8, memberAccessExpression9, memberAccessExpression10, memberAccessExpression11, memberAccessExpression12, memberAccessExpression13, memberAccessExpression14, memberAccessExpression15);
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(assignTolocalVariable);
        }

        public void AreUsedToInvokeAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> action)
        {
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(action);
        }

        public void AreSavedTo<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(Expression<Func<T1>> memberAccessExpression1, Expression<Func<T2>> memberAccessExpression2, Expression<Func<T3>> memberAccessExpression3, Expression<Func<T4>> memberAccessExpression4, Expression<Func<T5>> memberAccessExpression5, Expression<Func<T6>> memberAccessExpression6, Expression<Func<T7>> memberAccessExpression7, Expression<Func<T8>> memberAccessExpression8, Expression<Func<T9>> memberAccessExpression9, Expression<Func<T10>> memberAccessExpression10, Expression<Func<T11>> memberAccessExpression11, Expression<Func<T12>> memberAccessExpression12, Expression<Func<T13>> memberAccessExpression13, Expression<Func<T14>> memberAccessExpression14, Expression<Func<T15>> memberAccessExpression15, Expression<Func<T16>> memberAccessExpression16)
        {
            var assignTolocalVariable = ExpressionConverter.ConvertMemberAccessFuncsToAssignmentActionBlock(memberAccessExpression1, memberAccessExpression2, memberAccessExpression3, memberAccessExpression4, memberAccessExpression5, memberAccessExpression6, memberAccessExpression7, memberAccessExpression8, memberAccessExpression9, memberAccessExpression10, memberAccessExpression11, memberAccessExpression12, memberAccessExpression13, memberAccessExpression14, memberAccessExpression15, memberAccessExpression16);
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback(assignTolocalVariable);
        }



    }
}

