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
    public partial class DifficultyScreen : ContentPage
    {
        string Difficulty = "";
        public DifficultyScreen()
        {
            InitializeComponent();
            greeting.BackgroundColor = Color.FromRgba(17, 44, 184, 1);
        }

        private void DifficultButton_Clicked(object sender, EventArgs e)
        {
            Difficulty = "Difficult";
            Application.Current.Properties["Difficulty"] = Difficulty;
            Navigation.PushAsync(new Game());
        }

        private void IntermediateButton_Clicked(object sender, EventArgs e)
        {
            Difficulty = "Intermediate";
            Application.Current.Properties["Difficulty"] = Difficulty;
            Navigation.PushAsync(new Game());
        }

        private void EasyButton_Clicked(object sender, EventArgs e)
        {
            Difficulty = "Easy";
            Application.Current.Properties["Difficulty"] = Difficulty;
            Navigation.PushAsync(new Game());
        }
    }
}