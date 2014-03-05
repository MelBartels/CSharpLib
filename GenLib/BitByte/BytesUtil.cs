using System;
using System.Collections.Generic;
using System.Linq;
using GenLib.Helper;

namespace GenLib.BitByte
{
    public class BytesUtil
    {
        public byte Checksum(byte[] bytes, int startIx, int length)
        {
            var checksum = 0;
            for (var ix = 0; ix < length; ix++)
                checksum += bytes[ix + startIx];
            return (byte) (checksum%256);
        }

        public int IndexOf(byte[] bytes, byte value)
        {
            for (var ix = 0; ix < bytes.Length; ix++)
                if (value == bytes[ix])
                    return ix;
            return -1;
        }

        public byte SetBit(byte b, byte bit, bool isOn)
        {
            var removedBit = b & ~bit;
            return isOn ? (byte) (removedBit + bit) : (byte) removedBit;
        }

        public bool HasBit(byte b, List<byte> bits)
        {
            return bits.Any(bs => (b & bs) == bs);
        }

        public byte LowerNibble(byte b)
        {
            return (byte) (b & 0xF);
        }

        public byte[] ParseString(string s)
        {
            var st = new StringTokenizer();
            st.Tokenize(s);

            var bytes = new byte[st.Count];
            var ix = 0;
            var error = false;
            st.Tokens.ForEach(token =>
                                  {
                                      try
                                      {
                                          bytes[ix++] = Convert.ToByte(token, 16);
                                      }
                                      catch (Exception)
                                      {
                                          error = true;
                                      }
                                  });
            return error ? null : bytes;
        }
    }
}