using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoFiltrarLeiloes
    {
        private IWebDriver driver;

        public AoFiltrarLeiloes(TestFixture fixture)
        {
            driver = fixture.Driver;

        }

        [Fact]
        public void DadoLoginInteressadaDeveMostrarPainelResultado()
        {
            //arrange
            new LoginPO(driver)
                .EfetuarLoginComCredenciais("fulano@example.org", "123");
            
            
            var dashboardInteressadaPO = new DashboardInteressadaPO(driver);

            //act
            dashboardInteressadaPO.Filtro.PesquisarLeiloes(
                new List<string> { "Coleções" },
                "",
                true
            );
            //assert
            Assert.Contains("Resultado da pesquisa", driver.PageSource);
        }


    }
}
