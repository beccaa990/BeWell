using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using Radzen;
using Radzen.Blazor.Rendering;
using Microsoft.AspNetCore.Authorization;
using static System.Net.WebRequestMethods;
using System.Net.Http.Json;

namespace Rebecca.BeWell.BlazorApp.Client.Pages
{
    //[Authorize]

    public partial class Calendar : ComponentBase

    {
        public RadzenScheduler<Shared.Models.Appointment> scheduler { get; set; }
        public Dictionary<DateTime, string> events { get; set; } = new Dictionary<DateTime, string>();

        [Inject]
        public DialogService DialogService { get; set; }

        [Inject]
        public System.Net.Http.HttpClient Http { get; set; }


        public List<Shared.Models.Appointment> appointments = new List<Shared.Models.Appointment>()
        {
            //new Shared.Models.Appointment { Start = DateTime.Today.AddDays(-2), End = DateTime.Today.AddDays(-2), Text = "Birthday" },
            //new Shared.Models.Appointment { Start = DateTime.Today.AddDays(-11), End = DateTime.Today.AddDays(-10), Text = "Day off" },
            //new Shared.Models.Appointment { Start = DateTime.Today.AddDays(-10), End = DateTime.Today.AddDays(-8), Text = "Work from home" },
            //new Shared.Models.Appointment { Start = DateTime.Today.AddHours(10), End = DateTime.Today.AddHours(12), Text = "Online meeting" },
            //new Shared.Models.Appointment { Start = DateTime.Today.AddHours(10), End = DateTime.Today.AddHours(13), Text = "Skype call" },
            //new Shared.Models.Appointment { Start = DateTime.Today.AddHours(14), End = DateTime.Today.AddHours(14).AddMinutes(30), Text = "Dentist appointment" },
            //new Shared.Models.Appointment { Start = DateTime.Today.AddDays(1), End = DateTime.Today.AddDays(12), Text = "Vacation" },
        };

        protected override async Task OnInitializedAsync()
        {
            Rebecca.BeWell.BlazorApp.Shared.Data.Models.Profile profile = await Http.GetFromJsonAsync<Rebecca.BeWell.BlazorApp.Shared.Data.Models.Profile>("api/Profiles/user/current");



            List<Shared.Models.Appointment> appointmentsActivities = profile.Activities.Select(a => new Shared.Models.Appointment()
            {
                Id = a.Id,
                Text = a?.ActivityType?.Name,
                Start = a.Start,
                End = a.End,
                SelectedType = "Activity",
                SelectedActivityType = a.ActivityType.Name,
                SelectedIntensityType= a.Intensity.Name,              
            }).ToList();


            List<Shared.Models.Appointment> appointmentsNutritions = profile.Nutritions.Select(a => new Shared.Models.Appointment()
            {
                Id = a.Id,
                Text = a?.Description,
                Start = a.Start,
                End = a.Start.AddMinutes(10),
                SelectedType = "Nutrition",
                SelectedNutritionType = a.NutritionType.Name,
                Calories = a.Calories
            }).ToList();

            appointments.AddRange(appointmentsActivities);
            appointments.AddRange(appointmentsNutritions);

            await scheduler.Reload();
        }
        void OnSlotRender(SchedulerSlotRenderEventArgs args)
        {
            // Highlight today in month view
            if (args.View.Text == "Month" && args.Start.Date == DateTime.Today)
            {
                args.Attributes["style"] = "background: rgba(255,220,40,.2);";
            }

            // Highlight working hours (9-18)
            if ((args.View.Text == "Week" || args.View.Text == "Day") && args.Start.Hour > 8 && args.Start.Hour < 19)
            {
                args.Attributes["style"] = "background: rgba(255,220,40,.2);";
            }
        }

        async Task OnSlotSelect(SchedulerSlotSelectEventArgs args)
        {

            if (args.View.Text != "Year")
            {
                Shared.Models.Appointment data = await DialogService.OpenAsync<AddAppointmentPage>("Add Appointment",
                    new Dictionary<string, object> { { "Start", args.Start }, { "End", args.End } });

                if (data != null)
                {
                    appointments.Add(data);
                    // Either call the Reload method or reassign the Data property of the Scheduler
                    await scheduler.Reload();
                }
            }
        }

        async Task OnAppointmentSelect(SchedulerAppointmentSelectEventArgs<Shared.Models.Appointment> args)
        {

            var copy = new Rebecca.BeWell.BlazorApp.Shared.Models.Appointment
            {
                Id = args.Data.Id,
                //Category = args.Data.Category,
                Start = args.Data.Start,
                End = args.Data.End,
                Text = args.Data.Text,
                SelectedType = args.Data.SelectedType,
                SelectedSleepType = args.Data.SelectedActivityType,
                SelectedActivityType = args.Data.SelectedActivityType,
                SelectedIntensityType = args.Data.SelectedIntensityType,
                SelectedNutritionType = args.Data.SelectedNutritionType,
                Calories = args.Data.Calories,
            };

            var data = await DialogService.OpenAsync<EditAppointmentPage>("Edit Appointment", new Dictionary<string, object> { { "model", copy } });

            if (data != null)
            {
                // Update the appointment
                args.Data.Start = data.Start;
                args.Data.End = data.End;
                args.Data.Text = data.Text;
            }

            await scheduler.Reload();
        }

        void OnAppointmentRender(SchedulerAppointmentRenderEventArgs<Shared.Models.Appointment> args)
        {
            // Never call StateHasChanged in AppointmentRender - would lead to infinite loop

            if (args.Data.SelectedType == "Activity")
            {
                args.Attributes["style"] = "background: orange";
            }

            if (args.Data.SelectedType == "Nutrition")
            {
                args.Attributes["style"] = "background: green";
            }
            if (args.Data.SelectedType == "Sleep")
            {
                args.Attributes["style"] = "background: blue";
            }
        }

        async Task OnAppointmentMove(SchedulerAppointmentMouseEventArgs<Shared.Models.Appointment> args)
        {
            //var draggedAppointment = appointments.FirstOrDefault(x => x == args.Appointment.Data);

            //if (draggedAppointment != null)
            //{
            //    draggedAppointment.Start = draggedAppointment.Start + args.TimeSpan;

            //    draggedAppointment.End = draggedAppointment.End + args.TimeSpan;

            //    await scheduler.Reload();
            //}
        }
    }
}

