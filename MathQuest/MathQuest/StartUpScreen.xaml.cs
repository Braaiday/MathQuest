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
        }
        void OnClicked(object sender, EventArgs e)
        {
           Navigation.PushAsync(new DifficultyScreen());
        }
    }
}