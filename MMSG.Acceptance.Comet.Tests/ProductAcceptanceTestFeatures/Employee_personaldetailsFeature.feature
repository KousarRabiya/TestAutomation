Feature: Employee_personaldetailsFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Create New Employee as commet user
	When I click on "New" in "CCEnquiry" page
	Then I should be on "Employee" page
	When I enter new "NewCOMETUser" employee details
	Then I should be on "Maxxia Account Snapin" popup
	When I click on "cancel" button in "Maxxia Account Snapin" popup
	Then I should be on the "CCEnquiry" page
