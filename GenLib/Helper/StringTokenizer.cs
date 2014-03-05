using System;
using System.Collections.Generic;
using System.Linq;

namespace GenLib.Helper
{
    public class StringTokenizer
    {
        private readonly Dictionary<Type, Func<string, object>> _countTokensFuncMap;
        private readonly Dictionary<Type, Func<string, object>> _nextTokenFuncMap;

        public StringTokenizer()
        {
            _nextTokenFuncMap = new Dictionary<Type, Func<string, object>>
                                    {
                                        {typeof (string), s => s},
                                        {typeof (bool), s => TryBool(s)},
                                        {typeof (byte), s => TryByte(s)},
                                        {typeof (char), s => TryChar(s)},
                                        {typeof (DateTime), s => TryDateTime(s)},
                                        {typeof (double), s => TryDouble(s)},
                                        {typeof (int), s => TryInt(s)},
                                    };

            _countTokensFuncMap = new Dictionary<Type, Func<string, object>>
                                      {
                                          {typeof (string), s => s.Length > 0},
                                          {typeof (bool), s => TestBool(s)},
                                          {typeof (byte), s => TestByte(s)},
                                          {typeof (char), s => TestChar(s)},
                                          {typeof (DateTime), s => TestDateTime(s)},
                                          {typeof (double), s => TestDouble(s)},
                                          {typeof (int), s => TestInt(s)},
                                      };
        }

        public char[] Delimiters { get; set; }
        public string String { get; set; }
        public List<string> Tokens { get; set; }
        public int Count { get; set; }

        private int CurrentIx { get; set; }

        public bool Tokenize(string s)
        {
            return Tokenize(s, null);
        }

        public bool Tokenize(string s, char[] delimiters)
        {
            String = s;
            Delimiters = delimiters;
            CurrentIx = 0;
            Tokens = s.Split(Delimiters).ToList();
            Count = CountTokens<string>();
            return (Count > 0);
        }

        public string NextToken()
        {
            var ix = CurrentIx;
            var s = ScanForNextToken(ref ix);
            CurrentIx = ix;
            return s;
        }

        public string PeekNextToken()
        {
            var ix = CurrentIx;
            return ScanForNextToken(ref ix);
            // no currentIx increment 
        }

        public Object NextToken<T>()
        {
            while (true)
            {
                var s = NextToken();
                if (s == null) 
                    return null;

                Func<string, object> func;
                if (!_nextTokenFuncMap.TryGetValue(typeof (T), out func))
                    UnsupportedType<T>();

                var result = func(s);
                if (result != null)
                    return result;
            }
        }

        public int CountTokens<T>()
        {
            Func<string, object> func;
            if (!_countTokensFuncMap.TryGetValue(typeof (T), out func))
                UnsupportedType<T>();

            return Tokens.FindAll(s => (bool) func(s)).Count;
        }

        private static object TestBool(string s)
        {
            bool b;
            return bool.TryParse(s, out b);
        }

        private static object TestByte(string s)
        {
            byte b;
            return byte.TryParse(s, out b);
        }

        private static object TestChar(string s)
        {
            char c;
            return char.TryParse(s, out c);
        }

        private static object TestDateTime(string s)
        {
            DateTime dt;
            return DateTime.TryParse(s, out dt);
        }

        private static object TestDouble(string s)
        {
            double d;
            return double.TryParse(s, out d);
        }

        private static object TestInt(string s)
        {
            int i;
            return int.TryParse(s, out i);
        }

        private static object TryBool(string s)
        {
            bool b;
            return bool.TryParse(s, out b) ? (object) b : null;
        }

        private static object TryByte(string s)
        {
            byte b;
            return byte.TryParse(s, out b) ? (object) b : null;
        }

        private static object TryChar(string s)
        {
            char c;
            return char.TryParse(s, out c) ? (object) c : null;
        }

        private static object TryDateTime(string s)
        {
            DateTime dt;
            return DateTime.TryParse(s, out dt) ? (object) dt : null;
        }

        private object TryDouble(string s)
        {
            double d;
            return TryParseDouble(s, out d) ? (object) d : null;
        }

        private object TryInt(string s)
        {
            double d;
            if (!TryParseDouble(s, out d)) return null;

            int i;
            return int.TryParse(d.ToString(), out i) ? (object) i : null;
        }

        private static void UnsupportedType<T>()
        {
            throw new Exception("unsupported type " + typeof (T).FullName + " in NextToken<T>");
        }

        // returns a string (the next token) or null
        private string ScanForNextToken(ref int ix)
        {
            while (true)
            {
                if (ix >= Tokens.Count)
                    return null;
                var s = Tokens[ix++];
                if (!string.IsNullOrEmpty(s))
                    return s;
            }
        }

        // handle situation where space separates sign from number, eg, + 9 or - 9 
        // resulting in two tokens
        private bool TryParseDouble(string s, out double d)
        {
            if (s == Constants.General.Plus || s == Constants.General.Minus)
            {
                // don't consume next token unless it's a double
                var peek = PeekNextToken();
                if (double.TryParse(peek, out d))
                {
                    NextToken();
                    if (s == Constants.General.Minus)
                        d = -d;
                    return true;
                }
                return false;
            }
            // otherwise simply parse 
            return double.TryParse(s, out d);
        }
    }
}