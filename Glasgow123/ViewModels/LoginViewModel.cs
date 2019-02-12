using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Glasgow123.Models;
using Xamarin.Forms;

namespace Glasgow123.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public string EmailString { get; set; }
        public string PasswordString { get; set; }

        public Person User { get; set; }

        public async Task ExecuteLoginCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                User = null;
                var item = await DataStore.LoginAsync(EmailString, PasswordString);
                User = item;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
