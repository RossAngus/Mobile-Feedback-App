using Glasgow123.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Glasgow123.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Browse, Title="My Classes" },
                new HomeMenuItem {Id = MenuItemType.MyProfile, Title="My Profile" },
                new HomeMenuItem {Id = MenuItemType.About, Title="About" },
                new HomeMenuItem {Id = MenuItemType.Logout, Title="Logout" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;

                if ((MenuItemType)id == MenuItemType.Logout)
                {
                    Application.Current.MainPage = new LoginPage();
                    return;
                }

                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}