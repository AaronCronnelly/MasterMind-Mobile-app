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

        private async void BTNCStart_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        void BTNLoadGame_Clicked(System.Object sender, System.EventArgs e)
        {
        }

        private async void BTNRules_Clicked(System.Object sender, System.EventArgs e)
        {
            await DisplayAlert("Rules of the game", "Your aim to find decode the color code, you will be giving, " + "10 trys to do this, after that" +
                " the computer will win" + "if you win you will be told, you will input a 4 color code, and then ask to check, " + "You will either win, or be giving pegs depend" +
                "on how close you were, you get white pegs for the right color in the right location, and you get black pegs for the right color wrong location" +
                "please enjoy and have fun", "ok");  
        }
    }
}
