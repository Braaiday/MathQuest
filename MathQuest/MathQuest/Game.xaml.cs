using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MathQuest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Game : ContentPage
    {
        int Random1 = 0;
        int Random2 = 0;
        int Score = 0;
        int QuestionCounter = 0;
        public Game()
        {

            InitializeComponent();
            generateQuestion();

        }
        void GenerateRandomNums()
        {

            if ( Application.Current.Properties["Difficulty"].ToString() == "Easy")
            {
                Random random = new Random();
                Random1 = random.Next(6);
                Random2 = random.Next(6);
            }
            else if (Application.Current.Properties["Difficulty"].ToString() == "Intermediate")
            {
                Random random = new Random();
                Random1 = random.Next(13);
                Random2 = random.Next(13);
            }
            else if (Application.Current.Properties["Difficulty"].ToString() == "Difficult")
            {
                Random random = new Random();
                Random1 = random.Next(100);
                Random2 = random.Next(100);
            }
        }
        public int CalculateAnswer(int x, int y)
        {
            return x * y;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void SubmitButton_Clicked(object sender, EventArgs e)
        {
            int CorrectAnswer = CalculateAnswer(Random1, Random2);
            string answer = playeranswer.Text;
            if (CorrectAnswer == int.Parse(answer))
            {
                message.Text = "Correct!";
                QuestionCounter++;
                Score++;
                playeranswer.IsEnabled = false;
            }
            else
            {
                message.Text = "Incorrect!&#10; The answer is " + CorrectAnswer;
                QuestionCounter++;
                playeranswer.IsEnabled = false;
            }
            SubmitButton.IsEnabled = false;
            NextButton.IsEnabled = true;
        }

        private void NextButton_Clicked(object sender, EventArgs e)
        {
            if (QuestionCounter == 10)
            {
                Application.Current.Properties["Score"] = Score;
                Navigation.PushAsync(new GameDoneScreen());
                
            }
            else
            {
                generateQuestion();
            }
            
        }
        void generateQuestion()
        {
            GenerateRandomNums();
            playeranswer.IsEnabled = true;
            SubmitButton.IsEnabled = true;
            question.Text = Random1 + " x " + Random2;
            NextButton.IsEnabled = false;
        }
    }
}