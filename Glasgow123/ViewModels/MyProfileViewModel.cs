using System;
using Glasgow123.Models;
using Xamarin.Forms;

namespace Glasgow123.ViewModels
{
    public class MyProfileViewModel : BaseViewModel
    {
        public Person CurrentUser { get; set; }

        public MyProfileViewModel(Person user)
        {
            CurrentUser = user;
        }
    }
}

