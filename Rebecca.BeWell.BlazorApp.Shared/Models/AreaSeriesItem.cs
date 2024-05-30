using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rebecca.BeWell.BlazorApp.Shared.Models
{
    public class AreaSeriesItem
    {
        public DateOnly Date { get; set; }

        public int Mins { get; set; }

        public string Intensity { get; set; }

        public string Type { get; set; }


    }
}
