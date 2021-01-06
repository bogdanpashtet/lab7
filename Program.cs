using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/*Вариант 9.
 
    1. Сформировать два файла. В один из них поместить фамилии пяти ваших знакомых, а
в другой - номера их телефонов. Составить программу, которая по номеру телефона
вашего знакомого определяет его фамилию.
    2. Слова текста, расположенного в текстовом файле, вывести на экран в виде строки и
в виде столбика.
*/

namespace lab7
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}