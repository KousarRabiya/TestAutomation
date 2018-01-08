Feature: EmployeeProfileCreation

@mytag
#Ensure user can create a new employee record successfully
Scenario: TC1-Create an Employee
	Given User opens the browser and launch Comet application
	When User clicks on new button on Comet search screen
	Then User enters all new employee creation details 
	Then User clicks on Save button and EAMS Profile will appear and User closes the EAMS Profile
	Then User lands in the Call Centre Enquiry page and created Employee Num will be shown
 	

#Ensure search functionality is working on call centre screen
Scenario: TC2-Search the Employee
	Given User opens the browser and launch Comet application
	When User enters the valid Employee number and clicks on Search button
	Then Verify Employee Details are shown	
	

#Validate a new EAMS account can be created for a new employee
Scenario: TC3-Verify EAMS is configured to new Employee
	Given User opens the browser and launch Comet application
	When User enters the valid Employee number and clicks on Search button
	Then User clicks on employee number
	Then User selects EAMS option
	Then Verify MOL Username is displayed
	

	

