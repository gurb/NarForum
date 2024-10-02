using System.Text;

namespace GurbForumUser.Client.Extensions
{
    public static class GuidExtensions
    {
        public static string EncodeGuidToBase64Url(this Guid guid)
        {
            string base64 = Convert.ToBase64String(guid.ToByteArray());
            return base64.Replace("/", "_").Replace("+", "-").Replace("=", "");
        }

        public static Guid DecodeBase64UrlToGuid(this string base64Url)
        {
            string base64 = base64Url.Replace("_", "/").Replace("-", "+") + "==";
            byte[] bytes = Convert.FromBase64String(base64);
            return new Guid(bytes);
        }

        private const string Base32Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";

        public static string EncodeGuidToBase32Url(this Guid guid)
        {
            byte[] bytes = guid.ToByteArray();
            StringBuilder sb = new StringBuilder();
            int byteIndex = 0, bitIndex = 0;
            int currentByte = bytes[byteIndex];
            int digit = 0;

            while (byteIndex < bytes.Length)
            {
                int currentBit = (currentByte >> (7 - bitIndex)) & 1;
                digit = (digit << 1) | currentBit;

                if (++bitIndex == 5)
                {
                    sb.Append(Base32Chars[digit]);
                    bitIndex = 0;
                    digit = 0;
                }

                if (++byteIndex < bytes.Length)
                {
                    currentByte = bytes[byteIndex];
                }
            }

            if (bitIndex > 0)
            {
                digit <<= (5 - bitIndex);
                sb.Append(Base32Chars[digit]);
            }

            return sb.ToString();
        }

        public static Guid DecodeBase32UrlToGuid(this string base32)
        {
            byte[] bytes = new byte[16];
            int byteIndex = 0, bitIndex = 0;
            int currentByte = 0;

            foreach (char c in base32)
            {
                int digit = Base32Chars.IndexOf(c);

                for (int i = 4; i >= 0; i--)
                {
                    int currentBit = (digit >> i) & 1;
                    currentByte = (currentByte << 1) | currentBit;

                    if (++bitIndex == 8)
                    {
                        bytes[byteIndex++] = (byte)currentByte;
                        bitIndex = 0;
                        currentByte = 0;
                    }
                }
            }

            return new Guid(bytes);
        }
    }
}
