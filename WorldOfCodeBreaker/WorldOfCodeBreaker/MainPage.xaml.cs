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
        public MainPage()
        {
            InitializeComponent();
        }

        void BTNBegin_Clicked(System.Object sender, System.EventArgs e)
        {
            makeGrid();
        }

        private void makeGrid()
        {
            GameGrid.IsVisible = true;
            const int ROWS = 1;
            const int COLS = 4;
            for(int i=0; i<ROWS; i++)
            {
                GameGrid.RowDefinitions.Add(new RowDefinition());
                
            }
            for(int i=0; i<COLS; i++)
            {
                GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }
    }
}
