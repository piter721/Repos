using FrameworSeleniumDemo.utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworSeleniumDemo.pages
{
    class Preparaciones : GenericFunctions
    {
        //mantenedor
        public Preparaciones(IWebDriver driverComun) => driver = driverComun;    
        private IWebDriver driver { get; }

        private IWebElement opcMantenedores => driver.FindElement(By.XPath("//*[@id='cssmenu']/ul/li[4]/a"));
        private IWebElement opcPreparaciones => driver.FindElement(By.XPath("/html/body/nav/div[4]/div/ul/li[4]/ul/li/a"));

        private IWebElement lblTipoPreparacion => driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[1]/label"));
        private IWebElement lblRegimen => driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[2]/label"));
        private IWebElement lblEstado => driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[3]/label"));
        private IWebElement lblNombre => driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[4]/label"));
        private IWebElement slcPreparacion => driver.FindElement(By.Id("buscar_preparacion_ddl_tipo_preparacion"));
        private IWebElement slcRegimen => driver.FindElement(By.Id("buscar_preparacion_ddl_regimen"));
        private IWebElement slcEstado => driver.FindElement(By.Id("buscar_preparacion_ddl_estado"));
        private IWebElement txtNombre => driver.FindElement(By.Id("buscar_preparacion_txt_nombre"));
        private IWebElement btnBuscar => driver.FindElement(By.Id("btn_buscar"));
        private IList<IWebElement> tblResultados => driver.FindElements(By.XPath("//*[@class='table-body']/tr"));
        private String busqueda = "";
        private String regimenComp = "";
        private String tipoPreparacionComp = "";
        //private IWebElement btnNuevo => driver.FindElement(By.Id("btn_nuevo"));


        public void ingresarMantenedorPreparaciones() {
            WaitForElement(opcMantenedores , 30);
            hoverAndClick(opcMantenedores, opcPreparaciones);
        }
        public void compararTextosLabels() {
            CompararTextos(lblTipoPreparacion.Text, "Tipo Preparación");
            CompararTextos(lblRegimen.Text, "Regimen");
            CompararTextos(lblEstado.Text, "Estado");
            CompararTextos(lblNombre.Text, "Nombre");
        }

        public void llenarCamposPreparaciones(String tipoPreparacion, int regimen, String estado, String nombre) {
            SeleccionarOpcionPorTexto(slcPreparacion, "Pan con agregado");
            SeleccionarOpcionSelectPorIndex(slcRegimen, 1);
            SeleccionarOpcionSelectPorValue(slcEstado, "true");
            
            txtNombre.SendKeys(nombre);
        }

        public void HacerClickBotonBuscar() {
            btnBuscar.Click();
        }

        public void recorrerListaResultados() {
            TimeSpan.FromSeconds(10);
            for (int i = 0; i < (tblResultados.Count - 1); i++)
            {
                String nombrePrep = tblResultados[i].FindElement(By.XPath("td[1]")).Text;
                String tipoPrep = tblResultados[i].FindElement(By.XPath("td[2]")).Text;
                String regimen = tblResultados[i].FindElement(By.XPath("td[3]")).Text;

                Assert.That(nombrePrep, Is.EqualTo(""), "Los textos no coinciden");
                Assert.That(tipoPrep, Is.EqualTo(""), "Los textos no coinciden");
                Assert.That(regimen, Is.EqualTo(""), "Los textos no coinciden");
            }
            
        }

    }
}
