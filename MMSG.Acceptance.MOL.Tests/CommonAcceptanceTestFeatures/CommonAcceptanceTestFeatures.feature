Feature: CommonAcceptanceTestFeatures
	This file contains scenarios which are common across all the pages

@mytag
Scenario: Login as MOL user
	Given I access application URL as "MOLUser"
	When I login as user "MOLUser"
	Then I should be on "Maxxia Online" page

Scenario: Login as MOL Wallet Transaction User
	Given I access application URL as "MOLWalletTransactionUser"
	When I login as user "MOLWalletTransactionUser"
	Then I should be on "Maxxia Online" page

Scenario: Logout as MOL User
	When I click on Logout link as "MOLUser"
	Then I should be on "Maxxia Online" page

Scenario: Logout as MOL Wallet Transaction User
	When I click on Logout link as "MOLWalletTransactionUser"
	Then I should be on "Maxxia Online" page
