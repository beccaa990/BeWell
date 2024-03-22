using Microsoft.AspNetCore.Components;
using Radzen;
using Rebecca.BeWell.BlazorApp.Shared.Models;

namespace Rebecca.BeWell.BlazorApp.Client.Pages
{
    public partial class EditAppointmentPage : ComponentBase
    {
        [Parameter]
        public DateTime Start { get; set; }

        [Parameter]
        public DateTime End { get; set; }
        [Parameter]
        public Appointment model { get; set; } = new Rebecca.BeWell.BlazorApp.Shared.Models.Appointment();

        protected override void OnParametersSet()
        {
            model.Start = Start;
            model.End = End;
        }
        [Inject]
        DialogService DialogService { get; set; }
        void OnSubmit(Appointment model)
        { 
            DialogService.Close(model);
        }
    }
}
