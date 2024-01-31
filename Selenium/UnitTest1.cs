using NUnit.Framework;

namespace Selenium
{
    [TestFixture]
    public class Tests : TestSetup
    {
        [Test]
        public void BasicSetup()
        {
            NavigateAndAssertUrl("https://stackoverflow.com/");

            if (IsElementVisibleById("onetrust-banner-sdk"))
            {
                // If visible, click on the element with ID "onetrust-accept-btn-handler"
                ClickElementById("onetrust-accept-btn-handler");
            }

            ClickOnProductInNavigation("Products");
            sleep(2);
            ClickOnProductInNavigation("For Teams");
            sleep(2);
        }
    }
}

