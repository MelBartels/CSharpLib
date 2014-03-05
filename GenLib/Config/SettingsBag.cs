using System.Collections.Generic;

namespace GenLib.Config
{
    public class SettingsBag
    {
        public SettingsBag()
        {
            SettingContainers = new List<SettingContainer>();
        }

        public List<SettingContainer> SettingContainers { get; set; }
    }
}