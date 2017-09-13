using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

/***************************************************
 * Creator: Morris @ PC-HAMILTON
 * Create Date: 2017/9/13-星期三 20:57:02
 * ID: 3af38a9f-93c2-4d65-832c-58a5a2063191
 ***************************************************/
namespace Morris.YankeePark.TinyTools
{
    public class FisherYatesShuffle
    {
        static Random rand = new Random();
        public static Array genShuffleArray(int count)
        {
            ArrayList result = new ArrayList();
            int i,tmp,r;
            for (i = 0; i < count;i++ )
            {
                result.Add(i);
            }
            for (i = 0; i < count; i++)
            {
                r=rand.Next()%(count-i)+i;
                tmp = (int)result[i];
                result[i] = result[r];
                result[r] = tmp;
            }
            return result.ToArray();
        }
    }
}

