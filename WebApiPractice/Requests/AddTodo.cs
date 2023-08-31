using System.ComponentModel.DataAnnotations;

namespace WebApiPractice.Requests
{
    public class AddTodo
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
