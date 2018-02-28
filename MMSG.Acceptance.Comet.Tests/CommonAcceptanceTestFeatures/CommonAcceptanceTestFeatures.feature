Feature: CommonAcceptanceTestFeatures
				As a User
				I want to manage all the Comet User related usecases 
				so that I would validate all the Comet scenarios are working fine.

@mytag
#Purpose : Launch Comet URL and validate home page
Scenario: User launch Comet URL
Given  I access application URL as "COMETUser"
Then I should be displayed with Comet logo
And I should be on the "CCEnquiry" page

Scenario: Logout as Comet user
When I logout of Comet application
