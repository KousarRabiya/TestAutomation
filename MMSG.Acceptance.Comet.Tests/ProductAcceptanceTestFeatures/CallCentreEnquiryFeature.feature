Feature: CallCentreEnquiryFeature
	This is the page where the we will search the employee using the diffrent fields

@mytag
#Purpose:Searching the employee using the DB
#Testcase ID:
#Product:Comet
#UserStory: 
Scenario: Commet user search using Employee Number from DB
When I enter "EmployeeNumber" of "NewCOMETUser" in the search textbox from "DB"
And I click on Search button
#Then I should be displayed with employee information of "NewCOMETUser"

#Purpose:Searching the employee using the XML
#Testcase ID:
#Product:Comet
#UserStory:
Scenario: Comment user search using Employee number from XML
When I enter "EmployeeNumber" of "NewCOMETUser" in the search textbox from "XML"
And I click on Search button
Then I should be displayed with employee information of "NewCOMETUser"