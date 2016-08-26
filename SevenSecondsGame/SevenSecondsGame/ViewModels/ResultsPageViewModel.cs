using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SevenSecondsGame.ViewModels
{
    public class ResultsPageViewModel : BindableBase
    {
        private INavigationService _navigationService;

        public DelegateCommand NewGameCommand { get; set; }
        public DelegateCommand ExitCommand { get; set; }

        private List<string> _players;
        public List<string> Players
        {
            get { return _players; }
            set { SetProperty(ref _players, value); }
        }
        public ResultsPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NewGameCommand = new DelegateCommand(NewGame);

            //Players = new List<string>() {" sfds", "sdfdsfds", "sdfsdfds" };

            Players = App.Game.GetPlayersScores();
        }

        private void NewGame()
        {
            _navigationService.NavigateAsync("MainPage");
        }

    }
}
