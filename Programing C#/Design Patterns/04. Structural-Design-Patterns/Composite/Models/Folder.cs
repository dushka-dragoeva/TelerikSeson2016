using System;
using System.Collections.Generic;

namespace Composite.Models
{
    public class Folder : FileSystemEntity
    {
        private readonly ICollection<FileSystemEntity> content;

        public Folder(string name) : base(name)
        {
            this.content = new List<FileSystemEntity>();
        }

        public void Add(FileSystemEntity entity)
        {
            this.content.Add(entity);
        }

        public void Remove(FileSystemEntity entity)
        {
            this.content.Remove(entity);
        }

        public override void Print(int padding)
        {
            Console.WriteLine(new string(' ', padding) + $"* {this.Name}");

            foreach (var entity in this.content)
            {
                entity.Print(padding + 3);
            }
        }
    }
}
