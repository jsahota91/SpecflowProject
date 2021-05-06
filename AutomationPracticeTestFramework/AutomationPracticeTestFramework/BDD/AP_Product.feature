Feature: AP_Product
	As a user
	I want to add products to a cart
	So that I can buy items

@happy
Scenario: Add product to cart
	Given I go to the homepage
	And I click the T-shirts tab 
	When I choose an item and click add to cart
	Then I should get a success alert "Product successfully added to your shopping cart"