using System;

using GreetingHelloDI.Contracts;

namespace GreetingHelloDI.Models
{
    public class Salutation
    {
        private IMessageWriter messageWriter;

        public Salutation(IMessageWriter messageWriter)
        {
            this.MessageWriter = messageWriter;
        }

        public IMessageWriter MessageWriter
        {
            get
            {
                return this.messageWriter;
            }

            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException(nameof(value));
                }

                this.messageWriter = value;
            }
        }

        public void Greet()
        {
            this.MessageWriter.Write("Hello DI");
        }
    }
}