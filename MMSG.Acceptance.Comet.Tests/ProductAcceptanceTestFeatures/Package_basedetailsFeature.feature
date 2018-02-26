Feature: Package_basedetailsFeature
		Creating the package to the newly created employee and package related test cases are handled. 

@mytag
#Purpose:Creating the Package to new employee
#Testcase ID:86023
#Product:Comet
#UserStory: Add a package to the employee
Scenario: Create new package for COMET user
	When I click on "Create New Package" in "CCEnquiry" page
	And I enter new "NewPHCNPackage" package details
	Then I should be displayed with "NewPHCNPackage" for "NewCOMETUser"


#Purpose:Creating the Package to new employee
#Testcase ID:86038
#Product:Comet
#UserStory: Add a package to the employee
Scenario: Navigate to the Pacakage Edit page and Save the details
When I click on "Process Menu" in "CCEnquiry" page
Then I should be display with "PROCESSES" Pop up in Call Centre Enqiury screen
When I click on "Edit" option in Pop up
Then I should display "Edit Package" Page
When I change "Email" with  "testAutomation@mmsg.com.au" in Edit package Page
And I click on the Next button
And I click on the Next button
And I click on the Save Button 
Then I should be on the "CCEnquiry" page