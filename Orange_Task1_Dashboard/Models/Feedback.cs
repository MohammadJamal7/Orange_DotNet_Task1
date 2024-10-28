namespace DotNet_Orange_Task1.Models
{
	public class Feedback
	{

		public int Id { get; set; }
		public string SenderName { get; set; }
		public string SenderEmail { get; set; }
		public string Message { get; set; }
		public DateTime SentDate { get; set; }
	}
}
