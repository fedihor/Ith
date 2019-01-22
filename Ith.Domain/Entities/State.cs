using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ith.Domain.Entities
{
    [Table("States")]
    public class State
    {
        [Key]
        public byte Id { get; set; }
        [Display(Name = "Тип")]
        public string Title { get; set; }
    }
}
