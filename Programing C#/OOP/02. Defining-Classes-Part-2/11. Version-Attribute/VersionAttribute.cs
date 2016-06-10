namespace _11.Version_Attribute
{
    using System;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct |
            AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method)]
    public class VersionAttribute : Attribute
    {
        public VersionAttribute(Type component, string name, string version)
        {
            this.Component = component;
            this.Name = name;
            this.Version = version;
        }

        public enum Type
        {
            Class,
            Struct,
            Iterface,
            Enum,
            Method
        }

        public string Version { get; set; }

        public Type Component { get; set; }

        public string Name { get; set; }
    }
}
