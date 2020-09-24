using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MCserverManager.Util
{
    class Hash
    {
        // https://docs.microsoft.com/ja-jp/troubleshoot/dotnet/csharp/compute-hash-values
        public static byte[] CreateHash(string Raw) {
            byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(Raw);
            byte[] tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
            return tmpHash;
        }
        public static string CreateHashString(string Raw)
        {
            return ByteArrayToString(CreateHash(Raw));
        }

        public static Boolean compareHash(string Hash_origin, string Hash_new)
        {
            byte[] Hash_origin_byte = CreateHash(Hash_origin);
            byte[] Hash_new_byte = CreateHash(Hash_new);
            bool bEqual = false;
            if (Hash_origin_byte.Length == Hash_new_byte.Length)
            {
                int i = 0;
                while ((i < Hash_origin_byte.Length) && (Hash_origin_byte[i] == Hash_new_byte[i]))
                {
                    i += 1;
                }
                if (i == Hash_origin_byte.Length)
                {
                    bEqual = true;
                }
            }
            return bEqual;
        }

        private static string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }
    }
}
