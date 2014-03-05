using System.Drawing;

namespace GenLib.Startup
{
    public class ViewModel
    {
        public ViewModel(ApplicationDataModel applicationDataModel)
        {
            ApplicationDataModel = applicationDataModel;
        }

        public ApplicationDataModel ApplicationDataModel { get; set; }

        public string ImageFilename { get; set; }
        public string Title { get; set; }
        public string Version { get; set; }
        public string Copyright { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public Color TextColor { get; set; }

        public void SetProperties(string imageFilename, Color textColor)
        {
            ApplicationDataModel.SetValues();
            Company = ApplicationDataModel.Company;
            Copyright = ApplicationDataModel.Copyright;
            Description = ApplicationDataModel.Description;
            ImageFilename = imageFilename;
            TextColor = textColor;
            Title = ApplicationDataModel.Title;
            Version = @"Version " + ApplicationDataModel.Version;
        }
    }
}