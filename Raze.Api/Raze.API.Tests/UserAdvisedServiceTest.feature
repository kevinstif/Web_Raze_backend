Feature: UserAdvisedServiceTest
As a Develover
I want to add new UserAdvised through API
So that It can ve available for applications

    Background:
        Given the Endpoint https://localhost:5001/api/v1/useradviseds is available
        And A Interest is already stored
          | Id | Title          | description                       | published |
          | 10 | Formal Clothes | This types of clothes is necesary | true      |

    @useradvised-adding
    Scenario: Add UserAdvised
        When A UserAdvised Request is sent
          | FirstName | LastName | UserName | Password | Mood | InterestId | Age |
          | Yisus     | Graham   | yg25     | goku123  | 3    | 10         | 5   |
        Then A Response with Status 200 is received