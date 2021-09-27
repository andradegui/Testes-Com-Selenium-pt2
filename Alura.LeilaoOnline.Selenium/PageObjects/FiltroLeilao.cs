using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class FiltroLeilaoPO
    {
        private IWebDriver driver;
        private By bySelectCategorias;
        private By byInputTermo;
        private By byInputAndamento;
        private By byBotaoPesquisar;

        public FiltroLeilaoPO(IWebDriver driver)
        {
            this.driver = driver;
            bySelectCategorias = By.ClassName("select-wrapper");
            byInputTermo = By.Id("termo");
            byInputAndamento = By.ClassName("switch");
            byBotaoPesquisar = By.CssSelector("form>button.btn");
        }

        public void PesquisarLeiloes(
            List<string> categorias,
            string termo,
            bool emAdamento
            )
        {
            var select = new SelectMaterialize(driver, bySelectCategorias);

            select.DeselectAll();

            categorias.ForEach(categ =>
            {
                select.SelectByText(categ);
            });

            driver.FindElement(byInputTermo).SendKeys(termo);

            if (emAdamento)
            {
                driver.FindElement(byInputTermo).Click();
            }

            driver.FindElement(byBotaoPesquisar).Click();


        }
    }
}
