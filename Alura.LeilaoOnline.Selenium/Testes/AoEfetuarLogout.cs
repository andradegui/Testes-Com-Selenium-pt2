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
    public class AoEfetuarLogout
    {
        private IWebDriver driver;

        public AoEfetuarLogout(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginValidoDeveIrParaHomeNaoLogada()
        {
            //arrange
            new LoginPO(driver)
                .Visitar()
                .InformaEmail("fulano@example.org")
                .InformaSenha("123")
                .EfetuarLogin();
                
                
            
            //act - efetua login
            var dashboarPO = new DashboardInteressadaPO(driver);

            dashboarPO.MenuLogado.EfetuarLogout();

            //assert
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }
        
    }
}
