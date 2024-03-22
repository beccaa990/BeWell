namespace Rebecca.BeWell.BlazorApp.Client.Model
{
    public class Appointment
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public string Text { get; set; }
        public List<string> Types { get; set; }

        public string SelectedType { get; set; }

        public List<string> ActivityTypes { get; set; }

        public string SelectedActivityType { get; set; }

        public List<string> NutritionTypes { get; set; }

        public string SelectedNutritionType { get; set; }

        public List<string> SleepTypes { get; set; }

        public string SelectedSleepType { get; set; }
    }
}
