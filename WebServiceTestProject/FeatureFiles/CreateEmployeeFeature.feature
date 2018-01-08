Feature: CreateEmployeeFeature

Scenario: Verify New Employee Created
	Given Opens the browser and launch Comet Website
	When User Enters the newly created Employee number in Search Bar
	Then User clicks on the search button
	Then Wait until employee search grid is displayed
	Then Verify whether employee grid is displayed
	Then Close the Browser
