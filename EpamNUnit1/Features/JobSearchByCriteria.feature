@UI
Feature: Job Search by Criteria
  As an user,
  I want to search for open positions using keywords and location filters,
  So that I can find relevant remote job opportunities on the EPAM Careers page.

  Scenario Outline: Validate that the user can search for a position based on language and location
    Given I am on the EPAM homepage
    When I navigate to the "Careers" page
    And I accept cookies
    And I enter "<programmingLanguage>" into the "Keywords" field
    And I select the "Remote" option
    And I select "All Location" from the "Location" dropdown
    And I click the "Find" button
    And I click the “View and apply” button in the latest job post from the search results
    Then the job description page should contain the word "<programmingLanguage>"

    Examples:
      | programmingLanguage |
      | Java                |
      | .net                |