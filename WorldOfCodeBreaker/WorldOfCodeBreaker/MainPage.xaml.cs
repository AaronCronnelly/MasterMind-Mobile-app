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
        const int ROWS = 2;
        const int COLS = 4;
        const int PROWS = 2;
        const int PCOLS = 2;

        

        public MainPage()
        {
            InitializeComponent();
            
        }//END OF MAIN

        void BTNBegin_Clicked(System.Object sender, System.EventArgs e)
        {
            makeGrid(0);
            PegsGrid();//DISPLAYS USERS PEGS WHITE/BLACK
            BTNBegin.IsVisible = false;
            BTNCheck.IsVisible = true;
        }//END OF BTNBEGIN

      

        private void PegsGrid()
        {
            InputReplyGrid.IsVisible = true;
            for (int i = 0; i < PROWS; i++)
            {
                InputReplyGrid.RowDefinitions.Add(new RowDefinition());

                var pegs = new BoxView
                {
                    Margin = 2,
                    HeightRequest = 20,
                    WidthRequest = 20,
                    CornerRadius = 10,
                    BackgroundColor = Color.LightBlue,
                    Opacity = 1,
                    HorizontalOptions = LayoutOptions.End,
                    VerticalOptions = LayoutOptions.End,
                };


                InputReplyGrid.Children.Add(pegs, 0, i);
            }
            for (int j = 0; j < PCOLS; j++)
            {
                InputReplyGrid.ColumnDefinitions.Add(new ColumnDefinition());

                var pegs = new BoxView
                {
                    Margin = 2,
                    HeightRequest = 20,
                    WidthRequest = 20,
                    CornerRadius = 10,
                    BackgroundColor = Color.LightBlue,
                    Opacity = 1,
                    HorizontalOptions = LayoutOptions.End,
                    VerticalOptions = LayoutOptions.End,
                };
                
                InputReplyGrid.Children.Add(pegs, 1, j);
            }
        }//END OF PEGSGRID

        private string[,] userAsnwer = new string[ROWS, COLS];
        private void makeGrid(int row)
        {
            GameGrid.IsVisible = true;
            for (int i = 0; i < COLS; i++)
            {
                GameGrid.ColumnDefinitions.Add(new ColumnDefinition());

                var userInput = new BoxView
                {
                    Margin = 5,
                    HeightRequest = 40,
                    WidthRequest = 40,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Start,
                    CornerRadius = 20,
                    BackgroundColor = Color.Black,
                    Opacity = 1,
                };

                var userChoice = new TapGestureRecognizer
                {
                    Command = new Command(() =>
                    {
                        if (userInput.BackgroundColor == Color.Black)
                        {
                            userInput.BackgroundColor = Color.Red;
                            userAsnwer[row, i] = "red";//in theory this sould be userAnswer[0,0]="red";
                        }
                        else if (userInput.BackgroundColor == Color.Red)
                        {
                            userInput.BackgroundColor = Color.Blue;
                           
                        }
                        else if (userInput.BackgroundColor == Color.Blue)
                        {
                            userInput.BackgroundColor = Color.Yellow;
                            
                        }
                        else if (userInput.BackgroundColor == Color.Yellow)
                        {
                            userInput.BackgroundColor = Color.Green;
                            
                        }
                        else
                        {
                            userInput.BackgroundColor = Color.Black;
                        }

                    })
                };

                userInput.GestureRecognizers.Add(userChoice);
                GameGrid.Children.Add(userInput, i, 0);
            }
        }//END OF MAKEGRID

        void BTNCheck_Clicked(System.Object sender, System.EventArgs e)
        {
            string[,] corretAnswer = new string[1, 4] { { "red", "green", "blue", "yellow" } };

            checkAnswer(corretAnswer, userAsnwer);

            
        }//END OF BUTTON CHECK 

        private void checkAnswer(string[,] corretAnswer, string[,] userAnswer)
        {
            int blackPeg = 0;
            int whitePeg = 0;
            //understanding was gotting form ai generated explaintion and code
            List<string> usedColors = new List<string>();

            for (int i = 0; i < COLS; i++)
            {
                if (userAnswer[0, i] == corretAnswer[0, i])
                {
                    blackPeg++;
                     
                }
                else if (!usedColors.Contains(userAnswer[0, i]) && corretAnswer[0,1]!="")
                {
                    whitePeg++;
                    usedColors.Add(corretAnswer[0, i]);
                }

            }
        }//END OF CHECKANSWER
     }//END OF MAIN PAGE
}//END OF NAMES SPACE
