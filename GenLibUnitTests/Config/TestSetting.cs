using GenLib.Config;

namespace GenLibUnitTests.Config
{
    public class TestSetting : SettingBase
    {
        public string StringValue { get; set; }
        public int IntValue { get; set; }
        public bool BoolValue { get; set; }

        public override void SetToDefaults()
        {
            Name = "defaultName";
            StringValue = "defaultString";
            IntValue = 5;
            BoolValue = true;
        }
    }
}