using FrameworSeleniumDemo.utils;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworSeleniumDemo.pages.mantenedores
{
    class CrearPreparacion : GenericFunctions
    {
        public CrearPreparacion(IWebDriver driverComun) => driver = driverComun;

        private IWebElement btnNuevaPrep => driver.FindElement(By.Id("btn_nuevo"));

        //tiempo de recarga


        private IWebElement txtNombrePrep => driver.FindElement(By.Id("CABECERA_NOMBRE_PREPARACION")); 
        private IWebElement slcTipoPrep => driver.FindElement(By.Id("CABECERA_ID_TIPO_PREPARACION"));
        private IWebElement btnRegimen => driver.FindElement(By.XPath("/html/body/div[1]/div/form/div/div[3]/div[1]/span/div/button")); //visualmente se ve como un 'select'
        private IWebElement opcSeleccionarTodosRegimen => driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[3]/label"));  
        private IWebElement opcNormalEntero => driver.FindElement(By.XPath("//*[@title='Normal entero']"));
        private IWebElement opcPapillaNormal => driver.FindElement(By.XPath("//*[@title='Papilla normal']"));
        private IWebElement opcDiabetico => driver.FindElement(By.XPath("//*[@title='Diabético']"));
        private IWebElement opcPapilla => driver.FindElement(By.XPath("//*[@title='Papilla diabético']"));
        private IWebElement chbxEstado => driver.FindElement(By.Id("CABECERA_ESTADO"));
        private IWebElement btnCategoriaMenu => driver.FindElement(By.XPath("/html/body/div[1]/div/form/div/div[3]/div[2]/span/div/button"));
        private IWebElement opcSeleccionarTodasCategorias => driver.FindElement(By.XPath("/html/body/div[1]/div/form/div/div[3]/div[2]/span/div/div/button[1]"));
        private IWebElement opcDesayuno => driver.FindElement(By.XPath("//*[@title='Desayuno']"));
        private IWebElement opcOnce => driver.FindElement(By.XPath("//*[@title='Almuerzo']"));
        private IWebElement opcAlmuerzo => driver.FindElement(By.XPath("//*[@title='Once']"));
        private IWebElement opcCena => driver.FindElement(By.XPath("//*[@title='Cena']"));
        private IWebElement opcColacion => driver.FindElement(By.XPath("//*[@title='Colación']"));
        private IWebElement opcColacionColegio => driver.FindElement(By.XPath("//*[@title='Colación Colegio']"));

        private IWebElement btnAgregarIngrediente => driver.FindElement(By.Id("a_agregar_fila"));
        private IWebElement txtIngrediente => driver.FindElement(By.XPath("//*[@id='tb_product']/tbody/tr[1]/td[1]/table/tbody/tr/td[1]/input"));
        private IWebElement btnBuscar => driver.FindElement(By.XPath("//*[@id='tb_producto']/tbody/tr[1]/td[1]/table/tbody/tr/td[2]/a[1]"));
        private IWebElement txtCantNeto => driver.FindElement(By.Id("PRODUCTOS_0__RACION_NETO"));
        private IList<IWebElement> tblBodyIngredientesBusqueda => driver.FindElements(By.XPath("//*[@id='myModal2Contenido']/table/tbody/tr"));
        private IWebElement lblCampoNombreIngrediente => driver.FindElement(By.XPath("//*[@id='tb_producto']/tbody/tr[1]/td[2]"));
        private IWebElement btnGuardar => driver.FindElement(By.Id("btn_aceptar"));
        private IWebElement btnCancelar => driver.FindElement(By.Id("btn_cancelar"));
        private IWebElement lblMensajeGuardado => driver.FindElement(By.Id("myModalContenido"));
        private IWebElement btnCerrarPopupMensaje => driver.FindElement(By.Id("myModalContenido"));

        public void LlenarDatosPreparacion(String nombreIngrediente, int tipoPrep, String regimen, Boolean estado, String categoriaMenu ) { //si el estado es 'true', se selecciona, y si es false, se deselecciona
            
            WaitForElement(txtNombrePrep, 15);
            txtNombrePrep.SendKeys(nombreIngrediente);
            SeleccionarOpcionSelectPorIndex(slcTipoPrep, 2);
            btnRegimen.Click();
            WaitForElement(opcNormalEntero, 5);
            opcNormalEntero.Click();
            
            if (estado) {
                SeleccionarCheckbox(chbxEstado);
            }
            else
            {
                DeseleccionarCheckbox(chbxEstado);
            }

            btnCategoriaMenu.Click();
            WaitForElement(opcAlmuerzo, 5);
            opcSeleccionarTodasCategorias.Click();
        }


        public void BuscarIngrediente(String ingrediente) {
            txtIngrediente.SendKeys(ingrediente);
            btnBuscar.Click();
            EsperaGeneral(5);
            if (lblCampoNombreIngrediente.Text.Trim().Equals(""))
            {
                AgregarIngrediente();
            }
            else {
                Console.WriteLine("El ingrediente '" + lblCampoNombreIngrediente.Text + "' fue agregado exitosamente");
                Passed("El ingrediente fue ingresado exitosamente");
            }
        }

        public void AgregarIngrediente()
        {
            EsperaGeneral(10);
            if (tblBodyIngredientesBusqueda.Count != 0)
            {
                WaitForElement(tblBodyIngredientesBusqueda[0].FindElement(By.XPath("td[4]/input")), 5);
                tblBodyIngredientesBusqueda[0].FindElement(By.XPath("td[4]/input")).Click();
                WaitForElement(lblCampoNombreIngrediente, 5);
                if (lblCampoNombreIngrediente.Text.Trim().Equals(""))
                {
                    Failed("El ingrediente no fue ingresado, favor revisar");
                }
                else
                {
                    Console.WriteLine("El ingrediente '" + lblCampoNombreIngrediente.Text + "' fue agregado exitosamente");
                    Passed("El ingrediente fue ingresado exitosamente");
                }
            }

        }

        public void GuardarPreparacion() {
            btnGuardar.Click();
            WaitForElement(lblMensajeGuardado, 10);
            CompararTextos(lblMensajeGuardado.Text, "¡Datos han sido registrados correctamente!");
            btnCerrarPopupMensaje.Click();
        }

        public void Cancelar() {
            btnCancelar.Click();
        }

    }
}
