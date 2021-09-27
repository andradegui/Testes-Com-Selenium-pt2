using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class MenuLogadoPO
    {
        private IWebDriver driver;
        private By byLogoutLink;
        private By byMeuPerfilLink;

      
        public MenuLogadoPO(IWebDriver driver)
        {
            this.driver = driver;
            byLogoutLink = By.Id("logout");
            byMeuPerfilLink = By.Id("meu-perfil");
        }

        public void EfetuarLogout()
        {
            var linkMeuPerfil = driver.FindElement(byMeuPerfilLink);
            var linkLogout = driver.FindElement(byLogoutLink);

            IAction acaoLogout = new Actions(driver)
            //move o cursor para o elemento meu perfil
            .MoveToElement(linkMeuPerfil)
            //move o cursor para o link de logout
            .MoveToElement(linkLogout)
            //clica no logout
            .Click()
            .Build();

            //comando para a acao ser realizada
            acaoLogout.Perform();
        }
    }
}
