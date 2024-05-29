namespace Rebecca.BeWell.BlazorApp.Shared.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }


        //public string Category { get; set; }
        public string Text { get; set; }
        public List<string> Types { get; set; }

        public string SelectedType { get; set; }

        public List<string> ActivityTypes { get; set; }

        public string SelectedActivityType { get; set; }

        public List<string> NutritionTypes { get; set; }

        public string SelectedNutritionType { get; set; }

        public List<string> SleepTypes { get; set; }

        public string SelectedSleepType { get; set; }

        public List<string> IntensityTypes { get; set; }

        public string SelectedIntensityType { get; set; }

        public int Calories { get; set; }

        public int SleepHours { get; set; }
    }
}
