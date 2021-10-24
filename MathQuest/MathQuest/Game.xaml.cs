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
        int Time = 0;
        int QuestionCounter = 0;
        int QuestionCountDisplay = 1;
        int colorPicker = 0;
        public Game()
        {

            InitializeComponent();
            TimerLabel.Text = "0";
            GameTimer();
            generateQuestion();
            TimeArea.BackgroundColor = Color.FromRgba(0, 0, 0, 0.7);
            question.BackgroundColor = Color.FromRgba(0, 0, 0, 0.7);
            message.BackgroundColor = Color.FromRgba(0, 0, 0, 0.7);
        }
        void GenerateRandomNums()
        {

            if (Application.Current.Properties["Difficulty"].ToString() == "Easy")
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
            if ((answer == null) || (answer == ""))
            {
              
                DisplayAlert("Plase fill in answer", "", "OK");
            }
            else
            if (CorrectAnswer == int.Parse(answer))
            {
                message.IsVisible = true;
                message.Opacity = 0;
                message.FadeTo(1, 1500);
                message.Text = "Correct!";
                QuestionCounter++;
                Score++;
                playeranswer.IsEnabled = false;
                SubmitButton.IsEnabled = false;
                NextButton.IsEnabled = true;
                NextButton.IsVisible = true;
                SubmitButton.IsVisible = false;
                NextButtonTimer();
            }
            else
            {
                message.IsVisible = true;
                message.Opacity = 0;
                message.FadeTo(1, 1500);
                message.Text = "Incorrect!" + System.Environment.NewLine + "The answer is " + CorrectAnswer;
                QuestionCounter++;
                playeranswer.IsEnabled = false;
                SubmitButton.IsEnabled = false;
                NextButton.IsEnabled = true;
                NextButton.IsVisible = true;
                SubmitButton.IsVisible = false;
                NextButtonTimer();
            }
            
        }

        private void NextButton_Clicked(object sender, EventArgs e)
        {
            if (QuestionCounter == 10)
            {
                Application.Current.Properties["Score"] = Score;
                Application.Current.Properties["Time"] = Time;
                Navigation.PushAsync(new GameDoneScreen());
                
            }
            else
            {
                QuestionCountDisplay++;
                SubmitButton.IsVisible = true;
                NextButton.IsVisible = false;
                generateQuestion();
            }
            
        }
        void generateQuestion()
        {
            question.Opacity = 0;
            question.FadeTo(1, 1500);
            GenerateRandomNums();
            playeranswer.IsEnabled = true;
            SubmitButton.IsEnabled = true;
           
            message.IsVisible = false;
            //question.Text = Random1 + " x " + Random2 + " = " + "?";
            Num1.Text = Random1.ToString() + " ";
            MultiplySign.Text = " X ";
            Num2.Text = Random2.ToString() + " ";
            EqualSign.Text = "= ";
            QuestionMark.Text = "?";
            NextButton.IsEnabled = false;
            QuestionCount.Text = "Question " + QuestionCountDisplay + " of 10!";
        }
       
            
        

        
        bool OnTimerTick()
        {
            int curTime = int.Parse(TimerLabel.Text);
            int NewTime = curTime + 1;
            TimerLabel.Text = NewTime.ToString();
            Time++;
            return true;
        }

        bool OnTimerTick2()
        {
            var colors = new[]
            {
                new { value = Color.White, name = "white"},
                new { value = Color.Silver, name = "silver"},
                new { value = Color.Gray, name = "Gray"},
                new { value = Color.Purple, name = "Purple" },
                new { value = Color.Green, name = "Green" },
                new { value = Color.Yellow, name = "Yellow" },
                new { value = Color.Red, name = "Red" },
                new { value = Color.Pink, name = "Pink" }
            };
            
            if (colorPicker < 8)
            {
                NextButton.BackgroundColor = colors[colorPicker].value;
                colorPicker++;
            }
            else
            {
                colorPicker = 0;
                NextButton.BackgroundColor = colors[colorPicker].value;
            }
            return true;
        }

        public void NextButtonTimer()
        {
            Device.StartTimer(TimeSpan.FromSeconds(0.5), OnTimerTick2);
        }
        public void GameTimer()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
        }
    }
}