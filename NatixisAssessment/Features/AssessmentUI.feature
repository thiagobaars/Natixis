@UI
Feature: Assessment UI

Scenario 2 - UI Validation

Scenario:(1) - Login to the app
	Given I acess the url of aplication
	And I fill the the fields Login and Password with the values 'standard_user' and 'secret_sauce'
	When I click to the button Login
	Then the homepage must be shown

Scenario:(2) - Add two products to the cart
	When I choose the first product and click the button Add to Cart 
	And I click to add the second product
	Then the cart icon must show 2 products

Scenario:(3) - Go to cart page 
	Given I click the cart icon
	Then the selected itens must appear in the page

Scenario:(4) - Go to Checkout page 
	Given I click the Checkout button
	When I fill the the fields First, Last Name and Zip Code with the values 'Thiago', 'Baars' and '123456'
	And I click the Continue button
	Then I verify the sum of the items prices, tax and total
	And I click in the Finish button
	And I verify if the message 'THANK YOU FOR YOUR ORDER' is displayed
