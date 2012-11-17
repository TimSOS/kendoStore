using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using WatiN.Core;

namespace MvcMusicStore.Specs {
	[Binding]
	public class SpecHelper {
		// For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

		[BeforeScenario]
		public void BeforeScenario() {
			//TODO: implement logic that has to run before executing each scenario
		}

		[AfterScenario]
		public void AfterScenario() {
			//TODO: implement logic that has to run after executing each scenario
		}
	}

	public static class WebBrowser {
		public static IE Current {
			get {
				if (!ScenarioContext.Current.ContainsKey("browser")) {
					ScenarioContext.Current.Add("browser", new IE());
				}

				return (IE)ScenarioContext.Current["browser"];
			}
		}
	}
}
