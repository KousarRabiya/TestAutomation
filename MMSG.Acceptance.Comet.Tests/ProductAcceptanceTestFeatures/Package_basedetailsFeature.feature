Feature: Package_basedetailsFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Create new package for COMET user
	When I click on "Create New Package" in "CCEnquiry" page
	And I enter new "NewPHCNPackage" package details
	Then I should be displayed with "NewPHCNPackage" for "NewCOMETUser"

Scenario: Navigate to the Pacakage Edit page and Save the details
When I click on "Process Menu" in "CCEnquiry" page
Then I should be display with "PROCESSES" Pop up in Call Centre Enqiury screen
When I click on "Edit" option in Pop up
Then I should display "Edit Package" Page
When I change "Email" with  "testAutomation@mmsg.com.au" in Edit package Page
When I click on the Next button
When I click on the Next button
When I click on the Save Button 
Then I should be on the "CCEnquiry" page
