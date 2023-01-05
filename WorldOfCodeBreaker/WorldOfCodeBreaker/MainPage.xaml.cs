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
        private string[,] userAsnwer = new string[ROWS, COLS];
        private string[,] corretAnswer = new string[1, 4] { { "red", "green", "blue", "yellow" } };

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
            for (int i = 0; i < PCOLS; i++)
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


                InputReplyGrid.Children.Add(pegs, i, 0);
            }





        }//END OF PEGSGRID

        private string color = "red";
        private int currentCol = 0;
        private void updateUserAnswer(int row, int col, BoxView boxView)
        {

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

            //userAsnwer[row % ROWS, col % COLS] = color;
            userAsnwer[row % ROWS, currentCol] = color;
            currentCol++;
            if (currentCol >= 4)
            {
                currentCol = 0;
            }




        }//END OF UPDATE USER ANSWER

        //private string[,] userAsnwer = new string[ROWS, COLS];
        private void makeGrid()
        {
           
            GameGrid.IsVisible = true;

            for(int i=0; i<COLS; i++)
            {
                GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            
           
            
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
                            updateUserAnswer( i,  j, userInput);
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

        private int currentRow = 0;
        void BTNCheck_Clicked(System.Object sender, System.EventArgs e)
        {
            

            
            CheckAnswer();
            currentRow++;
            for (int i=0; i<COLS; i++)
            {
                BoxView boxView = (BoxView)GameGrid.Children[currentRow * COLS + i];
                boxView.IsEnabled = false;
            }

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
        
        private void CheckAnswer()
        {
            /*
             * ToDo
             * compare answer
             * update pegs
             * 
             *UPDATING PEGS
             * 
             */

            int black = 0;
            int white = 0;

            for (int i = 0; i < 4; i++)
            {

                for (int j = 0; j < 4; j++)
                {
                    if (userAsnwer[currentRow, i] == corretAnswer[0, j])
                    {
                        black++;
                        continue;
                    }
                }
            }




            System.Diagnostics.Debug.WriteLine(userAsnwer[0, 0]);
            System.Diagnostics.Debug.WriteLine(userAsnwer[0, 1]);
            System.Diagnostics.Debug.WriteLine(userAsnwer[0, 2]);
            System.Diagnostics.Debug.WriteLine(userAsnwer[0, 3]);

            System.Diagnostics.Debug.WriteLine(corretAnswer[0, 0]);
            System.Diagnostics.Debug.WriteLine(corretAnswer[0, 1]);
            System.Diagnostics.Debug.WriteLine(corretAnswer[0, 2]);
            System.Diagnostics.Debug.WriteLine(corretAnswer[0, 3]);

            System.Diagnostics.Debug.WriteLine(black);//when 1 color, black=1, when two/more, black=0;
            //int blackPegs = black;
            //int whitePegs = white;

            //for(int i=0; i<blackPegs; i++)
            //{
            //    InputReplyGrid.Children[0].BackgroundColor = Color.Black;
            //    //    var pegs = new BoxView
            //    //    {
            //    //        Margin = 1,
            //    //        HeightRequest = 20,
            //    //        WidthRequest = 20,
            //    //        CornerRadius = 5,
            //    //        BackgroundColor = Color.Black,
            //    //        Opacity = 1,
            //    //        HorizontalOptions = LayoutOptions.CenterAndExpand,
            //    //        VerticalOptions = LayoutOptions.CenterAndExpand,
            //    //    };
            //    //    InputReplyGrid.Children.Add(pegs, i, 0);
            //}

            //for(int i=blackPegs; i<whitePegs+blackPegs; i++)
            //{
            //    InputReplyGrid.Children[0].BackgroundColor = Color.White;

            //    //var pegs = new BoxView
            //    //{
            //    //    Margin = 1,
            //    //    HeightRequest = 20,
            //    //    WidthRequest = 20,
            //    //    CornerRadius = 5,
            //    //    BackgroundColor = Color.White,
            //    //    Opacity = 1,
            //    //    HorizontalOptions = LayoutOptions.CenterAndExpand,
            //    //    VerticalOptions = LayoutOptions.CenterAndExpand,
            //    //};
            //    //InputReplyGrid.Children.Add(pegs, i, 0);
            //}

            switch (black)
            {
                case 1:
                    InputReplyGrid.Children[0].BackgroundColor = Color.Black;
                    break;

                case 2:
                    InputReplyGrid.Children[0].BackgroundColor = Color.Black;
                    InputReplyGrid.Children[1].BackgroundColor = Color.Black;
                    break;

                case 3:
                    InputReplyGrid.Children[0].BackgroundColor = Color.Black;
                    InputReplyGrid.Children[1].BackgroundColor = Color.Black;
                    InputReplyGrid.Children[2].BackgroundColor = Color.Black;
                    break;

                case 4:
                    InputReplyGrid.Children[0].BackgroundColor = Color.Black;
                    InputReplyGrid.Children[1].BackgroundColor = Color.Black;
                    InputReplyGrid.Children[2].BackgroundColor = Color.Black;
                    InputReplyGrid.Children[3].BackgroundColor = Color.Black;
                    break;

                default:
                    break;
            }

        }//END OF CHECKANSWER
     }//END OF MAIN PAGE
}//END OF NAMES SPACE
