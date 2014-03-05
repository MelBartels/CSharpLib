using System;
using Xunit;

namespace GenLibUnitTests.Examples.Delegates
{
    public class MethodGroupExamplesTest
    {
        public delegate void IntDelegate(int i);

        private int _msgCount;

        private void WriteMsg(int i)
        {
            Console.WriteLine("msg: {0}", i);
            _msgCount++;
        }

        [Fact]
        public void Variations()
        {
// ReSharper disable SuggestUseVarKeywordEvident
// ReSharper disable RedundantDelegateCreation

            // Add a method group to the delegate - C# 1.0
            var intDelegate = new IntDelegate(WriteMsg);

// ReSharper restore RedundantDelegateCreation
// ReSharper restore SuggestUseVarKeywordEvident

            // Add using implicit method group conversion - C# 2.0
            // += polymorphic add, -= polymorphic remove
            intDelegate += WriteMsg;

// ReSharper disable ConvertToLambdaExpression
            // Add as an anonymous method - C# 2.0
            // += (args) => {statements} 
            intDelegate += delegate(int i) { Console.WriteLine("msg: {0} (delegate via anonymous inline method)", i); };
            _msgCount++;

// ReSharper restore ConvertToLambdaExpression

            // Add as a lamba expression - C# 3.0
            intDelegate += i => Console.WriteLine("msg: {0} (lamba)", i);
            _msgCount++;

            // results in 4 msgs
            intDelegate(123);

            Assert.Equal(4, _msgCount);
        }
    }
}