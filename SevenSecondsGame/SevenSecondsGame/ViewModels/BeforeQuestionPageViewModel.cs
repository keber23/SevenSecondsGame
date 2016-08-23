using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SevenSecondsGame.ViewModels
{
    public class BeforeQuestionPageViewModel : BindableBase
    {
        private INavigationService _navigationService;
        
        private string _who;
        public string Who
        {
            get { return _who; }
            set { SetProperty(ref _who, value); }
        }

        public BeforeQuestionPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            Who = App.Game.GetCurrentPlayer();
            StartQuestionCommand = new DelegateCommand(StartQuestion);
        }

        public DelegateCommand StartQuestionCommand { get; set; }

        private void StartQuestion()
        {
            //check ifwe have all names and then start
            _navigationService.NavigateAsync("QuestionPage");
            
        }
    }
}
