namespace DotNet_Orange_Task1.Models
{
	public class Employee
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime BirthDate { get; set; }
		public string PhoneNumber { get; set; }
		public string NationalID { get; set; }
		public string Nationality { get; set; }
		public string MaritalStatus { get; set; }
		public string PhotoPath { get; set; }
		public DateTime EntryDate { get; set; }
		public string Password { get; set; }
		public int DepartmentId { get; set; }
		public Department Dept { get; set; }
	}
}
