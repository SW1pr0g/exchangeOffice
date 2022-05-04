using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_exchangeOffice.classes
{
    //класс для конвертации типа даты до того
    //который принимает наша БД
    public class reversedate
    {
        //длинный формат
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
            charArr[5] = charArr1[3];
            charArr[6] = charArr1[4];
            charArr[7] = '-';
            charArr[8] = charArr1[0];
            charArr[9] = charArr1[1];
            s = new string(charArr);
            return new string(charArr);
        }

        //короткий формат
        public string dateReverse(string s)
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
            charArr[5] = charArr1[3];
            charArr[6] = charArr1[4];
            charArr[7] = '-';
            charArr[8] = charArr1[0];
            charArr[9] = charArr1[1];
            s = new string(charArr);
            s = s.Substring(0, 10);
            return s;
        }
    }
}
