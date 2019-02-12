using System;
using System.Collections.Generic;
using Glasgow123.ViewModels;
using Xamarin.Forms;

namespace Glasgow123.Views
{
    public partial class LoginPage : ContentPage
    {
        LoginViewModel viewModel;

        public LoginPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new LoginViewModel();
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            await viewModel.ExecuteLoginCommand();

            if (viewModel.User != null)
            {
                App.currentUser = viewModel.User;
                Application.Current.MainPage = new MainPage();
            }
            else
            {
                messageLabel.Text = "Login Failed";
                passwordEntry.Text = string.Empty;
            }
        }

        async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new RegisterPage();
        }
    }
}
