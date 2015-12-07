using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/***************************************************
 * Creator: Morris @ PC-HAMILTON
 * Create Date: 2015/12/7-星期一 11:25:37
 * ID: 887e094a-d7dd-4907-bb9f-f7ca090c1ee5
 ***************************************************/
namespace SecurityVerifyModule
{
    /// <summary>
    /// 随机字符串生成工具类
    /// </summary>
    public class RandomStringBuilder
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

        static RandomStringBuilder()
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


    }
}
