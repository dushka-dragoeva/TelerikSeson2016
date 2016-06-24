namespace AnimalHeirarchy.Models
{
    using Contracts;

    internal class Tomcat : Cat, ISound
    {
        public Tomcat(int age, string name, SexType sex)
            : base(age, name, SexType.Male)
        {
        }
    }
}
