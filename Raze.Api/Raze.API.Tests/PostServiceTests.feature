Feature: PostServiceTests
	As a Developer
	I want to add new Post through API
	So that It can be available for applicatios.

	Background: 
		Given the Endpoint https://localhost:5001/api/v1/posts is available
		And A Interest is already stored
		  | Id | Title  | Description    | Published |
		  | 1  | Casual | Casual Outfits | 1         |
    	And A Tag is already stored
    	  | Id | Title |
          | 2  | Jeans | 
		And A User is already stored
		  | Id | FirstName | LastName   | UserName | Password | Age | Premium | InterestId |
		  | 1  | Edward    | Ticlavilca | Edward24 | pass     | 19  | 1       | 1          |
    	And A Post is already stored
          | Id | Title              | Image   | Description                       | Rate | NumberOfRates | UserId | InterestId | TagId |
          | 1  | Best winter outfit | image 1 | Use a striped t-shirt this winter | 4    | 10            | 1      | 1          | 1     |
  		
        
@post-adding
	Scenario: Add Post
		When A Post Request is Sent
		  | Title              | Image   | Description                       | UserId | InterestId | TagId |
		  | Best summer outfit | image 1 | Use a striped t-shirt this summer | 1      | 1          | 1     |
		Then A Response with status 200 is received
		And A Post Resource is included in Response Body
		  | id | title              | image   | description                       | rate | numberOfRates | userId | interestId | tagId |
		  | 2  | Best summer outfit | image 1 | Use a striped t-shirt this summer | 0    | 0             | 1      | 1          | 1     |
      
	Scenario: Add Post with Invalid Tag
		When A Post Request is Sent
		  | Title              | Image   | Description                       | UserId | InterestId | TagId |
		  | Best autumn outfit | image 1 | Use a striped t-shirt this autumn | 1      | 1          | -20    |
		Then A Response with status 400 is received 
		And A Message of "Tag not found." is included in Response Body
	
	Scenario: Add Post with Invalid Interest
		When A Post Request is Sent
		  | Title              | Image   | Description                       | UserId | InterestId | TagId |
		  | Best autumn outfit | image 1 | Use a striped t-shirt this autumn | 1      | -1          | 2    |
		Then A Response with status 400 is received 
		And A Message of "Interest not found." is included in Response Body
		
	Scenario: Add Post with Invalid User
		When A Post Request is Sent
		  | Title              | Image   | Description                       | UserId | InterestId | TagId |
		  | Best autumn outfit | image 1 | Use a striped t-shirt this autumn | -1      | 1          | 1    |
		Then A Response with status 400 is received 
		And A Message of "User not found." is included in Response Body
