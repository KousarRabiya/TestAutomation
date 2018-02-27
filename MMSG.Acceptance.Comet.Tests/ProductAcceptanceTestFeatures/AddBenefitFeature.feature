Feature: AddBenefitFeature	

@mytag
Scenario: Add a benefit - Process Menu
	When I click on "Process Menu" in "CCEnquiry" page
	Then I should be display with "PROCESSES" Pop up in Call Centre Enqiury screen
	When I click on "New Benefit" option in Pop up
	Then I will land on New Benefit page
	Then I select "Insurance Life" in "Benefit"
	Then I click on "Next" Button
	Then I select "Per Annum" in "Budget Calculation Method"
	Then I enter Budget Amount
	Then I click on "Save" Button
	
