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
            
        }//END OF MAIN

        void BTNBegin_Clicked(System.Object sender, System.EventArgs e)
        {
            makeGrid();
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
                a
                InputReplyGrid.Children.Add(pegs, 1, j);
            }
        }//END OF PEGSGRID

        private string[,] userAsnwer = new string[ROWS, COLS];
        private void makeGrid()
        {
            //need to add a iteration to this
            //going to have to then print it out aggain
            //then have to display everything.

            

            GameGrid.IsVisible = true;
            for (int i = 0; i < ROWS; i++)
            {
                GameGrid.RowDefinitions.Add(new RowDefinition());

            }
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

                var userchoice = new TapGestureRecognizer
                {
                    Command = new Command(() =>
                      {
                          if (userInput.Color == Color.Black)
                          {
                              userInput.Color = Color.Red;
                              userAsnwer[0, i] = "red";
                          }
                          else if (userInput.Color == Color.Red)
                          {
                              userInput.Color = Color.Blue;
                              userAsnwer[0, i] = "blue";
                          }
                          else if (userInput.Color == Color.Blue)
                          {
                              userInput.Color = Color.Yellow;
                              userAsnwer[0, i] = "yellow";
                          }
                          else if (userInput.Color == Color.Yellow)
                          {
                              userInput.Color = Color.Green;
                              userAsnwer[0, i] = "green";
                          }
                          else
                          {
                              userInput.Color = Color.Black;
                          }
                      })
                };


                userInput.GestureRecognizers.Add(userchoice);

                GameGrid.Children.Add(userInput, i, 0);

            }
        }//END OF MAKEGRID

        void BTNCheck_Clicked(System.Object sender, System.EventArgs e)
        {
            string[,] corretAnswer = new string[ROWS, COLS] { { "red", "green", "blue", "yellow" } };

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
