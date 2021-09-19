using FrameworSeleniumDemo.utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworSeleniumDemo.pages.Login
{
    class Login : GenericFunctions
    {
        public Login(IWebDriver driverComun) => driver = driverComun;

        private IWebElement txtUsuario => driver.FindElement(By.Id("i0116"));
        private IWebElement lblMensajeErrorUsuario => driver.FindElement(By.Id("usernameError"));
        private IWebElement lblMensajeErrorPass => driver.FindElement(By.Id("i0116"));
        private IWebElement txtPass => driver.FindElement(By.Id("i0118"));
        private IWebElement btnSiguiente=> driver.FindElement(By.Id("idSIButton9"));

        public void IngresarCredenciales(String usuario, String pass) {
            WaitForElement(txtUsuario, 10);
            txtUsuario.SendKeys(usuario);
            btnSiguiente.Click();
            EsperaGeneral(3);
            txtPass.SendKeys(pass);
            btnSiguiente.Click();
            EsperaGeneral(3);
            btnSiguiente.Click();
        }
    }
}
