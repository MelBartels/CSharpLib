using System;
using System.Reflection;
using System.Text;
using Xunit;

namespace GenLibUnitTests.Examples
{
    internal class Foo
    {
    }

    internal class FooB
    {
        private FooB()
        {
        }

        public static FooB GetInstance()
        {
            return new FooB();
        }
    }

    internal class BuildServices
    {
        internal static object Build(string typeName)
        {
            var type = Type.GetType(typeName);
            return type == null ? null : type.GetMethod("GetInstance",BindingFlags.IgnoreCase | BindingFlags.Static | BindingFlags.Public).Invoke(null, null);
        }
    }

    public class CreationExamples
    {
        private class FooC
        {
        }

        private class FooD
        {
            private FooD()
            {
            }

            public static FooD GetInstance()
            {
                return new FooD();
            }
        }

        [Fact]
        public void CreateInstance()
        {
            var objectName = new StringBuilder();
            objectName.Append(typeof (Foo).FullName);
            var testResultObj = Activator.CreateInstance(Type.GetType(objectName.ToString()));
            Assert.IsType(typeof (Foo), testResultObj);

            objectName = new StringBuilder();
            objectName.Append(typeof (FooC).FullName);
            testResultObj = Activator.CreateInstance(Type.GetType(objectName.ToString()));
            Assert.IsType(typeof (FooC), testResultObj);

            Assert.True(true);
        }

        [Fact]
        public void FactoryBuild()
        {
            var testResultObj = BuildServices.Build("FooB");
            Assert.Null(testResultObj);

            testResultObj = BuildServices.Build(typeof (FooB).FullName);
            Assert.IsType(typeof (FooB), testResultObj);

            testResultObj = BuildServices.Build("FooD");
            Assert.Null(testResultObj);

            testResultObj = BuildServices.Build(typeof (FooD).FullName);
            Assert.IsType(typeof (FooD), testResultObj);

            Assert.True(true);
        }

        [Fact]
        public void GetTypeStudy()
        {
            // won't work unless namespace is included 
            Console.WriteLine(new FooC().GetType().FullName);
            Assert.Null(Type.GetType("FooC"));
            Assert.NotNull(Type.GetType("GenLibUnitTests.Examples.CreationExamples+FooC"));

            Assert.True(true);
        }

        [Fact]
        public void InvokeMethod()
        {
            var type = typeof (FooB);
            var method = type.GetMethod("GetInstance");
            var testResultObj = method.Invoke(null, null);
            Assert.IsType(typeof (FooB), testResultObj);

            method = type.GetMethod("GetInstance", BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Static);
            testResultObj = method.Invoke(null, null);
            Assert.IsType(typeof (FooB), testResultObj);

            testResultObj = type.GetMethod("GetInstance", BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Static).Invoke(null, null);
            Assert.IsType(typeof (FooB), testResultObj);

            type = typeof (FooD);
            method = type.GetMethod("GetInstance");
            testResultObj = method.Invoke(null, null);
            Assert.IsType(typeof (FooD), testResultObj);

            Assert.True(true);
        }
    }
}