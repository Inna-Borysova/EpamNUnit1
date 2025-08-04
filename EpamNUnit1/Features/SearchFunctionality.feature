@UI
Feature: Website Search Functionality 
As an user 
I want to perform a search on the main page 

Scenario Outline: Perform a search on the EPAM website 
    Given I am on the EPAM homepage 
    When I click on the Search icon element 
    And I enter the text "<text>" into the search input 
    And I click on the Find button
    And the user acceptes cookies
    Then all links in the list contain the text "<text>"  

    Examples: 
    |text        | 
    |BLOCKCHAIN  | 
    |Cloud       |
    |Automation  | 
