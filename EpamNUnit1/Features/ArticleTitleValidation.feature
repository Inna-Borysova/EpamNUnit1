@UI
Feature: Article Title Validation
 As a user 
  I want to ensure that the article title in the Insights carousel matches the title on the article page

   Scenario: Validate article title matches after clicking Read More
    Given I am on the EPAM homepage
    When I select "Insights" from the top menu
    And I accept cookies
    And I swipe the carousel two times
    And I note the title of the current article in the carousel
    And I click the "Read More" button of the current article
    Then the article title on the article page should match the noted title