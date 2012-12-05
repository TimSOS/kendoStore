Feature: Navigation
	In order to easily manuever the site
	A user can use the navigation menus

Scenario: Genre menu has multiple items
	Given I am om the homepage
	 When I click the "Genre" menu
	 Then I should see 9 menu choices
