using GenLib.Config;
using GenLib.Services;
using Xunit;

namespace GenLibUnitTests.Config
{
    public class SettingsService
    {
        private DirectoryFile _directoryFile;
        private GenLib.Config.SettingsService _settingsService;

        private void SetUpSettingsService()
        {
            _directoryFile = new DirectoryFile();
            _settingsService = new GenLib.Config.SettingsService();
            _settingsService.IncludeType(typeof (TestSetting));
        }

        [Fact]
        public void IncludeType()
        {
            SetUpSettingsService();

            // make sure type has been added (should have been added in Init())
            _settingsService.IncludeType(typeof (TestSetting));
            var expectedTypeCount = _settingsService.Types.Count;
            // try adding again
            _settingsService.IncludeType(typeof (TestSetting));
            Assert.Equal(expectedTypeCount, _settingsService.Types.Count);

            Assert.True(true);
        }

        [Fact]
        public void LoadSaveHierarchicalSettings()
        {
            SetUpSettingsService();

            // create setting
            const string settingId = "settings bag";
            var settingContainer = _settingsService.GetSettingContainer(settingId);
            var hierarchicalSetting = new SettingsBag();
            const string hierarchicalSettingId = "hierarchical setting";
            hierarchicalSetting.SettingContainers.Add(new SettingContainer {Id = hierarchicalSettingId});
            settingContainer.Setting = hierarchicalSetting;

            // save/load
            _settingsService.SaveConfig();
            _settingsService.LoadConfig();

            // test for setting
            settingContainer = _settingsService.GetSettingContainer(settingId);
            Assert.Equal(settingId, settingContainer.Id);
            Assert.IsType(typeof (SettingsBag), settingContainer.Setting);
            Assert.Equal(hierarchicalSettingId, ((SettingsBag) settingContainer.Setting).SettingContainers[0].Id);

            Assert.True(true);
        }

        [Fact]
        public void LoadSaveSettings()
        {
            SetUpSettingsService();

            // Id doubles for Setting Id and for ISetting's Name
            const string testId = "testId";
            const string testId2 = "testId2";

            // create, add 1st setting
            var settingContainer = _settingsService.GetSettingContainer(testId);
            var testSetting = new TestSetting {Name = testId};
            settingContainer.Setting = testSetting;
            settingContainer.SettingType = typeof (TestSetting).FullName;

            // create, add 2nd setting
            settingContainer = _settingsService.GetSettingContainer(testId2);
            var testSetting2 = new TestSetting {Name = testId2};
            settingContainer.Setting = testSetting2;
            settingContainer.SettingType = typeof (TestSetting).FullName;

            // test save/load
            _directoryFile.DeleteFileAndDirectory(_settingsService.Filename);
            _settingsService.SaveConfig();
            _settingsService.LoadConfig();

            settingContainer = _settingsService.GetSettingContainer(testId);
            Assert.Equal(((TestSetting) settingContainer.Setting).Name, testId);
            settingContainer = _settingsService.GetSettingContainer(testId2);
            Assert.Equal(((TestSetting) settingContainer.Setting).Name, testId2);

            // test removing setting
            _settingsService.RemoveSettingContainer(testId);
            settingContainer = _settingsService.GetSettingContainer(testId);
            Assert.Null(settingContainer.Setting);
            // test that other setting was unchanged
            settingContainer = _settingsService.GetSettingContainer(testId2);
            Assert.Equal(((TestSetting) settingContainer.Setting).Name, testId2);

            Assert.True(true);
        }

        public void SettingNull()
        {
            SetUpSettingsService();

            _settingsService.LoadConfig();
            Assert.Null(_settingsService.GetISetting("nullSetting"));

            Assert.True(true);
        }

        public void SettingUpdateSave()
        {
            SetUpSettingsService();

            const string testId = "testId";
            const string testStringValue = "testStringValue";
            const int testIntValue = 0;
            const bool testBoolValue = false;

            // create testSetting
            var testSetting = new TestSetting
                                  {
                                      Name = testId,
                                      StringValue = testStringValue,
                                      IntValue = testIntValue,
                                      BoolValue = testBoolValue
                                  };

            // save/update
            _directoryFile.DeleteFileAndDirectory(_settingsService.Filename);

            _settingsService.SetISetting(testSetting);
            _settingsService.SaveConfig();

            _settingsService.LoadConfig();
            Assert.Equal(testSetting.StringValue, testStringValue);
            Assert.Equal(testSetting.IntValue, testIntValue);
            Assert.Equal(testSetting.BoolValue, testBoolValue);

            Assert.True(true);
        }
    }
}