Feature: PaymentInstructionFeatures
		Payment instruction is be created to the Benifit by adding the Payee type 

@mytag
#Purpose:Creating the Package to new employee
#Testcase ID:86086
#Product:Comet
#UserStory: Add a package to the employee
Scenario: Create Payment Instruction to the benefit
Given  I access application URL as "COMETUser"
Then I should be displayed with Comet logo
And I should be on the "CCEnquiry" page
When I enter "EmployeeNumber" of "COMETUser" in the search textbox from "XML"
And I click on Search button
When I click on "Benefit" in "CCEnquiry" page
Then I should be display with the Benefit Grid
When I click on the Benefit in benefit grid
Then I should be display with "PROCESSES" Pop up in Call Centre Enqiury screen


	
