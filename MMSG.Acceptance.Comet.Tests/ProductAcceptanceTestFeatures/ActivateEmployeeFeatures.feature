Feature: ActivateEmployeeFeatures
	 Admin fees is been added to the package and the Package is made active in Review and active Page

@mytag
#Purpose:Adding the admin fees to the package
#Testcase ID:86026
#Product:Comet
#UserStory:Add the administration fee
Scenario:Adding Admin fees to the Employee
When I click on "Process Menu" in "CCEnquiry" page
Then I should be display with "PROCESSES" Pop up in Call Centre Enqiury screen
When I click on "Admin Fees" option in Pop up
Then I should be display with  "Admin Fees for Package" in title
When I enter Effective Date in Admin Fees for Package
When I should Click on the lookup button and select Fees Name from PopUp
When I click on Add button and Save the Fees
Then I should be on the "CCEnquiry" page


#Purpose:Activating the package from Review and activate page
#Testcase ID:86041
#Product:Comet
#UserStory: Activate the employee
Scenario: Activating the Employee
When I click on "Process Menu" in "CCEnquiry" page
Then I should be display with "PROCESSES" Pop up in Call Centre Enqiury screen
When I click on "Review And Activate" option in Pop up
Then I should Display the Review And Activate Package 
When I click on Save button in Review and Activate Page
Then I should be on the "CCEnquiry" page
Then I should display the package status as Active
 



