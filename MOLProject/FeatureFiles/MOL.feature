Feature: View benefits and Transaction in MOL Application.

#Login to MOL and navigate to Dashboard
Scenario: TC1-MOL View the benefits	
	Given User able to launch the MOL application 
	When User Login to the application using valid credentials
	Then User able to view benefits
	     

#View benefits and balances and view benefit transactions to the past 18 months
Scenario: TC2-MOL View the Transaction	
	Given User able to launch the MOL application
	When User Login to the application using valid credentials 	  
	Then User Clicks on View payroll and deduction.
	Then User Clicks on the Advance filter and set Date Picker
	Then User able to view  transaction
	
Scenario: MOL Login with Invalid Username	
	Given User able to launch the MOL application
	When User Login to the application using valid credentials  	  
	
     