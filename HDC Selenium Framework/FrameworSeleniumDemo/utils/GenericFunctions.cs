using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FrameworSeleniumDemo.utils
{
    class GenericFunctions : WebDriverFactory
    {
        public void WaitForElement(IWebElement element, int waitTime)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
            wait.Until(ExpectedConditions.ElementToBeClickable(element)); //There are several Expected conditions
            Console.WriteLine("Objeto encontrado exitosamente");
        }

        public void hoverAndClick(IWebElement element, IWebElement elementToMakeClick) {
            Actions action = new Actions(driver);
            action.MoveToElement(element).Click(elementToMakeClick).Build().Perform();
        }

        public static void CompararTextos(String textoObjeto, String textoComparacion) {
            Assert.That(textoObjeto, Is.EqualTo(textoComparacion));
            Console.WriteLine("Los textos coinciden correctamente");
        }
        public static void SeleccionarOpcionPorTexto(IWebElement element, String option) {
            SelectElement slc = new SelectElement(element);
            slc.SelectByText(option);
            Console.WriteLine("Opcion '" + option + "' seleccionada");
        }
        public static void SeleccionarOpcionSelectPorIndex(IWebElement element, int option)
        {
            SelectElement slc = new SelectElement(element);
            slc.SelectByIndex(option);
            Console.WriteLine("La opcion fue seleccionada correctamente");
        }
        public static void SeleccionarOpcionSelectPorValue(IWebElement element, String option)
        {
            SelectElement slc = new SelectElement(element);
            slc.SelectByValue(option);
            Console.WriteLine("La opcion fue seleccionada correctamente");
        }
        public static void EsperaGeneral(int segundos) {
            Console.WriteLine("INICIO ESPERA DE " + segundos + " SEGUNDOS");
            int milliseg = segundos * 1000;
            Thread.Sleep(milliseg);
            Console.WriteLine("TERMINO DE ESPERA DE " + segundos + " SEGUNDOS");
        }

        public void AceptarAlertaNavegador() {
            var confirm_win = driver.SwitchTo().Alert();
            confirm_win.Accept();
        }

        public void RechazarAlertaNavegador() {
            var confirm_win = driver.SwitchTo().Alert();
            confirm_win.Dismiss();
        }

        public void SeleccionarCheckbox(IWebElement element) {
            Boolean estado = element.Selected;
            if (estado == true)
            {
                Console.WriteLine("El elemento esta seleccionado");
            }
            else {
                Console.WriteLine("El elemento no esta seleccionado");
                element.Click();
            }
        }
        public void DeseleccionarCheckbox(IWebElement element)
        {
            Boolean estado = element.Selected;
            if (estado == true)
            {
                Console.WriteLine("El elemento esta seleccionado");
                element.Click();
            }
            else
            {
                Console.WriteLine("El elemento no esta seleccionado");
            }
        }

        public void ScrollToElement(IWebElement element) {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public void AbrirNuveaVentana(String url) {
            driver.FindElement(By.CssSelector("body")).SendKeys(Keys.Control + "t");
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.Navigate().GoToUrl(url);
        }

        public void VolverPrimeraPagina()
        {
            driver.SwitchTo().Window(driver.WindowHandles.First());
        }


    
    }
}
