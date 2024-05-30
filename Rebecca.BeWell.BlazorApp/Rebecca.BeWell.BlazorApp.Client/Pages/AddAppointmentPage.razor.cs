using Microsoft.AspNetCore.Components;
using Radzen.Blazor.Rendering;
using Radzen;
using Rebecca.BeWell.BlazorApp.Shared.Data.Models;
using System.Net.Http.Json;
using System.Diagnostics;
using Activity = Rebecca.BeWell.BlazorApp.Shared.Data.Models.Activity;

namespace Rebecca.BeWell.BlazorApp.Client.Pages
{

    public partial class AddAppointmentPage : ComponentBase
    {

        [Parameter]
        public DateTime Start { get; set; }

        [Parameter]
        public DateTime End { get; set; }


        public Shared.Models.Appointment model = new Rebecca.BeWell.BlazorApp.Shared.Models.Appointment();

        [Inject]
        public DialogService DialogService { get; set; }

        [Inject]
        public HttpClient Http { get; set; }

        protected override async Task OnInitializedAsync()
        {
            model.Start = Start.AddHours(DateTime.Now.Hour);
            model.Start = model.Start.AddHours(1);
            model.End =model.Start.AddHours(1);

            model.Types = new List<string>
            { "Activity", "Nutrition", "Sleep"  };


            List<ActivityType>? activityTypes = await Http.GetFromJsonAsync<List<ActivityType>?>("api/Activities/GetActivityTypes");
            model.ActivityTypes = activityTypes.Select(i => i.Name).ToList();


            List<Intensity>? intensityTypes = await Http.GetFromJsonAsync<List<Intensity>?>("api/Intensities/GetIntensities");
            model.IntensityTypes = intensityTypes.Select(i => i.Name).ToList();

            List<NutritionType>? nutritionTypes = await Http.GetFromJsonAsync<List<NutritionType>?>("api/Nutritions/GetNutritionTypes");
            model.NutritionTypes = nutritionTypes.Select(i => i.Name).ToList();

            //{ "Activity", "Nutrition", "Sleep"  };


        }

        protected override void OnParametersSet()
        {
            //model.Start = DateTime.Now;
           
        }

        private async void OnSubmit(Rebecca.BeWell.BlazorApp.Shared.Models.Appointment model)
        {
            DialogService.Close(model);

            if (model.SelectedType == "Activity")
            {
                Activity activity = new Activity();
                activity.TimeStamp = DateTime.Now;
                activity.ActivityType = new ActivityType()
                {
                    Name = model.SelectedActivityType
                };
                TimeSpan timeDifference = model.End - model.Start;
                activity.Mins = (int)Math.Round(timeDifference.TotalMinutes);

                activity.Intensity = await Http.GetFromJsonAsync<Intensity>($"api/Intensities/GetIntensityByName/{model.SelectedIntensityType}");
             
                activity.Start = model.Start;
                activity.End = model.End;

                await Http.PostAsJsonAsync<Activity>("api/Activities/Create", activity);

                return;
            }

            if (model.SelectedType == "Nutrition")
            {
                Nutrition nutrition = new Nutrition();
                nutrition.Description = model.Text;
                nutrition.Start = model.Start;
                nutrition.TimeStamp = DateTime.Now;
                nutrition.Calories = model.Calories;
                nutrition.NutritionType = new NutritionType()
                {
                    Name = model.SelectedNutritionType
                };

                await Http.PostAsJsonAsync<Nutrition>("api/Nutritions/create", nutrition);

                return;
            }

            if (model.SelectedType == "Sleep")
            {
                Sleep sleep = new Sleep();
                sleep.TimeStamp = DateTime.Now;
                sleep.Description = model.Text;
                TimeSpan timeDifference = model.End - model.Start;
                sleep.Mins = (int)(model.SleepHours * 60); //(int)Math.Round(timeDifference.TotalMinutes);
                sleep.Start = model.Start;
                sleep.End  = new DateTime(model.Start.Year, model.Start.Month, model.Start.Day, 23, 59, 59);

                await Http.PostAsJsonAsync<Sleep>("api/Sleeps/Create", sleep);

                return;
            }
        }

        void OnTypeChange(object value)
        {
            //var str = value is IEnumerable<object> ? string.Join(", ", (IEnumerable<object>)value) : value;

            model.SelectedType = (string)value;
        }

        void OnActivityTypeChange(object value)
        {
            //var str = value is IEnumerable<object> ? string.Join(", ", (IEnumerable<object>)value) : value;

            model.SelectedActivityType = (string)value;
        }

        void OnNutritionTypeChange(object value)
        {
            //var str = value is IEnumerable<object> ? string.Join(", ", (IEnumerable<object>)value) : value;

            model.SelectedNutritionType = (string)value;
        }

        void OnSleepTypeChange(object value)
        {
            //var str = value is IEnumerable<object> ? string.Join(", ", (IEnumerable<object>)value) : value;

            model.SelectedSleepType = (string)value;
        }

        void OnIntensityTypeChange(object value)
        {
            //var str = value is IEnumerable<object> ? string.Join(", ", (IEnumerable<object>)value) : value;

            model.SelectedIntensityType = (string)value;
        }
    }
}