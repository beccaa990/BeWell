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

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
