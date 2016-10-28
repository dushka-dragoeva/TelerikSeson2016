namespace Adapter
{
    public class Adapter : Target
    {
        private Adaptee adaptee = new Adaptee();

        public override void Request()
        {
            // Possibly do some other work
            //  and then call SpecificRequest
            this.adaptee.SpecificRequest();
        }
    }
}
