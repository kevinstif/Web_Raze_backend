Feature: UserAdvisedServiceTests
As a Developer
I want to add new UserAdvised through API
So that It can be available for applicatios.
 
    Background: 
        Given the Endpoint https://localhost:5001/api/v1/useradviseds is available
        And Interest is already stored
          | Id | Title  | Description    | Published |
          | 5  | Casual | Casual Outfits | 1         |
      
    @UserAdvised-adding
    Scenario: Add UserAdvised
        When A UserAdvised Request is Sent
          | firstName | LastName | UserName | Password | age | mood | InterestId |
          | George    | Tyson    | Demond   | goku1234 | 25  | 3    | 5          |
        Then Response with status 200 is received
        And A UserAdvised Resource is included in Response Body
          | Id | firstName | LastName | UserName | Password | age | Premiun | Profession | Mood | InterestId |
          | 10 | George    | Tyson    | Demond   | goku1234 | 25  | false   | Student    | 3    | 5          |
      
    Scenario: Add UserAdvised with Invalid Interest
        When A UserAdvised Request is Sent
          | firstName | LastName | UserName | Password | age | mood | InterestId |
          | George    | Tyson    | Demond   | goku1234 | 25  | 3    | -50        |
        Then Response with status 400 is received 
        And  Message of "Interst not found." is included in Response