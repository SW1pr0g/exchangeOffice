using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_exchangeOffice.classes
{
    public class reversedate
    {
        public string datetimeReverse(string s) 
        {
            s = s.Replace('.', '-');
            char[] charArr = s.ToCharArray();
            char[] charArr1 = new char[charArr.Length];
            Array.Copy(charArr, charArr1, charArr.Length);
            charArr[0] = charArr1[6];
            charArr[1] = charArr1[7];
            charArr[2] = charArr1[8];
            charArr[3] = charArr1[9];
            charArr[4] = '-';
            charArr[5] = charArr1[0];
            charArr[6] = charArr1[1];
            charArr[7] = '-';
            charArr[8] = charArr1[3];
            charArr[9] = charArr1[4];
            return new string(charArr);
        }
        public string dateReverse(string s)
        {
            //date Reversing
            //s = s.Replace('.', '-');
            //char[] charArr = s.ToCharArray();
            //char[] charArr1 = new char[charArr.Length];
            //Array.Copy(charArr, charArr1, charArr.Length);
            //charArr[0] = charArr1[6];
            //charArr[1] = charArr1[7];
            //charArr[2] = charArr1[8];
            //charArr[3] = charArr1[9];
            //charArr[4] = '-';
            //charArr[5] = charArr1[0];
            //charArr[6] = charArr1[1];
            //charArr[7] = '-';
            //charArr[8] = charArr1[3];
            //charArr[9] = charArr1[4];
            return s;
        }
    }
}
