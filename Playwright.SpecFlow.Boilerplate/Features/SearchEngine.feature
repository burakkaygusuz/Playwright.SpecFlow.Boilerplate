Feature: Search Engine
  As a user
  I want to search for "SpecFlow"
  So that I can find relevant information

  Scenario: Searching for SpecFlow on Bing
    Given I am on the Bing search engine
    When I enter SpecFlow in the search box
    And I click the search button
    Then I should see search results related to SpecFlow
