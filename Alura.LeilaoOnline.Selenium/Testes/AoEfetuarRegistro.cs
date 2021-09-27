using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {
        private IWebDriver driver;

        public AoEfetuarRegistro(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoInfoValidasDeveIrParaPaginaDeAgradecimento()
        {
            //arrange
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            registroPO.PreencheFormulario("Guilherme Lima", "guilima102013@gmail.com", "123", "123");

            //act
            registroPO.SubmeteFormulario();

            //assert
            Assert.Contains("Obrigado", driver.PageSource);

        }

        [Theory]
        [InlineData("", "guilima102013@gmail.com", "123", "123")]
        [InlineData("Guilherme Lima", "guilima", "123", "123")]
        [InlineData("Guilherme Lima", "guilima102013@gmail.com", "123", "456")]
        [InlineData("Guilherme Lima", "guilima102013@gmail.com", "123", "")]
        public void DadoInfoinvalidasDeveContinuarNaHome(
            string nome,
            string email,
            string senha,
            string confirmSenha)
        {
            //arrange
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();
            registroPO.PreencheFormulario(nome, email, senha, confirmSenha);

            //act
            registroPO.SubmeteFormulario();

            //assert
            Assert.Contains("section-registro", driver.PageSource);

        }

        [Fact]
        public void DadoNomeEmBrancoDeveMostrarMensagemDeErro()
        {
            //arrange
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            //act
            registroPO.SubmeteFormulario();

            //assert - 
            Assert.Equal("The Nome field is required.", registroPO.NomeMensagemErro);
        }

        [Fact]
        public void DadoEmailInvalidoDeveMostrarMensagemDeErro()
        {
            //arrange
            var registroPO = new RegistroPO(driver);
            registroPO.Visitar();

            registroPO.PreencheFormulario(
                nome: "",
                email: "guilima",
                senha: "",
                confirmSenha: ""
             );

            //act
            registroPO.SubmeteFormulario();

            //assert
            Assert.Equal("Please enter a valid email address.", registroPO.EmailMensagemErro);
        }
    }
}

//teste