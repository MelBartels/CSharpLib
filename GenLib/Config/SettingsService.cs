using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using GenLib.ExceptionService;
using GenLib.Extensions;
using GenLib.Properties;
using GenLib.Services;

namespace GenLib.Config
{
    // SettingsBag is the container for all settings (List<SettingContainers>);
    // Each SettingContainer has a Id, SettingType, and Setting (XmlSerializer cannot handle List<T> unless it's in an object);
    // To create hierarchical settings, set SettingContainer's Setting to a new SettingsBag;
    // SettingsService's methods GetISetting/SetISetting expects SettingContainer's Setting to be an object that implements ISetting;

    public class SettingsService
    {
        public SettingsService(IExceptionHandler exceptionHandler, 
                               SettingsBag settingsBag,
                               DirectoryFile directoryFile)
        {
            Types = new List<Type>();
            Filename = Path.Combine(Constants.General.SettingsSubdir, Constants.General.SettingsFilename);
            SettingsBag = settingsBag;
            ExceptionHandler = exceptionHandler;
            DirectoryFile = directoryFile;
        }

        public SettingsService(IExceptionHandler exceptionHandler)
            : this(exceptionHandler, new SettingsBag(), new DirectoryFile())
        {
        }

        public SettingsService() : this(new ExceptionHandlerLog())
        {
        }

        public string Filename { get; set; }
        public List<Type> Types { get; set; }

        private SettingsBag SettingsBag { get; set; }
        private IExceptionHandler ExceptionHandler { get; set; }
        private DirectoryFile DirectoryFile { get; set; }
        private XmlSerializer XmlSerializer { get; set; }

        public void IncludeType(Type type)
        {
            Types.Find(t => t == type).DoWhenNull(() => AddTypeStrategy(type));
        }

        private void AddTypeStrategy(Type type)
        {
            Types.Add(type);
            XmlSerializer = new XmlSerializer(typeof (SettingsBag), Types.ToArray());
        }

        public bool LoadConfig()
        {
            try
            {
                if (File.Exists(Filename))
                    SettingsBag = new StreamReader(Filename).Using(sr => XmlSerializer.Deserialize(sr)) as SettingsBag;
                return true;
            }
            catch (NullReferenceException nre)
            {
                ExceptionHandler.Notify(nre, Resources.UnableToDeserializeMsg + Filename);
            }
            return false;
        }

        public bool SaveConfig()
        {
            DirectoryFile.CreateDirectory(Filename);
            new StreamWriter(Filename).Using(sw => XmlSerializer.Serialize(sw, SettingsBag));
            return true;
        }

        public SettingContainer GetSettingContainer(string id)
        {
            return RetrieveSettingContainer(id).Return(sc => sc, () => CreateNewSettingContainer(id));
        }

        public void RemoveSettingContainer(string id)
        {
            RetrieveSettingContainer(id).Do(sc => SettingsBag.SettingContainers.Remove(sc));
        }

        public ISetting GetISetting(string id)
        {
            return GetSettingContainer(id).Setting as ISetting;
        }

        public void SetISetting(ISetting setting)
        {
            GetSettingContainer(setting.Name).Do(sc =>
                                                     {
                                                         sc.SettingType = typeof (ISetting).FullName;
                                                         sc.Setting = setting;
                                                     });
        }

        private SettingContainer RetrieveSettingContainer(string id)
        {
            return SettingsBag
                .With(sb => sb)
                .With(sb => sb.SettingContainers)
                .With(_ => FindSettingContainer(id));
        }

        private SettingContainer FindSettingContainer(string id)
        {
            return SettingsBag.SettingContainers.Find(obj => MatchSettingContainer(obj, id));
        }

        private static bool MatchSettingContainer(SettingContainer obj, string id)
        {
            return obj.GetType() == typeof (SettingContainer)
                   && !string.IsNullOrEmpty(obj.Id)
                   && obj.Id == id;
        }

        private SettingContainer CreateNewSettingContainer(string id)
        {
            return new SettingContainer {Id = id, SettingType = string.Empty}
                .Do(sc => SettingsBag.SettingContainers.Add(sc));
        }
    }
}