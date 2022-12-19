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
        //TAPGESUTER,
        TapGestureRecognizer Choice = new TapGestureRecognizer();


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
            PegsGrid();//DISPLAYS USERS PEGS WHITE/BLACK
            DisplayBoxView();
            BTNBegin.IsVisible = false;
        }

        private void PegsGrid()
        {
            InputReplyGrid.IsVisible = true;
            for(int i=0; i<PROWS; i++)
            {
                InputReplyGrid.RowDefinitions.Add(new RowDefinition());
                InputReplyGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

        }

        private void DisplayBoxView()
        {
            for (int i = 0; i < COLS; i++)
                GameGrid.Children.Add(new BoxView
                {
                    Margin = 5,
                    HeightRequest = 40,
                    WidthRequest = 40,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Start,
                    CornerRadius = 20,
                    BackgroundColor = Color.Black,
                    Opacity = 0.5,
                    
                }, i, 0);

            for(int i=0; i<PCOLS; i++)
            {
                InputReplyGrid.Children.Add(new BoxView
                {
                    Margin = 2,
                    HeightRequest = 20,
                    WidthRequest = 20,
                    CornerRadius = 10,
                    BackgroundColor = Color.Red,

                },i, 0);
            }
            for (int i=0; i<PROWS; i++)
            {
                InputReplyGrid.Children.Add(new BoxView
                {
                    Margin = 2,
                    HeightRequest = 20,
                    WidthRequest = 20,
                    CornerRadius = 10,
                    BackgroundColor = Color.Red,

                },i,1);
            }


        }//END OF DisplayBoxViwe

        private void makeGrid()
        {
            //need to add a iteration to this
            //going to have to then print it out aggain
            //then have to display everything.
            
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
