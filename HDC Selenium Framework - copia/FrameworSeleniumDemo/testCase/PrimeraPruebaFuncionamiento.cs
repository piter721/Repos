using FrameworSeleniumDemo.pages;
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
            Preparaciones prep = new Preparaciones(driver);
            prep.ingresarMantenedorPreparaciones();
            prep.compararTextosLabels();
            prep.llenarCamposPreparaciones("Pan con agregado", 1, "true", "Hamburguesa");
            prep.HacerClickBotonBuscar();
        }
    }
}
