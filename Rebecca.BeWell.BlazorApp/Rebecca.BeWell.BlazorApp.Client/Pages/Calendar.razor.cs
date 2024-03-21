using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using Radzen;
using Radzen.Blazor.Rendering;

namespace Rebecca.BeWell.BlazorApp.Client.Pages
{
    public partial class Calendar: ComponentBase

    {
        public RadzenScheduler<Rebecca.BeWell.BlazorApp.Client.Model.Appointment> scheduler { get; set; }
        public Dictionary<DateTime, string> events { get; set; } = new Dictionary<DateTime, string>();

        [Inject]
        DialogService DialogService { get; set; }

        IList<Rebecca.BeWell.BlazorApp.Client.Model.Appointment> appointments = new List<Rebecca.BeWell.BlazorApp.Client.Model.Appointment>
    {
        new Rebecca.BeWell.BlazorApp.Client.Model.Appointment { Start = DateTime.Today.AddDays(-2), End = DateTime.Today.AddDays(-2), Text = "Birthday" },
        new Rebecca.BeWell.BlazorApp.Client.Model.Appointment { Start = DateTime.Today.AddDays(-11), End = DateTime.Today.AddDays(-10), Text = "Day off" },
        new Rebecca.BeWell.BlazorApp.Client.Model.Appointment { Start = DateTime.Today.AddDays(-10), End = DateTime.Today.AddDays(-8), Text = "Work from home" },
        new Rebecca.BeWell.BlazorApp.Client.Model.Appointment { Start = DateTime.Today.AddHours(10), End = DateTime.Today.AddHours(12), Text = "Online meeting" },
        new Rebecca.BeWell.BlazorApp.Client.Model.Appointment { Start = DateTime.Today.AddHours(10), End = DateTime.Today.AddHours(13), Text = "Skype call" },
        new Rebecca.BeWell.BlazorApp.Client.Model.Appointment { Start = DateTime.Today.AddHours(14), End = DateTime.Today.AddHours(14).AddMinutes(30), Text = "Dentist appointment" },
        new Rebecca.BeWell.BlazorApp.Client.Model.Appointment { Start = DateTime.Today.AddDays(1), End = DateTime.Today.AddDays(12), Text = "Vacation" },
    };

        protected override async Task OnInitializedAsync()

        {
          
           

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
                Rebecca.BeWell.BlazorApp.Client.Model.Appointment data = await DialogService.OpenAsync<AddAppointmentPage>("Add Appointment",
                    new Dictionary<string, object> { { "Start", args.Start }, { "End", args.End } });

                if (data != null)
                {
                    appointments.Add(data);
                    // Either call the Reload method or reassign the Data property of the Scheduler
                    await scheduler.Reload();
                }
            }
        }

        async Task OnAppointmentSelect(SchedulerAppointmentSelectEventArgs<Rebecca.BeWell.BlazorApp.Client.Model.Appointment> args)
        {

            var copy = new Rebecca.BeWell.BlazorApp.Client.Model.Appointment
            {
                Start = args.Data.Start,
                End = args.Data.End,
                Text = args.Data.Text
            };

            var data = await DialogService.OpenAsync<EditAppointmentPage>("Edit Appointment", new Dictionary<string, object> { { "Appointment", copy } });

            if (data != null)
            {
                // Update the appointment
                args.Data.Start = data.Start;
                args.Data.End = data.End;
                args.Data.Text = data.Text;
            }

            await scheduler.Reload();
        }

        void OnAppointmentRender(SchedulerAppointmentRenderEventArgs<Rebecca.BeWell.BlazorApp.Client.Model.Appointment> args)
        {
            // Never call StateHasChanged in AppointmentRender - would lead to infinite loop

            if (args.Data.Text == "Birthday")
            {
                args.Attributes["style"] = "background: red";
            }
        }

        async Task OnAppointmentMove(SchedulerAppointmentMouseEventArgs<Rebecca.BeWell.BlazorApp.Client.Model.Appointment> args)
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

