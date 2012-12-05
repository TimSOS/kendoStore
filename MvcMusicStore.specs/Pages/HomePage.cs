using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatiN.Core;

namespace MvcMusicStore.Specs.Pages {
	[Page(UrlRegex = "/")]
	internal class HomePage : Page {
		private ListItem _activeMenu;

		[FindBy(Id = "menu")]
		private List menuList { get; set; }

		internal void SelectNavigation(string menuName) {
			_activeMenu = menuList.ChildrenOfType<ListItem>().FirstOrDefault(li => li.Text.StartsWith(menuName));

			if (_activeMenu != null) {
				_activeMenu.MouseDown();
			}
		}

		internal int ActiveMenuItemCount() {
			if (_activeMenu == null) {
				return 0;
			} else {
				return _activeMenu.ChildOfType<List>(Find.ByClass("k-group")).ChildrenOfType<ListItem>().Count;
			}
		}
	}
}
