using System.Collections.Generic;

namespace AstroLib.ObjectLibrary
{
    public class ObjectType
    {
        public Dictionary<string, string> Lookup =
            new Dictionary<string, string>
                {
                    {"ASTER", "Asterism"},
                    {"BRTNB", "Bright Nebula"},
                    {"CL+NB", "Cluster with Nebulosity"},
                    {"DRKNB", "Dark Nebula"},
                    {"GALCL", "Galaxy cluster"},
                    {"GALXY", "Galaxy"},
                    {"GLOCL", "Globular Cluster"},
                    {"GX+DN", "Diffuse Nebula in a Galaxy"},
                    {"GX+GC", "Globular Cluster in a Galaxy"},
                    {"G+C+N", "Cluster with Nebulosity in a Galaxy"},
                    {"LMCCN", "Cluster with Nebulosity in the LMC"},
                    {"LMCDN", "Diffuse Nebula in the LMC"},
                    {"LMCGC", "Globular Cluster in the LMC"},
                    {"LMCOC", "Open cluster in the LMC"},
                    {"NONEX", "Nonexistent"},
                    {"OPNCL", "Open Cluster"},
                    {"PLNNB", "Planetary Nebula"},
                    {"SMCCN", "Cluster with Nebulosity in the SMC"},
                    {"SMCDN", "Diffuse Nebula in the SMC"},
                    {"SMCGC", "Globular Cluster in the SMC"},
                    {"SMCOC", "Open cluster in the SMC"},
                    {"SNREM", "Supernova Remnant"},
                    {"QUASR", "Quasar"},
                };

        public string GetFrom(string value)
        {
            string returnValue;
            if (value.IndexOf("STAR") > -1)
                returnValue = "# Stars (#=1, 2, 3, 4, 5, etc.)";
            else
                Lookup.TryGetValue(value, out returnValue);
            return returnValue;
        }
    }
}