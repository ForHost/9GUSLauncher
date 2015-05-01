using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9GUSLauncher.Core
{
    public class Pause
    {
        public static void pause(int seconds)
        {
            DateTime Tthen = DateTime.Now;
            do
            {
                System.Windows.Forms.Application.DoEvents();
            }

            while (Tthen.AddSeconds(Convert.ToDouble(seconds)) > DateTime.Now);
        }
    }
}
