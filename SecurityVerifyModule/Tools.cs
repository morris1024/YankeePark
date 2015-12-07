using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

/***************************************************
 * Creator: Morris @ PC-HAMILTON
 * Create Date: 2015/12/7-星期一 13:30:06
 * ID: 38ede1ad-9d45-448d-bd4f-e6651d0d888f
 ***************************************************/
namespace SecurityVerifyModule
{
    /// <summary>
    /// 相关工具类
    /// </summary>
    public class Tools
    {
        /// <summary>
        /// 基本26字母与数字字符
        /// </summary>
        protected static readonly char[] basicChars = {
                                          'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r',
                                          's','t','u','v','w','x','y','z','A','B','C','D','E','F','G','H','I',
                                          'J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
                                          '0','1','2','3','4','5','6','7','8','9'
                                      };
        protected static Random rnd;

        static Tools()
        {
            rnd = new Random();
        }

        /// <summary>
        /// 生成随机由26个字母和数字及用户自定义字符组成的字符串
        /// </summary>
        /// <param name="length">生成字符串长度</param>
        /// <param name="appendedChars">附加自定义字符数组</param>
        /// <returns>结果字符串</returns>
        public static string GenerateRandomString(int length,char[] appendedChars=null)
        {
            char[] charList;
            if (appendedChars != null && appendedChars.Length > 0)
            {
                charList = new char[basicChars.Length + appendedChars.Length];
                basicChars.CopyTo(charList, 0);
                appendedChars.CopyTo(charList, basicChars.Length);
            }
            else
            {
                charList = basicChars.Clone() as char[];
            }
            return GennerateRandomStringWithSpecificChars(length, charList);
        }
        
        /// <summary>
        /// 随机字符串生成的核心方法
        /// </summary>
        /// <param name="length">字符串长度</param>
        /// <param name="charList">字符串组成字符列表</param>
        /// <returns>结果字符串</returns>
        public static string GennerateRandomStringWithSpecificChars(int length, char[] charList)
        {
            if (length > 0 && charList.Length > 0)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < length; i++)
                {
                    sb.Append(charList[rnd.Next(charList.Length)]);
                }
                return sb.ToString();
            }
            return null;
        }

        /// <summary>
        /// 获取字符串的MD5值字符串
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <param name="hashType">哈希方法</param>
        /// <returns></returns>
        public static string getHashString(string sourceString,HashType hashType=HashType.MD5)
        {
            switch (hashType)
            {
                case HashType.SHA256:
                    return getSHA256String(sourceString);
                case HashType.SHA512:
                    return getSHA512String(sourceString);
                case HashType.MD5:
                default: 
                return getMD5String(sourceString);
            }
        }

        /// <summary>
        /// 获取字符串的MD5值字符串
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <returns></returns>
        public static string getMD5String(string sourceString)
        {
            MD5 hashAlgorithm = new MD5CryptoServiceProvider();
            return getHashString(sourceString, hashAlgorithm);
        }

        /// <summary>
        /// 获取字符串的SHA256值字符串
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <returns></returns>
        public static string getSHA256String(string sourceString)
        {
            SHA256 hashAlgorithm = new SHA256CryptoServiceProvider();
            return getHashString(sourceString, hashAlgorithm);
        }
        /// <summary>
        /// 获取字符串的SHA512值字符串
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <returns></returns>
        public static string getSHA512String(string sourceString)
        {
            SHA512 hashAlgorithm = new SHA512CryptoServiceProvider();
            return getHashString(sourceString, hashAlgorithm);
        }

        /// <summary>
        /// 哈希字符串生成核心方法
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <param name="hashAlgorithm">哈希算法</param>
        /// <returns></returns>
        protected static string getHashString(string sourceString, HashAlgorithm hashAlgorithm)
        {
            byte[] resultTmp = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(sourceString));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < resultTmp.Length; i++)
            {
                sb.Append(resultTmp[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }

    public enum HashType
    {
        MD5,
        SHA256,
        SHA512
    }
}
