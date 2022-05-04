using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_exchangeOffice.classes
{
    //класс для мгновенного вывода предварительной
    //суммы обмена
    public class summValues
    {
        public double summoutputValues(int oper, int saledC, double value, double[] valuesBuy, double[] valuesSell) 
        {
            double output = 0.0;
            if (oper == 0)
            {
                output = value * valuesBuy[saledC];
            }
            else if (oper == 1)
            {
                output = value * valuesSell[saledC];
            }
            return output;
        }       
    }
}
