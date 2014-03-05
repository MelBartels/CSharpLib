using System;
using System.Text;
using GenLib.Constants;
using Xunit;

namespace GenLibUnitTests.Helper
{
    public class StringTokenizer
    {
        [Fact]
        public void CountString()
        {
            const string testStr = " true false xxx true ";
            var st = new GenLib.Helper.StringTokenizer();
            st.Tokenize(testStr);
            Assert.Equal(4, st.CountTokens<string>());

            Assert.True(true);
        }

        [Fact]
        public void CountBool()
        {
            const string testStr = " true false xxx true ";
            var st = new GenLib.Helper.StringTokenizer();
            st.Tokenize(testStr);
            Assert.Equal(3, st.CountTokens<bool>());

            Assert.True(true);
        }

        [Fact]
        public void CountChar()
        {
            const string testStr = " a b c d e ";
            var st = new GenLib.Helper.StringTokenizer();
            st.Tokenize(testStr);
            Assert.Equal(5, st.CountTokens<char>());

            Assert.True(true);
        }

        [Fact]
        public void CountDateTime()
        {
            var delimiter = ",".ToCharArray();
            var sb = new StringBuilder();
            sb.Append(DateTime.Now);
            sb.Append(delimiter);
            sb.Append(DateTime.Now);
            var testStr = sb.ToString();
            var st = new GenLib.Helper.StringTokenizer();
            st.Tokenize(testStr, delimiter);
            Assert.Equal(2, st.CountTokens<DateTime>());

            Assert.True(true);
        }

        [Fact]
        public void CountDouble()
        {
            const string testStr = " 1.2 - 3.4 xxx + 5.6 ";
            var st = new GenLib.Helper.StringTokenizer();
            st.Tokenize(testStr);
            Assert.Equal(3, st.CountTokens<double>());

            Assert.True(true);
        }

        [Fact]
        public void CountInt()
        {
            const string testStr = " 1 2 xxx - 3 ";
            var st = new GenLib.Helper.StringTokenizer();
            st.Tokenize(testStr);
            Assert.Equal(3, st.CountTokens<int>());

            Assert.True(true);
        }

        [Fact]
        public void NextBool()
        {
            const string testStr = " true false xxx true ";
            var st = new GenLib.Helper.StringTokenizer();
            st.Tokenize(testStr);
            Assert.Equal(4, st.Count);
            Assert.Equal(true, st.NextToken<bool>());
            Assert.Equal(false, st.NextToken<bool>());
            Assert.Equal(true, st.NextToken<bool>());
            Assert.Null(st.NextToken<bool>());

            Assert.True(true);
        }

        [Fact]
        public void NextChar()
        {
            const string testStr = " a b c d e ";
            var st = new GenLib.Helper.StringTokenizer();
            st.Tokenize(testStr);
            Assert.Equal(5, st.Count);
            Assert.Equal(Convert.ToChar("a"), st.NextToken<char>());
            Assert.Equal(Convert.ToChar("b"), st.NextToken<char>());
            Assert.Equal(Convert.ToChar("c"), st.NextToken<char>());
            Assert.Equal(Convert.ToChar("d"), st.NextToken<char>());
            Assert.Equal(Convert.ToChar("e"), st.NextToken<char>());

            Assert.True(true);
        }

        [Fact]
        public void NextDateTime()
        {
            var delimiter = ",".ToCharArray();
            var sb = new StringBuilder();
            sb.Append(DateTime.Now);
            sb.Append(delimiter);
            sb.Append(DateTime.Now);
            var testStr = sb.ToString();
            var st = new GenLib.Helper.StringTokenizer();
            st.Tokenize(testStr, delimiter);
            Assert.Equal(2, st.Count);
            DateTime dt;
            Assert.True(DateTime.TryParse(st.NextToken<DateTime>().ToString(), out dt));
            Console.WriteLine("stored DateTime looks like: " + st.NextToken<DateTime>());

            Assert.True(true);
        }

        [Fact]
        public void NextDouble()
        {
            const string testStr = " 1.2 3.4 xxx 5.6 ";
            var st = new GenLib.Helper.StringTokenizer();
            st.Tokenize(testStr);
            Assert.Equal(4, st.Count);
            Assert.Equal(1.2, st.NextToken<double>());
            Assert.Equal(3.4, st.NextToken<double>());
            Assert.Equal(5.6, st.NextToken<double>());

            Assert.True(true);
        }

        [Fact]
        public void NextDoublePosNeg()
        {
            const string testStr = " 1.2 - 3.4 xxx + 5.6 ";
            var st = new GenLib.Helper.StringTokenizer();
            st.Tokenize(testStr);
            Assert.Equal(6, st.Count);
            Assert.Equal(1.2, st.NextToken<double>());
            Assert.Equal(-3.4, st.NextToken<double>());
            Assert.Equal(5.6, st.NextToken<double>());

            Assert.True(true);
        }

        [Fact]
        public void NextDoublePosNeg2()
        {
            const string testStr = " 1.2 - 3.4 - 5.6 xxx + 7.8 ";
            var st = new GenLib.Helper.StringTokenizer();
            st.Tokenize(testStr);
            Assert.Equal(8, st.Count);
            Assert.Equal(1.2, st.NextToken<double>());
            Assert.Equal(-3.4, st.NextToken<double>());
            Assert.Equal(-5.6, st.NextToken<double>());
            Assert.Equal(7.8, st.NextToken<double>());

            Assert.True(true);
        }

