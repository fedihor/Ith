using System.ComponentModel.DataAnnotations;

namespace Ith.Domain.Entities
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Тема")]
        public string Title { get; set; }
        public int SortOrder { get; set; }
    }
}