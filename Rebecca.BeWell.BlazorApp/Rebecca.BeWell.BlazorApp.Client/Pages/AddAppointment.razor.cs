using Microsoft.AspNetCore.Components;
using Radzen.Blazor.Rendering;
using Radzen;

namespace Rebecca.BeWell.BlazorApp.Client.Pages
{
    public partial class AddAppointment : ComponentBase
    {

        [Parameter]
        public DateTime Start { get; set; }

        [Parameter]
        public DateTime End { get; set; }


        Rebecca.BeWell.BlazorApp.Client.Model.Appointment model = new Rebecca.BeWell.BlazorApp.Client.Model.Appointment();
        [Inject]
        DialogService DialogService { get; set; }

        protected override async Task OnInitializedAsync()
        {



        }

        protected override void OnParametersSet()
        {
            model.Start = Start;
            model.End = End;
        }

        private void OnSubmit()
        {
            DialogService.Close(model);
        }

    }
}
