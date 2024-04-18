using System.ComponentModel.DataAnnotations;

namespace Rebecca.BeWell.BlazorApp.Shared.Data.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }

        public virtual ActivityType ActivityType { get; set; }

        public int Mins { get; set; }

        public virtual Intensity Intensity { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
