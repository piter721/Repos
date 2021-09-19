using FrameworSeleniumDemo.pages;
using FrameworSeleniumDemo.pages.Login;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworSeleniumDemo.testCase
{
    class PrimeraPruebaFuncionamiento
    {
        public PrimeraPruebaFuncionamiento(IWebDriver driverComun) => driver = driverComun;
        private IWebDriver driver { get; }

        public void PrimeraPruebaFuncionamient() {
            Login lo = new Login(driver);
            lo.IngresarCredenciales("paperez@hogardecristo.cl", "pap_1234");
            Preparaciones prep = new Preparaciones(driver);
            prep.ingresarMantenedorPreparaciones();
            prep.compararTextosLabels();
            prep.llenarCamposPreparaciones("Pan con agregado", 1, "true", "Hamburguesa");
            prep.HacerClickBotonBuscar();
        }
    }
}
