using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoCriarNovoLeilao
    {
        private IWebDriver driver;

        public AoCriarNovoLeilao(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginAdminInfoValidasDeveCadastrarLeilao()
        {
            //arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("admin@example.org", "123");
            loginPO.SubmeteFormulario();

            var novoLeilaoPO = new NovoLeilaoPO(driver);
            novoLeilaoPO.Visitar();
            novoLeilaoPO.PreencheFormulario(
                "Leilao de Coleção 1",
                "Lorem ipsmpor ut. Vivamus vel varius dvel tristique qua ac leo e qua ac leo e qua ac leo e qua ac leo e qua ac leo Lorem",
                "Item de Colecionador",
                4000,
                "c:\\Users\\guilherme.lima\\Desktop\\backgroundNoovi.png",
                DateTime.Now.AddDays(20),
                DateTime.Now.AddDays(40)
                );

            //act
            novoLeilaoPO.SubmeteFormulario();

            //assert
            Assert.Contains("Leilões cadastrados no sistema", driver.PageSource);
        }
    }
}
