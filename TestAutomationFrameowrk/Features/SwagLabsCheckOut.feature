Feature: SwagLabsCheckOut


@checkout
Scenario Outline: Login to SwagLabs
    Given the user navigates to SwagLabs login page
	When the user enters the Username '<username>'
	Then the user enters the Password '<password>'
	Then the user clicks Sign in button
	 And the user verifies the successfull login
	 When Add the items to cart which has less than "$10"
     Then Landed to shopping cart page
     And Added item count should match with shopping cart item count
	 And shopping cart page
	 And checkout the item
	 Then navigate successfully to checkout page
	 Then checkout user page
	 Then perform continue
	 Then should see the error message "Error: First Name is required"

	 Examples:  
	| Browser | username                | password     |
	| Chrome  | standard_user           | secret_sauce |
	| Chrome  | problem_user            | secret_sauce |
	| Chrome  | performance_glitch_user | secret_sauce |
	| Chrome  | standard_user           | secret_sauce |
	| Chrome  | error_user              | secret_sauce |