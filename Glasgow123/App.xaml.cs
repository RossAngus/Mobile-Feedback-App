using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Glasgow123.Services;
using Glasgow123.Views;
using Glasgow123.Models;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Glasgow123
{
    public partial class App : Application
    {
        public static Person currentUser;
        
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        public static string AzureBackendUrl = "https://glasgow123-mobileappservice.azurewebsites.net";
        public static bool UseMockDataStore = false;

        public App()
        {
            InitializeComponent();

            //if (UseMockDataStore)
               // DependencyService.Register<MockDataStore>();
            //else
                DependencyService.Register<AzureDataStore>();

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
