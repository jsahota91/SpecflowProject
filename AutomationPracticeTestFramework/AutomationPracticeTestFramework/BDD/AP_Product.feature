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

	@unhappy
Scenario: Add product to too high a value
	Given I go to the homepage
	And I click the T-shirts tab
	When I choose an item and click add to cart
	And I close the success popup
	And I choose an item and click more
	And I change the quantity to "9999999999999999999"
	And I click the product page add to cart
	Then The items in the cart should be "(empty)"

	@unhappy
Scenario: Add product with zero quantity
	Given I go to the homepage
	And I click the T-shirts tab
	When I choose an item and click more
	And I change the quantity to "0"
	And I click the product page add to cart
	Then An error popup should appear with the message "Null quantity."