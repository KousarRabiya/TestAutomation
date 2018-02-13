Feature: DashBoardFeature

Scenario: Navigate the Dashboard - "Show more benefits.." link is available in Account Summary Dashboard (Home Page)
	Then I should be display with the benefit "Show me more benefits ..."

@mytag
Scenario: MOL user verifies the Benefits are displayed
	Then I should be display with the benefit "Meal Entertainment"
	Then I should be display with the benefit "Superannuation"
	Then I should be display with the benefit "Prof Indemnity Insurance"





