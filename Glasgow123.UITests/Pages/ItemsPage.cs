using Xamarin.UITest;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace Glasgow123.UITests
{
    public class ItemsPage : BasePage
    {
        readonly Query addToolbarButton;

        public ItemsPage(IApp app, Platform platform) : base(app, platform, "My Classes")
        {
            addToolbarButton = x => x.Marked("Add");
        }

        public void TapAddToolbarButton()
        {
            app.Tap(addToolbarButton);

            app.Screenshot("Toolbar Item Tapped");
        }
    }
}