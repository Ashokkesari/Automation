@loginFeature
Feature: SwagLabsLogin

This feature covers the SwagLab login scenarios

@Positive
Scenario Outline: Login to SwagLabs
    Given the user navigates to SwagLabs login page
	When the user enters the Username '<username>'
	Then the user enters the Password '<password>'
	Then the user clicks Sign in button
	And the user verifies the successfull login
	Examples: 
	| Browser | username      | password     |
	| chrome  | standard_user | secret_sauce |
	| edge    | standard_user | secret_sauce |


Scenario Outline: Login to SwagLabs with Invalid creds
    Given the user navigates to SwagLabs login page
	When the user enters the Username '<username>'
	Then the user enters the Password '<password>'
	Then the user clicks Sign in button
	Then the user should an error message
	Examples: 
	| Browser | username      | password |
	| chrome  | standard_user | secret   |
	

	