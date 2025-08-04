@DownloadUI
Feature: File Download
As a user of the EPAM website
  I want to be able to download the "EPAM_Systems_Company_Overview.pdf" file

  Scenario: Validate file download works as expected
    Given I am on the EPAM homepage
    When I select "About" from the top menu
    And I accept cookies
    And I scroll to the "EPAM at a Glance" section
    And I click the "Download" button
    And I wait for the file "EPAM_Systems_Company_Overview.pdf" to download
    Then the file "EPAM_Systems_Company_Overview.pdf" should exist in the download folder