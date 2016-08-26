using Prism.Unity;
using SevenSecondsGame.Game;
using SevenSecondsGame.Views;
using Xamarin.Forms;

namespace SevenSecondsGame
{
    public partial class App : PrismApplication
    {
        public static MainGame Game;

        public App(IPlatformInitializer initializer = null) : base(initializer) { Game = new MainGame(); }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("ResultsPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<BeforeQuestionPage>();
            
            Container.RegisterTypeForNavigation<QuestionPage>();
            Container.RegisterTypeForNavigation<RateQuestionPage>();

            Container.RegisterTypeForNavigation<ResultsPage>();
        }
    }
}
