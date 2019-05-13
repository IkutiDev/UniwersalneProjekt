using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using UniwersalneProjekt.Models;
using UniwersalneProjekt.ViewModels;

namespace UniwersalneProjekt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryDetailPage : ContentPage
    {
        CategoryDetailViewModel viewModel;

        public CategoryDetailPage(CategoryDetailViewModel categoryDetailViewModel)
        {
            InitializeComponent();

            BindingContext = viewModel = categoryDetailViewModel;
        }

        public CategoryDetailPage()
        {
            InitializeComponent();

            var category = new Category
            {
                Name = "Category 1",
                Questions = null
            };

            viewModel = new CategoryDetailViewModel(category);
            BindingContext = viewModel;
        }
        async void OnQuestionSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var question = args.SelectedItem as Question;
            if (question == null)
                return;

            await Navigation.PushAsync(new QuestionDetailPage(new QuestionDetailViewModel(question,viewModel.Category)));

            // Manually deselect item.
            QuesionsListView.SelectedItem = null;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

                viewModel.LoadQuestionsCommand.Execute(null);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddQuestion(new QuestionViewModel(viewModel.Category)));
        }
        private void Button_Clicked1(object sender, EventArgs e)
        {
            var button = sender as Button;
            var question = button?.BindingContext as Question;
            var vm = BindingContext as CategoryDetailViewModel;
            vm?.DeleteQuestionCommand.Execute(question);
            vm?.LoadQuestionsCommand.Execute(null);
        }

    }
}