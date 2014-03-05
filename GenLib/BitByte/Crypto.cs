using System.IO;
using System.Security.Cryptography;
using System.Text;
using GenLib.Helper;

namespace GenLib.BitByte
{
    public class Crypto
    {
        private const string Delimiter = " ";
        private readonly byte[] _iv = {9, 9, 1, 4, 3, 0, 9, 7};
        private readonly byte[] _key = {2, 5, 4, 0, 6, 7, 4, 7, 6, 7, 9, 0, 8, 6, 5, 4, 1, 9, 1, 4, 1, 7, 4, 1};

        public string EncryptStringToString(string data)
        {
            if (string.IsNullOrEmpty(data))
                return string.Empty;

            var encryptedBytes = EncryptStringToBytes(data, _key, _iv);

            var sb = new StringBuilder();
            for (var ix = 0; ix <= encryptedBytes.Length - 1; ix++)
            {
                sb.Append(encryptedBytes[ix] + Delimiter);
            }
            return sb.ToString().Trim();
        }

        public string DecryptStringFromString(string data)
        {
            if (string.IsNullOrEmpty(data))
                return string.Empty;

            var st = new StringTokenizer();
            st.Tokenize(data, Delimiter.ToCharArray());
            var encryptedBytes = new byte[st.Tokens.Count];
            var i = 0;
            st.Tokens.ForEach(t =>
                                  {
                                      byte b;
                                      if (byte.TryParse(t, out b))
                                          encryptedBytes[i] = b;
                                      i++;
                                  });

            var decryptedString = DecryptStringFromBytes(encryptedBytes, _key, _iv);

            return string.IsNullOrEmpty(decryptedString) ? string.Empty : decryptedString.Replace("\0", "");
        }

        public byte[] EncryptStringToBytes(string data, byte[] key, byte[] iv)
        {
            try
            {
                var memoryStream = new MemoryStream();
                var tripleDes = TripleDES.Create();
                var cryptoStream = new CryptoStream(memoryStream, tripleDes.CreateEncryptor(key, iv), CryptoStreamMode.Write);
                var dataAsBytes = new ASCIIEncoding().GetBytes(data);

                cryptoStream.Write(dataAsBytes, 0, dataAsBytes.Length);
                cryptoStream.FlushFinalBlock();

                var encryptedBytes = memoryStream.ToArray();

                cryptoStream.Close();
                memoryStream.Close();

                return encryptedBytes;
            }
            catch (CryptographicException)
            {
                return null;
            }
        }

        public string DecryptStringFromBytes(byte[] data, byte[] key, byte[] iv)
        {
            try
            {
                var memoryStream = new MemoryStream(data);
                var tripleDes = TripleDES.Create();
                var cryptoStream = new CryptoStream(memoryStream, tripleDes.CreateDecryptor(key, iv), CryptoStreamMode.Read);
                var decryptedBytes = new byte[data.Length];
                cryptoStream.Read(decryptedBytes, 0, decryptedBytes.Length);
                return new ASCIIEncoding().GetString(decryptedBytes);
            }
            catch (CryptographicException)
            {
                return null;
            }
        }
    }
}