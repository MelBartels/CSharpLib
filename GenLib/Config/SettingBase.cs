namespace GenLib.Config
{
    public abstract class SettingBase : ISetting
    {
        #region ISetting Members

        public string Name { get; set; }
        public abstract void SetToDefaults();

        #endregion
    }
}