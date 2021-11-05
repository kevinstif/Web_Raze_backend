Feature: CommentServiceTests
	As a developer
	I want to add new Comment through
	So that It can be available for applications
	
	Background: 
		Given The EndPoint https://localhost:5001/api/v1/comments is available
		
		And A Tag is already stored
		| Id | Title         |
		| 1  | black t-shirt |
  
		And A Interest is already stored
		| Id | Title          | Description                 | Published |
		| 2  | Casual clothes | this clothes is confortable | true      |
  
		And A Advised is already stored
		| Id | FirstName | LastName | UserName | Password | Age | Mood | InterestId |
		| 5  | Jose      | Saenz    | Pepe     | 12345678 | 30  | 3    | 2          |
  
		And A Advisor is already stored
		| Id | FirstName | LastName | UserName | Password | Age | YearsExperience | Profession |
		| 3  | Jose      | Saenz    | Pepe     | 12345678 | 30  | 6               | none       |
  
		And A Post is already stored
		| Id | Title                    | Image   | Description                       | UserId | InterestId | TagId |
		| 4  | The Basic Casual Clothes | img.png | This clothes basic is confortable | 3      | 2          | 1     |
		

@comment-adding
Scenario: Add Comment
	
	When A Post Request is sent
	| Text                      | PostId | UserId |
	| thank you for information | 4      | 5      |
	
	Then A Status 200 is received
	And Comment Resource is included in Response body
	| Text                      | PostId | UserId |
	| thank you for information | 4      | 5      |
 
Scenario: Add Comment with invalid post
	
	When A Post Request is sent
	| Text                      | PostId | UserId |
	| thank you for information | 100    | 5      |
	
	Then A Status 400 is received
	And Message of "Invalid Post." is included in response body
	
Scenario: Add Comment with invalid user
	
	When A Post Request is sent
	| Text                      | PostId | UserId |
	| thank you for information | 4      | 100    |
	
	Then A Status 400 is received
	And Message of "Invalid User." is included in response body
	
Scenario: Add Comment with invalid user and invalid post
	
	When A Post Request is sent
	| Text                      | PostId | UserId |
	| thank you for information | 98      | 100    |
	
	Then A Status 400 is received
	And Message of "Invalid User And Post." is included in response body