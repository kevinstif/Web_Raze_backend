Feature: UserAdvisedServiceTest
	As a Develover 
	I want to add new UserAdvised through API
	So that It can ve available for applications

	Background: 
		Given the Endpoint https://localhost:5001/api/v1/useradviseds is available
	
@useradvised-adding
Scenario: Add UserAdvised
	When  A UserAdvised Request is sent
            | FirstName | LastName | UserName | Password | Premium | Mood |
          | Yisus     | Graham   | yg25     | goku123  | true    | 3    |	
          Then A Reponse with Status 200 is received
          
          

     