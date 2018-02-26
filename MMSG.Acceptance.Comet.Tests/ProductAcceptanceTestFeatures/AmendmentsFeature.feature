Feature: AmendmentsFeature
	This is the page where we can get the Payroll Details,Current Reimbursement Details and Benefit Details.
	We can add benefit to the package through this screen.

@mytag
#Purpose:Adding the Benefit to the Package from Amendment screen
#Testcase ID:
#Product:Comet
#UserStory: Add a benefit - Amendment Scrren
Scenario: Add Benefit to the package through Amendment screen
	When I click on "Amendment" in "CCEnquiry" page
	Then I should be on the Amendment page
	When I click on "New" in Amendment page
	Then I should be display "Amendments - New Benefits" in Amendments_NewBenefits Page
	When I select Benefit for "PHCNBenefit"
	And I enter Effective date in Amendments_NewBenefits Page
	And I selelct Next Paydate for change 
	And I select Budget Calculation Method of "PHCNBenefit"
	And I enter the Budget Amount of "PHCNBenefit"
	When I enter save Button in Amendments_NewBenefits Page
	Then I should be on the Amendment page	
	Then I should see the New benefit Name of "PHCNBenefit"
	When I click on "Cancel" in Amendment page


