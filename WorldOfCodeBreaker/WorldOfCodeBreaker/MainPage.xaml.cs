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
        const int PCOLS = 4;

        //GLOBAL VARIABLE
        int pegRowCurrent = 0;
        private string[,] userAsnwer = new string[ROWS, COLS];
        private string[,] corretAnswer = new string[1, 4];

        public MainPage()
        {
            InitializeComponent();
            
        }//END OF MAIN

        void BTNBegin_Clicked(System.Object sender, System.EventArgs e)
        {
            makeGrid();//main gird
            PegsGrid();//display pegs 
            CorretAnswerPick();//created the color code
            BTNBegin.IsVisible = false;
            BTNCheck.IsVisible = true;
         }//END OF BTNBEGIN

        private void CorretAnswerPick()
        {
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                int colorIndex = random.Next(0, 5);
                string color = "";
                switch (colorIndex)
                {
                    case 0:
                        color = "red";
                        break;
                    case 1:
                        color = "blue";
                        break;
                    case 2:
                        color = "yellow";
                        break;
                    case 3:
                        color = "green";
                        break;
                    case 4:
                        color = "black";
                        break;
                }//end of swithc
                corretAnswer[0, i] = color;
            }//end of for loop
        }//END OF CORRECT ANSWER PICK

        private void PegsGrid()
        {
            InputReplyGrid.IsVisible = true;

            for (int i = 0; i < PCOLS; i++)
            {
                InputReplyGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }//end of for loop

            for (int j = 0; j < 10; j++)
            {
                InputReplyGrid.RowDefinitions.Add(new RowDefinition());
                for (int i = 0; i < PCOLS; i++)
                {
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

                    InputReplyGrid.Children.Add(pegs, i, j);
                }//end of out for loop 
            }//end of outher for looop


        }//END OF PEGSGRID

        private int currentCol = 0;
        private void updateUserAnswer(int row, int col, BoxView boxView)
        {
            //updating userAsnwer depening on user choice
            string color = "red";
            if (boxView.BackgroundColor == Color.Black)
            {
                boxView.BackgroundColor = Color.Red;
                color = "red";
            }
            else if (boxView.BackgroundColor == Color.Red)
            {
                boxView.BackgroundColor = Color.Blue;
                color = "blue";
            }
            else if (boxView.BackgroundColor == Color.Blue)
            {
                boxView.BackgroundColor = Color.Yellow;
                color = "yellow";
            }
            else if (boxView.BackgroundColor == Color.Yellow)
            {
                boxView.BackgroundColor = Color.Green;
                color = "green";
            }
            else if (boxView.BackgroundColor == Color.Green)
            {
                boxView.BackgroundColor = Color.Black;
                color = "black";
            }

            userAsnwer[row % ROWS, currentCol] = color;
            currentCol++;
            if (currentCol >= 4)
            {
                currentCol = 0;
            }

        }//END OF UPDATE USER ANSWER

        private void makeGrid()
        {           
            GameGrid.IsVisible = true;

            for(int i=0; i<COLS; i++)
            {
                GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }//end of for
            
            for (int i = 0; i < ROWS; i++)
            {
                GameGrid.RowDefinitions.Add(new RowDefinition());
                for (int j = 0; j < COLS; j++)
                {
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
                            updateUserAnswer( i,  j, userInput);
                        })
                    };

                    userInput.GestureRecognizers.Add(userChoice);
                    GameGrid.Children.Add(userInput, j, i);

                    if(i>0)
                    {
                        userInput.IsEnabled = false;
                    }
                }//end of inner for loop
            }//end of outher for loop 
            
        }//END OF MAKEGRID

        private int currentRow = 0;
        void BTNCheck_Clicked(System.Object sender, System.EventArgs e)
        {
            CheckAnswer();
            currentRow++;
            for (int i=0; i<COLS; i++)
            {
                BoxView boxView = (BoxView)GameGrid.Children[currentRow * COLS + i];
                boxView.IsEnabled = false;
            }//end of for loop

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
        
            int black = 0;
            int white = 0;
        private void CheckAnswer()
        {
            
            for (int i = 0; i < 4; i++)
            {
                // Check if the color is in the correct position
                if (userAsnwer[currentRow, i] == corretAnswer[0, i])
                {
                    black++;
                    continue;
                }

                // Check if the color is in the incorrect position
                for (int j = 0; j < 4; j++)
                {
                    if (userAsnwer[currentRow, i] == corretAnswer[0, j])
                    {
                        white++;
                        break;
                    }
                }//end of inner for
            }//end of outer for

            switch (black)
            {
                case 1:
                    InputReplyGrid.Children[0 + pegRowCurrent * PCOLS].BackgroundColor = Color.Black;
                    break;

                case 2:
                    InputReplyGrid.Children[0 + pegRowCurrent * PCOLS].BackgroundColor = Color.Black;
                    InputReplyGrid.Children[1 + pegRowCurrent * PCOLS].BackgroundColor = Color.Black;

                    break;

                case 3:
                    InputReplyGrid.Children[0 + pegRowCurrent * PCOLS].BackgroundColor = Color.Black;
                    InputReplyGrid.Children[1 + pegRowCurrent * PCOLS].BackgroundColor = Color.Black;
                    InputReplyGrid.Children[2 + pegRowCurrent * PCOLS].BackgroundColor = Color.Black;
                    break;

                case 4:
                    InputReplyGrid.Children[0 + pegRowCurrent * PCOLS].BackgroundColor = Color.Black;
                    InputReplyGrid.Children[1 + pegRowCurrent * PCOLS].BackgroundColor = Color.Black;
                    InputReplyGrid.Children[2 + pegRowCurrent * PCOLS].BackgroundColor = Color.Black;
                    InputReplyGrid.Children[3 + pegRowCurrent * PCOLS].BackgroundColor = Color.Black;
                    break;

                default:
                    break;

            }//END OF SWITCH BLACK

            switch (white)
            {
                case 1:
                    InputReplyGrid.Children[0 + pegRowCurrent * PCOLS].BackgroundColor = Color.White;
                    break;

                case 2:
                    InputReplyGrid.Children[0 + pegRowCurrent * PCOLS].BackgroundColor = Color.White;
                    InputReplyGrid.Children[1 + pegRowCurrent * PCOLS].BackgroundColor = Color.White;

                    break;

                case 3:
                    InputReplyGrid.Children[0 + pegRowCurrent * PCOLS].BackgroundColor = Color.White;
                    InputReplyGrid.Children[1 + pegRowCurrent * PCOLS].BackgroundColor = Color.White;
                    InputReplyGrid.Children[2 + pegRowCurrent * PCOLS].BackgroundColor = Color.White;
                    break;

                case 4:
                    InputReplyGrid.Children[0 + pegRowCurrent * PCOLS].BackgroundColor = Color.White;
                    InputReplyGrid.Children[1 + pegRowCurrent * PCOLS].BackgroundColor = Color.White;
                    InputReplyGrid.Children[2 + pegRowCurrent * PCOLS].BackgroundColor = Color.White;
                    InputReplyGrid.Children[3 + pegRowCurrent * PCOLS].BackgroundColor = Color.White;
                    break;

                default:
                    break;

            }//END OF SWTICH WHITE

            
            pegRowCurrent++;

        }//END OF CHECKANSWER
    }//END OF MAIN PAGE
}//END OF NAMES SPACE
