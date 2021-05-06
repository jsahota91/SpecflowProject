Feature: AP_ForgotPassword
	As a registered user of the Automation Practice Website
	I want to be able to retrieve a password
	So that I can login again with the right password

@happy
Scenario: Navigate to the GetPassword Page from the signin Page
	Given I am currently on the signin page
	And I have clicked the forgot your password link
	Then I will go to the forgot your password page

@sad
Scenario: Unregistered email
	Given I am on the forgot your password page
	And I enter an unregistered email "tinker123@gmail.com"
	When I click retrieve password button
	Then I will get an alert with the message "There is no account registered for this email address."

@sad
Scenario: : Invalid email
	Given I am on the forgot your password page
	And I enter an invalid email "tim"
	When I click retrieve password button
	Then I will get an alert with the message "Invalid email address."

@happy
Scenario: Registered email
	Given I am on the forgot your password page
	And I enter a registered email "test@test.com"
	When I click retrieve password button
	Then I will get an alert with the message "A confirmation email has been sent to your address: test@test.com"


