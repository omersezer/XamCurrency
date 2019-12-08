using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamCurrency.Models;

namespace XamCurrency.Views
{
    public partial class CurrencyPage : ContentPage
    {
        Service service;
        public CurrencyPage()
        {
            InitializeComponent();
            service = new Service();
            FillCurrencies();
        }

        private void ListViewCurrency_Refreshing(object sender, EventArgs e)
        {
            listViewCurrency.IsRefreshing = true;
            FillCurrencies();
            listViewCurrency.IsRefreshing = false;
        }

        private async void FillCurrencies()
        {
            indicator.IsRunning = true;
            var takenData = await service.GetAsync<List<CurrencyModel>>("https://www.btcturk.com/api/ticker?fbclid=IwAR3-RzMvjpF18zGH3gW5uLxzbVE4kexILcK-e3ufQNopkjhiWC1zLcGL5Ow");
            if (takenData != null)
            {
                listViewCurrency.ItemsSource = takenData;
            }
            indicator.IsRunning = false;
        }
    }
}
