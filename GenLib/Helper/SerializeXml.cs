using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using GenLib.Extensions;

namespace GenLib.Helper
{
    public class SerializeXml
    {
        public void SerializeXmlToFile<T>(Object obj, string filename)
        {
            File.WriteAllText(Serialize<T>(obj), filename);
        }

        public T DeserializeXmlFromFile<T>(string filename)
        {
            return Deserialize<T>(File.ReadAllText(filename));
        }

        public string Serialize<T>(Object obj)
        {
            return new StringWriterWithEncoding(Encoding.UTF8)
                .Do(w => new XmlSerializer(typeof (T)).Serialize(w, obj))
                .With(w => w.ToString());
        }

        public T Deserialize<T>(string str)
        {
            return (T) new XmlSerializer(typeof (T)).Deserialize(new StringReader(str));
        }

        #region Nested type: StringWriterWithEncoding

        private class StringWriterWithEncoding : StringWriter
        {
            Encoding ThisEncoding { get; set; }

            // .Net strings use UTF16, but XML written in UTF8, resulting in mismatch;
            // using MemoryStream w/ Encoding.UTF8.GetString() converting bytes to string results in non-printable chars
            // solution: subclass StringWriter to set encoding;
            public StringWriterWithEncoding(Encoding encoding)
            {
                ThisEncoding = encoding;
            }

            // returns locally stored encoding for use in StringWriter methods
            public override Encoding Encoding
            {
                get { return ThisEncoding; }
            }
        }

        #endregion
    }
}