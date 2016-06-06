using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var basilik = "shfgsjlghRFlsjfsfaA";
            var winerBasilik = basilik.ToCharArray().OrderBy(x => x).First();
            Console.WriteLine(winerBasilik);
        }
    }
}
