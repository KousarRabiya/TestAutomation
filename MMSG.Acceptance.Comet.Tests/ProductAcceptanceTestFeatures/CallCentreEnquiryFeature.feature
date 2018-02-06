Feature: CallCentreEnquiryFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Commet user search using Employee Number from DB
When I enter "EmployeeNumber" of "NewCOMETUser" in the search textbox from "DB"
And I click on Search button
#Then I should be displayed with employee information of "NewCOMETUser"

Scenario: Comment user search using Employee number from XML
When I enter "EmployeeNumber" of "NewCOMETUser" in the search textbox from "XML"
And I click on Search button
Then I should be displayed with employee information of "NewCOMETUser"