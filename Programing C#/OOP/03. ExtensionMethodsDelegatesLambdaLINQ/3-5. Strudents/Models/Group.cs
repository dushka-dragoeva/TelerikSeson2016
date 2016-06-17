namespace Students.Models
{
    public class Group
    {
        public Group()
        {
        }

        public Group(int groupNumber, string departmentName)
        {
            this.GroupNumber = groupNumber;
            this.DepartmentName = departmentName;
        }

        public int GroupNumber { get; set; }

        public string DepartmentName { get; set; }

        public override string ToString()
        {
            return $"{this.DepartmentName}, group {this.GroupNumber}";
        }

        /*•Create a class Group with properties GroupNumber and DepartmentName.
•Introduce a property GroupNumber in the Student class.
•Extract all students from "Mathematics" department.
•Use the Join operator
*/
    }
}
