namespace Task5.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public DateTime JoiningDate { get; set; }


        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
