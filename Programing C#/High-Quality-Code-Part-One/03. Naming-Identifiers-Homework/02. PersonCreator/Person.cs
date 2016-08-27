namespace PersonCreator
{
    internal class Person
    {
        public Person(int age)
        {
            this.Age = age;

            if (age % 2 == 0)
            {
                this.Name = NameType.Ron;
                this.Gender = GenderType.Male;
            }
            else
            {
                this.Name = NameType.Daisy;
                this.Gender = GenderType.Female;
            }
        }

        public GenderType Gender { get; set; }

        public NameType Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"  {nameof(this.Name)}: {this.Name}, {nameof(this.Age)}: {this.Age}, {nameof(this.Gender)}: {this.Gender}.";
        }
    }
}
