using Microsoft.AspNetCore.Components;
using BlazorBootstrap;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Json;
using Rebecca.BeWell.BlazorApp.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rebecca.BeWell.BlazorApp.Client.Pages
{
    public partial class Summary : ComponentBase
    {
        [Inject]
        public HttpClient Http { get; set; } = default!;
        public List<AreaSeriesItem> ActivityData { get; set; } = new List<AreaSeriesItem>();
        public List<Shared.Data.Models.ActivityType> ActivityTypes { get; set; } = new List<Shared.Data.Models.ActivityType>();

        public DateTime StartDate { get; set; } = DateTime.Now.AddYears(-1);
        public DateTime EndDate { get; set; } = DateTime.Now;
        public List<PieSeries> PieSeriesList { get; set; } = new List<PieSeries> { };

        public PieChart pieChart = default!;
        public PieChartOptions pieChartOptions = default!;
        public ChartData chartData = default!;
        private string[]? backgroundColors;

        protected override async Task OnInitializedAsync()
        {
            var profile = await Http.GetFromJsonAsync<Shared.Data.Models.Profile>("api/Profiles/user/current");

            if (profile?.Activities == null)
            {
                // Handle the case where profile or activities are null
                return;
            }

            ActivityTypes = await Http.GetFromJsonAsync<List<Shared.Data.Models.ActivityType>>("api/Activities/GetActivityTypes") ?? new List<Shared.Data.Models.ActivityType>();

            ActivityData = profile.Activities.Where(d => d.Start >= StartDate && d.Start <= EndDate).Select(a => new AreaSeriesItem()
            {
                Date = DateOnly.FromDateTime(a.Start),
                Mins = a.Mins,
                Intensity = a.Intensity.Name,
                Type = a.ActivityType.Name,
            }).ToList();

            foreach (var at in ActivityTypes)
            {
                var pieSeries = new PieSeries()
                {
                    TypeName = at.Name,
                    TotalMins = ActivityData.Where(a => a.Type == at.Name).Sum(a => a.Mins),
                };

                PieSeriesList.Add(pieSeries);
            }

            backgroundColors = new string[] { "#FF6384", "#36A2EB", "#FFCE56", "#4BC0C0", "#9966FF", "#FF9F40" };
            chartData = new ChartData
            {
                Labels = PieSeriesList.Select(p => p.TypeName).ToList(),
                Datasets = new List<IChartDataset>
                {
                    new PieChartDataset
                    {
                        Data = PieSeriesList.Select(p => (double?)p.TotalMins).ToList(),
                        BackgroundColor = backgroundColors.Take(PieSeriesList.Count).ToList()
                    }
                }
            };

            pieChartOptions = new PieChartOptions
            {
                Responsive = true,
                Plugins = new PieChartPlugins
                {
                    Title = new ChartPluginsTitle
                    {
                        Text = "Activity Summary",
                        Display = true
                    }
                }
            };

            await pieChart.InitializeAsync(chartData, pieChartOptions);
        }

        //protected override async Task OnAfterRenderAsync(bool firstRender)
        //{
        //    if (firstRender)
        //    {
        //        await pieChart.InitializeAsync(chartData, pieChartOptions);
        //    }
        //    await base.OnAfterRenderAsync(firstRender);
        //}
    }
}