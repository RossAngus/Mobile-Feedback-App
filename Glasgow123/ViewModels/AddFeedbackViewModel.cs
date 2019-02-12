using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Glasgow123.Models;
using Glasgow123.ViewModels;
using Xamarin.Forms;

namespace Glasgow123.ViewModels
{
    public class AddFeedbackViewModel : BaseViewModel
    {
        public UniversityClass Item { get; set; }
        public Person ToPerson { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }

        public AddFeedbackViewModel(UniversityClass universityClass, Person person)
        {
            Item = universityClass;
            ToPerson = person;
        }

        public async Task<bool> ExecuteAddFeedbackCommand()
        {

            if (IsBusy)
                return false;

            IsBusy = true;

            try
            {
                var newFeedback = new Feedback { AuthorId = App.currentUser.Id, Comment = Comment, Date = DateTime.Now, Score = Score, ToPersonId = ToPerson.Id, UniversityClassId = Item.Id };
                IsBusy = false; 
                return await DataStore.AddFeedbackAsync(newFeedback);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                IsBusy = false; 
                return false;
            }
        }
    }
}

