using System;
using System.Text;

namespace GenLib.BitByte
{
    public class Encoder
    {
        public string BytesToString(byte[] bytes, Int32 startIx, Int32 count)
        {
            var subBytes = new byte[count];
            Array.Copy(bytes, startIx, subBytes, 0, count);
            return Encoding.GetEncoding(1252).GetString(subBytes);
        }

        public string BytesToString(byte[] bytes)
        {
            return BytesToString(bytes, 0, bytes.Length);
        }

        public byte[] StringToBytes(string @string)
        {
            return Encoding.GetEncoding(1252).GetBytes(@string);
        }

        public string ConvertToHex(string msg, bool appendChar)
        {
            var sb = new StringBuilder();
            foreach (var c in msg)
            {
                var i = Asc(c.ToString());
                sb.Append("x");
                sb.Append(Hex(i));
                if (appendChar)
                {
                    if (i > 31 && i < 127)
                    {
                        sb.Append("(");
                        sb.Append(c);
                        sb.Append(")");
                    }
                }
                sb.Append(" ");
            }
            return sb.ToString();
        }

        public String Hex(int i)
        {
            return i.ToString("X");
        }

        public string Chr(int i)
        {
            return ((char) i).ToString();
        }

        public int Asc(string @string)
        {
            return Convert.ToChar(@string);
        }
    }
}