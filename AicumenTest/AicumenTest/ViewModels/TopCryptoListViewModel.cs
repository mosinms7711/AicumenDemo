﻿using AicumenTest.Helper;
using AicumenTest.Models;
using Microcharts;
using Newtonsoft.Json;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Linq;
using Xamarin.Forms;
using System.Globalization;
using System.Diagnostics;

namespace AicumenTest.ViewModels
{
    /// <summary>
    /// Top Crypto List ViewModel
    /// </summary>
    public class TopCryptoListViewModel:BaseViewModel,IValueConverter
    {
        //Temperory Observable collection used for Sorting purpose
        private ObservableCollection<Crypto> SortingCollection = new ObservableCollection<Crypto>();

        private ObservableCollection<Crypto> _Cryptos = new ObservableCollection<Crypto>();
        public ObservableCollection<Crypto> Cryptos
        {
            get
            {
                return _Cryptos;
            }
            set
            {
                if (value != null)
                {
                    _Cryptos = value;
                    Notify("Cryptos");
                }
            }
        }

        public TopCryptoListViewModel()
        {
            //Navigation between Hamburger menu takes very less time
            //so that persisting top 10 Cryptos into App settings            
            if (Application.Current.Properties.ContainsKey("Cryptos"))
            {
                Cryptos = Application.Current.Properties["Cryptos"] as ObservableCollection<Crypto>;
            }

            //Load Top 10 Cryptos 
            LoadTop10Cryptos();
        }

        /// <summary>
        /// Load Top 10 Cryptos
        /// </summary>
        private async void LoadTop10Cryptos()
        {
            //Http call for getting Cryptos list from requested web api
            HttpResponseMessage response = await HttpHelper.GetTop10Cryptos("https://api.coinmarketcap.com/v1/ticker/");
            SortingCollection = JsonConvert.DeserializeObject<ObservableCollection<Crypto>>(response.Content.ReadAsStringAsync().Result);

            //Sorting collection based on market_cap_usd property value
            SortingCollection.ToList().Sort((x, y) => x.Market_Cap_USD.CompareTo(y.Market_Cap_USD));

            //Clear collection before inserting updated entries
            Cryptos.Clear();

            //Get first 10 items from collection
            foreach (var item in SortingCollection.Skip(0).Take(10))
            {
                //Cryptos.Add(item);
          
                Cryptos.Add(new Crypto { Name = item.Name, Symbol = item.Symbol, Price_USD =Math.Round(double.Parse(item.Price_USD),2).ToString(), Percent_change_1h = Math.Round(double.Parse(item.Percent_change_1h),2).ToString(), Percent_change_24h = Math.Round(double.Parse(item.Percent_change_24h),2).ToString(), Percent_change_7d = Math.Round(double.Parse(item.Percent_change_7d),2).ToString(),Market_Cap_USD= (float)(Math.Round(item.Market_Cap_USD)) });
            }

            //Adding upated Top 10 Cryptos into App settings
            Application.Current.Properties["Cryptos"] = Cryptos;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Equals(value, null))
            {
                return "#000000";
            }

            Crypto i = value as Crypto;

            if (i.Percent_change_24h.StartsWith("-"))
            {
                return "#FF0000";
            }
            else
            {
                return "#008000";

            }            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Crypto i = value as Crypto;

            if (i.Percent_change_1h.StartsWith("-"))
            {
                return "#FF0000";
            }
            else
            {
                return "#008000";
            }
        }
    }
}
