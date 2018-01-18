Feature: Payment InstructionsCreation
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
#Create ad–hoc payment instruction and verify voucher generated for ad-hoc
Scenario:TC7-Adding Adhoc Payment Instruction
	Given User opens Browser and Launch Comet Appliction
	When User Enters Newly Created Employee ID and Search
	When User clicks on the benefits
	Then User clicks on the benefit from the Benefit Grid
	Then Click on the Edit Payment Instructions from Process menu
	Then User fills all the details and selecting Payment type as Adhoc
	Then User save the Payment Instruction
	Then Verify Payment Instruction is been Created
	#Then Close browser

#Create regular payment instruction
Scenario:TC8-Adding Regular Payment Instruction
	Given User opens Browser and Launch Comet Appliction
	When User Enters Newly Created Employee ID and Search
	When User clicks on the benefits
	Then User clicks on the benefit from the Benefit Grid
	Then Click on the Edit Payment Instructions from Process menu
	Then User fills all the details and selecting Payment type as Regular
	Then User save the Payment Instruction
	Then Verify Payment Instruction is been Created
	#Then Close browser
