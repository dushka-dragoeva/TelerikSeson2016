namespace AnimalHeirarchy.Models
{
    using Contracts;

    internal class Kitten : Cat, ISound
    {
        public Kitten(int age, string name, SexType sex)
            : base(age, name, SexType.Female)
        {
        }
    }
}