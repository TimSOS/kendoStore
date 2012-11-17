Feature: Printing
	As a shopper in order to have a permanent record of their shopping cart
	I can choose to print it

	Background: 
		Given I am viewing my Shopping Cart

Scenario: Print Cart
	When I choose to Print
	Then my Shopping Cart page should be formatted and sent to the printer
