# Log-Files-Google-DropDown

Tasks : 
1) Use MSTest to write tests 
2) Create a method, which reads from the “log.txt” file and saves that value
3) Use Timer to call the above method again and again after a time interval
4) Write 2 TestMethods - these methods take values to search from log.txt file
5) Print content from the "log.txt" file every 10 seconds

Workflow:

a. Fields
1) Initialize instance of ChromeDriver class

b. Methods

i. your_method (called every 10 seconds)
1) calls ReadLogFile method

ii. ReadLogFile method
1) extract data from "log.txt"
2) store data in variables 
3) print the data

c. ClassInitialize
1) Initialize a new instance of the Timer class, and sets the Timer.Interval property to the specified number of milliseconds
2) Start raising the Timer.Elapsed event by setting Timer.Enabled to true

d. TestInitialize 
1) Maximize browser
2) Set implicit time wait ( which stays for entire session)

e. TestMethods 

i. TestMethod0 (Google Search WorkFlow) 
1) Go to the Url "http://google.com"
2) Finds the element with the Name "q" and enters "GeeksForGeeks" there and press Enter (keyboard) (the value entered is read from the "log.txt" file)
3) Press browser's back button
4) Press browser's front button                  
5) Refresh current page
6) Prints current page title from the browser
7) Exception handling is also used

ii. TestMethod1 (Dropdown WorkFlow)
1) Go to the Url "http://google.com"
2) Finds the element with the Name "q" and enters "GeeksForGeeks" there and press Enter (keyboard) (the value entered is read from the "log.txt" file)
3) Finds element with the ClassName "r" and click it (Clicking 'GeeksForGeeks' website link)
4) Finds element with Id "menu-item-351946" and click it (Clicking Tutorials)
5) Finds element with Id "menu-item-351977" and click it (Clicking Sub Parts of it)       
6) Finds element with Id "menu-item-362995" and click it (Clicking Super Sub Part of it)
7) Use Assert to check if the page title matches with the required page title ("Stack Data Structure - GeeksforGeeks")
8) Exception handling is also used

f. TestCleanup : 
1) Closes the browser
2) Quits
