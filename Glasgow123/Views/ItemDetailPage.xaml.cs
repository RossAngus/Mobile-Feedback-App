using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Glasgow123.Models;
using Glasgow123.ViewModels;
using Glasgow123.MobileAppService.Models.Relationships;

namespace Glasgow123.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            // Bind data
            var item = new UniversityClass
            {
                Title = "Item 1",
                Description = "This is an item description.",
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }

        async void OnStudentSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var personClass = (args.SelectedItem as PersonClass);
            if (personClass == null)
                return;

            var feedbackViewModel = new AddFeedbackViewModel(viewModel.Item, personClass.Person);
            await Navigation.PushModalAsync(new NavigationPage(new NewFeedbackPage(feedbackViewModel)));

            // Manually deselect item.
            StudentListView.SelectedItem = null;
        }
    }
}