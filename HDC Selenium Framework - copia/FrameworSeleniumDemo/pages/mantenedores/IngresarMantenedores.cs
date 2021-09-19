using FrameworSeleniumDemo.utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworSeleniumDemo.pages.mantenedores
{
    class IngresarMantenedores : GenericFunctions
    {
        public IngresarMantenedores(IWebDriver driverComun) => driver = driverComun;

        private IWebElement opcMantenedores => driver.FindElement(By.XPath("//*[@id='cssmenu']/ul/li[4]/a"));
        private IWebElement opcPreparaciones => driver.FindElement(By.XPath("/html/body/nav/div[4]/div/ul/li[4]/ul/li/a"));

        public void ingresarMantenedorPreparaciones()
        {
            WaitForElement(opcMantenedores, 30);
            hoverAndClick(opcMantenedores, opcPreparaciones);
        }
    }
}
