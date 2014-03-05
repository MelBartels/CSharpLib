using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Atlas.Extensions
{
    public static class StringExtension
    {
        // http://www.cumbrowski.com/CarstenC/articles/20070623_Title_Capitalization_in_the_English_Language.asp

        private static readonly List<string> SingleWordsNotCapitalized =
            new List<string>
                {
                    "a",
                    "aboard",
                    "about",
                    "above",
                    "absent",
                    "across",
                    "after",
                    "against",
                    "along",
                    "alongside",
                    "although",
                    "amid",
                    "amidst",
                    "among",
                    "amongst",
                    "an",
                    "and",
                    "around",
                    "as",
                    "aslant",
                    "astride",
                    "at",
                    "atop",
                    "barring",
                    "because",
                    "before",
                    "behind",
                    "below",
                    "beneath",
                    "beside",
                    "besides",
                    "between",
                    "beyond",
                    "both",
                    "but",
                    "by",
                    "despite",
                    "down",
                    "during",
                    "either",
                    "except",
                    "failing",
                    "following",
                    "for",
                    "from",
                    "in",
                    "inside",
                    "into",
                    "like",
                    "merry",
                    "mid",
                    "minus",
                    "near",
                    "neither",
                    "next",
                    "nor",
                    "notwithstanding",
                    "of",
                    "off",
                    "on",
                    "onto",
                    "or",
                    "opposite",
                    "outside",
                    "over",
                    "past",
                    "plus",
                    "regarding",
                    "round",
                    "save",
                    "since",
                    "so",
                    "than",
                    "the",
                    "through",
                    "throughout",
                    "till",
                    "times",
                    "to",
                    "toward",
                    "towards",
                    "under",
                    "underneath",
                    "unlike",
                    "until",
                    "up",
                    "upon",
                    "via",
                    "when",
                    "while",
                    "with",
                    "within",
                    "without",
                };

        private static readonly List<string> DoubleWordsNotCapitalized =
            new List<string>
                {
                    "but also",
                    "even if",
                    "not only",
                };

        public static string ToTitleCase(this string source)
        {
            var sbFixedWord = new StringBuilder();
            FixWords(source, sbFixedWord);

            var sbFixedDoubleWords = new StringBuilder();
            FixDoubleWords(sbFixedWord.ToString().Trim(), sbFixedDoubleWords);

            return CapitalizeFirstLetter(sbFixedDoubleWords.ToString().Trim());
        }

        private static void FixDoubleWords(string source, StringBuilder sb)
        {
            var words = source.Split(" ".ToCharArray());
            // array to protect int from modified closure in the functional extension below
            int[] ix = {0};
            while (ix[0] < words.Length - 1)
            {
                var doubleWord = words[ix[0]].ToLowerInvariant() + " " + words[ix[0] + 1].ToLowerInvariant();

                DoubleWordsNotCapitalized.IfAny(dw => dw == doubleWord,
                                                () =>
                                                    {
                                                        sb.Append(doubleWord);
                                                        ix[0] += 2;
                                                    },
                                                () =>
                                                    {
                                                        sb.Append(words[ix[0]]);
                                                        ix[0]++;
                                                    });
              
                sb.Append(" ");
            }
            if (ix[0] < words.Length)
                sb.Append(words[ix[0]]);
        }

        private static void FixWords(string source, StringBuilder sb)
        {
            var titleCase = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(source ?? string.Empty);
            var words = titleCase.Split(" ".ToCharArray());
            words.ToList().ForEach(word => FixAWord(word, sb));
        }

        private static string CapitalizeFirstLetter(string source)
        {
            if (string.IsNullOrEmpty(source)) return string.Empty;

            var chars = source.ToCharArray();
            chars[0] = char.ToUpper(chars[0]);
            return new string(chars);
        }

        private static void FixAWord(string source, StringBuilder sb)
        {
            sb.Append(SingleWordsNotCapitalized
                          .Find(wordNotCap => wordNotCap == source.ToLower())
                          .IsNullOrEmpty()
                          ? source
                          : source.ToLower());
            sb.Append(" ");
        }

        public static string ToSentenceCase(this string source)
        {
            return source.IsNullOrEmpty()
                       ? source
                       : CapitalizeFirstLetter(source.ToLowerInvariant());
        }

        public static bool IsNullOrEmpty(this string source)
        {
            return string.IsNullOrEmpty(source);
        }

        public static int IntParse(this string source, int defaultIfEmpty)
        {
            int i;
            return int.TryParse(source, out i) ? i : defaultIfEmpty;
        }

        public static long LongParse(this string source, long defaultIfEmpty)
        {
            long i;
            return long.TryParse(source, out i) ? i : defaultIfEmpty;
        }

        public static Stream ToStream(this string source)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(source);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}