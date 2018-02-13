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
	When I selelct Next Paydate for change is "29/03/2018"
	When I select Budget Calculation Method As "Per Annum"

