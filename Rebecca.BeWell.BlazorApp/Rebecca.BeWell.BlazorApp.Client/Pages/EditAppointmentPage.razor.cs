using Microsoft.AspNetCore.Components;
using Radzen;
using Rebecca.BeWell.BlazorApp.Shared.Data.Models;
using Rebecca.BeWell.BlazorApp.Shared.Models;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace Rebecca.BeWell.BlazorApp.Client.Pages
{
    public partial class EditAppointmentPage : ComponentBase
    {
        //[Parameter]
        //public DateTime Start { get; set; }

        //[Parameter]
        //public DateTime End { get; set; }
        [Parameter]
        public Appointment model { get; set; } = new Rebecca.BeWell.BlazorApp.Shared.Models.Appointment();

        [Inject]
        public HttpClient Http { get; set; }

        //protected override void OnParametersSet()
        //{
        //    model.Start = Start;
        //    model.End = End;
        //}


        protected override async Task OnInitializedAsync()
        {
            model.Types = new List<string>
            { "Activity", "Nutrition", "Sleep"  };


            List<ActivityType>? activityTypes = await Http.GetFromJsonAsync<List<ActivityType>?>("api/Activities/GetActivityTypes");
            model.ActivityTypes = activityTypes.Select(i => i.Name).ToList();


            List<Intensity>? intensityTypes = await Http.GetFromJsonAsync<List<Intensity>?>("api/Intensities/GetIntensities");
            model.IntensityTypes = intensityTypes.Select(i => i.Name).ToList();

            List<NutritionType>? nutritionTypes = await Http.GetFromJsonAsync<List<NutritionType>?>("api/Nutritions/GetNutritionTypes");
            model.NutritionTypes = nutritionTypes.Select(i => i.Name).ToList();



        }

        [Inject]
        DialogService DialogService { get; set; }
        private async void OnSubmit(Rebecca.BeWell.BlazorApp.Shared.Models.Appointment model)
        {
            DialogService.Close(model);

            if (model.SelectedType == "Activity")
            {
                Shared.Data.Models.Activity activity = new Activity();
                activity.Id = model.Id;
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

                await Http.PostAsJsonAsync<Activity>("api/Activities/Update", activity);

                return;
            }

            if (model.SelectedType == "Nutrition")
            {
                Nutrition nutrition = new Nutrition();
                nutrition.Id = model.Id;
                nutrition.Description = model.Text;
                nutrition.Start = model.Start;
                nutrition.TimeStamp = DateTime.Now;
                nutrition.Calories = model.Calories;
                nutrition.NutritionType = new NutritionType()
                {
                    Name = model.SelectedNutritionType
                };

                await Http.PostAsJsonAsync<Nutrition>("api/Nutritions/Update", nutrition);

                return;
            }

            if (model.SelectedType == "Sleep")
            {
                Sleep sleep = new Sleep();
                sleep.Id = model.Id;
                sleep.TimeStamp = DateTime.Now;
                sleep.Description = model.Text;
                TimeSpan timeDifference = model.End - model.Start;
                sleep.Mins = (int)Math.Round(timeDifference.TotalMinutes);


                await Http.PostAsJsonAsync<Sleep>("api/Sleeps/Update", sleep);


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

