namespace DataBindingHomework.Employees.Models
{
    public class EmployeeShortInfo
    {
        public EmployeeShortInfo(int id, string name)
        {
            this.Id = id;
            this.Fullname = name;
        }

        public int Id { get; set; }

        public string Fullname { get; set; }
    }
}
