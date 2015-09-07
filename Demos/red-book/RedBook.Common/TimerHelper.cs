using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RedBook.Common
{
    public static class TimerHelper
    {

        [DllImport("kernel32")]
        public static extern uint GetTickCount();
    }
}
