using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIS_exchangeOffice
{
    static class Program
    {        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //запуск приложения с формы аунтефикации(AuthForm)
            Application.Run(new AdminWindow());

        }
    }
}
