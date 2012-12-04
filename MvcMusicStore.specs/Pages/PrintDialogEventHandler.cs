using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN.Core.DialogHandlers;
using WatiN.Core.Native.Windows;

namespace MvcMusicStore.Specs.Pages {
	public class PrintDialogEventHandler : PrintDialogHandler {
		public event EventHandler PrintDialogHandled;

		public PrintDialogEventHandler() : base(PrintDialogHandler.ButtonsEnum.Cancel) {}

		public override bool HandleDialog(Window window) {
			bool success = base.HandleDialog(window);

			if (success && PrintDialogHandled != null) {
				PrintDialogHandled(this, EventArgs.Empty);
			}

			return success;
		}

		//public override bool CanHandleDialog(Window window) {
		//	bool result = base.CanHandleDialog(window);
		//	return result;
		//}

		//public override bool CanHandleDialog(Window window, IntPtr mainWindowHwnd) {
		//	bool result = base.CanHandleDialog(window, mainWindowHwnd);
		//	return result;
		//}
	}
}
