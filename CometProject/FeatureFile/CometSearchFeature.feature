Feature: CometSearchFeature
	Gets Comet search parameters from Database

Scenario: Search with Employee Number
	Given I open the browser and launch Comet application
	When I enter "EmpNum" in the employee number field
	Then I click on Search button
	

Scenario: Search with Employer Code
	Given I open the browser and launch Comet application
	When I enter "EmpCode" in the employer code field
	Then I click on Search button
	
	
