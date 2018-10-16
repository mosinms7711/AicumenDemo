﻿using AicumenTest.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AicumenTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : MasterDetailPage
    {
        public IFileEngine fileEngine = DependencyService.Get<IFileEngine>();

        public DashboardPage()
        {
            InitializeComponent();
            Debug.WriteLine("dashboard initialize");

            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }
        protected override void OnAppearing()
        {            
            NavigationPage.SetBackButtonTitle(this, string.Empty);
            NavigationPage.SetHasBackButton(this, false);
        }        
        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as DashboardPageMenuItem;
            if (item == null)
                return;

            //Sign out
            if (item.Id == 2)
            {
                Debug.WriteLine("navigation done dashboard");

                await fileEngine.WriteTextAsync("AccessToken", string.Empty);
                Application.Current.Properties.Clear();
                DependencyService.Get<IClearCookies>().ClearAllCookies();

                if (App.Current.MainPage is NavigationPage)
                {
                    await (App.Current.MainPage as NavigationPage).PushAsync(new MainPage());
                    //App.Current.MainPage = new MainPage();
                    Debug.WriteLine("Current Page:"+App.Current.MainPage);
                }
                
                return;
            }

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}
