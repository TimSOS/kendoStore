using System;

using NUnit.Framework;
using TechTalk.SpecFlow;

using MvcMusicStore.Specs.Pages;

namespace MvcMusicStore.Specs.ShoppingCart
{
    [Binding]
    public class PrintingSteps
    {
		ShoppingCartPage _page;

        [Given(@"I am viewing my Shopping Cart")]
        public void GivenIAmViewingMyShoppingCart()
        {
			WebBrowser.Current.GoTo("http://localhost:59537/ShoppingCart/");
			_page = WebBrowser.Current.Page<ShoppingCartPage>();
        }
        
        [When(@"I choose to Print")]
        public void WhenIChooseToPrint()
        {
			_page.PrintCart();
        }
        
        [Then(@"my Shopping Cart page should be formatted and sent to the printer")]
        public void ThenMyShoppingCartPageShouldBeFormattedAndSentToThePrinter()
        {
			Assert.That(_page.CartWasPrinted(), "Cart did not print.");
        }
    }
}
