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
        const int PROWS = 4;
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
                InputReplyGrid.ColumnDefinitions.Add(new ColumnDefinition());

                var pegs = new BoxView
                {
                    Margin = 1,
                    HeightRequest = 20,
                    WidthRequest = 20,
                    CornerRadius = 5,
                    BackgroundColor = Color.Yellow,
                    Opacity = 1,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                };


                InputReplyGrid.Children.Add(pegs, i,0);
            }
         
        }//END OF PEGSGRID

        private int currentRow = 0;
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

                    if(i>0)
                    {
                        userInput.IsEnabled = false;
                    }
                }
            }
            
        }//END OF MAKEGRID

        void BTNCheck_Clicked(System.Object sender, System.EventArgs e)
        {
            string[,] corretAnswer = new string[1, 4] { { "red", "green", "blue", "yellow" } };

            checkAnswer(corretAnswer, userAsnwer);

            for(int i=0; i<COLS; i++)
            {
                BoxView boxView = (BoxView)GameGrid.Children[currentRow * COLS + i];
                boxView.IsEnabled = false;
            }
            currentRow++;

            if (currentRow < ROWS)
            {
                for (int i = 0; i < COLS; i++)
                {
                    BoxView boxView = (BoxView)GameGrid.Children[currentRow * COLS + i];
                    boxView.IsEnabled = true;
                }

            }
            else
            {
                BTNCheck.IsVisible = false;
            }
        }//END OF BUTTON CHECK 

        private void checkAnswer(string[,] corretAnswer, string[,] userAnswer)
        {
            for(int i=0; i<COLS; i++)
            {
                if (userAnswer[currentRow, i]==corretAnswer[0,i])//userAnswer[0,0]==coreetAnswer[0,0]=> "red"=="red"=> blackPeg+1
                {
                    //InputReplyGrid.Children[i].BackgroundColor = Color.Black;//in theory "red"=="red", display black peg
                    InputReplyGrid.Children[i * PROWS].BackgroundColor = Color.Black;
                }
                else
                {
                    for(int j=0; j<COLS; j++)
                    {
                        if(userAnswer[currentRow, i]==corretAnswer[0,j])
                        {
                            InputReplyGrid.Children[i*PROWS].BackgroundColor = Color.White;
                        }
                    }
                }
            }
        }//END OF CHECKANSWER
     }//END OF MAIN PAGE
}//END OF NAMES SPACE
