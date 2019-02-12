using System;
using System.Collections.Generic;
using System.Text;
using Glasgow123.Models;

namespace Glasgow123.ViewModels
{
    public class FeedbackGivenViewModel : BaseViewModel
    {
        public Feedback Item { get; set; }

        public FeedbackGivenViewModel(Feedback selectedFeedback = null)
        {
            Title = selectedFeedback?.Comment;
            Item = selectedFeedback;
        }
    }
}

