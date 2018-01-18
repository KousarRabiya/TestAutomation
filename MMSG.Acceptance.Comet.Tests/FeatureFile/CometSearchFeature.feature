Feature: CometSearchFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Search with Employee Number
	Given I open the browser and launch Comet application
	When I enter "EmpNum" in the employee number field
	Then I click on Search button

	Scenario: Search with Employer Code
	Given I open the browser and launch Comet application
	When I enter "EmpCode" in the employer code field
	Then I click on Search button
