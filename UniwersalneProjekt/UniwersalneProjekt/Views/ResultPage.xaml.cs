using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniwersalneProjekt.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniwersalneProjekt.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ResultPage : ContentPage
	{
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        public ResultPage (ObservableCollection<Question> questions)
		{
			InitializeComponent ();
            var mainLayout = new StackLayout();
            bool correct;
            int score = 0;
            if (questions != null)
            {
                int totalScore = questions.Count;
                foreach (var q in questions)
                {
                    if (q.Answers != null)
                    {
                        correct = true;
                        foreach(var a in q.Answers)
                        {
                            if ((a.Selected==true&&a.IsCorrect==false)||(a.Selected==false && a.IsCorrect==true))
                            {
                                correct = false;
                                break;
                            }
                            a.Selected = false;
                        }
                        if (correct)
                        {
                            score++;
                        }
                    }
                }
                var resultLabel = new Label
                {
                    Text ="Your managed to score "+score+" questions correctly out of total "+totalScore+". The percentage result is: "+Math.Truncate((double)score/totalScore*100)+"%",
                    FontSize = 16
                };
                mainLayout.Children.Add(resultLabel);
                Content = mainLayout;
            }

        }
        protected async override void OnDisappearing()
        {
            await Navigation.PopToRootAsync();
        }
    }
}