using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using UniwersalneProjekt.Models;
using UniwersalneProjekt.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;

namespace UniwersalneProjekt.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DoQuizPage : ContentPage
	{
        DoQuizViewModel viewModel;
        ListView listView;
		public DoQuizPage (DoQuizViewModel doQuizViewModel)
		{
			InitializeComponent ();

            BindingContext = viewModel = doQuizViewModel;

            
        }
        public DoQuizPage()
        {
            InitializeComponent();

            var category = new Category
            {
                Name = "Category 1",
                Questions = null
            };

            viewModel = new DoQuizViewModel(category);
            BindingContext = viewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var mainLayout = new StackLayout();
            var dataTemplate = new DataTemplate(() =>
            {
                var listViewLayout = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Padding = 10,
                    HorizontalOptions=LayoutOptions.FillAndExpand
                };
                var letterLabel = new Label {  FontSize=16};
                var answerTextLabel = new Label {  FontSize = 16 };
                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped1;
                listViewLayout.GestureRecognizers.Add(tapGestureRecognizer);
                letterLabel.SetBinding(Label.TextProperty, "AnswerLetter");
                answerTextLabel.SetBinding(Label.TextProperty, "AnswerText");
                listViewLayout.Children.Add(letterLabel);
                listViewLayout.Children.Add(answerTextLabel);
                listViewLayout.BackgroundColor = Color.Green;
                var vc = new ViewCell { View=listViewLayout};
                //vc.View.BackgroundColor = Color.Wheat;
                vc.Tapped+= TapGestureRecognizer_Tapped;
                return vc;

            });
            foreach (var q in viewModel?.Questions)
            {
                bool questionWorks = false;
                int asciiLetter = 65;
                foreach (var a in q?.Answers)
                {
                    if (a.IsCorrect)
                    {
                        questionWorks = true;
                    }
                    a.Selected = false;
                    a.AnswerLetter = (char)asciiLetter;
                    asciiLetter++;
                }
                if (q.Answers.Count <= 1)
                {
                    questionWorks = false;
                }
                if (questionWorks)
                {
                    var layout = new StackLayout
                    {
                        Spacing = 20,
                        Padding = 15
                    };
                    var label = new Label
                    {
                        Text = q.QuestionText,
                        FontSize = 16
                    };
                    layout.Children.Add(label);
                    listView = new ListView();
                    listView.ItemsSource = q.Answers;
                    int i = q.Answers.Count;
                    int heightRowList = 45;
                    i = (i * heightRowList);
                    listView.HeightRequest = i;
                    listView.ItemTemplate = dataTemplate;
                    listView.ItemSelected +=OnAnswerSelected;
                    layout.Children.Add(listView);
                    mainLayout.Children.Add(layout);
                }
            }
            var completeButton = new Button
            {
                Text = "Zakończ quiz"
            };
            completeButton.Clicked += Button_Clicked1;
            mainLayout.Children.Add(completeButton);
            Content = new ScrollView
            {
                Content = mainLayout
            };
        }
        async void OnAnswerSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (args.SelectedItem != null)
            {
                Answer a = args.SelectedItem as Answer;
                ListView lv = sender as ListView;
                lv.SelectedItem = null;
                if (a.Selected == false)
                {
                    a.Selected = true;
                    
                }
                else
                {
                    a.Selected = false;
                }
                Debug.WriteLine(a.Selected);
            }
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var vc = sender as ViewCell;
            if (vc.View.BackgroundColor == Color.Default)
            {
                //vc.View.BackgroundColor = Color.FromRgb(0,100,0);
                vc.View.BackgroundColor = Color.Green;
                Debug.WriteLine(vc.View.BackgroundColor);
            }
            else
            {
                vc.View.BackgroundColor = Color.Default;
                Debug.WriteLine(vc.View.BackgroundColor);
            }
        }
        private void TapGestureRecognizer_Tapped1(object sender, EventArgs e)
        {
            var layout = sender as StackLayout;
            if (layout.BackgroundColor == Color.Default)
            {
                layout.BackgroundColor = Color.Green;
                Debug.WriteLine(layout.BackgroundColor);
            }
            else
            {
                layout.BackgroundColor = Color.Default;
                Debug.WriteLine(layout.BackgroundColor);
            }
        }
        private void Button_Clicked1(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button.BackgroundColor == Color.Green)
            {
                button.BackgroundColor = Color.Default;
                button.BorderColor = Color.Default;
            }
            else
            {
                button.BackgroundColor = Color.Green;
                button.BorderColor = Color.Green;
            }
        }
    }
}