namespace GenLib.Config
{
    public interface ISetting
    {
        string Name { get; set; }
        void SetToDefaults();
    }
}