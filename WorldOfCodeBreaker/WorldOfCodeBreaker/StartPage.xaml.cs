using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WorldOfCodeBreaker
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private async void BTNChangePage_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}
