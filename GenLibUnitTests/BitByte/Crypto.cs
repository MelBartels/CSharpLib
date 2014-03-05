using System;
using GenLib.BitByte;
using Xunit;

namespace GenLibUnitTests.BitByte
{
    public class Crypt
    {
        [Fact]
        public void TestStringToBytes()
        {
            const string testString = "testingTesting123";

            var crypto = new Crypto();
            var encryptedString = crypto.EncryptStringToString(testString);
            var result = crypto.DecryptStringFromString(encryptedString);
            Console.WriteLine("result=" + result);

            Assert.True(testString.Equals(result));

            Assert.True(true);
        }
    }
}