using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computers.Common.Models.Components
{
    public class Cpu128 : Cpu
    {
        public Cpu128(byte numberOfCores) 
            : base(numberOfCores)
        {
        }

        public override int GetMaxNumber()
        {
            return 2000;
        }
    }
}
