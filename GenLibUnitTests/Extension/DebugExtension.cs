using System;
using System.Collections.Generic;
using System.Linq;
using GenLib.Extensions;
using Xunit;

namespace GenLibUnitTests.Extension
{
    public class DebugExtension
    {
        [Fact]
        public void Dump()
        {
            var words = new[] {"hello", "world"};
            Console.WriteLine("----");
            words
                .Dump()
                .Select(a => a.ToUpper())
                .Dump()
                .ToList();
            Console.WriteLine("----");
            words
                .Dump(a => "Beginning list: " + a)
                .Select(a => a.ToUpper())
                .Dump(a => "ToUpper : " + a)
                .ToList();
            Console.WriteLine("----");

            Assert.True(true);
        }

        [Fact]
        public void Dump2()
        {
            var planes = new List<Airplane> {new Airplane(), null, new Airplane()};
            Console.WriteLine("----");
            planes
                .Dump()
                .ToList();
            Console.WriteLine("----");

            Assert.True(true);
        }

        [Fact]
        public void Dump3()
        {
            var bools = new [] { true, false };
            Console.WriteLine("----");
            bools
                .Dump()
                .ToList();
            Console.WriteLine("----");

            Assert.True(true);
        }

        [Fact]
        public void Dump4()
        {
            var bools = new bool?[] { true, null, false };
            Console.WriteLine("----");
            bools
                .Dump()
                .ToList();
            Console.WriteLine("----");

            Assert.True(true);
        }

        [Fact]
        public void Dump5()
        {
            var ints = new [] { 1, 2, 3, 4, 5 };
            Console.WriteLine("----");
            ints
                .Dump()
                .ToList();
            Console.WriteLine("----");

            Assert.True(true);
        }
    }
}