using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using Radzen;
using Radzen.Blazor.Rendering;
using Microsoft.AspNetCore.Authorization;
using static System.Net.WebRequestMethods;
using System.Net.Http.Json;
using Rebecca.BeWell.BlazorApp.Shared.Models;



namespace Rebecca.BeWell.BlazorApp.Client.Pages
{
    public partial class Summary : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }
        public List<AreaSeriesItem> ActivityData { get; set; }
        public List<Shared.Data.Models.ActivityType> ActivityTypes { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Rebecca.BeWell.BlazorApp.Shared.Data.Models.Profile profile = await Http.GetFromJsonAsync<Shared.Data.Models.Profile>("api/Profiles/user/current");

            ActivityTypes = await  Http.GetFromJsonAsync<List<Shared.Data.Models.ActivityType>>("api/Activities/GetActivityTypes");

            ActivityData = profile.Activities.Select(a => new Shared.Models.AreaSeriesItem()
            {
                Date = DateOnly.FromDateTime( a.Start),
                Mins = a.Mins,
                Intensity = a.Intensity.Name,
                Type = a.ActivityType.Name,

            }).ToList();
        }
    }
}
