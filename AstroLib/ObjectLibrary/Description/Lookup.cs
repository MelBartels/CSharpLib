using System.Collections.Generic;
using System.Linq;
using System.Text;
using AstroLib.Properties;
using GenLib.Extensions;

namespace AstroLib.ObjectLibrary.Description
{
    // from Sacdoc.txt and http://obs.nineplanets.org/ngc.html and inspecting descriptions in Saguaro catalog

    public class Lookup
    {
        private const string Space = " ";
        private const string Comma = ",";
        private const string Separator = ", ";
        private const string MainDelimiters = ",;";
        private const string Stars = "*";

        public Lookup(Loader<Record> loader)
        {
            Dictionary = new Dictionary<string, string>();
            loader.Load(Settings.Default.DescriptionLookupFilename).ForEach(l => Dictionary.Add(l.Key, l.Value));
        }

        public Lookup() : this(new Loader<Record>())
        {
        }

        public Dictionary<string, string> Dictionary { get; set; }

        public string GetFrom(string value)
        {
            var sb = new StringBuilder();
            value.Split(MainDelimiters.ToCharArray()).ForEach(v => ProcessSemicolonDelimitedCodes(v, sb));
            return sb.ToString().TrimEnd(Separator.ToCharArray());
        }

        private void ProcessSemicolonDelimitedCodes(string semiColonDelimitedValue, StringBuilder mainSb)
        {
            semiColonDelimitedValue = semiColonDelimitedValue.Trim();
            var semiColonDelimitedValueFixed = PreFixSemiColonDelimitedValue(semiColonDelimitedValue);
            var semiColonDelimitedSB = new StringBuilder();
            semiColonDelimitedValueFixed.Split(Space.ToCharArray())
                .ForEach(s => ProcessSpaceDelimitedCodes(s, semiColonDelimitedSB));
            mainSb.Append(semiColonDelimitedSB.ToString().TrimEnd((Comma + Space).ToCharArray()) + Separator);
        }

        private void ProcessSpaceDelimitedCodes(string spaceDelimitedValue, StringBuilder semiColonDelimitedSB)
        {
            spaceDelimitedValue = spaceDelimitedValue.Trim();
            if (spaceDelimitedValue.Length <= 0) return;

            var spaceDelimitedSB = new StringBuilder();
            var subSpaceDelimitedValue = spaceDelimitedValue;
            var parsing = true;
            while (parsing)
            {
                var subSpaceDelimitedValue1 = subSpaceDelimitedValue;
                if (subSpaceDelimitedValue1.Length > 0)
                    subSpaceDelimitedValue = ProcessLookupValue(subSpaceDelimitedValue, subSpaceDelimitedValue1,
                                                                spaceDelimitedSB);
                else
                    parsing = false;
            }
            semiColonDelimitedSB.Append(subSpaceDelimitedValue.Length == 0
                                            ? spaceDelimitedSB.ToString()
                                            : spaceDelimitedValue);

            PostFixSemiColonDelimitedSB(semiColonDelimitedSB);
        }

        private string ProcessLookupValue(string valueToLookup, string spaceLimitedValue, StringBuilder spaceDelimitedSB)
        {
            var result = Dictionary
                .Where(c => spaceLimitedValue.Trim().StartsWith(c.Key))
                // best fit is longest fitting key
                .OrderByDescending(c => c.Key.Length)
                .FirstOrDefault();

            if (string.IsNullOrEmpty(result.Value))
            {
                spaceDelimitedSB.Append(valueToLookup + Space);
                valueToLookup = valueToLookup.Substring(valueToLookup.Length).Trim();
            }
            else
            {
                valueToLookup = CheckManualFixups(result, spaceDelimitedSB, valueToLookup);
            }

            return valueToLookup;
        }

        private static string PreFixSemiColonDelimitedValue(string semiColonDelimitedValue)
        {
            int num;

            // fixup '* 9' to be '*9' for star magnitude decoding by removing the space that would be a delimiter
            var ix = semiColonDelimitedValue.IndexOf(Stars);
            if (ix > -1
                && semiColonDelimitedValue.Length > ix + 1
                && semiColonDelimitedValue[ix + 1].ToString() == Space
                && int.TryParse(semiColonDelimitedValue[ix + 2].ToString(), out num))

                semiColonDelimitedValue = semiColonDelimitedValue.Replace(Stars + Space, Stars);

            // fixup '9x' to be '9 x', inserting space after each number, unless:
            //   '9m' which is magnitude or
            //   '7* 135X' which is magnification or
            //   '*12.3' which is star magnitude
            var ixs = new List<int>();
            for (var jIx = semiColonDelimitedValue.Length - 1; jIx > 0; jIx--)
            {
                if (semiColonDelimitedValue[jIx].ToString() != Space
                    && semiColonDelimitedValue[jIx].ToString().ToLower() != "m"
                    && semiColonDelimitedValue[jIx].ToString() != "X"
                    && semiColonDelimitedValue[jIx].ToString() != "."
                    && !int.TryParse(semiColonDelimitedValue[jIx].ToString(), out num)
                    && int.TryParse(semiColonDelimitedValue[jIx - 1].ToString(), out num))

                    ixs.Add(jIx);
            }
            ixs.ForEach(i => semiColonDelimitedValue = semiColonDelimitedValue.Insert(i, Space));

            return semiColonDelimitedValue;
        }

        private static void PostFixSemiColonDelimitedSB(StringBuilder semiColonDelimitedSB)
        {
            // magnitude magnitude can occur from '* 7 mag ' where '* 7' is translated into star of 7th magnitude and 
            // mag is also translated into magnitude
            semiColonDelimitedSB.Replace("magnitude magnitude", "magnitude");
            // '( x' should be '(x' and ditto for ')'
            semiColonDelimitedSB.Replace("( ", "(");
            semiColonDelimitedSB.Replace(" )", ")");
        }

        private static string CheckManualFixups(KeyValuePair<string, string> result, StringBuilder sb, string value)
        {
            int num;
            double dbl;

            // E50 translates to elongated in position angle 50 degrees
            if (result.Key == "E" && int.TryParse(value.Substring(result.Key.Length).Trim(), out num))
            {
                sb.Append("elongated in position angle " + num + " degrees ");
                value = string.Empty;
            }
                // *10 translates to star of 10th magnitude; also *12.3 translates to star of 12.3th magnitude
            else if (result.Key == Stars && double.TryParse(value.Substring(result.Key.Length).Trim(), out dbl))
            {
                sb.Append("star " + dbl + "th magnitude ");
                value = string.Empty;
            }
            else
            {
                // sometimes shorthand is '!  B' instead of '!;B'
                var insertComma = result.Key.IndexOf("!") > -1;
                sb.Append(result.Value + (insertComma ? Comma : string.Empty) + Space);
                value = value.Substring(result.Key.Length).Trim();
            }

            return value;
        }
    }
}