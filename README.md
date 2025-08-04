# Task 1

Automate test cases from the previous home task using identified elements and its locators. For this practical task, Selenium WebDriver and any preferred unit test framework (NUnit, MSTest or xUnit) should be used. 
The type of .NET project is Class Library.


The following basic WebDriver features should be used:
browser interactions.
capabilities and features browser specifics.
explicit and implicit waits.


Enlarge the window. Use basic commands that can be executed on an element (at least click, send keys, clear). 


P.S: Make all tests parameterized to practice the Data-Driven approach.


## Test Cases


### Test case #1. 

Validate that the user can search for a position based on criteria.

Navigate to https://www.epam.com/

Find a link “Carriers” and click on it

Write the name of any programming language in the field “Keywords” (should be taken from test parameter)

Select “All Locations” in the “Location” field (should be taken from the test parameter)

Select the option “Remote”

Click on the button “Find”

Find the latest element in the list of results

Click on the button “View and apply”

Validate that the programming language mentioned in the step above is on a page


### Test case #2. 

Validate global search works as expected.

Navigate to https://www.epam.com/

Find a magnifier icon and click on it

Find a search string and put there “BLOCKCHAIN”/”Cloud”/”Automation” (use as a parameter for a test)

Click “Find” button

Validate that all links in a list contain the word “BLOCKCHAIN”/”Cloud”/”Automation” in the text. LINQ should be used. 

# Task 2

For this practical task, you're required to use the result of the previous module. You should proceed to work with Selenium WebDriver along with your chosen unit test framework, either NUnit, MSTest or xUnit. Your .NET project type should be a Class Library.
Your solution should consist of a single class containing several test methods. It would be best if you utilized the page object pattern, but kindly don't use the PageFactory extension. Also, reflect on the appropriate passing of the IWebDriver object to make it user-friendly. Consider using the Actions API to execute a scroll wheel action in your code at least once. Additionally, incorporate an option to run tests in headless mode, which should be the second option for test execution.
Tasks #1 and #2:
Refactor tasks created for the previous module to use the PageObject pattern to abstract any page information away from the actual.
Precondition: Execute test cases manually before creating automated tests. Make all tests parameterized to practice the Data-Driven approach. 


## Test case #3. Validate file download function works as expected:
Create a Chrome instance.

Navigate to https://www.epam.com/.

Select “About” from the top menu.

Scroll down to the “EPAM at a Glance” section.

Click on the “Download” button.

Wait till the file is downloaded.

Validate that file “EPAM_Systems_Company_Overview.pdf” downloaded (use the name of the file as a parameter)

Close the browser.


## Test case #4. Validate title of the article matches with title in the carousel:
Create a Chrome instance.

Navigate to https://www.epam.com/.

Select “Insights” from the top menu.

Swipe a carousel twice.

Note the name of the article.

Click on the “Read More” button.

Validate that the name of the article matches with the noted above. 

Close the browser.

# Task 3

For this practical task the result of the previous module should be used. 
The solution should be split into next layers:
Core layer (core functionality of TAF, that aren’t project specific).
Business layer (should contain all functionality, related with business logic of the tested application.
Tests layer (should contain automated tests, TAF configuration).

Initialization of WebDriver instance should be done with helping Factory design pattern (consider adding dedicated class for Browser Factory functionality) 
All repeating actions, that should be done from test to test, should be aggregated in an abstract base class (actions such as initialization and closing a browser and so on).
Logging should be implemented (NLog, log4net or Serilog). Each test should generate logs from what should be clear test actions. TAF should support logging to both, file and console, and opportunity to use different logging levels (Error, Info, etc.). Min log level should be configurable via TAF configuration. When the test fails, a screenshot with the date and time should be taken. 

For this practical task, you should proceed to work with Selenium WebDriver along with SpecFlow and any SpecFlow runner and refactor the solution created in the Page Object module.
The main objective of this task is to gain practical experience in writing automated tests using the Behavioral Driven Development (BDD) methodology. You will adapt an existing codebase, originally developed by you using the Page Object model, to incorporate BDD practices using Selenium WebDriver and SpecFlow.

# Task #4
Implement the automated test using the SpecFlow BDD framework.

Precondition:
Execute test case manually before creating automated test. Make the test parametrized.
Test case #1. Validate Navigation to Services Section

Navigate to https://www.epam.com/

Locate and click on the "Services" link in the main navigation menu.

From the dropdown, select a specific service category: “Generative AI” or “Responsible AI” (parameterize the category selection).

Validate that the page contains the correct title.

Validate that the section ‘Our Related Expertise’ is displayed on the page


# Task #5
Enhance an existing solution based on the Page Object model using a BDD approach. This task requires you to organize your project with a clear and logical folder structure and to implement required classes for a fully functioning BDD test suite.
Precondition: 
Make sure you have Visual Studio (or a similar IDE), Selenium WebDriver, SpecFlow, and a compatible SpecFlow runner installed on your machine.
Before proceeding with the BDD implementation, execute the existing tests under the Page Object model structure. Ensure that all tests are passing as this serves as your base functionality upon which you will build the BDD solution.
Task description:
## Folder Structure Set-up:
Create a structured folder hierarchy in your project to segregate different components like features, step definitions and page objects.
Ensure the folders reflect a logical and modular test architecture.

## Class Incorporation:
Add necessary classes to the respective project folders. This may include addition of new Page Objects, Step Definition files.
Make sure all classes are correctly named and reside in appropriate folders based on their functionality.

## BDD Feature File Development:
In a .feature file within your Features folder, describe your test scenario using the BDD syntax: Given, When, Then.
Clearly outline the preconditions, actions, and expected outcomes for the tests.

## Page Objects Refactoring:
Adapt your Page Object classes to align with BDD steps. Ensure these objects remain modular and avoid any direct test assertions within these classes.

Tasks #1-#4:
Refactor automated tests created in previous module to follow SOLID, DRY, KISS, YAGNI principles, use Design Patterns (Singleton and Browser Factory) and add logging mechanism.  Solution should have Layers in Architecture and be able to execute on several environments.


