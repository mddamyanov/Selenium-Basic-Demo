using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SummatorForNumbersTests
{
    public class SummatorTests
    {
        private ChromeDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver();
            driver.Url = "https://sum-numbers.nakov.repl.co/";
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test_AddTwoNumbers_Valid()
        {
            driver.FindElement(By.Id("number1")).SendKeys("15");
            driver.FindElement(By.Id("number2")).SendKeys("7");
            driver.FindElement(By.Id("calcButton")).Click();
            var resultText = driver.FindElement(By.Id("result")).Text;
            Assert.AreEqual("Sum: 22", resultText);
            driver.FindElement(By.Id("resetButton")).Click();
        }

        [Test]
        public void Test_AddTwoNumbers_InvalidInput()
        {
            driver.FindElement(By.Id("number1")).SendKeys("hello");
            driver.FindElement(By.Id("number2")).SendKeys("");
            driver.FindElement(By.Id("calcButton")).Click();
            var resultText = driver.FindElement(By.Id("result")).Text;
            Assert.AreEqual("Sum: invalid input", resultText);
            driver.FindElement(By.Id("resetButton")).Click();
        }

        [Test]
        public void Test_AddTwoNumbers_Reset()
        {
            driver.FindElement(By.Id("number1")).SendKeys("15");
            driver.FindElement(By.Id("number2")).SendKeys("7");
            driver.FindElement(By.Id("calcButton")).Click();
            var num1Text = driver.FindElement(By.Id("number1")).GetAttribute("value");
            Assert.IsNotEmpty(num1Text);
            var num2Text = driver.FindElement(By.Id("number2")).GetAttribute("value");
            Assert.IsNotEmpty(num2Text);
            var resultText = driver.FindElement(By.Id("result")).GetAttribute("value");
            Assert.IsNotEmpty(resultText);

            driver.FindElement(By.Id("resetButton")).Click();
            num1Text = driver.FindElement(By.Id("number1")).GetAttribute("value");
            Assert.AreEqual("", num1Text);
            num2Text = driver.FindElement(By.Id("number2")).GetAttribute("value");
            Assert.AreEqual("", num2Text);
            resultText = driver.FindElement(By.Id("result")).Text;
            Assert.AreEqual("", resultText);
        }
    }
}