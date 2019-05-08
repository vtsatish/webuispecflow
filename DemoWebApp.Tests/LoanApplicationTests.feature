Feature: LoanApplicationTests
	In order to buy
	As a cashless person
	I want to take loan

@completeapplication
Scenario: Application completed successfully
	Given I am on the loan application screen
		And I enter a first name of Sarah
		And I enter a second name of Smith
		And I select that I have an existing loan account
		And I confirm my acceptance of the terms and conditions	
	When I submit my application
	Then I should see the application complete confirmation for Sarah


@failedapplication
Scenario: Application ccould not be ompleted successfully
	Given I am on the loan application screen
		And I enter a first name of Sarah
		And I enter a second name of Smith
		And I select that I have an existing loan account
	When I submit my application
	Then I should see error message for not ccepting terms and conditions