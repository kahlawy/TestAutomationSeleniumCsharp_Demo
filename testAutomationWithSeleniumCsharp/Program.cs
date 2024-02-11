using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

class Program
{
	static void Main(string[] args)
	{
		// Initialize WebDriver (Chrome)
		using (IWebDriver driver = new ChromeDriver())
		{
			driver.Manage().Window.Maximize();

			// Navigate to the registration page
			driver.Navigate().GoToUrl("https://demo.nopcommerce.com/");

			// Click on the Register link
			IWebElement registerLink = driver.FindElement(By.ClassName("ico-register"));
			registerLink.Click();

			// Fill registration form
			FillRegistrationForm(driver);

			// Perform assertions
			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
			IWebElement resultMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("result")));
			string actualResult = resultMessage.Text;
			string expectedResult = "Your registration completed";

			if (actualResult == expectedResult)
			{
				Console.WriteLine("Result is correct: " + actualResult);
			}
			else
			{
				Console.WriteLine("Result is incorrect. Expected: " + expectedResult + ", Actual: " + actualResult);
			}
		}
	}

	private static void FillRegistrationForm(IWebDriver driver)
	{
		// Locate elements in the registration form
		IWebElement genderRadio = driver.FindElement(By.Name("Gender"));
		IWebElement firstNameText = driver.FindElement(By.Name("FirstName"));
		IWebElement lastNameText = driver.FindElement(By.Name("LastName"));
		IWebElement bDay = driver.FindElement(By.Name("DateOfBirthDay"));
		IWebElement bMonth = driver.FindElement(By.Name("DateOfBirthMonth"));
		IWebElement bYear = driver.FindElement(By.Name("DateOfBirthYear"));
		IWebElement eMail = driver.FindElement(By.Name("Email"));
		IWebElement eCompany = driver.FindElement(By.Name("Company"));
		IWebElement newsletter = driver.FindElement(By.Name("Newsletter"));
		IWebElement setPassword = driver.FindElement(By.Name("Password"));
		IWebElement setConfirmPassword = driver.FindElement(By.Name("ConfirmPassword"));
		IWebElement registerButton = driver.FindElement(By.Id("register-button"));

		// Set registration data
		SelectElement dayDropDown = new SelectElement(bDay);
		SelectElement monthDropDown = new SelectElement(bMonth);
		SelectElement yearDropDown = new SelectElement(bYear);

		dayDropDown.SelectByIndex(1);
		monthDropDown.SelectByIndex(2);
		yearDropDown.SelectByIndex(3);

		genderRadio.Click();
		firstNameText.SendKeys("Kahlawy");
		lastNameText.SendKeys("Hussein");
		eMail.SendKeys("kahlawy@gmail.com");
		eCompany.SendKeys("ABC Company");
		newsletter.Click();
		setPassword.SendKeys("K@123456");
		setConfirmPassword.SendKeys("K@123456");
		registerButton.Click();
	}
}
