using System.Collections.Generic;

namespace _05.DataBindingHomework.Models.Cars
{
    public class Producer
    {
        public Producer(string name)
        {
            this.Name = name;
            this.Models = new List<string>();
        }

        public string Name { get; private set; }
        public List<string> Models { get; set; }
    }
}