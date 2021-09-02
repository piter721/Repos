using System;
using System.Collections.Generic;
using System.Text;
using FrameworSeleniumDemo.testCase;
using FrameworSeleniumDemo.utils;
using NUnit.Framework;

namespace FrameworSeleniumDemo.tests
{
    [TestFixture]
    public class MultipleTest : Hooks
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
