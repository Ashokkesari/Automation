Feature: Post

 This feature file covers the scenrios of the Posts CRUD operations
@positive
Scenario Outline: Create Update Delete Post
	Given I create a new post uisng id '<iD>' title '<title>' and views '<views>'
	When I update a created post with id '<iD>' title 'title - modified' and views '<views>'
	Then I delete the created post with id '<iD>'

	Examples: 
	| iD | title   | views |
	| 100| title 6 | 1000  |



@positive
Scenario Outline: Update the Post
	Given I create a new post uisng id '<id>' title '<title>' and views '<views>'
	When I update a created post with id '<id>' title '<updated title>' and views '<views>'
	Then I verify the updated post with id '<id>' title 'Modified Title' and views '<views>'
	And I delete the created post with id '<id>'

	Examples: 
	| id | title    | views | updated title    |
	| 15 | title 10 | 500   | Modified Title   |



@positive
Scenario Outline: Read the Post
	Given I create a new post uisng id '<id>' title '<title>' and views '<views>'
	When I read a created post with id '<id>' title '<updated title>' and views '<views>'
	Then I delete the created post with id '<id>'

	Examples: 
	| id | title    | views |
	| 17 | title 11 | 2000  |



@negative
Scenario Outline: Failing this Test case - Negative scenario Read the Post 
	Given I create a new post uisng id '<id>' title '<title>' and views '<views>'
	When I read a created post with id '<id>' title '<updated title>' and views '<views>'
	Then I delete the created post with id '<id>'

	Examples: 
	| id | title    | views |
	|    | title 16 | 20000 |