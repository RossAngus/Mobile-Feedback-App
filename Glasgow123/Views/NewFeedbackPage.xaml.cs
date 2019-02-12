using System;
using System.Collections.Generic;
using Glasgow123.Models;
using Glasgow123.ViewModels;
using Xamarin.Forms;

namespace Glasgow123.Views
{
    public partial class NewFeedbackPage : ContentPage
    {
        AddFeedbackViewModel viewModel;

        public NewFeedbackPage(AddFeedbackViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            bool success = await viewModel.ExecuteAddFeedbackCommand();
            if (success) { 
                await Navigation.PopModalAsync(); 
            }

        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
