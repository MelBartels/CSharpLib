using System.Collections.Generic;
using Xunit;

namespace GenLibUnitTests.Examples.Delegates
{
    internal class DelegateAndLambdaExamples
    {
        private readonly List<Person> _people = new List<Person>();

        internal DelegateAndLambdaExamples()
        {
            _people.Add(new Person {Name = "Sam"});
            _people.Add(new Person {Name = "Julie"});
        }

        internal List<Person> NamedMethodWithExplicitConstruction()
        {
            return _people.FindAll(NameIsSam);
        }

        private static bool NameIsSam(Person person)
        {
            return person.Name=="Sam";
        }

        internal List<Person> NamedMethodWithImplicitConstruction()
        {
            return _people.FindAll(NameIsSam);
        }

        internal List<Person> AnonymousMethodWithImplicitConstruction()
        {
            return _people.FindAll(delegate(Person person) { return person.Name=="Sam"; });
        }

        internal List<Person> LambdaExpression()
        {
            return _people.FindAll(person => person.Name=="Sam");
        }

        #region Nested type: Person

        internal class Person
        {
            internal string Name { get; set; }
        }

        #endregion
    }

    public class DelegateAndLambdaExamplesTest
    {
        [Fact]
        public void AnonymousMethodWithImplicitConstruction()
        {
            Assert.Equal(1, new DelegateAndLambdaExamples().AnonymousMethodWithImplicitConstruction().Count);
        }

        [Fact]
        public void LambdaExpression()
        {
            Assert.Equal(1, new DelegateAndLambdaExamples().LambdaExpression().Count);
        }

        [Fact]
        public void NamedMethodWithExplicitConstruction()
        {
            Assert.Equal(1, new DelegateAndLambdaExamples().NamedMethodWithExplicitConstruction().Count);
        }

        [Fact]
        public void NamedMethodWithImplicitConstruction()
        {
            Assert.Equal(1, new DelegateAndLambdaExamples().NamedMethodWithImplicitConstruction().Count);
        }
    }
}