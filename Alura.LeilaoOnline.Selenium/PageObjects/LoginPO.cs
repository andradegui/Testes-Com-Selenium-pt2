using OpenQA.Selenium;
using System;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class LoginPO
    {
        private IWebDriver driver;
        private By byInputLogin;
        private By byInputSenha;
        private By byBotaoLogin;

        public LoginPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputLogin = By.Id("Login");
            byInputSenha = By.Id("Password");
            byBotaoLogin = By.Id("btnLogin");
        }

        public LoginPO Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Autenticacao/Login");
            return this;
        }

        public LoginPO PreencheFormulario(string login, string senha)
        {
            return
                InformaEmail(login)
                .InformaSenha(senha);
            
            return this;

        }

        public LoginPO EfetuarLogin()
        {
            return SubmeteFormulario();
        }

        public LoginPO InformaEmail(string login)
        {
            driver.FindElement(byInputLogin).SendKeys(login);
            return this;
        }

        public LoginPO InformaSenha(string senha)
        {
            driver.FindElement(byInputSenha).SendKeys(senha);
            return this;
        }

        public LoginPO SubmeteFormulario()
        {
            driver.FindElement(byBotaoLogin).Submit();
            return this;
        }

        public void EfetuarLoginComCredenciais(string login, string senha)
        {
            Visitar();
            PreencheFormulario(login, senha);
            SubmeteFormulario();
        }

    }
}

//teste
