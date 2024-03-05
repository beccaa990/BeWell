using System.ComponentModel.DataAnnotations;

namespace Rebecca.BeWell.BlazorApp.Data.Models
{
    public class NutritionType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        
      
    }
}
