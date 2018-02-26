Feature: Employee_personaldetailsFeature
		In this feature file we are creating the employee and Other employee related test cases are added 

@mytag

#Purpose:Creating the employee 
#Testcase ID:86010
#Product:Comet
#UserStory: Create an employee 
Scenario: Create New Employee as commet user
	When I click on "New" in "CCEnquiry" page
	Then I should be on "Employee" page
	When I enter new "NewCOMETUser" employee details
	Then I should be on "Maxxia Account Snapin" popup
	When I click on "cancel" button in "Maxxia Account Snapin" popup
	Then I should be on the "CCEnquiry" page
