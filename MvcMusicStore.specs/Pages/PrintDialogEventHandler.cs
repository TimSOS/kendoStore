using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN.Core.DialogHandlers;
using WatiN.Core.Native.Windows;

namespace MvcMusicStore.Specs.Pages {
	internal class PrintDialogEventHandler : PrintDialogHandler {
		public event EventHandler PrintDialogHandled;

		public PrintDialogEventHandler(PrintDialogHandler.ButtonsEnum buttonToPush) : base(buttonToPush) {}

		public override bool HandleDialog(Window window) {
			bool success = base.HandleDialog(window);

			if (success && PrintDialogHandled != null) {
				PrintDialogHandled(this, EventArgs.Empty);
			}

			return success;
		}
	}
}
