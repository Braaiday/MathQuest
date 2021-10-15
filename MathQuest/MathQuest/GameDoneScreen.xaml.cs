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
    public partial class GameDoneScreen : ContentPage
    {
        public GameDoneScreen()
        {
            InitializeComponent();
            ScoreLabel.Text = Application.Current.Properties["Score"].ToString() + "/10";
        }

        private void RetryButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Game());
        }

        private void DifficultyButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DifficultyScreen());
        }
    }
}