using GenLib.Extensions;
using Xunit;

namespace GenLibUnitTests.Config
{
    public class Setting
    {
        [Fact]
        public void Cloning()
        {
            const string name = "name";

            var setting = new TestSetting {Name = name};
            var clonedSetting = setting.CloneAndSetPropertiesFrom();
            Assert.NotNull(clonedSetting);
            setting.Name = null;
            Assert.Equal(name, clonedSetting.Name);

            Assert.True(true);
        }
    }
}