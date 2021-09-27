using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.Helpers;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoOfertarLance
    {
        private IWebDriver driver;

        //Setup
        public AoOfertarLance(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginInteressadaDeveAtualizarLanceAtual()
        {
            //arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("fulano@example.org", "123");
            loginPO.SubmeteFormulario();

            var detalhePO = new DetalheLeilaoPO(driver);
            detalhePO.Visitar(7); //em adamento

            //act
            detalhePO.OfertarLance(350);

            //assert
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            bool iguais = wait.Until(drv => detalhePO.LanceAtual == 350);

            Assert.True(iguais);
        }

    }
}
