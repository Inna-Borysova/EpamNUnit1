@UI
Feature: Services Navigation
  As a user
  I want to navigate to EPAM services
  So that I can view information about a specific AI category

  @navigation
  Scenario Outline: Validate navigation to <category> Services page
    Given I am on the EPAM homepage
    When I navigate to the Services section and select "<category>"
    And I accept cookies
    Then I should see the page title containing "<category>"
    But the section "Our Related Expertise" should be visible

    Examples:
      | category       |
      | Generative AI  |
      | Responsible AI |
