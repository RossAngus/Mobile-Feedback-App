using System;
using System.Collections.Generic;
using Glasgow123.ViewModels;
using Xamarin.Forms;

namespace Glasgow123.Views.Student
{
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

            var item = new Item
            {
                Text = "Item 1",
                Description = "This is an item description.",
            };

            var students = String.Join(", ", item.Students);

            viewModel = new ItemDetailViewModel(item, students);
            BindingContext = viewModel;
        }
    }
}
