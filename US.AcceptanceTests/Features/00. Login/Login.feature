@Story:Login

Feature: Login

Scenario: Login - Invalid email
	Given The user introduces a 'invalid' email
	When The user clicks continue button
	Then The invalid user message appears 

Scenario: Login - Valid email
	Given The user introduces a 'valid' email
	When The user clicks continue button
	Then The password input appears

Scenario: Login - Empty email
	Given The user introduces a 'empty' email
	When The user clicks continue button
	Then The invalid user message appears

Scenario: Login - Unauthorized email
	Given The user introduces a 'unauthorized' email
	When The user clicks continue button
	And The user introduces a 'valid' password
	And The user clicks continue button
	Then The unauthorized error message appears

Scenario: Login - Invalid password
	Given The user introduces a 'valid' email
	When The user clicks continue button
	And The user introduces a 'invalid' password
	And The user clicks continue button
	Then The invalid password message appears

Scenario: Login - Valid password
	Given The user introduces a 'valid' email
	When The user clicks continue button
	And The user introduces a 'valid' password
	And The user clicks continue button
	And The user confirms the login
	Then The user is at Contactos tab


Scenario: 1. Valid Login
	Given The user introduces a 'valid' email
	When The user introduces a 'valid' password
	And The user clicks Login button
	Then The user is at homepage


