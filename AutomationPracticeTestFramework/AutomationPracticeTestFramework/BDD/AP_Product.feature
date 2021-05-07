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
Scenario: Null quantity when entering a word
	Given I go to the homepage
	And I click the T-shirts tab 
	And I click the more button
	When I enter a string in the quantity field "word"
	When I click the add to cart button
	Then I should get an error alert "Null quantity."

@unhappy
Scenario: Add product with extreme quantity
	Given I go to the homepage
	And I click the T-shirts tab
	When I choose an item and click add to cart
	And I close the success popup
	And I choose an item and click more
	And I change the quantity to "9999999999999999999"
	When I click the add to cart button
	Then The items in the cart should be "(empty)"

@unhappy
Scenario: Add product with zero quantity
	Given I go to the homepage
	And I click the T-shirts tab
	When I choose an item and click more
	And I change the quantity to "0"
	When I click the add to cart button
	Then I should get an error alert "Null quantity."

@happy
Scenario: Change Quantity
	Given I go to the homepage
	And I click the T-shirts tab
	When I choose an item and click more
	And I change the quantity to "3"
	When I click the add to cart button
	Then The quantity of items in the cart should be "3"

@happy
Scenario: Remove item from cart
	Given I go to the homepage
	And I click the T-shirts tab 
	When I choose an item and click add to cart
	And I close the success popup
	And I hover my mouse over the cart and click the cart cross button
	Then The items in the cart should be "(empty)"

@happy
Scenario: Select size of item
	Given I go to the homepage
	And I click the T-shirts tab
	When I choose an item and click more
	And I select the size L
	When I click the add to cart button
	Then I should get a success alert with the selected size "L"

@unhappy
Scenario: Change quantity to negative number
	Given I go to the homepage
	And I click the T-shirts tab
	When I choose an item and click add to cart
	And I close the success popup
	And I choose an item and click more
	And I change the quantity to "-10"
	When I click the add to cart button
	Then The Quantity should be "11"

@happy
Scenario: Select color of item
	Given I go to the homepage
	And I click the T-shirts tab
	When I choose an item and click more
	And I select the color
	When I click the add to cart button
	Then I should get a success alert with the selected color "Blue"

@unhappy
	Scenario: failed add to wishlist
	Given I go to the homepage
	And I click the T-shirts tab
	When I choose an item and click more
	When I click add to wishlist
	Then I will get a pop up saying "You must be logged in to manage your wishlist."
	