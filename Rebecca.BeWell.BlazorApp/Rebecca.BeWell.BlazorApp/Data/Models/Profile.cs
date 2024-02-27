using Microsoft.Extensions.Configuration.UserSecrets;
using System.ComponentModel.DataAnnotations;

namespace Rebecca.BeWell.BlazorApp.Data.Models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        public string UserID { get; set; }

        public int Weight { get; set; }
        public int Height { get; set; }

        public virtual List<Activity>? Activities { get; set; }



    }
}