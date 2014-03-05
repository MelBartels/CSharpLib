using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenLib.BitByte;

namespace AstroLib.ObjectLibrary.SAC
{
    public class Classification
    {
        private readonly Dictionary<string, Func<string, string>> _planetaryDetailFuncMap;

        public Dictionary<string, string> LookupOpenCluster =
            new Dictionary<string, string>
                {
                    {"ASTER", "Asterism"},
                    {"IV", "Not well detached from surrounding star field"},
                    {"III", "Detached, no concentration toward the center"},
                    {"II", "Detached, weak concentration toward the center"},
                    {"I", "Detached, strong concentration toward the center"},
                    {"1", "Small range"},
                    {"2", "Moderate range"},
                    {"3", "Large range"},
                    {"p", "Poor (<50 stars)"},
                    {"m", "Moderately rich (50-100 stars)"},
                    {"r", "Rich (>100 stars)"},
                    {"n", "nebulosity in cluster"},
                };

        public Dictionary<string, string> LookupOpenPlanetary =
            new Dictionary<string, string>
                {
                    {"1", "Stellar"},
                    {"2", "Smooth disk"},
                    {"3", "Irregular disk"},
                    {"4", "Ring structure"},
                    {"5", "Irregular form similar to diffuse nebula"},
                    {"6", "Anomalous form, no regular structure"},
                };

        public Dictionary<string, string> LookupOpenPlanetary2 =
            new Dictionary<string, string>
                {
                    {"a", "brighter center"},
                    {"b", "uniform brightness"},
                    {"c", "traces of ring structure"},
                };

        public Dictionary<string, string> LookupOpenPlanetary3 =
            new Dictionary<string, string>
                {
                    {"a", "very irregular brightness distribution"},
                    {"b", "traces of ring structure"},
                };

        public Dictionary<string, string> LookupGalaxy =
            new Dictionary<string, string>
                {
                    {"elliptical", "elliptical"},
                    {"compact", "compact"},
                    {"ring", "ring"},
                    {"bar", "with central bar"},
                    {"pec", "peculiar"},
                    {"ir", "irregular"},
                    {"sbo", "barred spiral lenticular"},
                    {"sb", "barred spiral"},
                    {"so", "lenticular"},
                    {"d", "irregular"},
                    {"e", "elliptical"},
                    {"m", "Magellanic"},
                    {"p", "peculiar"},
                    {"s", "spiral"},
                    {"*", "star"},
                    {"+", "plus"},
                    {"-", "-"},
                    {"/", "/"},
                    {"(", "("},
                    {")", ")"},
                    {" ", " "},
                    {"0", "very round"},
                    {"1", "almost round"},
                    {"2", "barely round"},
                    {"3", "semi round"},
                    {"4", "flat round"},
                    {"5", "semi flat"},
                    {"6", "almost flat"},
                    {"7", "very flat"},
                };

        public Dictionary<string, string> LookupElliptical =
            new Dictionary<string, string>
                {
                    {"c", "supergiant"},
                    {"d", "dwarf"},
                    {"D", "diffuse halo"},
                };

        public Dictionary<string, string> LookupSpiral =
            new Dictionary<string, string>
                {
                    {"a", "tightly wound arms"},
                    {"b", "moderately wound arms"},
                    {"c", "loosely wound arms"},
                };

        public Classification()
            : this(new RomanNumeralConverter())
        {
        }

        public Classification(RomanNumeralConverter romanNumeralConverter)
        {
            RomanNumeralConverter = romanNumeralConverter;

            _planetaryDetailFuncMap = new Dictionary<string, Func<string, string>>
                                          {
                                              {"2", s => PlanetaryLookup2(s)},
                                              {"3", s => PlanetaryLookup3(s)},
                                          };
        }

        private RomanNumeralConverter RomanNumeralConverter { get; set; }

        public string GetFrom(string type, string value)
        {
            var sb = new StringBuilder();

            if (type == "OPNCL" || type == "CL+NB")
            {
                var value1 = value;
                var found = true;
                while (found)
                {
                    var value2 = value1;
                    var value3 = value1;
                    var value4 = value1;
                    var kvp = LookupOpenCluster.ToList().Find(l => value2.IndexOf(l.Key) > -1);
                    if (string.IsNullOrEmpty(kvp.Key))
                    {
                        found = false;
                        sb.Append(value3);
                    }
                    else
                    {
                        value1 = value4.Replace(kvp.Key, "");
                        sb.Append(kvp.Value + "; ");
                    }
                }
            }
            if (type == "GLOCL")
            {
                sb.Append("concentration is ");
                sb.Append(RomanNumeralConverter.Convert(value));
                sb.Append(" (1 is most concentrated, 12 is least concentrated)");
            }
            if (type == "PLNNB")
            {
                // examples: "3b(2)", "2(2a)"
                for (var ix = 0; ix < value.Length; ix++)
                {
                    string result;
                    var c = value[ix].ToString();
                    if (LookupOpenPlanetary.TryGetValue(c, out result))
                        sb.Append(result);
                    else if ("abc".IndexOf(value[ix].ToString()) > -1
                             && ix > 0
                             && "23".IndexOf(value[ix - 1].ToString()) > -1)
                        sb.Append(_planetaryDetailFuncMap[value[ix - 1].ToString()](value[ix].ToString()));
                    else if (value[ix].ToString() == "(")
                        sb.Append(" (");
                    else
                        sb.Append(value[ix].ToString());
                }
            }
            if (type == "GALXY")
            {
                const string space = " ";
                const int unknown = 0;
                const int elliptical = 1;
                const int spiral = 2;
                var lastType = unknown;

                var value1 = value.ToLower();
                while (value1.Length > 0)
                {
                    var value2 = value1;
                    var kvp = LookupGalaxy.ToList().Find(g => value2.StartsWith(g.Key));
                    if (string.IsNullOrEmpty(kvp.Key))
                    {
                        var valueChar = value1[0];
                        string result;
                        if (lastType == elliptical && LookupElliptical.TryGetValue(valueChar.ToString(), out result)
                            || lastType == spiral && LookupSpiral.TryGetValue(valueChar.ToString(), out result))
                            sb.Append(space + result + space);
                        else
                            sb.Append(space + valueChar + space);
                        
                        value1 = value1.Substring(1);
                    }
                    else
                    {
                        sb.Append(space + kvp.Value + space);
                        value1 = value1.Substring(kvp.Key.Length);
                        var keyChar = kvp.Key[0].ToString().ToLower();
                        lastType = keyChar == "s" ? spiral : keyChar == "e" ? elliptical : lastType;
                    }
                }
            }

            // replace two spaces with one before replacing three spaces with one
            return sb.ToString()
                .Replace("  ", " ")
                .Replace("   ", " ")
                .Replace("( ", "(")
                .Replace(" )", ")")
                .Trim()
                .TrimEnd("; ".ToCharArray());
        }

        private string PlanetaryLookup2(string value)
        {
            string result;
            return LookupOpenPlanetary2.TryGetValue(value, out result) ? ": " + result : value;
        }

        private string PlanetaryLookup3(string value)
        {
            string result;
            return LookupOpenPlanetary3.TryGetValue(value, out result) ? ": " + result : value;
        }
    }
}