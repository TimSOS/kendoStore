using System;
using MvcMusicStore.Specs.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace MvcMusicStore.Specs.Home.Steps
{
    [Binding]
    public class NavigationSteps
    {
		private HomePage page;

        [Given(@"I am om the homepage")]
        public void GivenIAmOmTheHomepage()
        {
			WebBrowser.Current.GoTo("http://localhost:59537/");
			page = WebBrowser.Current.Page<HomePage>();
        }

		[When(@"I click the ""(.*)"" menu")]
		public void WhenIClickTheMenu(string menuName) {
			page.SelectNavigation(menuName);
		}
        
        [Then(@"I should see (.*) menu choices")]
        public void ThenIShouldSeeMenuChoices(int count)
        {
			Assert.That(page.ActiveMenuItemCount(), Is.EqualTo(count));
        }
    }
}
