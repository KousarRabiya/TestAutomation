Feature: CommonAcceptanceTestFeatures
	This file contains scenarios which are common across all the pages

@mytag
Scenario: Login as ROL user
	Given I access application URL as "ROLUser"
	When I login as user "ROLUser"
	Then I should be on "RemServ Online" page

Scenario: Login as ROL Wallet Transaction User
	Given I access application URL as "ROLWalletTransactionUser"
	When I login as user "ROLWalletTransactionUser"
	Then I should be on "RemServ Online" page

Scenario: Login as ROL Non-Wallet Transaction User
	Given I access application URL as "ROLNonWalletTransactionUser"
	When I login as user "ROLNonWalletTransactionUser"
	Then I should be on "RemServ Online" page

Scenario: Logout as ROL User
	When I click on Logout link as "ROLUser"
	Then I should be on "RemServ Online" page

Scenario: Logout as ROL Wallet Transaction User
	When I click on Logout link as "ROLWalletTransactionUser"
	Then I should be on "RemServ Online" page