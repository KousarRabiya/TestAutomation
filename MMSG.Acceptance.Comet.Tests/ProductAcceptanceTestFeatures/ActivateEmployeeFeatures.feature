Feature: ActivateEmployeeFeatures
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario:Adding Admin fees to the Employee
When I click on "Process Menu" in "CCEnquiry" page
Then I should be display with "PROCESSES" Pop up in Call Centre Enqiury screen
When I click on "Admin Fees" option in Pop up
Then I should be display with  "Admin Fees for Package" in title
When I enter Effective Date in Admin Fees for Package
When I should Click on the lookup button and select Fees Name from PopUp
When I click on Add button and Save the Fees
Then I should be on the "CCEnquiry" page
