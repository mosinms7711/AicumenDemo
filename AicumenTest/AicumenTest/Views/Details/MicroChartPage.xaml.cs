using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entry = Microcharts.Entry;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;
using Microcharts;
using System.Diagnostics;

namespace AicumenTest
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MicroChartPage : ContentPage
	{        
        private Random rnd = new Random();
        public List<Entry> entries;

        public MicroChartPage ()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            int i = 0;
            entries = new List<Entry>();
            foreach (var item in TopCryptoListVM.Cryptos)
            {
                entries.Add(new Entry(item.Market_Cap_USD)
                {
                    Color = SKColor.Parse(String.Format("#{0:X6}", rnd.Next(0x1000000))),
                    Label = item.Symbol,
                    ValueLabel = Math.Round(item.Market_Cap_USD,2).ToString()
                });

                Debug.WriteLine("entries:" + entries);
            }
            PieChart.Chart = new DonutChart { Entries = entries};
           
        }

    }
}