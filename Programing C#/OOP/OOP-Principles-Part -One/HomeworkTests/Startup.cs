namespace HomeworkTests
{
    using AnimalHeirarchy;
    using SchoolClasses;
    using StudentsAndWorkers;

    public class Startup
    {
        public static void Main()
        {
            SchoolClassesTests.Run();
            StudentsAndWorkersTest.Run();
            AnimalHeirarchyTest.Run();
        }
    }
}
