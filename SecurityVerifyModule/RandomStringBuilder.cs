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
    public class RandomStringBuilder
    {
        protected static readonly char[] basicChars = {
                                          'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r',
                                          's','t','u','v','w','x','y','z','A','B','C','D','E','F','G','H','I',
                                          'J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z',
                                          '0','1','2','3','4','5','6','7','8','9'
                                      };

        public static string GenerateRandomString(int length,char[] appendedChars=null)
        {
            char[] charList;
            if (appendedChars != null && appendedChars.Length > 0)
            {
                charList = basicChars.Clone() as char[];
            }
            else
            {
                charList = new char[basicChars.Length + appendedChars.Length];
                basicChars.CopyTo(charList, 0);
                appendedChars.CopyTo(charList, basicChars.Length);
            }
            return GennerateRandomStringWithSpecificChars(length, charList);
        }
        
        public static string GennerateRandomStringWithSpecificChars(int length, char[] charList)
        {
            return null;
        }


    }
}
