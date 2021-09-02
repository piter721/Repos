using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworSeleniumDemo.utils
{
    
    public class Hooks : WebDriverFactory
    {
        public Hooks() {
        }

        [SetUp]
        public void Setup()
        {
            //definir una nueva ruta para el proyecto
            driver = new ChromeDriver(@"C:\\Users\\paperez\\source\\repos\\HDC Selenium Framework\\FrameworSeleniumDemo\\driverNavegadores");
            driver.Navigate().GoToUrl("https://app-abacook-qa.azurewebsites.net/");
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown() => driver.Quit();

    
}
}
