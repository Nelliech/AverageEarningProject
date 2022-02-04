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
using AverageEarning.Services.Interface;

namespace AverageEarning.Pages
{
    public partial class MonthlyEarning
    {
        [Inject]
        protected ICountriesData CountriesData { get; set; }

        [Inject]
        protected IExchange Exchange { get; set; }

        [Inject]
        protected IHttpClientFactory _clientFactory { get; set; }

        [Parameter]
        public float Rate { get; set; }

        [Parameter]
        public string Code { get; set; }

        List<ExchangeRate> exchangeRate;
        List<Payout> Payouts;
        string errorString;
        public ICollection<Country> Countries { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Countries = CountriesData.GetAllCountries();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.nbp.pl/api/exchangerates/tables/A?format=json");
            var client = _clientFactory.CreateClient();
            HttpResponseMessage respones = await client.SendAsync(request);
            if (respones.IsSuccessStatusCode)
            {
                exchangeRate = await respones.Content.ReadFromJsonAsync<List<ExchangeRate>>();
                errorString = null;
            }
            else
            {
                errorString = $"There was an error getting our exchangeRat : {respones.ReasonPhrase}";
            }

            Payouts = Exchange.ExchangeToPLN(Rate, Code, exchangeRate, Countries);
            var q = 53;
        }
    }
}