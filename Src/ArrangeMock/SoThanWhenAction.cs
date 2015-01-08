using System;
using System.Linq.Expressions;
using ArrangeMock.Interfaces;
using Moq;

namespace ArrangeMock
{
    internal class SoThatWhenAction<T> : ISoThatWhenAction<T>, 
                                         IActionIsCalled<T>,
                                         IArgumentPassedIn
                                         where T : class
    {
        private readonly Expression<Action<T>> _actionToArrange;
        private Expression<Action<T>> _moqExpressionCastToOriginalType;
        private Mock<T> _mockToArrange;
        private Expression _actionToArrangeConvertedToMoqExpression;

        internal SoThatWhenAction(Mock<T> mockToArrange, Expression<Action<T>> actionToArrange)
        {
            _mockToArrange = mockToArrange;
            _actionToArrange = actionToArrange;
            _actionToArrangeConvertedToMoqExpression = ExpressionConverter.ConvertArrangeMockExpressionToMoqExpression(_actionToArrange);
            _moqExpressionCastToOriginalType = (Expression<Action<T>>)_actionToArrangeConvertedToMoqExpression;
        }


        public IActionIsCalled<T> IsCalled()
        {
            return this;
        }

        public IArgumentPassedIn TheArgumentsPassedIn()
        {
            return this;
        }

        public void AreSavedTo<T>(Expression<Func<T>> memberAccessExpression)
        {
            var assignTolocalVariable = ExpressionConverter.ConvertMemberAccessFuncToAssignmentAction(memberAccessExpression);
            _mockToArrange.Setup(_moqExpressionCastToOriginalType).Callback<T>( assignTolocalVariable );
        }
    }
}
