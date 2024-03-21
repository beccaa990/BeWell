using Microsoft.AspNetCore.Components;
using Radzen;

namespace Rebecca.BeWell.BlazorApp.Client.Pages
{
    public partial class EditAppointmentPage : ComponentBase
    {
        [Parameter]
        public DateTime Start { get; set; }

        [Parameter]
        public DateTime End { get; set; }
        [Parameter]
        public Rebecca.BeWell.BlazorApp.Client.Model.Appointment model { get; set; } = new Rebecca.BeWell.BlazorApp.Client.Model.Appointment();

        protected override void OnParametersSet()
        {
            model.Start = Start;
            model.End = End;
        }
        [Inject]
        DialogService DialogService { get; set; }
        void OnSubmit(Rebecca.BeWell.BlazorApp.Client.Model.Appointment model)
        { 
            DialogService.Close(model);
        }
    }
}
