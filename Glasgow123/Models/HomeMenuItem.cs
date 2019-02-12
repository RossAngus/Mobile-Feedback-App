using System;
using System.Collections.Generic;
using System.Text;

namespace Glasgow123.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        MyProfile,
        Logout
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
