using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computers.Common.Contracts
{
    public interface IMotherboard
    {
        int LoadRamValue();

        void SaveRamValue(int value);

        void DrawOnVideoCard(string data);
    }
}
