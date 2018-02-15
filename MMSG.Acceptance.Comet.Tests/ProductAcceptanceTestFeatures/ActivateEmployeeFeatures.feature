Feature: ActivateEmployeeFeatures
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario:Adding Admin fees to the Employee
Given  I access application URL as "COMETUser"
Then I should be displayed with Comet logo
And I should be on the "CCEnquiry" page
When I enter Employee number as "13864112" and search in Call centre Enquiry
When I click on "Process Menu" in "CCEnquiry" page
Then I should be display with "PROCESSES" Pop up in Call Centre Enqiury screen
When I click on "Admin Fees" option in Pop up
