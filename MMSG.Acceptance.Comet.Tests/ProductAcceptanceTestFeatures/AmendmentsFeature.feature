Feature: AmendmentsFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add Benefit to the package through Amendment screen
	When I click on "Amendment" in "CCEnquiry" page
	Then I should be on the Amendment page
	When I click on "New" in Amendment page
	Then I should be display "Amendments - New Benefits" in Amendments_NewBenefits Page
	When I select "Airport Lounge Membership" Benefit in Amendments_NewBenefits Page
	When I enter Effective date in Amendments_NewBenefits Page
	When I selelct Next Paydate for change 
	When I select Budget Calculation Method As "Per Annum"
	When I enter the Budget Amount as "10"
	When I enter save Button in Amendments_NewBenefits Page
	Then I should be on the Amendment page
	Then I should see the New benefit Name "Airport Lounge Membership" in Benefit details of Amendment page
	When I click on "Cancel" in Amendment page


