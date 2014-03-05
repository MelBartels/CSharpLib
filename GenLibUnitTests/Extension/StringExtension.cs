using GenLib.Extensions;
using Xunit;

namespace GenLibUnitTests.Extension
{
    public class StringExtension
    {
        [Fact]
        public void TestToSentenceCaseAndToTitleCase()
        {
            Assert.Equal("Hello", "hello".ToSentenceCase());
            Assert.Equal("Hello", "hello".ToTitleCase());

            Assert.Equal("Hello world", "Hello world".ToSentenceCase());
            Assert.Equal("Hello World", "Hello world".ToTitleCase());

            Assert.Equal("Add a series of design drawings", "Add a series of Design drawings".ToSentenceCase());
            Assert.Equal("Add a Series of Design Drawings", "Add a series of Design drawings".ToTitleCase());

            Assert.Equal("Completed adding design drawings", "Completed adding Design drawings".ToSentenceCase());
            Assert.Equal("Completed Adding Design Drawings", "Completed adding Design drawings".ToTitleCase());

            Assert.Equal("As the world turns", "As The World Turns".ToSentenceCase());
            Assert.Equal("As the World Turns", "As the world turns".ToTitleCase());

            Assert.Equal("As the world turns but here", "As The world Turns But Here".ToSentenceCase());
            Assert.Equal("As the World Turns but Here", "As The world Turns But Here".ToTitleCase());

            Assert.Equal("As the world turns not only here", "As The world Turns not Only Here".ToSentenceCase());
            Assert.Equal("As the World Turns not only Here", "As The world Turns not Only Here".ToTitleCase());

            Assert.Equal("As the world turns not even if", "As The world Turns not Even If".ToSentenceCase());
            Assert.Equal("As the World Turns Not even if", "As The world Turns not Even If".ToTitleCase());

            Assert.True(true);
        }
    }
}