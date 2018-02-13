Feature: Package_basedetailsFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Create new package for COMET user
	When I click on "Create New Package" in "CCEnquiry" page
	And I enter new "NewPHCNPackage" package details
	Then I should be displayed with "NewPHCNPackage" for "NewCOMETUser"