using System.ComponentModel.DataAnnotations;

namespace Rebecca.BeWell.BlazorApp.Shared.Data.Models
{
    public class Sleep
    {
        [Key]
        public int Id { get; set; }

        public int Mins { get; set; }

        public DateTime TimeStamp { get; set; }

        public string? Description { get; set; }
    }

}
