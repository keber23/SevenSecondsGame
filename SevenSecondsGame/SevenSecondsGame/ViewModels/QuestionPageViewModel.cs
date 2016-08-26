using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SevenSecondsGame.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace SevenSecondsGame.ViewModels
{
    public class QuestionPageViewModel : BindableBase, INavigationAware
    {
        private INavigationService _navigationService;
        
        private string _question;
        public string Question
        {
            get { return _question; }
            set { SetProperty(ref _question, value); }
        }

        private string _timeLeft;
        public string TimeLeft
        {
            get { return _timeLeft; }
            set { SetProperty(ref _timeLeft, value); }
        }

        private bool _isVisible;
        public bool IsVisible
        {
            get { return _isVisible; }
            set { SetProperty(ref _isVisible, value); }
        }

        private bool _timeIsVisible;
        public bool TimeIsVisible
        {
            get { return _timeIsVisible; }
            set { SetProperty(ref _timeIsVisible, value); }
        }

        public QuestionPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            
            TimeLeft = "7";
           
            Question = App.Game.GetQuestion();

            StartQuestionCommand = new DelegateCommand(StartQuestion);

            IsVisible = true;
            TimeIsVisible = false;
        }

        public DelegateCommand StartQuestionCommand { get; set; }
        
        private void StartQuestion()
        {
            IsVisible = false;
            TimeIsVisible = true;

            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                var number = float.Parse(TimeLeft) - 1;
                TimeLeft = number.ToString();
                if (number > 0)
                    return true;
                else
                {
                    _navigationService.NavigateAsync("RateQuestionPage");
                    return false;
                }
            });

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
           
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }
    }
}
