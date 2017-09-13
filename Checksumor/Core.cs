using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

/***************************************************
 * Creator: Morris @ PC-HAMILTON
 * Create Date: 2016/8/18-星期四 16:13:53
 * ID: b31af748-a912-49c8-bc58-fbcff00ab096
 ***************************************************/
namespace Checksumor
{
    public class Core
    {
        HashAlgorithm md5 = new MD5CryptoServiceProvider();
        HashAlgorithm sha1 = new SHA1CryptoServiceProvider();

        public string checksum(byte[] source,HashAlgorithm hashAlgorithm)
        {
            byte[] resultTmp = hashAlgorithm.ComputeHash(source);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < resultTmp.Length; i++)
            {
                sb.Append(resultTmp[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
