namespace BlogPostAngularApi.Server.Model
{
    public class Employee
    {
         public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Active { get; set; }
        public Department Department { get; set; }
    }
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }
}
