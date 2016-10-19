using GreetingHelloDI.Models;
using System.Threading;

using GreetingHelloDI.Contracts;
using System.Security.Principal;

namespace GreetingHelloDI
{
    class Program
    {
        static void Main()
        {
            // IMessageWriter messageWriter = new ConsoleWriter();
            //  var typeName =  ConfigurationManager.AppSettings["messageWriter"];
            //  var type = Type.GetType(typeName, true);
            //  IMessageWriter writer = (IMessageWriter)Activator.CreateInstance(type);

            Thread.CurrentPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            IMessageWriter messageWriter = new SecureConsoleWriter(new ConsoleWriter());
            
            var solutatian = new Salutation(messageWriter);
            solutatian.Greet();
        }
    }
}
