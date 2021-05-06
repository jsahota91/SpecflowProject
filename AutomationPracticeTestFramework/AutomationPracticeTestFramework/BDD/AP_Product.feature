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
  
@sad
Scenario: Null quantity when entering a word
	Given I go to the homepage
	And I click the T-shirts tab 
	And I click the more button
	When I enter a string in the quantity field "word"
	When I click the add to cart button
	Then I should get an error alert "Null quantity."

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
	When I click the add to cart button
	Then I should get an error alert "Null quantity."