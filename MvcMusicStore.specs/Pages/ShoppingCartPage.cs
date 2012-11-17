using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN.Core;
using WatiN.Core.DialogHandlers;

namespace MvcMusicStore.Specs.Pages {
	[Page(UrlRegex = "/ShoppingCart")]
	internal class ShoppingCartPage : Page {
		private bool _wasPrinted = false;

		[FindBy(Id = "printLink")]
		private Link PrintLink { get; set; }

		public void PrintCart() {
			//WebBrowser.Current.DialogWatcher.CloseUnhandledDialogs = true;
			//PrintDialogEventHandler handler = new PrintDialogEventHandler(PrintDialogHandler.ButtonsEnum.Cancel);
			//handler.PrintDialogHandled += PrintDialogHandled;
			//using (new UseDialogOnce(WebBrowser.Current.DialogWatcher, handler)) {
			PrintDialogHandler handler = new PrintDialogHandler(PrintDialogHandler.ButtonsEnum.Cancel);
			WebBrowser.Current.DialogWatcher.Add(handler);
				PrintLink.Click();
			//}

				WebBrowser.Current.WaitForComplete();
		}

		private void PrintDialogHandled(object sender, EventArgs e) {
			_wasPrinted = true;
		}

		public bool CartWasPrinted() {
			return _wasPrinted;
		}
	}
}
