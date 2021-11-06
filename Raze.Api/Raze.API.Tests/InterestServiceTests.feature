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
        When A Post Request is sent
          | Title | Description  | Published |
          | null  | Just clothes | true      |
        Then A Response with Status 400 is received
        And A Message of "The Title field is required." is included in Response Body

    Scenario: Add Interest with existing Title
        Given A Interest with the same Title already exists
          | Title | Description          | Published |
          | Sport | Clothes for training | true      |
        When A Post Request is sent
          | Title | Description          | Published |
          | Sport | Clothes for training | true      |
        Then A Response with Status 400 is received
        And A Message of "Interest title already exists." is included in Response Body