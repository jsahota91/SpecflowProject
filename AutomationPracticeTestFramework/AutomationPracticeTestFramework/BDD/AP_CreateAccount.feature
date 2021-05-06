Feature: AP_CreateAccount
	As a registered user of the Automation Practice Website
	I want to be able to create an account
	So that I can buy items

@sad
Scenario: Invalid email
Given I go to the signin page
And I have entered an invalid email "invalid"
When I click the create account button
Then there should be an alert containing the error message "Invalid email address"

@sad
Scenario: Existing email
Given I go to the signin page
And I have entered an exisiting email "test@test.com"
When I click the create account button
Then there should be an alert containing the error message "An account using this email address has already been registered"

@happy
Scenario: Valid email
Given I go to the signin page
And I have entered a valid email "tinker123@gmail.com"
When I click the create account button
Then I should navigate to the url "http://automationpractice.com/index.php?controller=authentication#account-creation"
