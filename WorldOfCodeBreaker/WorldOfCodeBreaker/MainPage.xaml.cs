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
        const int ROWS = 10;
        const int COLS = 4;
        const int PROWS = 2;
        const int PCOLS = 2;

        //GLOBAL VARIABLE
        

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
                
                InputReplyGrid.Children.Add(pegs, 1, j);
            }
        }//END OF PEGSGRID

        private string[,] userAsnwer = new string[ROWS, COLS];
        private void makeGrid()
        {
           
            GameGrid.IsVisible = true;

            for(int i=0; i<COLS; i++)
            {
                GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            //GameGrid.RowDefinitions.Add(new RowDefinition());

            for (int i = 0; i < ROWS; i++)
            {
                GameGrid.RowDefinitions.Add(new RowDefinition());
                for (int j = 0; j < COLS; j++)
                {
                    //GameGrid.ColumnDefinitions.Add(new ColumnDefinition());

                    var userInput = new BoxView
                    {
                        Margin = 5,
                        HeightRequest = 30,
                        WidthRequest = 30,
                        HorizontalOptions = LayoutOptions.Start,
                        VerticalOptions = LayoutOptions.Start,
                        CornerRadius = 10,
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
                                userAsnwer[i%ROWS,j%COLS] = "red";//in theory this sould be userAnswer[0,0]="red";
                            }
                            else if (userInput.BackgroundColor == Color.Red)
                            {
                                userInput.BackgroundColor = Color.Blue;
                                userAsnwer[i % ROWS, j % COLS] = "blue";
                            }
                            else if (userInput.BackgroundColor == Color.Blue)
                            {
                                userInput.BackgroundColor = Color.Yellow;
                                userAsnwer[i % ROWS, j % COLS] = "yellow";
                            }
                            else if (userInput.BackgroundColor == Color.Yellow)
                            {
                                userInput.BackgroundColor = Color.Green;
                                userAsnwer[i % ROWS, j % COLS] = "green";
                            }
                            else
                            {
                                userInput.BackgroundColor = Color.Black;
                            }

                        })
                    };

                    userInput.GestureRecognizers.Add(userChoice);
                    GameGrid.Children.Add(userInput, j, i);
                }
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
