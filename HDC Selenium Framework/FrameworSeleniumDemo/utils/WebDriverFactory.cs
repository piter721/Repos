using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace FrameworSeleniumDemo.utils
{
    public class WebDriverFactory
    {
        public IWebDriver driver { get; set; }
    }
}
