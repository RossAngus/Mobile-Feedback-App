using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Glasgow123.Models;
using Glasgow123.ViewModels;
using Glasgow123.MobileAppService.Models.Relationships;

namespace Glasgow123.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FeedbackGivenDetailPage : ContentPage
	{
        FeedbackGivenViewModel viewModel;

        public FeedbackGivenDetailPage (FeedbackGivenViewModel viewModel)
		{
			InitializeComponent ();

            BindingContext = this.viewModel = viewModel;
        }
        public FeedbackGivenDetailPage()
        {
            InitializeComponent();

            // Bind data
            var item = new Feedback
            {
                Comment = "Item 1",
                Score = 1,
            };

            viewModel = new FeedbackGivenViewModel(item);
            BindingContext = viewModel;
        }
    }

}