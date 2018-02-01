Feature: CallCentreEnquiryFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Commet user search using Employee Number
When I enter "EmployeeNumber" of "COMETUser" in the search textbox
And I click on Search button
Then I should be displayed with employee information of "COMETUser"
