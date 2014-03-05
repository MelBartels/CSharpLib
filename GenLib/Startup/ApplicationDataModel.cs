using System.Reflection;
using System.Windows.Forms;

namespace GenLib.Startup
{
    public class ApplicationDataModel
    {
        public string Title { get; set; }
        public string Version { get; set; }
        public string Company { get; set; }
        public string Copyright { get; set; }
        public string Description { get; set; }

        public void SetValues()
        {
            var copyright = "copyright";
            var description = "description";
            var assembly = Assembly.GetEntryAssembly();
            if (assembly != null)
            {
                copyright =
                    ((AssemblyCopyrightAttribute)
                     (assembly.GetCustomAttributes(typeof (AssemblyCopyrightAttribute), false)[0])).Copyright;
                description =
                    ((AssemblyDescriptionAttribute)
                     assembly.GetCustomAttributes(typeof (AssemblyDescriptionAttribute), false)[0]).Description;
            }

            Title = Application.ProductName;
            Version = Application.ProductVersion;
            Company = Application.CompanyName;
            Copyright = copyright;
            Description = description;
        }
    }
}