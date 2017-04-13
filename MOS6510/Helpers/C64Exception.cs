using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MOS6510.Helpers
{
    class C64Exception : ApplicationException
    {
        public C64Exception()
        {
        }

        public C64Exception(string message)
            : base(message)
        {
        }
    }
}
