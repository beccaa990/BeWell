using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using Radzen;
using Radzen.Blazor.Rendering;
using Microsoft.AspNetCore.Authorization;
using static System.Net.WebRequestMethods;
using System.Net.Http.Json;
using Rebecca.BeWell.BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;



namespace Rebecca.BeWell.BlazorApp.Client.Pages
{
    public partial class Summary : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; }
        public List<AreaSeriesItem> ActivityData { get; set; }
        public List<Shared.Data.Models.ActivityType> ActivityTypes { get; set; }

        public DateTime StartDate { get; set; } = new DateTime(2024, 6, 1);
        public DateTime EndDate { get; set; } = new DateTime(2024, 6, 30);

        //public string typeName { get; set; }

        //public List<AreaSeriesItem> data { get; set; }

        public List<AreaSeries> AreaSeriesList { get; set; } = new List<AreaSeries> { };

        public List<PieSeries> PieSeriesList { get; set; } = new List<PieSeries> { };

        protected override async Task OnInitializedAsync()
        {
            Rebecca.BeWell.BlazorApp.Shared.Data.Models.Profile profile = await Http.GetFromJsonAsync<Shared.Data.Models.Profile>("api/Profiles/user/current");

            ActivityTypes = await Http.GetFromJsonAsync<List<Shared.Data.Models.ActivityType>>("api/Activities/GetActivityTypes");

            ActivityData = profile.Activities.Where(d => d.Start >= StartDate && d.Start <= EndDate).Select(a => new Shared.Models.AreaSeriesItem()
            {
                Date = DateOnly.FromDateTime(a.Start),
                Mins = a.Mins,
                Intensity = a.Intensity.Name,
                Type = a.ActivityType.Name,
            }).ToList();

            foreach (var at in ActivityTypes)
            {
                //foreach (var a in ActivityData.Where(a => a.Type == at.Name))
                //{
                    PieSeries pieSeries = new PieSeries()
                    {
                        TypeName = at.Name,
                        TotalMins = ActivityData.Where(a => a.Type == at.Name).Sum(a => a.Mins),
                    };

                    PieSeriesList.Add(pieSeries);
                //}
            }

            //typeName = ActivityData.Select(x => x.Type).FirstOrDefault();
            //data = ActivityData.Where(x => x.Type == typeName).ToList();
        }
    }
}
