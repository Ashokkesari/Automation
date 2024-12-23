Feature: SwagLabsProducts


Background: 
    Given the user navigates to SwagLabs login page
    
@tag1
Scenario: Add to cart less than cost 10$
    When the user enters the Username '<username>'
	Then the user enters the Password '<password>'
	Then the user clicks Sign in button
	And the user verifies the successfull login
	When Add the items to cart which has less than "$10"
    Then Landed to shopping cart page
    And Added item count should match with shopping cart item count

	 Examples:  
	| Browser | username                | password     |
	| Chrome  | standard_user           | secret_sauce |