using System;
using System.Collections.Generic;
using Glasgow123.Models;
using Glasgow123.ViewModels;
using Xamarin.Forms;

namespace Glasgow123.Views
{
    public partial class MyProfilePage : TabbedPage
    {

        MyProfileViewModel ViewModel { get; set; }

        public MyProfilePage(MyProfileViewModel viewModel)
        {
            InitializeComponent();

       
            BindingContext = this.ViewModel = viewModel;
        }


        async void OnFeedbackGivenSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var selectedFeedback = (args.SelectedItem as Feedback);
            if (selectedFeedback == null)
                return;

            await Navigation.PushAsync(new FeedbackGivenDetailPage(new FeedbackGivenViewModel(selectedFeedback)));

            // Manually deselect item.
            FeedbackGivenListView.SelectedItem = null;

        }

        async void OnFeedbackReceivedSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var selectedFeedback = (args.SelectedItem as Feedback);
            if (selectedFeedback == null)
                return;
            await Navigation.PushAsync(new FeedbackReceivedDetailPage(new FeedbackReceivedViewModel(selectedFeedback)));

            // Manually deselect item.
            FeedbackGivenListView.SelectedItem = null;

        }

    }
}
