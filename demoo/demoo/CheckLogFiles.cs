using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Timers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections;

namespace demoo
{
    [TestClass]
    public class CheckLogFiles
    {
        //to store content of "log.txt"
        static IList values;

        IWebDriver driver = new ChromeDriver();

        [ClassInitialize]
        public static void Reloading(TestContext testContext)
        {
            Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt") + " :   " + "Start"   );

            //Initilizes a new instance of the Timer class, and sets the Timer.Interval property to the specified number of milliseconds

           //TimeSpan represents a time interval

           //TimeSpan.FromSeconds(double value) returns TimeSpan that returns number of seconds, where specification is accurate to the nearest millisecond.

           //TimeSpan.TotalMilliseconds - Gets the value of the current timespan structure expressed in whole and fractional seconds.

           Timer t = new Timer(TimeSpan.FromSeconds(10).TotalMilliseconds); // Set the time (10 seconds in this case)
            t.AutoReset = true;

            //occurs when Timer elapsed
            t.Elapsed += new System.Timers.ElapsedEventHandler(your_method);

            //Start raising the Timer.Elapsed event by setting Timer.Enabled to true
            t.Start();

            ReadLogFile();
        }

        // This method is called every 10 seconds
        private static void your_method(object sender, ElapsedEventArgs e)
        {
            ReadLogFile();
        }

        ////to extract data from "log.txt", store into variables and print it
        public static void ReadLogFile()
        {
            //System.IO.SystemReader implements a System.IO.TextReader that reads a character from a byte stream in particular encoding
            System.IO.StreamReader reader = new System.IO.StreamReader(@"C:\Users\YOGESH GARG\source\repos\demoo\demoo\log.txt");
            
            //gets the value that indicates whether the current stream position is at the end of the stream
            while (!reader.EndOfStream)
            {
                //reads line of characters from current stream and returns data as a string
                var line = reader.ReadLine();
                values = line.Split(' ');

                //get the current date time
                Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt") + " :   "+ values[0] + " " + values[1]);
            }
        }

        [TestInitialize]
        public void Initilize()
        {
            //maximize the browser
            driver.Manage().Window.Maximize();

            //set Implicit Time Wait as well
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TestMethod]
        public void TestMethod0()
        {
            try
            {
                //set url of driver 
                driver.Url = "http://google.com";

                //finding element with the Name "q" and entering "GeeksForGeeks" there, after that enter is pressed (keyboard)
                driver.FindElement(By.Name("q")).SendKeys(values[1] + Keys.Enter);

                // press browser's back button
                driver.Navigate().Back();

                // press browser's front button
                driver.Navigate().Forward();

                // refresh current page
                driver.Navigate().Refresh();

                //current page title from the browser
                Console.WriteLine(driver.Title);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception encountered : " + e);
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                //set url of driver 
                driver.Url = "https://www.google.com/";
                
                //finding element with the Name "q" and entering "GeeksForGeeks" there, after that enter is pressed (keyboard)
                driver.FindElement(By.Name("q")).SendKeys(values[1] + Keys.Enter);
                Console.WriteLine("1 - Searched 'GeeksForGeeks'");

                //finding element with the ClassName "r" and clicking it
                driver.FindElement(By.ClassName("r")).Click();
                Console.WriteLine("2 - Clicking 'GeeksForGeeks' website link");

                //find element with id mentioned and click it
                driver.FindElement(By.Id("menu-item-351946")).Click();
                Console.WriteLine("3 - Clicked Tutorials");

                //find element with id mentioned and click it
                driver.FindElement(By.Id("menu-item-351977")).Click();
                Console.WriteLine("4 - Clicked Sub Part of it");

                //find element with id mentioned and click it
                driver.FindElement(By.Id("menu-item-362995")).Click();
                Console.WriteLine("5 - Clicked Super Sub Part of it");

                //title is which appears on the tab
                //Console.WriteLine(driver.Title);

                //assert
                Assert.AreEqual(driver.Title, "Stack Data Structure - GeeksforGeeks");

                Console.WriteLine("6 - Success!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured : " + e);
            }
        }


        [TestCleanup]
        public void CleanUp()
        {
            //closes the browser
            driver.Close();

            Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt") + " :   " + "End");

            //most important step
            driver.Quit();
        }
    }
}
