using FrameworSeleniumDemo.testCase;
using FrameworSeleniumDemo.utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworSeleniumDemo.tests
{
    class PruebasEjemplo : Hooks
    {

        [Test]
        public void pruebaEjecucion()
        {
            PrimeraPruebaFuncionamiento pf = new PrimeraPruebaFuncionamiento(driver);
            pf.PrimeraPruebaFuncionamient();
        }
        [Test]
        public void Config2()
        {
            PrimeraPruebaFuncionamiento pf = new PrimeraPruebaFuncionamiento(driver);
            pf.PrimeraPruebaFuncionamient();
        }
        [Test]
        public void Config3()
        {
            PrimeraPruebaFuncionamiento pf = new PrimeraPruebaFuncionamiento(driver);
            pf.PrimeraPruebaFuncionamient();
        }

    }
}
