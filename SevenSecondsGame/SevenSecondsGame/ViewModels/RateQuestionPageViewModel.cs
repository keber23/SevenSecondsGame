using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SevenSecondsGame.ViewModels
{
    public class RateQuestionPageViewModel : BindableBase
    {
        private INavigationService _navigationService;
        private IPageDialogService _dialogService;


        public DelegateCommand<string> YesCommand { get; set; }
        public DelegateCommand<string> NoCommand { get; set; }


        public RateQuestionPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;


            YesCommand = new DelegateCommand<string>(Answear);
            NoCommand = new DelegateCommand<string>(Answear);
        }

        private void Answear(string isYes)
        {
            if (isYes == "true")
            {
                //add points to current user

                App.Game.AddPointsToCurrentUser();


                if (App.Game.CheckWinner())
                {
                    //var name = App.Game.GetCurrentPlayer();

                    //_dialogService.DisplayAlertAsync("Mamy wygranego", "A jest nim: " + name, "OK");

                    _navigationService.NavigateAsync("ResultsPage");

                    //App.Current.MainPage.Navigation.


                    return;
                }

            }


            App.Game.NextPlayer();

            //check ifwe have all names and then start
            _navigationService.NavigateAsync("BeforeQuestionPage");

        }

    }
}
