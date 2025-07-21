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

