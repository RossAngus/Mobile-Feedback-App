using System;
using Glasgow123.Models;

namespace Glasgow123.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public UniversityClass Item { get; set; }

        public ItemDetailViewModel(UniversityClass item = null)
        {
            Title = item?.Title;
            Item = item;
        }
    }
}
