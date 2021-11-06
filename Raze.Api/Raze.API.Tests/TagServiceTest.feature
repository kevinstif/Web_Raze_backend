Feature: TagServiceTest
As a developer
I want to add new tag through API
So that It can be available for applications.

    Background:
        Given The Endpoint https://localhost:5001/api/v1/tags is available

    @tag-adding
    Scenario: Add Tag
        When A Post Request is sent
          | Title         |
          | White t-shirt |
        Then A Response with Status 200 is received
        And A Tag Resource is included in response body
          | Title         |
          | White t-shirt |

    Scenario: Add Tag with exiting title
        Given A Tag is already saved
          | Title         |
          | black Clothes |
        When A Post Request is sent
          | Title         |
          | black Clothes |
        Then A Response with Status 400 is received
        And A Message of "This tag already exist" is include in response body