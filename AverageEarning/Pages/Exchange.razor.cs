using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using AverageEarning;
using AverageEarning.Shared;
using AverageEarning.Models;

namespace AverageEarning.Pages
{
    public partial class Exchange
    {
        public DailyRate dailyRate { get; set; }

        [Inject]
        public NavigationManager NavManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            dailyRate = new DailyRate();
        }

        private async void RecalculateStake()
        {
            NavManager.NavigateTo("/MonthlyEarning/" + dailyRate.Rate + "/" + dailyRate.Code);
        }
    }
}