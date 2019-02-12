using System;
using System.Collections.Generic;
using System.Text;
using Glasgow123.Models;

namespace Glasgow123.ViewModels
{
    public class FeedbackReceivedViewModel : BaseViewModel
    {
        public Feedback Item { get; set; }

        public FeedbackReceivedViewModel(Feedback selectedFeedback = null)
        {
            Title = selectedFeedback?.Comment;
            Item = selectedFeedback;
        }
    }
}
