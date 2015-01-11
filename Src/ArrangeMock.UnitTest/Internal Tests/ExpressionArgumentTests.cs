using System;
using System.Linq.Expressions;
using System.Reflection;
using ArrangeMock.UnitTest.TestableArtifacts;
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

        [Test]
        public void ConvertVariableAccessFunctionToAssignmentAction()
        {
            string testString = null;
            Expression<Func<string>> inputFunc = () => testString;
            Action<string> outputAction = x => testString = x;
            var result = ExpressionConverter.ConvertMemberAccessFuncToAssignmentAction(inputFunc);

            result.ToString().ShouldBe(outputAction.ToString());
        }

        [Test]
        public void ConvertPropertyAccessFunctionToAssignmentAction()
        {
            Expression<Func<string>> inputFunc = () => TestProperty1;
            Action<string> outputAction = x => TestProperty1 = x;
            var result = ExpressionConverter.ConvertMemberAccessFuncToAssignmentAction(inputFunc);

            result.ToString().ShouldBe(outputAction.ToString());
        }

        [Test]
        public void ConvertVariableAccessFunctionsToAssignmentActionBlock()
        {
            string testString1 = null;
            string testString2 = null;
            Expression<Func<string>> inputFunc = () => testString1;
            Expression<Func<string>> inputFunc2 = () => testString2;

            Action<string,string> outputAction = (x1, x2) => {  testString1 = x1; testString2 = x2; };

            var result = ExpressionConverter.ConvertMemberAccessFuncsToAssignmentActionBlock<string,string>(inputFunc, inputFunc2);

            result.ToString().ShouldBe(outputAction.ToString());
        }

        [Test]
        public void ConvertPropertyAccessFunctionsToAssignmentActionBlock()
        {
            Expression<Func<string>> inputFunc1 = () => TestProperty1;
            Expression<Func<string>> inputFunc2 = () => TestProperty2;
            Action<string, string> outputAction = (x1, x2) => { TestProperty1 = x1; TestProperty2 = x2; };

            var result = ExpressionConverter.ConvertMemberAccessFuncsToAssignmentActionBlock<string,string>(inputFunc1,inputFunc2);

            result.ToString().ShouldBe(outputAction.ToString());
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ConvertMemberAccessFunctionThrowsExceptionWhenNotPassedVariableAccess()
        {
            string testString = null;
            Expression<Func<string>> inputFunc = () => TestMethod();
            Action<string> outputAction = x => testString = x;
            var result = ExpressionConverter.ConvertMemberAccessFuncToAssignmentAction(inputFunc);

            result.ToString().ShouldBe(outputAction.ToString());
        }

        private string TestMethod()
        {
            return "TestString";
        }

        private string TestProperty1 { get; set; }
        private string TestProperty2 { get; set; }
    }
}
