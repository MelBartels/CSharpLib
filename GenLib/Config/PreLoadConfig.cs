namespace GenLib.Config
{
    public class PreLoadConfig
    {
        public PreLoadConfig(SettingsService settingsService)
        {
            settingsService.IncludeType(typeof (SettingContainer));
        }
    }
}