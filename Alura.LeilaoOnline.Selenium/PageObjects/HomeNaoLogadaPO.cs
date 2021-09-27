using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class HomeNaoLogadaPO
    {
        private IWebDriver driver;
        public  MenuNaoLogadoPO Menu { get; set; }

        public HomeNaoLogadaPO(IWebDriver driver)
        {
            this.driver = driver;
            Menu = new MenuNaoLogadoPO(driver);
        }

        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000");
        }
    }
}
