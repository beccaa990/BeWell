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


        Shared.Models.Appointment model = new Rebecca.BeWell.BlazorApp.Shared.Models.Appointment();
        
        [Inject]
        DialogService DialogService { get; set; }
        
         [Inject]
         HttpClient Http  { get; set; }

        
        
        protected override async Task OnInitializedAsync()
        {
            model.Types= new List<string>
            { "Activity", "Nutrition", "Sleep"  };


            List<ActivityType>? activityTypes = await Http.GetFromJsonAsync<List<ActivityType>?>("api/Activities/GetActivityTypes");
            model.ActivityTypes = activityTypes.Select(i => i.Name).ToList();


            List<Intensity>? intensityTypes = await Http.GetFromJsonAsync<List<Intensity>?>("api/Intensities/GetIntensities");
            model.ActivityTypes = intensityTypes.Select(i => i.Name).ToList();



            model.NutritionTypes = new List<string>
            { "Activity", "Nutrition", "Sleep"  };
           

        }

        protected override void OnParametersSet()
        {
            model.Start = Start;
            model.End = End;
        }

        private async void OnSubmit(Rebecca.BeWell.BlazorApp.Shared.Models.Appointment model)
        {
           DialogService.Close(model);

            if (model.SelectedType== "Activity")
            {
                Activity activity = new Activity();
                activity.TimeStamp = DateTime.Now;
                activity.ActivityType = new ActivityType()
                {
                    Name = model.SelectedActivityType
                };
                TimeSpan timeDifference = model.End  - model.Start;
                activity.Mins= (int)Math.Round(timeDifference.TotalMinutes);

                activity.Intensity = new Intensity()
                {
                    Name = model.SelectedIntensityType
                };


               await Http.PostAsJsonAsync<Activity>("api/Activities/Create", activity);


                return;
            }
                   
            if(model.SelectedType == "Nutrition")
            {
                Nutrition nutrition = new Nutrition();
                nutrition.Name = model.Text;    
                nutrition.TimeStamp = DateTime.Now;
                nutrition.Calories = (int)Math.Round(model.TotalCalories) ;
                nutrition.NutritionType = new NutritionType()
                {
                    Name = model.SelectedNutritionType
                };
                nutrition.NutritionType = new NutritionType()
                {
                    Name = model.SelectedNutritionType
                };

                await Http.PostAsJsonAsync<Nutrition>("api/Nutritions/Create", nutrition);

                return;
            }

            if(model.SelectedType == "Sleep")
            {
                Sleep sleep = new Sleep();
                sleep.TimeStamp = DateTime.Now;
                sleep.Description = model.Text;
                TimeSpan timeDifference = model.End - model.Start;
                sleep.Mins = (int)Math.Round(timeDifference.TotalMinutes);


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

            model.SelectedActivityType = (string)value;
        }

        void OnSleepTypeChange(object value)
        {
            //var str = value is IEnumerable<object> ? string.Join(", ", (IEnumerable<object>)value) : value;

            model.SelectedActivityType = (string)value;
        }

        void OnIntensityTypeChange(object value)
        {
            //var str = value is IEnumerable<object> ? string.Join(", ", (IEnumerable<object>)value) : value;

            model.SelectedIntensityType = (string)value;
        }
    }
}