        [Fact]
        public void NextDoublePosNeg3()
        {
            const string testStr = " 1.2 - - 3.4 - 5.6 xxx + 7.8 ";
            var st = new GenLib.Helper.StringTokenizer();
            st.Tokenize(testStr);
            Assert.Equal(9, st.Count);
            Assert.Equal(1.2, st.NextToken<double>());
            Assert.Equal(-3.4, st.NextToken<double>());
            Assert.Equal(-5.6, st.NextToken<double>());
            Assert.Equal(7.8, st.NextToken<double>());

            Assert.True(true);
        }

        [Fact]
        public void NextInt()
        {
            const string testStr = " 1 2 xxx 3 ";
            var st = new GenLib.Helper.StringTokenizer();
            st.Tokenize(testStr);
            Assert.Equal(4, st.Count);
            Assert.Equal(1, st.NextToken<int>());
            Assert.Equal(2, st.NextToken<int>());
            Assert.Equal(3, st.NextToken<int>());

            Assert.True(true);
        }

        [Fact]
        public void NextIntPosNeg()
        {
            const string testStr = " 1 2 xxx - 3 ";
            var st = new GenLib.Helper.StringTokenizer();
            st.Tokenize(testStr);
            Assert.Equal(5, st.Count);
            Assert.Equal(1, st.NextToken<int>());
            Assert.Equal(2, st.NextToken<int>());
            Assert.Equal(-3, st.NextToken<int>());

            Assert.True(true);
        }

        [Fact]
        public void NextIntPosNeg2()
        {
            const string testStr = " 1 2 - 3 - 4 xxx 5 ";
            var st = new GenLib.Helper.StringTokenizer();
            st.Tokenize(testStr);
            Assert.Equal(8, st.Count);
            Assert.Equal(1, st.NextToken<int>());
            Assert.Equal(2, st.NextToken<int>());
            Assert.Equal(-3, st.NextToken<int>());
            Assert.Equal(-4, st.NextToken<int>());
            Assert.Equal(5, st.NextToken<int>());

            Assert.True(true);
        }

        [Fact]
        public void NextIntPosNeg3()
        {
            const string testStr = " 1 2 - - 3 - 4 xxx 5 ";
            var st = new GenLib.Helper.StringTokenizer();
            st.Tokenize(testStr);
            Assert.Equal(9, st.Count);
            Assert.Equal(1, st.NextToken<int>());
            Assert.Equal(2, st.NextToken<int>());
            Assert.Equal(-3, st.NextToken<int>());
            Assert.Equal(-4, st.NextToken<int>());
            Assert.Equal(5, st.NextToken<int>());

            Assert.True(true);
        }

        [Fact]
        public void NextIntPosNeg4()
        {
            const string testStr = " 1 2.3 - - 4 - 5 xxx 6.7 ";
            var st = new GenLib.Helper.StringTokenizer();
            st.Tokenize(testStr);
            Assert.Equal(9, st.Count);
            Assert.Equal(1, st.NextToken<int>());
            Assert.Equal(-4, st.NextToken<int>());
            Assert.Equal(-5, st.NextToken<int>());

            Assert.True(true);
        }

        [Fact]
        public void NextIntPosNeg5()
        {
            const string testStr = " 1 - 2.3 4 - 5 xxx - 6 ";
            var st = new GenLib.Helper.StringTokenizer();
            st.Tokenize(testStr);
            Assert.Equal(9, st.Count);
            Assert.Equal(1, st.NextToken<int>());
            Assert.Equal(4, st.NextToken<int>());
            Assert.Equal(-5, st.NextToken<int>());
            Assert.Equal(-6, st.NextToken<int>());

            Assert.True(true);
        }

        [Fact]
        public void NextIntPosNeg6()
        {
            const string testStr = " 1 -2.3 4 -5 xxx -6 ";
            var st = new GenLib.Helper.StringTokenizer();
            st.Tokenize(testStr);
            Assert.Equal(6, st.Count);
            Assert.Equal(1, st.NextToken<int>());
            Assert.Equal(4, st.NextToken<int>());
            Assert.Equal(-5, st.NextToken<int>());
            Assert.Equal(-6, st.NextToken<int>());

            Assert.True(true);
        }

        [Fact]
        public void NextToken()
        {
            const string testStr = " 1.2 3.4 5.6 7.8 ";
            var st = new GenLib.Helper.StringTokenizer();
            st.Tokenize(testStr);
            Assert.Equal(4, st.Count);
            Assert.Equal("1.2", st.NextToken());
            Assert.Equal("3.4", st.NextToken());
            Assert.Equal("5.6", st.NextToken());
            Assert.Equal("7.8", st.NextToken());

            Assert.True(true);
        }

        [Fact]
        public void StripTrailingCrNotNecessary()
        {
            var testString = "1234" + General.Cr;
            Int32 testInt32;
            Assert.True(Int32.TryParse(testString, out testInt32));
            testString = "12.34" + General.Cr;
            double testDouble;
            Assert.True(double.TryParse(testString, out testDouble));

            Assert.True(true);
        }
    }
}