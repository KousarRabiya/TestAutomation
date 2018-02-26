Feature: DashBoardFeature
		The dashboard fuctionality is been checked like amount,benifit


#Purpose:Adding the more benefit to the employee and see the checking the result in the MOL online is more benefit link is present
#Testcase ID:58036
#Product:Comet
#UserStory:Navigate the Dashboard
Scenario: Navigate the Dashboard - "Show more benefits.." link is available in Account Summary Dashboard (Home Page)
	Then I should be display with the benefit "Show me more benefits ..."


@mytag
Scenario: MOL user verifies the Benefits are displayed
	Then I should be display with the benefit "Meal Entertainment"
	Then I should be display with the benefit "Superannuation"
	Then I should be display with the benefit "Prof Indemnity Insurance"





