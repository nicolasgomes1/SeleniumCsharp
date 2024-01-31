using BrowserSetup;

namespace Selenium
{
    public class Tests : TestSetup
    {
        [SetUp]
        public void CommonSetup()
        {
            NavigateAndAssertUrl("https://stackoverflow.com/");
            AcceptCookies();
            ClickOnProductInNavigation("Products");
        }

        [TestCase(TestName = "Navigate to Stack Overflow")]
        public void NavigateToStackOverflow()
        {
            DropDownOptions("Stack Overflow");
            AssertUrl("https://stackoverflow.com/questions");
        }

        [TestCase(TestName = "Navigate to Stack Overflow for teams")]
        public void NavigateToStackOverflowforTeams()
        {
            DropDownOptions("Stack Overflow for Teams");
            AssertUrl("https://stackoverflow.co/teams/");
        }

        [TestCase(TestName = "Navigate to Talent")]
        public void NavigateToTalent()
        {
            DropDownOptions("Talent");
            AssertUrl("https://stackoverflow.co/advertising/employer-branding/");
        }

        [TestCase(TestName = "Navigate to Advertising")]
        public void NavigateToAdvertising()
        {
            DropDownOptions("Advertising");
            AssertUrl("https://stackoverflow.co/advertising/");
        }

        [TestCase(TestName = "Navigate to Labs")]
        public void NavigateToLabs()
        {
            DropDownOptions("Labs");
            AssertUrl("https://stackoverflow.co/labs/");
        }

        [TestCase(TestName = "Navigate to About the company")]
        public void NavigateToAbout()
        {
            DropDownOptions("About the company");
            AssertUrl("https://stackoverflow.co/");
        }
    }
}

