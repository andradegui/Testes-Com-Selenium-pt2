using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashboardInteressadaPO
    {
        private IWebDriver driver;
        

        public FiltroLeilaoPO Filtro { get; }
        public MenuLogadoPO MenuLogado { get; set; }

        public DashboardInteressadaPO(IWebDriver driver)
        {
            this.driver = driver;            
            Filtro = new FiltroLeilaoPO(driver);
            MenuLogado = new MenuLogadoPO(driver);
            
        }
        

        
    }
}
