using System.ComponentModel.DataAnnotations;

namespace Rebecca.BeWell.BlazorApp.Shared.Data.Models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        public string UserID { get; set; }

        public int Weight { get; set; }
        public int Height { get; set; }

        public virtual List<Activity>? Activities { get; set; }

        public virtual List<Nutrition> Nutritions { get; set; }

        public virtual List<Sleep> Sleeps { get; set; }

    }
}