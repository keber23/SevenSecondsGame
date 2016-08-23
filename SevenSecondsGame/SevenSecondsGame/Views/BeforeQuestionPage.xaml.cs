using Xamarin.Forms;

namespace SevenSecondsGame.Views
{
    public partial class BeforeQuestionPage : ContentPage
    {
        public BeforeQuestionPage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            // If you want to continue going back
            base.OnBackButtonPressed();

            return true;
            //var res = Question();

            //Device.StartTimer(new TimeSpan(0, 0, 10), async () => {
            //    var tiempo = await DisplayAlert("time passed", "time has passed buddy", "ok", "no way!");

            //    return true;
        }

        private async System.Threading.Tasks.Task<bool> Question()
        {
            var answer = await DisplayAlert("Question?", "Would you like to end the game", "Yes", "No");

            return answer;
        }

    }
}
