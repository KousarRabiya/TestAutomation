Feature: TransactionFeature
	
@mytag
Scenario: Display Wallet Transactions - User is able to view the card balance if he has SP Card Only
	When I navigate to "Your Account" tab 
	Then I should be displayed with "View Account:" dropdown and contains "RemServ Wallet" value
	Then I should be displayed with "From:" dropdown and contains "Living Expenses (RemServ Wallet)" value
	Then I should be displayed with Available Balance
