using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GreetingHelloDI.Contracts;
using System.Threading;

namespace GreetingHelloDI.Models
{
    public class SecureConsoleWriter : IMessageWriter
    {
        private readonly IMessageWriter messageWriter;

        public SecureConsoleWriter(IMessageWriter messageWriter)
        {
            if (messageWriter == null)
            {
                throw new NullReferenceException(nameof(messageWriter));
            }
            this.messageWriter = messageWriter;
        }

        public void Write(string message)
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                this.messageWriter.Write(message);
            }
        }
    }
}
