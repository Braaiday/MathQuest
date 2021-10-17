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
    public partial class StartUpScreen : ContentPage
    {
        public StartUpScreen()
        {
            InitializeComponent();
            MyButton.BackgroundColor = Color.FromRgba(255, 247, 5, 0.8);
            WelcomeFrame.BackgroundColor = Color.FromRgba(255, 247, 5, 0);
            PlayFrame.BackgroundColor = Color.FromRgba(255, 247, 5, 0);
            GreetingsLabel.BackgroundColor = Color.FromRgba(0, 0, 0, 0.8);
        }
        void OnClicked(object sender, EventArgs e)
        {
           Navigation.PushAsync(new DifficultyScreen());
        }
    }
}