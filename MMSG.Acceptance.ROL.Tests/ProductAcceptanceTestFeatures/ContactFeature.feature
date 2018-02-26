Feature: ContactFeature
	

@mytag
Scenario: ROL user validate data in default view of Contact us page
When I navigate to "Contact" tab 
Then I should be displayed with "ROLUser" details

Scenario: ROL user Lodges the Request 
Then I should be display "I want to" dropdown
When I select "Make a change to my package" in the dropdown "I want to"
Then I should be display "Change" dropdown
When I select "Add a new benefit to my package" in the dropdown "Change"
Then I should be display "Add benefit" dropdown
When I select "Adjustment" in the dropdown "Add benefit"
Then I should be display "Deduction per pay" dropdown
When I Enter the "Amount"
When I select the Radio Button "Once off deduction"
When I select the Radio Button "Select a pay date"
Then I should be display "Pay date for change" dropdown
When I select "22/03/2018" in the dropdown "Pay date for change"
When I Enter the "Phone"
When I Enter the "Email"
When I select the Radio Button "Phone"
When I Enter the "Message"
When I click on "Submit" Button
Then I should be displayed with "Thank you for contacting RemServ. We will respond to your request within four working days." message



