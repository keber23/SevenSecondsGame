using Xamarin.Forms;

namespace SevenSecondsGame.Views
{
    public partial class RateQuestionPage : ContentPage
    {
        public RateQuestionPage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            // If you want to continue going back
            base.OnBackButtonPressed();

            return true;
        }
    }
}
