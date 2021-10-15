﻿using System;
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
        Boolean Timercontrol = false;
        public Game()
        {

            InitializeComponent();
            generateQuestion();
            question.BackgroundColor = Color.FromRgba(0, 0, 0, 0.7);
            Error.BackgroundColor = Color.FromRgba(0, 0, 0, 0.7);
            message.BackgroundColor = Color.FromRgba(0, 0, 0, 0.7);
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
            if (answer == null)
            {
                Error.IsVisible = true;
                Error.Text = "Please fill in a answer!";
                Error.FadeTo(1, 1500);
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
                AnimateNextQuetionBtton();

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
                AnimateNextQuetionBtton();
            }
            
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
                Timercontrol = false;
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
            Error.IsVisible = false;
            message.IsVisible = false;
            question.Text = Random1 + " x " + Random2 + " = " + "?";
            NextButton.IsEnabled = false;
        }
        void AnimateNextQuetionBtton()
        {
            Timercontrol = true;
            var colors = new[]
            {
                new { value = Color.White, name = "white"},
                new { value = Color.Silver, name = "silver"},
                new { value = Color.Gray, name = "Gray"},
                new { value = Color.Black, name = "Black"},
                new { value = Color.Purple, name = "Purple" },
                new { value = Color.Green, name = "Green" },
                new { value = Color.Yellow, name = "Yellow" },
                new { value = Color.Red, name = "Red" },
                new { value = Color.Pink, name = "Pink" }
            };
            foreach (var color in colors)
            {
                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    if (Timercontrol == true)
                    {
                        NextButton.BackgroundColor = color.value;
                        return true;
                    }

                    else return false;
                });
            }
            
        }
    }
}