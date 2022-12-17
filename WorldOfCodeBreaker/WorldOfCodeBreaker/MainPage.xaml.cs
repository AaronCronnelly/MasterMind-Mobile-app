using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;



namespace WorldOfCodeBreaker
{
    public partial class MainPage : ContentPage
    {
        //CONSTATNS
        const int ROWS = 1;
        const int COLS = 4;
        const int PROWS = 2;
        const int PCOLS = 2;



        public MainPage()
        {
            InitializeComponent();
        }

        void BTNBegin_Clicked(System.Object sender, System.EventArgs e)
        {
            makeGrid();
            DisplayBoxView();
            BTNBegin.IsVisible = false;
        }

        private void DisplayBoxView()
        {
            for (int i = 0; i < COLS; i++)
                GameGrid.Children.Add(new BoxView
                {
                    Margin=5,
                    HeightRequest = 40,
                    WidthRequest = 40,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions=LayoutOptions.Start,
                    CornerRadius=20,
                    BackgroundColor=Color.Black,
                    Opacity=0.5,
                },i, 0);
        }//END OF DisplayBoxViwe

        private void makeGrid()
        {
            
            GameGrid.IsVisible = true;
            for(int i=0; i<ROWS; i++)
            {
                GameGrid.RowDefinitions.Add(new RowDefinition());
          
            }
            for(int i=0; i<COLS; i++)
            {
                GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
                
            }
        }//END OF makeGrid
    }//END OF MAIN PAGE
}//END OF NAMES SPACE
