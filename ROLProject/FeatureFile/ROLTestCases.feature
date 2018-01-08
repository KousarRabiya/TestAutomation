Feature: ROLNavigateToContactPage	

#Login to ROL and navigate to Contacts page
Scenario: TC1-ROL navigate to Contact Page	
	Given User able to launch the ROL application
	When User Login to the  ROL application using valid credentials	  
	  |Username |Password| 
      |072270859| MOL1234|
	Then User clicks on the Contact present right side of the appliction	
	Then Application should land in Contact Page
	

#Lodge a request
Scenario: TC2-ROL Lodge a request in contact page	
	Given User able to launch the ROL application
	When User Login to the  ROL application using valid credentials	  
	  |Username |Password| 
      |072270859| MOL1234|
	Then User clicks on the Contact present right side of the appliction	
	Then Application should land in Contact Page
	Then User fills the details of the request 
	Then User Clicks on the Submit Button
	

Scenario: ROL Login with Invalid Username	
	Given User able to launch the ROL application
	When User Login to the  ROL application using valid credentials	  
	  |Username |Password| 
      |072270859| MOL1234|	
 Then User clicks on the Contact present right side of the appliction
	


