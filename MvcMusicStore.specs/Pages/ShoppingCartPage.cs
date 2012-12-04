using System;
using System.Linq;
using System.Threading;

using WatiN.Core;
using WatiN.Core.Native.Windows;
using WatiN.Core.Native.InternetExplorer;

namespace MvcMusicStore.Specs.Pages {
	[Page(UrlRegex = "/ShoppingCart")]
	internal class ShoppingCartPage : Page {
		private bool _wasPrinted = false;
		private PrintDialogEventHandler handler;

		[FindBy(Id = "printLink")]
		private Link PrintLink { get; set; }

		protected override void InitializeContents() {
			base.InitializeContents();
			
			handler = new PrintDialogEventHandler();
			handler.PrintDialogHandled += PrintDialogHandled;
			WebBrowser.Current.DialogWatcher.Add(handler);
			//WebBrowser.Current.AddDialogHandler(handler);
		}

		public void PrintCart() {
			PrintLink.Click();
			Thread.Sleep(1000);

			WindowsEnumerator we = new WindowsEnumerator();
			Window printDialog = we.GetChildWindows(IntPtr.Zero, "#32770").FirstOrDefault(w => w.Title == "Print");
			if (printDialog != null) {
				WebBrowser.Current.DialogWatcher.HandleWindow(printDialog);
				WebBrowser.Current.DialogWatcher.Remove(handler);
			}
		}

		private void PrintDialogHandled(object sender, EventArgs e) {
			_wasPrinted = true;
		}

		public bool CartWasPrinted() {
			return _wasPrinted;
		}
	}
}
