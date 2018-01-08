Feature: PackageCreationAndAddingBenifit

@mytag
#Ensure user can create a new package successfully
Scenario: TC4-Adding the Package to the Employee
    Given User opens the browser and launch Comet application
	Given User enters the valid Employee number in text box
	When User clicks on the search button	 
	Then Employee Details are shown
	Then Click on the Create new package
	Then User enters all the details for creating the package and Click on the save button
	Then Verify the Package is created	
	
#Add a benefit - Amendment Screen
Scenario: TC5-1-Adding the benefit from amendment screen
    Given User opens the browser and launch Comet application
	Given User enters the valid Employee number in text box
	When User clicks on the search button	 
	Then Employee Details are shown
	Then Click on Amendments
	Then Click on New button
	Then Enter New Benefit details
	Then Click on Save button
	Then Click on Cancel button
	Then Close Browser

Scenario: TC5-Activating the new Package
    Given User opens the browser and launch Comet application
	Given User enters the valid Employee number in text box
	When  User clicks on the search button	 
	Then Employee Details are shown
	Then Click on Process Menu 
	Then User Clicks on the Admin Fees option
	Then User Add the AdminFees
	Then Click on Process Menu 
	Then User Clicks on the New Benefit option
	Then User Add Benefits
	Then Click on Process Menu 
	Then Click on Review and Activate
	Then Activate the Package 
	Then Verify the Package is activated
	

#Ensure user can edit, navigate all pages, update and SAVE changes to an existing package
Scenario:TC6-Edit Package and save the Details
    Given User opens the browser and launch Comet application
	Given User enters the valid Employee number in text box
	When  User clicks on the search button	 
	Then Employee Details are shown
	Then Click on Process Menu 
	Then User Clicks on the Edit option 
	Then User able to change Email Id And Click on the save button
	Then Click on Process Menu
	Then User Clicks on the Edit option
	Then Verify Email is Updated
	

#Ensure user can create a new main EML SP VISA card in the new package. Run the batch job and able to Order it
	Scenario:TC9-Ordering the card
	Given User opens the browser and launch Comet application
	Given User enters the valid Employee number in text box
	When  User clicks on the search button	 
	Then Employee Details are shown
	Then Click on Process Menu 
	Then User Clicks on the New Benefit option
	Then User Add Benefits
	Then Verify Card symbol appeared on call center page
	Then User click on the card symbol and check the card status is order pending
	Then User run batch file in remote machine
	Then User Verify card status is incative
	Then Close Browser


	