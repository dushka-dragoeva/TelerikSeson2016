using System;

namespace Composite.Models
{
    public abstract class FileSystemEntity
    {
        protected FileSystemEntity(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public abstract void Print(int padding);
    }
}
