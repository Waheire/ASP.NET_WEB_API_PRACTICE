namespace WebApiPractice.Entities
{
    public class Todo
    {
        //list properties
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public  DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);
    }
}
