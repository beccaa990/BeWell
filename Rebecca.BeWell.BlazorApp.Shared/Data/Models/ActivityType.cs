using System.ComponentModel.DataAnnotations;

namespace Rebecca.BeWell.BlazorApp.Shared.Data.Models
{
    public class ActivityType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

    }
}
