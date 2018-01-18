Feature: CommonAcceptanceTestFeatures
	This file contains scenarios which are common across all the pages

@mytag
Scenario: Login as ROL user
Given I access application URL as "ROLUser"
When I login as user "ROLUser"
Then I should be on "RemServ Online" page

Scenario: Logout as ROL User
When I click on Logout link as "ROLUser"
Then I should be on "RemServ Online" page