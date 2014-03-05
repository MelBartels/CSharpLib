using Xunit;

namespace GenLibUnitTests.Email
{
    public class Gmail
    {
        [Fact]
        public void Send()
        {
            new GenLib.Email.Gmail().Send("melbartelswork", "56hGK8!!s555", "melbartelswork@gmail.com",
                                         "mbartels@fabtrol.com", "test subject", "test body");

            Assert.True(true);
        }
    }
}