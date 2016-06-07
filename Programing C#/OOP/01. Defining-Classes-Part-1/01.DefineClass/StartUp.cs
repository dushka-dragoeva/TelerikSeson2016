using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDevice

{
    class StartUp
    {
        static void Main()
        {
            var battery = new Battery(BatteryType.LiIon);
            Console.WriteLine(battery.ToString());
            var display = new Display();
            display.Size = 7.3;
            Console.WriteLine(display.ToString());

        }
    }
}
