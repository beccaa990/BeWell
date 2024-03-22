using System.ComponentModel.DataAnnotations;

namespace Rebecca.BeWell.BlazorApp.Shared.Data.Models
{
    public class Nutrition
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }
        public string Description { get; set; }
        public int Calories { get; set; }

        public DateTime TimeStamp { get; set; }

        public virtual NutritionType NutritionType { get; set; }


    }
}
