using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SevenSecondsGame.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private INavigationService _navigationService;
        private IPageDialogService _dialogService;

        private string _firstPlayer;
        public string FirstPlayer
        {
            get { return _firstPlayer; }
            set { SetProperty(ref _firstPlayer, value); }
        }

        private string _secondPlayer;
        public string SecondPlayer
        {
            get { return _secondPlayer; }
            set { SetProperty(ref _secondPlayer, value); }
        }


        private string _thirdPlayer;
        public string ThirdPlayer
        {
            get { return _thirdPlayer; }
            set { SetProperty(ref _thirdPlayer, value); }
        }


        private string _fourthPlayer;
        public string FourthPlayer
        {
            get { return _fourthPlayer; }
            set { SetProperty(ref _fourthPlayer, value); }
        }


        public DelegateCommand StartGameCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            StartGameCommand = new DelegateCommand(StartGame);
            _navigationService = navigationService;
            _dialogService = dialogService;
        }

        private void StartGame()
        {
            //check ifwe have all names and then start
            if (string.IsNullOrEmpty(FirstPlayer))
            {
                _dialogService.DisplayAlertAsync("Alert", "You have been alerted", "OK");
                return;
            }

            App.Game.StartGame(FirstPlayer, SecondPlayer, ThirdPlayer, FourthPlayer);

            _navigationService.NavigateAsync("BeforeQuestionPage");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            //if (parameters.ContainsKey("title"))
            //    Title = (string)parameters["title"] + " and Prism";
        }
    }
}
