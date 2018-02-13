Feature: YourAccountFeature	

@mytag
Scenario: MOL User View the transaction 
	Given I access application URL as "MOLUser"
	When I login as user "MOLUser"
	Then I should be on "Maxxia Online" page

	When I click on the link "View payroll deductions & transfers"
	Then I should be display with page name "Payroll Deductions & Transfers"
	When I click on the tab "Advanced Filter"


	
