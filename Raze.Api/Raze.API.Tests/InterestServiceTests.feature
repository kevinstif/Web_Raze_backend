Feature: InterestServiceTests
As a Developer
I want to add new Interest through API
So that It can be available for applications.

    Background:
        Given the Endpoint https://localhost:5001/api/v1/interests is available

    @interest-adding
    Scenario: Add Interest
        When A Post Request is sent
          | Title   | Description                  | Published |
          | Elegant | Suits for important meetings | true      |
        Then A Response with Status 200 is received
        And A Interest Resource is included in Response Body
          | Title   | Description                  | Published |
          | Elegant | Suits for important meetings | true      |

    Scenario: Add Interest with null title
        When A Post Request is sent with title null
          | Title | Description  | Published |
          |       | Just clothes | true      |
        Then A Response with Status 400 is received
        